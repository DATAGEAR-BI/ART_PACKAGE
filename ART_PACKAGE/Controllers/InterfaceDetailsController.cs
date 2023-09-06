using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers {
    //[Authorize(Policy = "Licensed" , Roles = "InterfaceDetails")]

    
    public class InterfaceDetailsController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public InterfaceDetailsController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiInterfaceDetailsReport> data = fti.ArtTiInterfaceDetailsReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(InterfaceDetailsController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                //{"Status".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"MstRef".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.MstRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"EvtRef".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.EvtRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"ToType".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.ToType).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"FromType".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.FromType).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"FromCcy".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.FromCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"ToCcy".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.ToCcy).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"FromBranch".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.FromBranch).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"ToBranch".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.ToBranch).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"Xref".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.Xref).Distinct().Where(x=> x != null ).ToDynamicList() },
                ////{"UserOptions".ToLower(),fti.ArtTiInterfaceDetailsReports.Select(x=>x.UserOptions).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(InterfaceDetailsController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiInterfaceDetailsReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "InterfaceDetails"
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
            var data = fti.ArtTiInterfaceDetailsReports;
            var bytes = await data.ExportToCSV<ArtTiInterfaceDetailsReport, GenericCsvClassMapper<ArtTiInterfaceDetailsReport, InterfaceDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(InterfaceDetailsController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(InterfaceDetailsController).ToLower()].SkipList;
            var data = fti.ArtTiInterfaceDetailsReports.CallData<ArtTiInterfaceDetailsReport>(req).Data.ToList();
            ViewData["title"] = "Interface Details Report";
            ViewData["desc"] = "This report produces a listing of items passed from Fusion Trade Innovation to each back office system like Postings, Foreign exchange deals etc..";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}
