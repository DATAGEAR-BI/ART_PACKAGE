using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Data.Data.SASAml;
using Data.Services;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class GridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly SasAmlContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;

        private readonly IBaseRepo<SasAmlContext, ArtAmlAlertDetailView> _repo;

        public GridController(SasAmlContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections, IBaseRepo<SasAmlContext, ArtAmlAlertDetailView> repo)
        {
            this.dbfcfkc = dbfcfkc;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;

            _exportHub = exportHub;
            this.connections = connections;
            _repo = repo;
        }

        public IActionResult GetData([FromBody] GridRequest request)
        {
            IQueryable<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    {"AlertId",new GridColumnConfiguration { DisplayName ="Alert ID"}},
                    {"AlertedEntityName",new GridColumnConfiguration { DisplayName ="Alerted Entity Name"}},
                    {"AlertedEntityNumber",new GridColumnConfiguration { DisplayName ="Alerted Entity Number"}},
                    {"BranchName",new GridColumnConfiguration { DisplayName ="Branch Name"}},
                    {"PartyTypeDesc",new GridColumnConfiguration { DisplayName ="Party Type"}},
                    {"PoliticallyExposedPersonInd",new GridColumnConfiguration { DisplayName ="PEP"}},
                    {"RunDate",new GridColumnConfiguration { DisplayName ="Run Date"}},
                    {"CreateDate",new GridColumnConfiguration { DisplayName ="Create Date"}},
                    {"CloseDate",new GridColumnConfiguration { DisplayName ="Closed Date"}},
                    {"MoneyLaunderingRiskScore",new GridColumnConfiguration { DisplayName ="Money Laundering RiskScore"}},
                    {"AlertTypeCd",new GridColumnConfiguration { DisplayName ="Alert Type"}},
                    {"AlertSubCat",new GridColumnConfiguration { DisplayName ="Alert Sub-Category"}},
                    {"AlertStatus",new GridColumnConfiguration { DisplayName ="Alert Status"}},
                    {"AlertDescription",new GridColumnConfiguration { DisplayName ="Alert Description"}},
                    {"ScenarioName",new GridColumnConfiguration { DisplayName ="Scenario Name"}},
                    {"ReportCloseRsn",new GridColumnConfiguration { DisplayName ="Report Close Reason"}},
                    {"ActualValuesText",new GridColumnConfiguration { DisplayName ="Scenario Description"}},
                    {"OwnerUserid",new GridColumnConfiguration { DisplayName ="Owner "}},
                    {"InvestigationDays",new GridColumnConfiguration { DisplayName ="Investigation Days"}}

            };
                List<dynamic> PEPlist = new()
                    {
                        "Y","N"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown().ToDynamicList() },
                    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    //{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                    {"PoliticallyExposedPersonInd".ToLower(),PEPlist.ToDynamicList() },
                    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown().ToDynamicList() }
                };

                ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;

                GridIntializationConfiguration result = new()
                {
                    columns = GridHelprs.GetColumns<ArtAmlAlertDetailView>(DropDownColumn, DisplayNames, ColumnsToSkip),
                    containsActions = false,
                    selectable = true
                };
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(result)
                };
            }

            GridResult<ArtAmlAlertDetailView> res = _repo.GetGridData(request);

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(res)
            };

        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;
            List<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Alert Details";
            ViewData["desc"] = "Presents the alerts details";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }


    }
}
