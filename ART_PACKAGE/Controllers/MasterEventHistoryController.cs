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
    //[Authorize(Policy = "Licensed" , Roles = "MasterEventHistory")]


    public class MasterEventHistoryController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public MasterEventHistoryController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiMasterEventHistory> data = fti.ArtTiMasterEventHistories.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"BranchName".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Shortname".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Stepdescr".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Stepdescr).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Status".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Status).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Address1".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Address1).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"StatusEv".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.StatusEv).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Ccy".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },


            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].SkipList;

            }

            var Data = data.CallData<ArtTiMasterEventHistory>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                reportname = "MasterEventHistory"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiMasterEventHistories;
            var bytes = await data.ExportToCSV<ArtTiMasterEventHistory, GenericCsvClassMapper<ArtTiMasterEventHistory, MasterEventHistoryController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(MasterEventHistoryController).ToLower()].SkipList;
            var data = fti.ArtTiMasterEventHistories.CallData<ArtTiMasterEventHistory>(req).Data.ToList();
            ViewData["title"] = "Master Event History Report";
            ViewData["desc"] = "This report produces a full history of the events for master records";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}
