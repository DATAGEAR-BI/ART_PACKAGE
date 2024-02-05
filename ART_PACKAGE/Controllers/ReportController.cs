using ART_PACKAGE.Data.Attributes;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Reflection;
using static ART_PACKAGE.Helpers.CustomReport.DbContextExtentions;

namespace ART_PACKAGE.Controllers
{
    public partial class ReportController : BaseController
    {
        private readonly AuthContext db;
        private readonly DBFactory dBFactory;
        private readonly ILogger<ReportController> logger;
        private readonly IConfiguration _config;
        private readonly IPdfService _pdfSrv;
        private DbContext dbInstance;
        private readonly ICsvExport _csvSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;


        public ReportController(ILogger<ReportController> logger, AuthContext db, UserManager<AppUser> userManager, IConfiguration config, IPdfService pdfSrv, DBFactory dBFactory, ICsvExport csvSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections) : base(userManager)
        {

            this.logger = logger;
            this.db = db;
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

        // [HttpPost("[controller]/[action]/{id}")]
        // public IActionResult GetGridData([FromRoute] int id, [FromBody] KendoRequest obj)
        // {
        //
        //
        //
        //
        //     ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == id);
        //
        //     ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
        //     {
        //         name = x.Column,
        //         isNullable = x.IsNullable,
        //         type = x.JsType
        //
        //     }).ToArray();
        //     List<ArtSavedReportsChart>? charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
        //
        //     if (obj.IsIntialize)
        //     {
        //         return Content(JsonConvert.SerializeObject(new
        //         {
        //             columns,
        //             title = Report.Name,
        //             desc = Report.Description,
        //             chartsids = charts.Select((x, i) => $"chart-{i}")
        //
        //         }
        //  ), "application/json"
        //  );
        //     }
        //     string schema = Report.Schema.ToString();
        //     dbInstance = dBFactory.GetDbInstance(schema);
        //     string dbtype = db.Database.IsOracle() ? "oracle" : db.Database.IsSqlServer() ? "sqlServer" : "";
        //
        //     string orderBy = obj.Sort is null ? null : string.Join(" , ", obj.Sort.Select(x => $"{x.field} {x.dir}"));
        //
        //     List<ChartData<dynamic>> chartsdata = null;
        //
        //
        //     string filter = obj.Filter.GetFiltersString(dbtype, columns);
        //     if (charts is not null && charts.Count != 0)
        //     {
        //         chartsdata = dbInstance.GetChartData(charts, filter);
        //     }
        //     DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, obj.Take, obj.Skip, orderBy);
        //     return Content(JsonConvert.SerializeObject(new
        //     {
        //         data = data.Data,
        //         total = data.DataCount,
        //         chartdata = chartsdata,
        //         title = Report.Name,
        //         desc = Report.Description,
        //
        //     }
        //     ), "application/json"
        //     );
        //
        // }
        //
        //



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
        //[HttpPost("[controller]/[action]/{id}")]
        // public async Task<IActionResult> Export([FromRoute] int id, [FromBody] ExportDto<decimal> exportDto)
        // {
        //     string orderBy = exportDto.Req.Sort is null ? null : string.Join(" , ", exportDto.Req.Sort.Select(x => $"{x.field} {x.dir}"));
        //     ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == id);
        //     List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
        //     dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
        //     string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
        //     ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
        //     {
        //         name = x.Column,
        //         isNullable = x.IsNullable,
        //         type = x.JsType,
        //     }).ToArray();
        //     string filter = exportDto.Req.Filter.GetFiltersString(dbtype, columns);
        //     List<ChartData<dynamic>> chartsdata = charts is not null && charts.Count > 0 ? dbInstance.GetChartData(charts, filter) : null;
        //     List<List<object>> filterCells = exportDto.Req.Filter.GetFilterTextForCsv();
        //
        //     DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, exportDto.Req.Take, exportDto.Req.Skip, orderBy);
        //     byte[] bytes = KendoFiltersExtentions.ExportCustomReportToCSV(data.Data, chartsdata?.Select(x => x.Data).ToList(), filterCells);
        //     string FileName = Report.Name + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //     await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
        //                         .SendAsync("csvRecevied", bytes, FileName);
        //     return new EmptyResult();
        // }
        // [HttpPost("[controller]/[action]/{id}")]
        // public async Task<IActionResult> ExportPdf([FromRoute] int id, [FromBody] KendoRequest req)
        // {
        //     string orderBy = req.Sort is null ? null : string.Join(" , ", req.Sort.Select(x => $"{x.field} {x.dir}"));
        //     ArtSavedCustomReport? Report = db.ArtSavedCustomReports.Include(x => x.Columns).FirstOrDefault(x => x.Id == id);
        //     List<ArtSavedReportsChart> charts = db.ArtSavedReportsCharts.Include(x => x.Report).Where(x => x.ReportId == id).OrderBy(x => x.Type).ThenBy(x => x.Column).ToList();
        //     dbInstance = dBFactory.GetDbInstance(Report.Schema.ToString());
        //     string dbtype = dbInstance.Database.IsOracle() ? "oracle" : dbInstance.Database.IsSqlServer() ? "sqlServer" : "";
        //     ColumnsDto[] columns = Report.Columns.Select(x => new ColumnsDto
        //     {
        //         name = x.Column,
        //         type = x.JsType,
        //         isNullable = x.IsNullable
        //     }).ToArray();
        //     string filter = req.Filter.GetFiltersString(dbtype, columns);
        //     ViewData["title"] = Report.Name;
        //     DataResult data = dbInstance.GetData(Report.Table, columns.Select(x => x.name).ToArray(), filter, req.Take, req.Skip, orderBy);
        //     ViewData["desc"] = Report.Description;
        //     ViewData["filters"] = req.Filter.GetFilterTextForCsv();
        //     byte[] pdfBytes = await _pdfSrv.ExportCustomReportToPdf(data.Data, ViewData, ControllerContext, 5
        //                                             , User.Identity.Name, Report.Columns.Select(x => x.Column).ToList());
        //     return File(pdfBytes, "application/pdf");
        // }
    }
}
