using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;

using Data.Constants.StoredProcs;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.DropDown;
using Data.Services.Grid;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLPartiesListDetailsController : Controller
    {

        private readonly IMemoryCache _cache;
        private readonly ArtDgAmlContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IConfiguration _config;
        private readonly string dbType;
        private readonly IDropDownService _dropDown;



        public DGAMLPartiesListDetailsController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, ArtDgAmlContext context, IConfiguration config,IDropDownService dropDown)
        {
            _env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
            _dropDown = dropDown;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ArtStDgAmlPartiesListDetails> data = Enumerable.Empty<ArtStDgAmlPartiesListDetails>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(SQLSERVERSPNames.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(ORACLESPName.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(MYSQLSPName.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }

            KendoDataDesc<ArtStDgAmlPartiesListDetails> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "DGAMLPartiesListDetails"
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCitizenshipCountryDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetCitizenshipCountryDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetCustomerNameDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetCustomerNameDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetPoliticalExposedDropDown()
        {
            List<SelectItem> Result = new()
            {
                    new SelectItem(){ text="Yes" , value="Yes" },
                    new SelectItem(){ text="No" , value="No" },
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(Result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtStDgAmlPartiesListDetails> data = Enumerable.Empty<ArtStDgAmlPartiesListDetails>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(SQLSERVERSPNames.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(ORACLESPName.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(MYSQLSPName.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtStDgAmlPartiesListDetails> data = Enumerable.Empty<ArtStDgAmlPartiesListDetails>().AsQueryable();

            IEnumerable<System.Data.Common.DbParameter> summaryParams = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(SQLSERVERSPNames.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.Oracle)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(ORACLESPName.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            else if (dbType == DbTypes.MySql)
            {
                data = context.ExecuteProc<ArtStDgAmlPartiesListDetails>(MYSQLSPName.ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT, summaryParams.ToArray());
            }
            ViewData["title"] = "Parties List Details";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}
