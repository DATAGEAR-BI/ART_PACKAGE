using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Dynamic.Core;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Controllers
{
    public class GOAMLReportsSuspectController : Controller
    {
        private readonly AuthContext _context;
        //private readonly IDropDownService _dropDown;
        public GOAMLReportsSuspectController(AuthContext context)
        {
            this._context = context;
            //this._dropDown = dropDown;
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
                    //{"Reportcode".ToLower(),dgcmgmt.ArtCaseTypesViews.Select(x => x.CaseType).ToDynamicList() },
                    //{"Reportstatuscode".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"Branch".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },

                    //{"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown().ToDynamicList() },
                    //{"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown().ToDynamicList() },
                    //{"Branch".ToLower(),_dropDown.GetReportAcctBranchDropDown().ToDynamicList() },


                };
            }


            var ColumnsToSkip = new List<string>
            {

            };
            var Data = data.CallData<ArtGoamlReportsSusbectParty>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = _context.ArtGoamlReportsSusbectParties.AsQueryable();
            var bytes = await data.ExportToCSV<ArtGoamlReportsSusbectParty, GenericCsvClassMapper<ArtGoamlReportsSusbectParty, GOAMLReportsSuspectController>>(para.Req);
            return File(bytes, "text/csv");
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
