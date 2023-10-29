using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.ExportSchedular;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.EXPORT_SCHEDULAR
{
    public class TasksController : Controller
    {
        private readonly ExportSchedularContext _context;
        private readonly IRecurringJobManager jobsManger;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ExportSchedularContext context, IRecurringJobManager jobsManger, ILogger<TasksController> logger)
        {
            _context = context;
            this.jobsManger = jobsManger;
            _logger = logger;
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

        [HttpPost]
        public IActionResult AddTask([FromBody] AddTaskDto task)
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


            jobsManger.AddOrUpdate(taskToAdd.Name, () => Console.WriteLine($"Task Running : {taskToAdd.Name} At : {DateTime.Now}"), Cron.Minutely);

            return Ok();
        }

        public async Task<IActionResult> GetData([FromBody] KendoRequest request)
        {
            Microsoft.EntityFrameworkCore.DbSet<ExportTask> data = _context.ExportsTasks;
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = new();

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {

                };
                ColumnsToSkip = new List<string>()
                {
                    nameof(ExportTask.Parameters),
                    nameof(ExportTask.Mails)
                };
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
