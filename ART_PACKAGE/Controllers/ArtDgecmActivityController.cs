using Microsoft.AspNetCore.Mvc;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;
using Microsoft.AspNetCore.Authorization;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ArtDgecmActivity", Policy = "License")]
    public class ArtDgecmActivityController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        public ArtDgecmActivityController(AuthContext dbfcfkc, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtDgecmActivity> data = dbfcfkc.ArtDgecmActivities.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"BranchId".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.BranchId!=null).Select(x => x.BranchId).Distinct().ToDynamicList() },
                    //{"CustomerName".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.CustomerName!=null).Select(x => x.CustomerName).Distinct().ToDynamicList() },
                    {"Currency".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.Currency!=null).Select(x => x.Currency).Distinct().ToDynamicList()  },
                    {"PrimaryOwner".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.PrimaryOwner!=null).Select(x => x.PrimaryOwner).Distinct().ToDynamicList() },
                    {"CaseStatus".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.CaseStatus!=null).Select(x => x.CaseStatus).Distinct().ToDynamicList() },
                    //{"CaseComments".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.CaseComments!=null).Select(x => x.CaseComments).Distinct().ToDynamicList() },
                    {"Product".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.Product!=null).Select(x => x.Product).Distinct().ToDynamicList() },
                    {"ProductType".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.ProductType!=null).Select(x => x.ProductType).Distinct().ToDynamicList() },
                    {"EventName".ToLower(),dbfcfkc.ArtDgecmActivities.Where(x=>x.EventName!=null).Select(x => x.EventName).Distinct().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtDgecmActivity> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                    /*new
                    {
                        text = "Delete Cases",
                        id="dltCases",
                        show = User.IsInRole("Delete_Cases")
                    }*/
                },

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        /*public IActionResult Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfkc.AmlCaseDetailViews.AsQueryable();
            var bytes = data.ExportToCSV<AmlCaseDetailView>(req.Req);
            return File(bytes, "test/csv");
        }*/
        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtDgecmActivity> data = dbfcfkc.ArtDgecmActivities.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtDgecmActivity, GenericCsvClassMapper<ArtDgecmActivity, ArtDgecmActivityController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtDgecmActivityController).ToLower()].SkipList;
            List<ArtDgecmActivity> data = dbfcfkc.ArtDgecmActivities.CallData(req).Data.ToList();
            ViewData["title"] = "DGECM-Activities";
            ViewData["desc"] = "Transactions from FTI and their communication with DGECM, FTI Transaction main detail,The first line parties that are selected to communicate with on DGECM";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
