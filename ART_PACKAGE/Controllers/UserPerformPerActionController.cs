using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

using Microsoft.Extensions.Caching.Memory;
using Oracle.ManagedDataAccess.Client;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Data;
using Microsoft.Data.SqlClient;
using Data.Constants.StoredProcs;
using ART_PACKAGE.Helpers.CustomReportHelpers;

namespace ART_PACKAGE.Controllers
{
    public class UserPerformPerActionController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;


        public UserPerformPerActionController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache,IPdfService pdfSrv,AuthContext context)
        {
            this._env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IEnumerable<ArtUserPerformPerAction> data = Enumerable.Empty<ArtUserPerformPerAction>().AsQueryable();

            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            var sd = new SqlParameter("@V_START_DATE", SqlDbType.VarChar)
            {
                Value = startDate
            };
            var ed = new SqlParameter("@V_END_DATE", SqlDbType.VarChar)
            {
                Value = endDate
            };
            data = context.ExecuteProc<ArtUserPerformPerAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION, sd, ed);

            var Data = data.AsQueryable().CallData<ArtUserPerformPerAction>(para.req);


            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                reportname = "UserPerformPerAction"
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
            IEnumerable<ArtUserPerformPerAction> data = Enumerable.Empty<ArtUserPerformPerAction>().AsQueryable();
            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            var sd = new SqlParameter("@V_START_DATE", SqlDbType.VarChar)
            {
                Value = startDate
            };
            var ed = new SqlParameter("@V_END_DATE", SqlDbType.VarChar)
            {
                Value = endDate
            };


            data = context.ExecuteProc<ArtUserPerformPerAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION, sd, ed/*, ci, ct, cs, cd, cf, cl*/);

            var bytes = await data.AsQueryable().ExportToCSV<ArtUserPerformPerAction>(para.req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformPerAction> data = Enumerable.Empty<ArtUserPerformPerAction>().AsQueryable();
            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value?.Replace("/", "-") ?? "";
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value?.Replace("/", "-") ?? "";
            var sd = new SqlParameter("@V_START_DATE", SqlDbType.VarChar)
            {
                Value = startDate
            };
            var ed = new SqlParameter("@V_END_DATE", SqlDbType.VarChar)
            {
                Value = endDate
            };

            data = context.ExecuteProc<ArtUserPerformPerAction>(SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION, sd, ed/*, ci, ct, cs, cd, cf, cl*/);

            ViewData["title"] = "User Performance Per Action Report";
            ViewData["desc"] = "";
            var bytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }
    }
}
