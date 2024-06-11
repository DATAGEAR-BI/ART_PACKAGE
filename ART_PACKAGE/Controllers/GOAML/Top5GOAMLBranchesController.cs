using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTGOAML;
using Data.GOAML;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.GOAML
{
    public class Top5GOAMLBranchesController : Controller
    {


        private readonly ArtGoAmlContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;
        private readonly string dbType;
        private readonly IConfiguration _config;

        public Top5GOAMLBranchesController(ArtGoAmlContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv, IConfiguration config)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
            _csvSrv = csvSrv;
            _config = config;
            dbType = config.GetValue<string>("dbType").ToUpper();

        }
        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ART_ST_YEARLY_TOP_GOAML_BRANCHES> data = Enumerable.Empty<ART_ST_YEARLY_TOP_GOAML_BRANCHES>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(SQLSERVERSPNames.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(ORACLESPName.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(MYSQLSPName.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }


            KendoDataDesc<ART_ST_YEARLY_TOP_GOAML_BRANCHES> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "Top5GOAMLBranches"
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }

        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ART_ST_YEARLY_TOP_GOAML_BRANCHES> data = Enumerable.Empty<ART_ST_YEARLY_TOP_GOAML_BRANCHES>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(SQLSERVERSPNames.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(ORACLESPName.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(MYSQLSPName.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ART_ST_YEARLY_TOP_GOAML_BRANCHES> data = Enumerable.Empty<ART_ST_YEARLY_TOP_GOAML_BRANCHES>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(SQLSERVERSPNames.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(ORACLESPName.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_TOP_GOAML_BRANCHES>(MYSQLSPName.ART_ST_YEARLY_TOP_GOAML_BRANCHES, summaryParams.ToArray());
            }
            ViewData["title"] = "Top 5 GOAML Branches Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "application/pdf");
        }





        public IActionResult Index()
        {
            return View();
        }

    }
}
