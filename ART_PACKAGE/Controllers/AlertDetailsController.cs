
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.Services.Pdf;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{

    public class AlertDetailsController : Controller
    {
        private readonly AuthContext dbfcfkc;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        private readonly IHubContext<ExportHub> _exportHub;
        public AlertDetailsController(AuthContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown, IPdfService pdfSrv, IHubContext<ExportHub> exportHub)
        {
            this.dbfcfkc = dbfcfkc;

            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
            _exportHub = exportHub;
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

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
        {
            IQueryable<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.AsQueryable();
            foreach (Task<byte[]> item in data.ExportToCSVE<ArtAmlAlertDetailView, GenericCsvClassMapper<ArtAmlAlertDetailView, AlertDetailsController>>(req.Req))
            {
                byte[] bytes = await item;
                await _exportHub.Clients.Client(ExportHub.Connections[User.Identity.Name])
                            .SendAsync("csvRecevied", bytes);
            }
            return new EmptyResult();
        }
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

        public IEnumerable<ArtAmlAlertDetailView> GetLargeDataSetInBatches(int batchSize)
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews;
            int totalRecords = data.Count();
            // Implement your data retrieval logic here, fetching data in chunks of 'batchSize'
            // For example, you could use database queries with pagination.
            // Ensure that each batch is efficiently streamed and not loading all data at once.
            // Return each batch of data as an IEnumerable<YourDataClass>.
            // You may need to adjust the logic based on your specific data source.
            // This is just a basic example:
            for (int i = 0; i < totalRecords; i += batchSize)
            {
                IQueryable<ArtAmlAlertDetailView> batch = data.Skip(i * batchSize).Take(batchSize);
                foreach (ArtAmlAlertDetailView? item in batch)
                {
                    yield return item;
                }
            }
        }
        public async Task<IActionResult> StreamExport()
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews;
            int totalRecords = data.Count();
            CsvConfiguration csvConfig = new(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true, // Set this to false if you don't want a header row
            };
            try
            {

                while (totalRecords > 0)
                {
                    MemoryStream stream = new();
                    using StreamWriter writer = new(stream);
                    using (CsvWriter csv = new(writer, csvConfig))
                    {
                        csv.WriteRecords(GetLargeDataSetInBatches(1000));
                        byte[] bytes = stream.ToArray();
                        await _exportHub.Clients.Client(ExportHub.Connections[User.Identity.Name])
                            .SendAsync("csvRecevied", bytes);
                        writer.AutoFlush = true;
                        stream.Position = 0;

                    }
                    totalRecords -= 1000;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return new EmptyResult();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
