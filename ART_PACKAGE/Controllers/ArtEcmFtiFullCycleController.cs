using Microsoft.AspNetCore.Mvc;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Newtonsoft.Json;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Services.Pdf;
using Microsoft.AspNetCore.Authorization;

namespace ART_PACKAGE.Controllers
{
    [Authorize(Roles = "ArtEcmFtiFullCycle")]
    public class ArtEcmFtiFullCycleController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public ArtEcmFtiFullCycleController(AuthContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv)
        {
            this.dbfcfkc = dbfcfkc;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }



        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtEcmFtiFullCycle> data = dbfcfkc.ArtEcmFtiFullCycles.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    {"BranchId".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.BranchId!=null).Select(x => x.BranchId).Distinct().ToDynamicList() },
                    //{"CustomerName".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.CustomerName!=null).Select(x => x.CustomerName).Distinct().ToDynamicList() },
                    {"Currency".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.Currency!=null).Select(x => x.Currency).Distinct().ToDynamicList()  },
                    {"PrimaryOwner".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.PrimaryOwner!=null).Select(x => x.PrimaryOwner).Distinct().ToDynamicList() },
                    {"CaseStatus".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.CaseStatus!=null).Select(x => x.CaseStatus).Distinct().ToDynamicList() },
                    {"MasterAssignedTo".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.MasterAssignedTo!=null).Select(x => x.MasterAssignedTo).Distinct().ToDynamicList() },
                    {"Product".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.Product!=null).Select(x => x.Product).Distinct().ToDynamicList() },
                    {"ProductType".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.ProductType!=null).Select(x => x.ProductType).Distinct().ToDynamicList() },
                    {"EventName".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.EventName!=null).Select(x => x.EventName).Distinct().ToDynamicList() },
                    {"FtiReference".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.FtiReference!=null).Select(x => x.FtiReference).Distinct().ToDynamicList() },
                    {"StepStatus".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.StepStatus!=null).Select(x => x.StepStatus).Distinct().ToDynamicList() },
                    {"EventSteps".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.EventSteps!=null).Select(x => x.EventSteps).Distinct().ToDynamicList() },
                    {"EventStatus".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.EventStatus!=null).Select(x => x.EventStatus).Distinct().ToDynamicList() },
                    {"LastActionTokenBy".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.LastActionTokenBy!=null).Select(x => x.LastActionTokenBy).Distinct().ToDynamicList() },
                    //{"Name".ToLower(),dbfcfkc.ArtEcmFtiFullCycles.Where(x=>x.Name!=null).Select(x => x.Name).Distinct().ToDynamicList() },
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].SkipList;
            }

            KendoDataDesc<ArtEcmFtiFullCycle> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            IQueryable<ArtEcmFtiFullCycle> data = dbfcfkc.ArtEcmFtiFullCycles.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtEcmFtiFullCycle, GenericCsvClassMapper<ArtEcmFtiFullCycle, ArtEcmFtiFullCycleController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ArtEcmFtiFullCycleController).ToLower()].SkipList;
            List<ArtEcmFtiFullCycle> data = dbfcfkc.ArtEcmFtiFullCycles.CallData(req).Data.ToList();
            ViewData["title"] = "ECM-FTI Full cycle";
            ViewData["desc"] = "The full cycle between DGECM and FTI, DGECM case main details, Request and response on comment section, FTI main details, Action/ Feedback requested from FTI to DGECM first line, FTI Notes";
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
