using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{


    public class ACPostingsAccountController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;
        private readonly ICsvExport _csvSrv;
        public ACPostingsAccountController(IPdfService pdfSrv, FTIContext fti, IDropDownService dropDown, ICsvExport csvSrv)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
            _csvSrv = csvSrv;
        }
        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiAcpostingsAccReport> data = fti.ArtTiAcpostingsAccReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ACPostingsAccountController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {

                { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null ).ToDynamicList() },
                { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null ).ToDynamicList() },

            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(ACPostingsAccountController).ToLower()].SkipList;
            }
            KendoDataDesc<ArtTiAcpostingsAccReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "ACPostingsAccount"

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
            IQueryable<ArtTiAcpostingsAccReport> data = fti.ArtTiAcpostingsAccReports.AsQueryable();
            await _csvSrv.ExportAllCsv<ArtTiAcpostingsAccReport, ACPostingsAccountController, decimal>(data, User.Identity.Name, para);
            return new EmptyResult();

        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            List<ArtTiAcpostingsAccReport> data = fti.ArtTiAcpostingsAccReports.CallData(req).Data.ToList();
            ViewData["title"] = "A C Postings – Account Report";
            ViewData["desc"] = "This report produces all postings posted to an account by value date";
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ACPostingsAccountController).ToLower()].DisplayNames;
            List<string> columnsToPrint = new() {
                nameof(ArtTiAcpostingsAccReport.EventRef)
               ,nameof(ArtTiAcpostingsAccReport.MasterRef)
               ,nameof(ArtTiAcpostingsAccReport.AccountType)
               ,nameof(ArtTiAcpostingsAccReport.Valuedate)
               ,nameof(ArtTiAcpostingsAccReport.AcctNo)
               ,nameof(ArtTiAcpostingsAccReport.DrCrFlg)
               ,nameof(ArtTiAcpostingsAccReport.Ccy)
               ,nameof(ArtTiAcpostingsAccReport.PostAmount)
            };
            List<string> ColumnsToSkip = typeof(ArtTiAcpostingsAccReport).GetProperties().Select(x => x.Name).Where(x => !columnsToPrint.Contains(x)).ToList();
            if (req.Group is not null && req.Group.Count != 0)
            {
                byte[] pdfBytes = await _pdfSrv.ExportGroupedToPdf(data, ViewData, ControllerContext
                                                   , User.Identity.Name, req.Group, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }
            else
            {
                byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 8
                                                   , User.Identity.Name, ColumnsToSkip, DisplayNames);
                return File(pdfBytes, "application/pdf");
            }

        }

    }
}
