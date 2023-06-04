using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using Oracle.ManagedDataAccess.Client;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Data;
using Data.Constants.StoredProcs;
using Microsoft.Data.SqlClient;
using ART_PACKAGE.Helpers.CustomReportHelpers;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class UserPerformancePerActionUserController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly AuthContext context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;


        public UserPerformancePerActionUserController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMemoryCache cache, IPdfService pdfSrv,AuthContext context)
        {
            this._env = env;
            _cache = cache;
            _pdfSrv = pdfSrv;
            this.context = context;

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

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

            data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, sd, ed);




            var Data = data.AsQueryable().CallData<ArtUserPerformancePerActionUser>(para.req);


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

            data = context.ExecuteProc<ArtUserPerformancePerActionUser>(SPNames.ST_USER_PERFORMANCE_PER_ACTION_USER, sd, ed);

            var bytes = await data.AsQueryable().ExportToCSV<ArtUserPerformancePerActionUser>(para.req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] StoredReq para)
        {
            IEnumerable<ArtUserPerformancePerActionUser> data = Enumerable.Empty<ArtUserPerformancePerActionUser>().AsQueryable();

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

            data = context.ExecuteProc<ArtUserPerformancePerActionUser>("ART_ST_USER_PERFORMANCE_PER_ACTION_USER", sd, ed);
            ViewData["title"] = "User Performance Per Action User Report";
            ViewData["desc"] = "";
            var bytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name);
            return File(bytes, "text/csv");
        }





        public IActionResult Index()
        {
            return View();
        }
    }
}
