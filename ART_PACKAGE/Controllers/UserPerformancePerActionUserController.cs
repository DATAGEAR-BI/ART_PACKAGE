using ART_PACKAGE.Extentions.DbContextExtentions;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using ART_PACKAGE.Services.Pdf;
using Data.Constants.StoredProcs;
using Data.Data.ECM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Data;

namespace ART_PACKAGE.Controllers
{
    public class UserPerformancePerActionUserController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly EcmContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;


        public UserPerformancePerActionUserController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv, EcmContext context)
        {
            _env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

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

            data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, sd, ed);




            KendoDataDesc<ArtUserPerformancePerActionUser> Data = data.AsQueryable().CallData(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "UserPerformancePerActionUser"
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
            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            SqlParameter sd = new("@V_START_DATE", SqlDbType.VarChar)
            {
                Value = startDate
            };
            SqlParameter ed = new("@V_END_DATE", SqlDbType.VarChar)
            {
                Value = endDate
            };

            data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, sd, ed);

            byte[] bytes = await data.AsQueryable().ExportToCSV(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

            string startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            string endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            SqlParameter sd = new("@V_START_DATE", SqlDbType.VarChar)
            {
                Value = startDate
            };
            SqlParameter ed = new("@V_END_DATE", SqlDbType.VarChar)
            {
                Value = endDate
            };

            data = context.ExecuteProc<ArtUserPerformancePerActionUser>("ART_ST_USER_PERFORMANCE_PER_ACTION_USER", sd, ed);
            ViewData["title"] = "User Performance Per Action User Report";
            ViewData["desc"] = "";
            byte[] bytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }





        public IActionResult Index()
        {
            return View();
        }
    }
}
