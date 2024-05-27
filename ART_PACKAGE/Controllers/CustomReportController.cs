using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Data.Attributes;
using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Handlers;
using Data.Services.CustomReport;
using Data.Services.Grid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;

namespace ART_PACKAGE.Controllers
{
    public class CustomReportController : BaseReportController<ICustomReportGridConstructor, ICustomReportRepo, AuthContext, Dictionary<string, object>>
    {
        private readonly ProcessesHandler _processHanandler;


        public CustomReportController(ICustomReportGridConstructor gridConstructor, UserManager<AppUser> um, ProcessesHandler processesHandler) : base(gridConstructor, um)
        {
            _processHanandler = processesHandler;
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
        public override async Task<IActionResult> ExportToCsv([FromBody] ExportRequest req, [FromRoute] string gridId, [FromQuery] string reportGUID)
        {
            AppUser user = await GetUser();
            int reportId = Convert.ToInt32(gridId.Split("-")[1]);
            string folderGuid = _gridConstructor.ExportGridToCsv(reportId, req, user.UserName, reportGUID);
            return Ok(new { folder = folderGuid });
        }
        [HttpPost("[controller]/[action]/{gridId}")]
        public override async Task<IActionResult> ExportPdf([FromBody] ExportRequest req, [FromRoute] string gridId, [FromQuery] string reportGUID)
        {
            int reportId = Convert.ToInt32(gridId.Split("-")[1]);
            ViewData["reportId"] = reportGUID;
            byte[] pdfBytes = await _gridConstructor.ExportGridToPdf(reportId, req, User.Identity.Name, ControllerContext, ViewData);
            return File(pdfBytes, "application/pdf");
        }// Task<IActionResult>

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