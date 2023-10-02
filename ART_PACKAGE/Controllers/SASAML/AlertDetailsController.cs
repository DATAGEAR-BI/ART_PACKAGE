using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using ART_PACKAGE.Hubs;
using Data.Data.SASAml;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.SASAML
{
    [Authorize(Roles = "AlertDetails")]
    public class AlertDetailsController : Controller
    {
        private readonly SasAmlContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly UsersConnectionIds connections;

        public AlertDetailsController(SasAmlContext dbfcfkc, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub, UsersConnectionIds connections)
        {
            this.dbfcfkc = dbfcfkc;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;

            _exportHub = exportHub;
            this.connections = connections;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
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
            }



            KendoDataDesc<ArtAmlAlertDetailView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                selectable = true,
                toolbar = new List<dynamic>  {new
                {
                    id = "StreamExport",
                    text = "StreamExport"
                }
                }
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        //public async Task<IActionResult> Export([FromBody] ExportDto<long?> req)
        //{
        //    IQueryable<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.AsQueryable();
        //    IEnumerable<Task> tasks;
        //    int i = 1;
        //    if (req.All)
        //    {
        //        tasks = data.ExportToCSVE<ArtAmlAlertDetailView, GenericCsvClassMapper<ArtAmlAlertDetailView, AlertDetailsController>>(req.Req);


        //    }
        //    else
        //    {


        //        // Modify the LINQ expression to use Any and Contains
        //        tasks = data
        //            .Where(x => req.SelectedIdz.Contains(x.AlertId))
        //            .ExportToCSVE<ArtAmlAlertDetailView, GenericCsvClassMapper<ArtAmlAlertDetailView, AlertDetailsController>>(req.Req);
        //    }

        //    foreach (Task<byte[]> item in tasks.Cast<Task<byte[]>>())
        //    {
        //        try
        //        {
        //            byte[] bytes = await item;
        //            string FileName = nameof(AlertDetailsController).Replace("Controller", "") + "_" + i + "_" + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //            await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
        //                        .SendAsync("csvRecevied", bytes, FileName);
        //            i++;
        //        }
        //        catch (Exception ex)
        //        {
        //            await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
        //                        .SendAsync("csvErrorRecevied", i);

        //        }

        //    }
        //    return new EmptyResult();
        //}
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;
            List<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.CallData(req).Data.ToList();
            ViewData["title"] = "Alert Details";
            ViewData["desc"] = "Presents the alerts details";
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
