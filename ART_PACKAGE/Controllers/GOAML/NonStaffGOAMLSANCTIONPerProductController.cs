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
using System.Linq.Dynamic.Core;
namespace ART_PACKAGE.Controllers.GOAML
{
    public class NonStaffGOAMLSANCTIONPerProductController : Controller
    {


        private readonly ArtGoAmlContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;
        private readonly string dbType;
        private readonly IConfiguration _config;

        public NonStaffGOAMLSANCTIONPerProductController(ArtGoAmlContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv, IConfiguration config)
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
            IEnumerable<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT> data = Enumerable.Empty<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(SQLSERVERSPNames.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(ORACLESPName.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(MYSQLSPName.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
 Dictionary<string, List<dynamic>> DropDownColumn = null;
DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"year".ToLower(),_dropSrv.GetLast10YearsDropDown().Select(s=>Int32.Parse(s.value)).ToDynamicList()},

            };

            KendoDataDesc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT> Data = data.AsQueryable().CallData(para.req, columnsToDropDownd: DropDownColumn);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "NonStaffGOAMLSANCTIONPerProduct"
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
            IEnumerable<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT> data = Enumerable.Empty<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(SQLSERVERSPNames.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(ORACLESPName.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(MYSQLSPName.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT> data = Enumerable.Empty<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(SQLSERVERSPNames.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(ORACLESPName.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT>(MYSQLSPName.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT, summaryParams.ToArray());
            }
            ViewData["title"] = "Non-Staff GOAML Sanction Per Product Report";
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
