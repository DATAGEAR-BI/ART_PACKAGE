using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.ExportSchedular;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.EXPORT_SCHEDULAR
{
    public class TasksController : Controller
    {
        private readonly ExportSchedularContext _context;
        private readonly IRecurringJobManager jobsManger;
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskPerformer _taskPerformer;

        public TasksController(ExportSchedularContext context, IRecurringJobManager jobsManger, ILogger<TasksController> logger, ITaskPerformer taskPerformer)
        {
            _context = context;
            this.jobsManger = jobsManger;
            _logger = logger;
            _taskPerformer = taskPerformer;
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


        [HttpGet("[controller]/[action]/{taskId}")]
        public IActionResult EditTask(int taskId)
        {
            ExportTask? task = _context.ExportsTasks.Include(x => x.Mails).Include(x => x.Parameters).FirstOrDefault(x => x.Id == taskId);

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
                Parameters = task.Parameters.GroupBy(x => new { x.ParameterName, x.Operator }).Select(x => new Parameter { Name = x.Key.ParameterName, Operator = x.Key.Operator, Value = x.Select(v => v.ParameterValue).ToList() }).ToList(),
                Period = task.Period,
                ReportName = task.ReportName
            };
            return View(taskDto);
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
                Name = task.Name,
                ReportName = task.ReportName,
                Parameters = task.Parameters.SelectMany(x => x.Value.Select(v => new TaskParameters { Operator = x.Operator, ParameterName = x.Name, ParameterValue = v })).ToList(),
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
            DbSet<ExportTask> data = _context.ExportsTasks;
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

    }
}
