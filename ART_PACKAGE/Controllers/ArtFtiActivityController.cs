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
    [Authorize(Roles = "ArtFtiActivity", Policy = "License")]
    public class ArtFtiActivityController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IPdfService _pdfSrv;
        public ArtFtiActivityController(AuthContext dbfcfkc, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc; ;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtFtiActivity> data = dbfcfkc.ArtFtiActivities.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"BranchId".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.BranchId!=null).Select(x => x.BranchId).Distinct().ToDynamicList() },
                    //{"CustomerName".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.CustomerName!=null).Select(x => x.CustomerName).Distinct().ToDynamicList() },
                    {"Currency".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.Currency!=null).Select(x => x.Currency).Distinct().ToDynamicList()  },
                    {"PrimaryOwner".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.PrimaryOwner!=null).Select(x => x.PrimaryOwner).Distinct().ToDynamicList() },
                    {"CaseStatus".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.CaseStatus!=null).Select(x => x.CaseStatus).Distinct().ToDynamicList() },
                    {"Product".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.Product!=null).Select(x => x.Product).Distinct().ToDynamicList() },
                    {"ProductType".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.ProductType!=null).Select(x => x.ProductType).Distinct().ToDynamicList() },
                    {"EventName".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.EventName!=null).Select(x => x.EventName).Distinct().ToDynamicList() },
                    {"LastActionTokenBy".ToLower(),dbfcfkc.ArtCasesInitiatedFromBranches.Where(x=>x.LastActionTokenBy!=null).Select(x => x.LastActionTokenBy).Distinct().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtFtiActivity> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtFtiActivity> data = dbfcfkc.ArtFtiActivities.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtFtiActivity, GenericCsvClassMapper<ArtFtiActivity, ArtFtiActivityController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtFtiActivityController).ToLower()].SkipList;
            List<ArtFtiActivity> data = dbfcfkc.ArtFtiActivities.CallData(req).Data.ToList();
            ViewData["title"] = "FTI-Activities";
            ViewData["desc"] = "DGECM Activity Report showing what cases have been created and their status";
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
