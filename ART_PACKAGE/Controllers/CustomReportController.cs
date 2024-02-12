using System.Reflection;
using ART_PACKAGE.Data.Attributes;
using ART_PACKAGE.Helpers.Grid;
using Data.Services.CustomReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public class CustomReportController : BaseReportController<ICustomReportGridConstructor, ICustomReportRepo, AuthContext, Dictionary<string, object>>
    {


        public CustomReportController(ICustomReportGridConstructor gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        [HttpPost("[controller]/[action]/{id}")]
        public IActionResult GetData([FromRoute] int id, [FromBody] GridRequest request)
        {
            if (request.IsIntialize)
            {
                GridIntializationConfiguration intializationResult = _gridConstructor.IntializeGrid(id);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(intializationResult)
                };
            }
            else
            {
                GridResult<Dictionary<string, object>> dataResult = _gridConstructor.GetGridData(id, request);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(dataResult)
                };
            }
        }

        [HttpPost("[controller]/[action]/{id}")]
        public IActionResult GetReportChartsData([FromRoute] int id, [FromBody] GridRequest request)
        {
            try
            {
                IEnumerable<ChartDataDto> chartsData = _gridConstructor.GetReportChartsData(id, request);
                return Ok(chartsData);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("[controller]/[action]/{schemaType}")]
        public IActionResult GetDbObjects(int schemaType)
        {
            try
            {
                IEnumerable<DbObject> dbObjects = _gridConstructor.GetDbObjectsOf(schemaType);
                return Ok(dbObjects);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("[controller]/[action]/{schemaType}/{View}/{type}")]
        public async Task<IActionResult> GetObjectColumnNames(int schemaType, string View, string type)
        {
            try
            {
                IEnumerable<ColumnDto> columns = _gridConstructor.GetObjectColumns(schemaType, View, type);
                return Ok(columns);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult GetChartsTypes()
        {
            IEnumerable<SelectListItem> result = typeof(ChartType).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return displayAttr == null || !displayAttr.IsHidden;
            }).Select(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                string text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                string value = ((int)Enum.Parse(typeof(ChartType), x.Name)).ToString();
                return new SelectListItem
                {
                    Text = text,
                    Value = value
                };

            });
            return Ok(result);
        }
        [HttpGet("[controller]/[action]")]
        public IActionResult GetDbSchemas()
        {
            IEnumerable<SelectListItem> result = typeof(DbSchema).GetMembers(BindingFlags.Static | BindingFlags.Public).Where(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                return displayAttr == null || !displayAttr.IsHidden;
            }).Select(x =>
            {
                OptionAttribute? displayAttr = x.GetCustomAttribute<OptionAttribute>();
                string text = displayAttr is null ? x.Name : displayAttr.DisplayName;
                string value = ((int)Enum.Parse(typeof(DbSchema), x.Name)).ToString();
                return new SelectListItem
                {
                    Text = text,
                    Value = value
                };

            });
            return Ok(result);
        }
        [HttpPost("[controller]/[action]/{gridId}")]
        public override async Task<IActionResult> ExportToCsv([FromBody] ExportRequest req, [FromRoute] string gridId)
        {
            AppUser user = await GetUser();
            int reportId = Convert.ToInt32(gridId.Split("-")[1]);
            string folderGuid = _gridConstructor.ExportGridToCsv(reportId, req, user.UserName, gridId);
            return Ok(new { folder = folderGuid });
        }

        [HttpGet("[controller]/{reportId}")]
        public async Task<IActionResult> ViewReport(int reportId)
        {
            ArtSavedCustomReport report = _gridConstructor.Repo.GetReport(reportId);
            if (report == null)
                return NotFound();

            AppUser currentUser = await GetUser();

            if (!report.Users.Contains(currentUser))
                return Forbid();

            ViewBag.id = reportId;
            return View("Index");
        }
        [HttpGet("[controller]/[action]")]
        public IActionResult CreateReport()
        {
            return View();
        }

        [HttpGet("[controller]/[action]/{reportId}")]
        public async Task<IActionResult> GetReportCharts(int reportId)
        {
            ArtSavedCustomReport report = _gridConstructor.Repo.GetReport(reportId);
            if (report == null)
                return NotFound();

            AppUser currentUser = await GetUser();

            if (!report.Users.Contains(currentUser))
                return Forbid();
            IEnumerable<ReportChartDto> charts = report.Charts.Select((x, i) => new ReportChartDto
            {
                ChartId = $"chart-{reportId}-{i}",
                Title = x.Title,
                Type = x.Type,
            });
            return Ok(charts);
        }
        public override IActionResult Index()
        {
            return View();
        }
    }
}