

using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.Services.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using static ART_PACKAGE.Helpers.CustomReportHelpers.DbContextExtentions;

namespace ART_PACKAGE.Controllers
{
    [AllowAnonymous]
    public partial class ReportController : Controller
    {
        private readonly AuthContext db;
        private readonly DBFactory dBFactory;
        private readonly ILogger<ReportController> logger;
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration _config;
        private readonly IPdfService _pdfSrv;
        private DbContext dbInstance;
        private readonly ICsvExport _csvSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;


        public ReportController(ILogger<ReportController> logger, AuthContext db, UserManager<AppUser> userManager, IConfiguration config, IPdfService pdfSrv, DBFactory dBFactory, ICsvExport csvSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
        {

            this.logger = logger;
            this.db = db;
            this.userManager = userManager;
            _config = config;
            _pdfSrv = pdfSrv;
            this.dBFactory = dBFactory;
            _csvSrv = csvSrv;
            _exportHub = exportHub;
            this.connections = connections;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult GetGridData([FromBody] KendoRequest obj)
        {

            string dbtype = db.Database.IsOracle() ? "oracle" : db.Database.IsSqlServer() ? "sqlServer" : "";
            string filter = obj.Filter.GetFiltersString(dbtype);
            string orderBy = obj.Sort is null ? null : string.Join(" , ", obj.Sort.Select(x => $"{x.field} {x.dir}"));
            ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == obj.Id);
            string schema = Report.Schema.ToString();
            dbInstance = dBFactory.GetDbInstance(schema);
            List<ArtSavedReportsChart>? charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == obj.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            List<ChartData<dynamic>> chartsdata = null;
            if (charts is not null && charts.Count != 0)
            {
                chartsdata = dbInstance.GetChartData(charts, filter);
            }

            ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column,
                isNullable = x.IsNullable,
                type = x.JsType

            }).ToArray();
            DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, obj.Take, obj.Skip, orderBy);
            return Content(JsonConvert.SerializeObject(new
            {
                data = data.Data,
                columns,
                total = data.DataCount,
                chartdata = chartsdata,
                title = Report.Name,
                desc = Report.Description,

            }
            ), "application/json"
            );

        }
















        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult ShowReport(int id)
        {

            List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Where(x => x.ReportId == id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            ViewBag.id = id;
            return View(charts);
        }







        [HttpGet("[controller]/[action]/{schema}")]
        public async Task<IActionResult> GetViews(int schema, string type)
        {
            dbInstance = dBFactory.GetDbInstance(((DbSchema)schema).ToString());
            IEnumerable<View> Views = dbInstance.GetViewsNames();
            return Ok(Views);
        }
        [HttpGet("[controller]/[action]/{schema}/{View}/{type}")]
        public async Task<IActionResult> GetViewColumn(int schema, string View, string type)
        {
            dbInstance = dBFactory.GetDbInstance(((DbSchema)schema).ToString());
            if (string.IsNullOrEmpty(View))
            {
                return null;
            }

            IEnumerable<ViewColumn> Columns = dbInstance.GetViewColumns(View, type);

            return Ok(Columns.ToArray());
        }




        public IActionResult MyReports()
        {
            return View();
        }

        public IActionResult GetMyReportsData([FromBody] KendoRequest obj)
        {
            string user = userManager.GetUserId(User);
            IQueryable<ArtSavedCustomReport> alerts = db.ArtSavedCustomReports.Include(x => x.Columns).Include(x => x.Charts).Where(x => x.UserId == user);



            List<string> skipList = new()
            {
                  nameof(ArtSavedCustomReport.User),
                  nameof(ArtSavedCustomReport.UserId),
                nameof(ArtSavedCustomReport.Schema)
            };

            KendoDataDesc<ArtSavedCustomReport> Data = alerts.CallData(obj, propertiesToSkip: skipList);

            var data = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = true
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }




        [HttpPost]
        public async Task<IActionResult> SaveReport([FromBody] CustumReportViewmodel model)
        {
            ArtSavedCustomReport report = new()
            {
                Table = model.Table,
                Type = model.ObjectType,
                Name = model.Title,
                Description = model.Description,
                CreateDate = DateTime.Now,
                Schema = model.Schema,
            };



            List<ArtSavedReportsColumns> columns = model.Columns.Select(e => new ArtSavedReportsColumns
            {
                Column = e.Name,
                IsNullable = e.IsNullable == "YES",
                JsType = e.JsDataType,
                ReportId = report.Id
            }).ToList();

            List<ArtSavedReportsChart> charts = model.Charts.Select(c => new ArtSavedReportsChart
            {
                Column = c.Column,
                Type = c.Type,
                Title = c.Title,
                ReportId = report.Id
            }).ToList();

            report.UserId = userManager.GetUserId(User);
            report.Charts = charts;
            report.Columns = columns;

            _ = db.Add(report);
            _ = db.SaveChanges();

            ArtSavedCustomReport? reportAfter = db.ArtSavedCustomReports.Include(x => x.Columns).Include(x => x.User).Include(x => x.Charts).FirstOrDefault(x => x.Id == report.Id);

            return Ok(reportAfter);
        }
        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> exportDto)
        {
            string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
            ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
            List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            string filter = exportDto.Req.Filter.GetFiltersString(dbtype);
            List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;
            ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();
            List<List<object>> filterCells = exportDto.Req.Filter.GetFilterTextForCsv();

            DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
            byte[] bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata?.Select(x => x.Data).ToList(), filterCells);
            string FileName = Report.Name + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
            await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
                                .SendAsync("csvRecevied", bytes, FileName);
            return new EmptyResult();
        }

        public async Task<IActionResult> ExportMyReports([FromBody] ExportDto<decimal> req)
        {
            IQueryable<ArtSavedCustomReport> data = db.ArtSavedCustomReports.AsQueryable();
            await _csvSrv.ExportAllCsv<ArtSavedCustomReport, ReportController, decimal>(data, User.Identity.Name, req);
            return new EmptyResult();
        }
        public async Task<IActionResult> ExportPdfMyReports([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ReportController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ReportController).ToLower()].SkipList;
            List<ArtSavedCustomReport> data = db.ArtSavedCustomReports.CallData(req).Data.ToList();
            ViewData["title"] = $"My Reports ({User.Identity.Name})";
            ViewData["desc"] = $"Reports That Are Made Using Custom Report Module By ({User.Identity.Name})";
            ViewData["filters"] = req.Filter.GetFilterTextForCsv();
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip: ColumnsToSkip, DisplayNamesAndFormat: DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            string orderBy = req.Sort is null ? null : string.Join(" , ", req.Sort.Select(x => $"{x.field} {x.dir}"));
            ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == req.Id);
            List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            string filter = req.Filter.GetFiltersString(dbtype);
            ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();
            DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, req.Take, req.Skip, orderBy);
            ViewData["title"] = Report.Name;
            ViewData["desc"] = Report.Description;
            ViewData["filters"] = req.Filter.GetFilterTextForCsv();
            byte[] pdfBytes = await _pdfSrv.ExportCustomReportToPdf(data.Data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, Report.Columns.Select(x => x.Column).ToList());
            return File(pdfBytes, "application/pdf");
        }
    }
}
