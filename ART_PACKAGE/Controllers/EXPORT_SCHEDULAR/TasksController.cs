using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Data.Attributes;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.ExportSchedular;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace ART_PACKAGE.Controllers.EXPORT_SCHEDULAR
{
    public class TasksController : Controller
    {
        private readonly ExportSchedularContext _context;
        private readonly IRecurringJobManager jobsManger;
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskPerformer _taskPerformer;
        private readonly UserManager<AppUser> _userManager;

        public TasksController(ExportSchedularContext context, IRecurringJobManager jobsManger, ILogger<TasksController> logger, ITaskPerformer taskPerformer, UserManager<AppUser> userManager)
        {
            _context = context;
            this.jobsManger = jobsManger;
            _logger = logger;
            _taskPerformer = taskPerformer;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetMonthes()
        {
            IEnumerable<SelectListItem> result = typeof(MonthsOfYear).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return displayAttr == null || !displayAttr.IsHidden;
            }).Select(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                string text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                string value = ((int)Enum.Parse(typeof(MonthsOfYear), x.Name)).ToString();
                return new SelectListItem
                {
                    Text = text,
                    Value = value
                };

            });
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetDays()
        {
            IEnumerable<SelectListItem> result = typeof(DayOfWeek).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return displayAttr == null || !displayAttr.IsHidden;
            }).Select(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                string text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                string value = ((int)Enum.Parse(typeof(DayOfWeek), x.Name)).ToString();
                return new SelectListItem
                {
                    Text = text,
                    Value = value
                };

            });
            return Ok(result);
        }



        [HttpGet]
        public IActionResult GetTaskPeriods()
        {
            IEnumerable<SelectListItem> result = typeof(TaskPeriod).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return displayAttr == null || !displayAttr.IsHidden;
            }).Select(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                string text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                string value = ((int)Enum.Parse(typeof(TaskPeriod), x.Name)).ToString();
                return new SelectListItem
                {
                    Text = text,
                    Value = value
                };

            });
            return Ok(result);


        }





        [HttpGet("[controller]/[action]/{taskId}")]
        public IActionResult EditTask(int taskId)
        {
            ExportTask? task = _context.ExportsTasks.Include(x => x.Mails).FirstOrDefault(x => x.Id == taskId);

            ExportTaskDto taskDto = new()
            {
                Day = task?.Day,
                DayOfWeek = task?.DayOfWeek,
                Description = task?.Description,
                Hour = task?.Hour,
                IsMailed = task.IsMailed,
                IsSavedOnServer = task.IsSavedOnServer,
                Mails = task.Mails.Select(x => x.Mail).ToList(),
                Minute = task.Minute,
                Month = task.Month,
                Name = task.Name,
                //Parameters = task.Parameters.GroupBy(x => new { x.ParameterName, x.Operator }).Select(x => new Parameter { Name = x.Key.ParameterName, Operator = x.Key.Operator, Value = x.Select(v => v.ParameterValue).ToList() }).ToList(),
                Period = task.Period,
                ReportName = task.ReportName
            };
            return View(taskDto);
        }










        [HttpPost]
        public IActionResult IsValidPath([FromBody] string path)
        {

            if (!Path.IsPathRooted(path))
                return BadRequest();

            if (!Directory.Exists(path))
                return BadRequest();

            return Ok();
        }




        [HttpPost]
        public IActionResult AddTask([FromBody] ExportTaskDto task)
        {
            if (task is null)
                return BadRequest();


            bool isExists = _context.ExportsTasks.FirstOrDefault(x => x.Name == task.Name) != null;


            if (isExists)
                return BadRequest();

            ExportTask taskToAdd = new()
            {
                Name = task.Name + "##" + Guid.NewGuid().ToString(),
                ReportName = task.ReportName,
                ParametersJson = task.Parameters,
                IsMailed = task.IsMailed,
                Mails = task.Mails.Select(x => new TaskMails { Mail = x }).ToList(),
                Month = task.Month,
                DayOfWeek = task.DayOfWeek,
                Day = task.Day,
                Hour = task.Hour,
                Minute = task.Minute,
                Description = task.Description,
                IsSavedOnServer = task.IsSavedOnServer,
                Period = task.Period,
                MailContent = task.MailContent,
                Path = task.Path,
                UserId = _userManager.GetUserId(User)

            };

            _ = _context.ExportsTasks.Add(taskToAdd);
            int res = _context.SaveChanges();
            if (res <= 0)
                return BadRequest();




            Func<string> period = _taskPerformer.GetPeriod(taskToAdd);

            jobsManger.AddOrUpdate(taskToAdd.Name, () => _taskPerformer.PerformTask(taskToAdd), period);

            return Ok();
        }

        public async Task<IActionResult> GetData([FromBody] KendoRequest request)
        {
            IQueryable<ExportTask> data = _context.ExportsTasks.Where(x => x.UserId == _userManager.GetUserId(User));
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(TasksController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                   {nameof(ExportTask.Period).ToLower(),Enum.GetNames(typeof(TaskPeriod)).Select((x,i) => new { text = x , value = i}).ToDynamicList() },
                   {nameof(ExportTask.DayOfWeek).ToLower(),Enum.GetNames(typeof(DayOfWeek)).Select((x,i) => new { text = x , value = i}).ToDynamicList() },
                   {nameof(ExportTask.Month).ToLower(),Enum.GetNames(typeof(MonthsOfYear)).Select((x,i) => new { text = x , value = i}).ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(TasksController).ToLower()].SkipList;
            }

            KendoDataDesc<ExportTask> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = true,
                actions = new List<dynamic>
                {
                    new
                    {
                        text = "Edit",
                        action = "editTask",
                        icon = "k-i-edit"
                    },
                    new
                    {
                        text = "Delete",
                        action = "deleteTask",
                        icon = "k-i-trash"
                    },
                    new
                    {
                        text = "Run Now",
                        action = "runNow",
                        icon = "k-i-video-external"
                    }
                },
                toolbar = new List<dynamic>
                {
                    new
                    {
                        text = "Add New Task",
                        id = "addTask"
                    }
                }

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        [HttpGet("[controller]/[action]/{name}")]
        public IActionResult IsTaskExists(string name)
        {
            bool isExists = _context.ExportsTasks.FirstOrDefault(x => x.Name == name) != null;
            return !isExists ? Ok() : BadRequest();
        }


        [HttpDelete("[controller]/[action]/{id}")]
        public IActionResult DeleteTask(int id)
        {
            ExportTask task = _context.ExportsTasks.Find(id);
            if (task == null)
                return BadRequest();

            task.Deleted = true;
            int change = _context.SaveChanges();
            if (change <= 0)
                return BadRequest();
            jobsManger.RemoveIfExists(task.Name);
            return Ok();
        }



        [HttpPost("[controller]/[action]/{id}")]
        public IActionResult RunNow(int id)
        {
            ExportTask task = _context.ExportsTasks.Find(id);
            if (task == null)
                return BadRequest();

            jobsManger.Trigger(task.Name);
            return Ok();
        }

    }
}
