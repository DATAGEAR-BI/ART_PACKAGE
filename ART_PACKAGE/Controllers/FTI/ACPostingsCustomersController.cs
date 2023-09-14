using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.FTI
{


    public class ACPostingsCustomersController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public ACPostingsCustomersController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiAcpostingsCustReport> data = fti.ArtTiAcpostingsCustReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ACPostingsCustomersController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
               {"MasterRef".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"AcctNo".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"AccountType".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.AccountType).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Shortname".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"DrCrFlg".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.DrCrFlg).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Ccy".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"CusMnm".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Spsk".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Spsk).Distinct().Where(x=> x != null ).ToDynamicList() },
               {"Mainbanking".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Mainbanking).Distinct().Where(x=> x != null ).ToDynamicList() },
               { "BranchName".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },

               { "EventRef".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ACPostingsCustomersController).ToLower()].SkipList;
            }
            KendoDataDesc<ArtTiAcpostingsCustReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {


                },
                reportname = "ACPostingsCustomers"

            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };


        }
        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            List<ArtTiAcpostingsCustReport> data = fti.ArtTiAcpostingsCustReports.CallData(req).Data.ToList();

            ViewData["title"] = "A C Postings - Customers Report";
            ViewData["desc"] = "This report produces all postings posted to an account by value date";

            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ACPostingsCustomersController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new() {
                 nameof(ArtTiAcpostingsCustReport.EventRef)
                ,nameof(ArtTiAcpostingsCustReport.MasterRef)
                ,nameof(ArtTiAcpostingsCustReport.AccountType)
                ,nameof(ArtTiAcpostingsCustReport.Valuedate)
                ,nameof(ArtTiAcpostingsCustReport.AcctNo)
                ,nameof(ArtTiAcpostingsCustReport.DrCrFlg)
                ,nameof(ArtTiAcpostingsCustReport.Ccy)
                ,nameof(ArtTiAcpostingsCustReport.PostAmount)
                ,nameof(ArtTiAcpostingsCustReport.CusMnm)
            };
            List<string> ColumnsToSkip = typeof(ArtTiAcpostingsCustReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();
            if (req.Group is not null && req.Group.Count != 0)
            {
                byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 9
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");


            }
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            Microsoft.EntityFrameworkCore.DbSet<ArtTiAcpostingsCustReport> data = fti.ArtTiAcpostingsCustReports;
            byte[] bytes = await data.ExportToCSV<ArtTiAcpostingsCustReport, GenericCsvClassMapper<ArtTiAcpostingsCustReport, ACPostingsCustomersController>>(para.Req);
            return File(bytes, "text/csv");
        }
    }
}
