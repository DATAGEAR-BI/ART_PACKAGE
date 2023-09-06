using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    //[Authorize(Policy = "Licensed" , Roles = "DiaryExceptions")]


    public class DiaryExceptionsController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;
        public DiaryExceptionsController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiDiaryExceptionsReport> data = fti.ArtTiDiaryExceptionsReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(DiaryExceptionsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"MasterRef".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Product".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Status".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"BranchName".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Address1".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"BranchCode".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.BranchCode).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Team".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Team).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Outstccy".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Sovaluedesc".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Sovaluedesc).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Ccy".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(DiaryExceptionsController).ToLower()].SkipList;
            }

            var Data = data.CallData<ArtTiDiaryExceptionsReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                },
                reportname = "DiaryExceptions"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiDiaryExceptionsReports;
            var bytes = await data.ExportToCSV<ArtTiDiaryExceptionsReport, GenericCsvClassMapper<ArtTiDiaryExceptionsReport, DiaryExceptionsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(DiaryExceptionsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(DiaryExceptionsController).ToLower()].SkipList;
            var data = fti.ArtTiDiaryExceptionsReports.CallData<ArtTiDiaryExceptionsReport>(req).Data.ToList();
            ViewData["title"] = "Diary Exceptions Report";
            ViewData["desc"] = "This report produces a list of diary activities that were not carried out when due because of exception conditions";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}
