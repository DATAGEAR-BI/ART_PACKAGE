using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ARTGOAML;

namespace ART_PACKAGE.Controllers.GOAML
{
    public class GOAMLReportsSuspectController : Controller
    {
        private readonly ArtGoAmlContext _context;
        private readonly IDropDownService _dropDown;
        private readonly IPdfService _pdfSrv;
        public GOAMLReportsSuspectController(ArtGoAmlContext context, IDropDownService dropDown, IPdfService pdfSrv)
        {
            _context = context;
            _dropDown = dropDown;
            _pdfSrv = pdfSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtGoamlReportsSusbectParty> data = _context.ArtGoamlReportsSusbectParties.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsSuspectController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {

                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown().ToDynamicList() },
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown().ToDynamicList() },
                    {"Branch".ToLower(),_dropDown.GetReportAcctBranchDropDown().ToDynamicList() },


                };
            }


            List<string> ColumnsToSkip = new()
            {

            };
            KendoDataDesc<ArtGoamlReportsSusbectParty> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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


        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            IQueryable<ArtGoamlReportsSusbectParty> data = _context.ArtGoamlReportsSusbectParties.AsQueryable();
            byte[] bytes = await data.ExportToCSV<ArtGoamlReportsSusbectParty, GenericCsvClassMapper<ArtGoamlReportsSusbectParty, GOAMLReportsSuspectController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(GOAMLReportsSuspectController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GOAMLReportsSuspectController).ToLower()].SkipList;
            List<ArtGoamlReportsSusbectParty> data = _context.ArtGoamlReportsSusbectParties.CallData(req).Data.ToList();
            ViewData["title"] = "GOAML Reports Suspected Partites Details";
            ViewData["desc"] = "Presents details about the GOAML reports with the related suspected parties";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }


        //public ContentResult GetData(long? Id, string? Reportstatuscode, string? Reportcode, string? Branch,
        //    string? Reportcreateddatestart, string? Reportcreateddateend, int page = 1)
        //{
        //    if (string.IsNullOrEmpty(Reportstatuscode))
        //    {
        //        Reportstatuscode = "";
        //    }
        //    if (string.IsNullOrEmpty(Reportcode))
        //    {
        //        Reportcode = "";
        //    }
        //    if (string.IsNullOrEmpty(Branch))
        //    {
        //        Branch = "";
        //    }
        //    if (string.IsNullOrEmpty(Reportcreateddatestart))
        //    {
        //        Reportcreateddatestart = "2018-01-01";
        //    }
        //    if (string.IsNullOrEmpty(Reportcreateddateend))
        //    {
        //        Reportcreateddateend = DateTime.Now.ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(Id.ToString()) && string.IsNullOrEmpty(Branch.ToString()))
        //    {
        //        var result_2 = db.GoamlReportsSusbectParties
        //        .Where(b => b.Reportstatuscode.Contains(Reportstatuscode))
        //        .Where(c => c.Reportcode.Contains(Reportcode))
        //        .Where(e => e.Reportcreateddate.Value >= Convert.ToDateTime(Reportcreateddatestart) && e.Reportcreateddate.Value <= Convert.ToDateTime(Reportcreateddateend))
        //        .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //    }
        //    else if (string.IsNullOrEmpty(Branch.ToString()))
        //    {
        //        var result_2 = db.GoamlReportsSusbectParties
        //        .Where(a => a.Id.ToString().Equals(Id.ToString()))
        //        .Where(b => b.Reportstatuscode.Contains(Reportstatuscode))
        //        .Where(c => c.Reportcode.Contains(Reportcode))
        //        .Where(e => e.Reportcreateddate.Value >= Convert.ToDateTime(Reportcreateddatestart) && e.Reportcreateddate.Value <= Convert.ToDateTime(Reportcreateddateend))
        //        .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //    }
        //    else if (string.IsNullOrEmpty(Id.ToString()))
        //    {
        //        var result_2 = db.GoamlReportsSusbectParties
        //        .Where(b => b.Reportstatuscode.Contains(Reportstatuscode))
        //        .Where(c => c.Reportcode.Contains(Reportcode))
        //        .Where(d => d.Branch == Branch)
        //        .Where(e => e.Reportcreateddate.Value >= Convert.ToDateTime(Reportcreateddatestart) && e.Reportcreateddate.Value <= Convert.ToDateTime(Reportcreateddateend))
        //        .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //    }
        //    else
        //    {
        //        var result_2 = db.GoamlReportsSusbectParties
        //        .Where(a => a.Id.ToString().Equals(Id.ToString()))
        //        .Where(b => b.Reportstatuscode.Contains(Reportstatuscode))
        //        .Where(c => c.Reportcode.Contains(Reportcode))
        //        .Where(d => d.Branch == Branch)
        //        .Where(e => e.Reportcreateddate.Value >= Convert.ToDateTime(Reportcreateddatestart) && e.Reportcreateddate.Value <= Convert.ToDateTime(Reportcreateddateend))
        //        .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //    }
        //}
        //public ContentResult getTotalCount()
        //{
        //    var result = db.GoamlReportsSusbectParties.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        ////Get Drop Down Values
        //public ContentResult GetReportAcctBranchDropDown()
        //{
        //    var distinct_value = db.GoamlReportAcctBranchMatviews.GroupBy(s => s.Branch).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetReportTypeDropDown()
        //{
        //    var distinct_value = db.GoamlReportTypeMatviews.GroupBy(s => s.Reporttype).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetReportStatusDropDown()
        //{
        //    var distinct_value = db.GoamlReportStatusMatviews.GroupBy(s => s.ReportStatus).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
