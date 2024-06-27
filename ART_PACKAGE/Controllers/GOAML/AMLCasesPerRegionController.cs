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
    public class AMLCasesPerRegionController : Controller
    {


        private readonly ArtGoAmlContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;
        private readonly string dbType;
        private readonly IConfiguration _config;

        public AMLCasesPerRegionController(ArtGoAmlContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv, IConfiguration config)
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
            IEnumerable<ART_ST_YEARLY_AML_PER_REGION> data = Enumerable.Empty<ART_ST_YEARLY_AML_PER_REGION>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(SQLSERVERSPNames.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(ORACLESPName.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(MYSQLSPName.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }


            KendoDataDesc<ART_ST_YEARLY_AML_PER_REGION> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "AMLCasesPerRegion"
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
            IEnumerable<ART_ST_YEARLY_AML_PER_REGION> data = Enumerable.Empty<ART_ST_YEARLY_AML_PER_REGION>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(SQLSERVERSPNames.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(ORACLESPName.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(MYSQLSPName.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ART_ST_YEARLY_AML_PER_REGION> data = Enumerable.Empty<ART_ST_YEARLY_AML_PER_REGION>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(SQLSERVERSPNames.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(ORACLESPName.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_AML_PER_REGION>(MYSQLSPName.ART_ST_YEARLY_AML_PER_REGION, summaryParams.ToArray());
            }
            ViewData["title"] = "AML Cases Per Region";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "application/pdf");
        }





        public IActionResult Index()
        {
            return View();
        }

    }
}
