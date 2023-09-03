using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Controllers { 
    //[Authorize(Policy = "Licensed" , Roles = "SystemTailoring")]

    
    public class SystemTailoringController : Controller
    {
        private readonly AuthContext fti;
        private readonly IPdfService _pdfSrv;

        public SystemTailoringController(IPdfService pdfSrv, AuthContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiSystemTailoringReport> data = fti.ArtTiSystemTailoringReports.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"Paramsetdescr".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Paramsetdescr).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Prodlongname".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Prodlongname).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Eventlongname".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Eventlongname).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Attachment".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Attachment).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Mappingtype".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Mappingtype).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Templateid".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Templateid).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Optional".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Optional).Distinct().Where(x=> x != null ).ToDynamicList() },
                    {"Templatedescr".ToLower(),fti.ArtTiSystemTailoringReports.Select(x=>x.Templatedescr).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].SkipList;

            }
            var Data = data.CallData<ArtTiSystemTailoringReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                reportname = "SystemTailoring"
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
            var data = fti.ArtTiSystemTailoringReports;
            var bytes = await data.ExportToCSV<ArtTiSystemTailoringReport, GenericCsvClassMapper<ArtTiSystemTailoringReport, SystemTailoringController>>(para.Req);
            return File(bytes, "text/csv");
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].DisplayNames;
            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(SystemTailoringController).ToLower()].SkipList;
            var data = fti.ArtTiSystemTailoringReports.CallData<ArtTiSystemTailoringReport>(req).Data.ToList();
            ViewData["title"] = "System Tailoring Report";
            ViewData["desc"] = "This report produces rules conditions and parameter code details";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }
    }
}
