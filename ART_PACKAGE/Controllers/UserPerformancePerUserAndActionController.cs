using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.StoredProcs;
using Data.Data.ECM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Data;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "UserPerformancePerUserAndAction")]
    public class UserPerformancePerUserAndActionController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;


        public UserPerformancePerUserAndActionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, EcmContext context)
        {
            _env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtUserPerformPerUserAndAction> data = Enumerable.Empty<ArtUserPerformPerUserAndAction>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            SqlParameter sd = new("@V_START_DATE", SqlDbType.Date)
            {
                Value = startDate
            };
            SqlParameter ed = new("@V_END_DATE", SqlDbType.Date)
            {
                Value = endDate
            };
            data = context.ExecuteProc<ArtUserPerformPerUserAndAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, sd, ed/*, ci, ct, cs, cd, cf, cl*/);




            KendoDataDesc<ArtUserPerformPerUserAndAction> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "UserPerformancePerUserAndAction"
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


        public async Task<IActionResult> Export([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformPerUserAndAction> data = Enumerable.Empty<ArtUserPerformPerUserAndAction>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            SqlParameter sd = new("@V_START_DATE", SqlDbType.Date)
            {
                Value = startDate
            };
            SqlParameter ed = new("@V_END_DATE", SqlDbType.Date)
            {
                Value = endDate
            };

            data = context.ExecuteProc<ArtUserPerformPerUserAndAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, sd, ed/*, ci, ct, cs, cd, cf, cl*/);


            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformPerUserAndAction> data = Enumerable.Empty<ArtUserPerformPerUserAndAction>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            SqlParameter sd = new("@V_START_DATE", SqlDbType.Date)
            {
                Value = startDate
            };
            SqlParameter ed = new("@V_END_DATE", SqlDbType.Date)
            {
                Value = endDate
            };

            data = context.ExecuteProc<ArtUserPerformPerUserAndAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION, sd, ed/*, ci, ct, cs, cd, cf, cl*/);
            ViewData["title"] = "User Performance Per User and Action Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}
