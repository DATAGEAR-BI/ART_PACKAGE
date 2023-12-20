using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Data.Attributes;
using ART_PACKAGE.Helpers.ExportTasks;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ExportSchedular;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Security.Claims;

namespace ART_PACKAGE.Controllers.EXPORT_SCHEDULAR
{
    public class TasksController : BaseReportController<ExportSchedularContext, ExportTask>
    {
        private readonly ExportSchedularContext _context;
        private readonly IRecurringJobManager jobsManger;
        private readonly IBackgroundJobClient backGroundJobManger;
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskPerformer _taskPerformer;
        private readonly UserManager<AppUser> _userManager;


        public TasksController(ExportSchedularContext context, IRecurringJobManager jobsManger, ILogger<TasksController> logger, ITaskPerformer taskPerformer, UserManager<AppUser> userManager, IGridConstructor<ExportSchedularContext, ExportTask> gridConstructor, IBackgroundJobClient backGroundJobManger) : base(gridConstructor)
        {
            _context = context;
            this.jobsManger = jobsManger;
            _logger = logger;
            _taskPerformer = taskPerformer;
            _userManager = userManager;
            this.backGroundJobManger = backGroundJobManger;
        }

        public override IActionResult Index()
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


            ExportTask? task = _context.ExportsTasks.FirstOrDefault(x => x.Id == taskId);

            if (task == null)
            {
                return NotFound();
            }


            if (task.UserId != User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
                return Forbid();


            ExportTaskDto taskDto = new()
            {
                Id = taskId,
                Day = task?.Day,
                DayOfWeek = task?.DayOfWeek,
                Description = task?.Description,
                Hour = task?.Hour,
                IsMailed = task.IsMailed,
                IsSavedOnServer = task.IsSavedOnServer,
                Mails = task.Mails,
                Minute = task.Minute,
                Month = task.Month,
                Name = task.Name,
                Parameters = task.ParametersJson,
                Period = task.Period,
                ReportName = task.ReportName,
                Path = task.Path,
                EndOfMonth = task.EndOfMonth
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
                Mails = task.Mails,
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
                UserId = _userManager.GetUserId(User),
                CornExpression = task.CronExpression,
                EndOfMonth = task.EndOfMonth

            };

            _ = _context.ExportsTasks.Add(taskToAdd);
            int res = _context.SaveChanges();
            if (res <= 0)
                return BadRequest();


            jobsManger.AddOrUpdate(taskToAdd.Name, () => _taskPerformer.PerformTask(taskToAdd, null), taskToAdd.CornExpression);
            (DateTime? lastDate, DateTime? nextDate) = _taskPerformer.GetExecutionDateTimes(taskToAdd.Name);
            taskToAdd.NextExceutionDate = nextDate;
            taskToAdd.LastExceutionDate = lastDate;

            _context.SaveChanges();
            return Ok();
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


        [HttpPut("[controller]/[action]/{taskId}")]
        public IActionResult EditTask(int taskId, [FromBody] ExportTaskDto task)
        {
            ExportTask? oldTask = _context.ExportsTasks.FirstOrDefault(x => x.Id == taskId);

            if (oldTask is null)
                return BadRequest();



            jobsManger.RemoveIfExists(oldTask.Name);

            oldTask.Name = task.Name + "##" + Guid.NewGuid().ToString();
            oldTask.ReportName = task.ReportName;
            oldTask.ParametersJson = task.Parameters;
            oldTask.IsMailed = task.IsMailed;
            oldTask.Mails = task.Mails;
            oldTask.Month = task.Month;
            oldTask.DayOfWeek = task.DayOfWeek;
            oldTask.Day = task.Day;
            oldTask.Hour = task.Hour;
            oldTask.Minute = task.Minute;
            oldTask.Description = task.Description;
            oldTask.IsSavedOnServer = task.IsSavedOnServer;
            oldTask.Period = task.Period;
            oldTask.MailContent = task.MailContent;
            oldTask.Path = task.Path;
            oldTask.UserId = _userManager.GetUserId(User);
            oldTask.CornExpression = task.CronExpression;
            oldTask.EndOfMonth = task.EndOfMonth;


            int res = _context.SaveChanges();

            if (res <= 0)
                return BadRequest();

            jobsManger.AddOrUpdate(oldTask.Name, () => _taskPerformer.PerformTask(oldTask, null), oldTask.CornExpression);
            (DateTime? lastDate, DateTime? nextDate) = _taskPerformer.GetExecutionDateTimes(oldTask.Name);
            oldTask.NextExceutionDate = nextDate;
            _ = _context.SaveChanges();
            return Ok();

        }


    }
}
