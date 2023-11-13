using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Data.Data.CRP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.CRP
{
    public class CrpSystemPerformanceController : Controller
    {
        private readonly CRPContext _crp;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;

        public CrpSystemPerformanceController(CRPContext crp, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
        {
            _crp = crp;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;

            _exportHub = exportHub;
            this.connections = connections;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtCrpSystemPerformance> data = _crp.ArtCrpSystemPerformances.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"CaseType".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CaseType).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
                    {"CaseStatus".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CaseStatus).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
                    {"CreateUserId".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CreateUserId).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
                    {"CaseCurrentRate".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.CaseCurrentRate).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
                    {"Casetargetrate".ToLower(),_crp.ArtCrpSystemPerformances.Select(x=>x.Casetargetrate).Where(x=>!string.IsNullOrEmpty(x)).Distinct().ToDynamicList() },
                };

                ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].SkipList;
            }



            KendoDataDesc<ArtCrpSystemPerformance> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CrpSystemPerformanceController).ToLower()].SkipList;
            List<ArtCrpSystemPerformance> data = _crp.ArtCrpSystemPerformances.CallData(req).Data.ToList();
            ViewData["title"] = "CRP System Performance Details";
            ViewData["desc"] = "";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }


    }
}
