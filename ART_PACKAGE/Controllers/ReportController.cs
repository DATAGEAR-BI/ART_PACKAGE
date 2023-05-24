

using Newtonsoft.Json;


using Microsoft.Extensions.Configuration;


using ART_PACKAGE.Services.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ART_PACKAGE.Helpers.CSVMAppers;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;

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



        public ReportController(ILogger<ReportController> logger, AuthContext db, UserManager<AppUser> userManager, IConfiguration config, IPdfService pdfSrv, DBFactory dBFactory)
        {

            this.logger = logger;
            this.db = db;
            this.userManager = userManager;
            _config = config;
            _pdfSrv = pdfSrv;
            this.dBFactory = dBFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult GetGridData([FromBody] KendoRequest obj)
        {

            string dbtype = db.Database.IsOracle() ? "oracle" : db.Database.IsSqlServer() ? "sqlServer" : "";
            var filter = obj.Filter.GetFiltersString(dbtype);
            string orderBy = obj.Sort is null ? null : String.Join(" , ", obj.Sort.Select(x => $"{x.field} {x.dir}"));
            var Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == obj.Id);
            var schema = Report.Schema.ToString();
            dbInstance = dBFactory.GetDbInstance(schema);
            var charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == obj.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            List<ChartData<dynamic>> chartsdata = null;
            if (charts is not null && charts.Count != 0)
                chartsdata = dbInstance.GetChartData(charts, filter);
            var columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();
            var data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, obj.Take, obj.Skip, orderBy);
            return Content(JsonConvert.SerializeObject(new
            {
                data = data.Data,
                columns = columns,
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

            var charts = db.ArtSavedReportsCharts.Where(x => x.ReportId == id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            ViewBag.id = id;
            return View(charts);
        }







        [HttpGet("[controller]/[action]/{schema}")]
        public async Task<IActionResult> GetViews(int schema)
        {
            dbInstance = dBFactory.GetDbInstance(((DbSchema)schema).ToString());
            var Views = dbInstance.GetViewsNames();
            return Ok(Views);
        }
        [HttpGet("[controller]/[action]/{schema}/{View}")]
        public async Task<IActionResult> GetViewColumn(int schema, string View)
        {
            dbInstance = dBFactory.GetDbInstance(((DbSchema)schema).ToString());
            if (string.IsNullOrEmpty(View))
                return null;

            var Columns = dbInstance.GetViewColumns(View);

            return Ok(Columns.ToArray());
        }




        public IActionResult MyReports()
        {
            return View();
        }




































        public IActionResult GetMyReportsData([FromBody] KendoRequest obj)
        {
            var user = userManager.GetUserId(User);
            IQueryable<ArtSavedCustomReport> alerts = db.ArtSavedCustomReports.Include(x => x.Columns).Include(x => x.Charts).Where(x => x.UserId == user);



            var skipList = new List<string>()
            {
                  nameof(ArtSavedCustomReport.User),
                  nameof(ArtSavedCustomReport.UserId),
                nameof(ArtSavedCustomReport.Schema)
            };

            var Data = alerts.CallData<ArtSavedCustomReport>(obj, propertiesToSkip: skipList);







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
            var report = new ArtSavedCustomReport
            {
                Table = model.Table,
                Name = model.Title,
                Description = model.Description,
                CreateDate = DateTime.Now,
                Schema = model.Schema,
            };



            var columns = model.Columns.Select(e => new ArtSavedReportsColumns
            {
                Column = e,
                ReportId = report.Id
            }).ToList();

            var charts = model.Charts.Select(c => new ArtSavedReportsChart
            {
                Column = c.Column,
                Type = c.Type,
                Title = c.Title,
                ReportId = report.Id
            }).ToList();

            report.UserId = userManager.GetUserId(User);
            report.Charts = charts;
            report.Columns = columns;

            db.Add(report);
            db.SaveChanges();

            var reportAfter = db.ArtSavedCustomReports.Include(x => x.Columns).Include(x => x.User).Include(x => x.Charts).FirstOrDefault(x => x.Id == report.Id);

            return Ok(reportAfter);
        }
        public IActionResult Export([FromBody] ExportDto<decimal> exportDto)
        {
            string orderBy = exportDto.Req.Sort is null ? null : String.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
            var Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == exportDto.Req.Id);
            var charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == exportDto.Req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            var filter = exportDto.Req.Filter.GetFiltersString(dbtype);
            var chartsdata = dbInstance.GetChartData(charts, filter);
            var columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();
            var data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
            var bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata.Select(x => x.Data).ToList());
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportMyReports([FromBody] ExportDto<decimal> req)
        {
            var data = db.ArtSavedCustomReports.AsQueryable();
            var bytes = await data.ExportToCSV<ArtSavedCustomReport, GenericCsvClassMapper<ArtSavedCustomReport, ReportController>>(req.Req);
            return File(bytes, "test/csv");
        }
        public async Task<IActionResult> ExportPdfMyReports([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(ReportController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(ReportController).ToLower()].SkipList;
            var data = db.ArtSavedCustomReports.CallData<ArtSavedCustomReport>(req).Data.ToList();
            ViewData["title"] = $"My Reports ({User.Identity.Name})";
            ViewData["desc"] = $"Reports That Are Made Using Custom Report Module By ({User.Identity.Name})";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip: ColumnsToSkip, DisplayNamesAndFormat: DisplayNames);
            return File(pdfBytes, "application/pdf");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            string orderBy = req.Sort is null ? null : String.Join(" , ", req.Sort.Select(x => $"{x.field} {x.dir}"));
            var Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == req.Id);
            var charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == req.Id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
            dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
            string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
            var filter = req.Filter.GetFiltersString(dbtype);
            var chartsdata = dbInstance.GetChartData(charts, filter);
            var columns = Report.Columns.Select(x => new ColumnsDto
            {
                name = x.Column
            }).ToArray();
            var data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, req.Take, req.Skip, orderBy);
            ViewData["title"] = Report.Name;
            ViewData["desc"] = Report.Description;
            var pdfBytes = await _pdfSrv.ExportCustomReportToPdf(data.Data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, Report.Columns.Select(x => x.Column).ToList());
            return File(pdfBytes, "application/pdf");
        }
    }
}
