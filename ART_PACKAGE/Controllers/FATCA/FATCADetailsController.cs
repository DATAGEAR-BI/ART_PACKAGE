using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.DATA.FATCA;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    /*[AllowAnonymous]*/

    public class FATCADetailsController : BaseReportController<IGridConstructor<IBaseRepo<FATCAContext, ArtFatcaCustomer>, FATCAContext, ArtFatcaCustomer>, IBaseRepo<FATCAContext, ArtFatcaCustomer>, FATCAContext, ArtFatcaCustomer>
    {
        public FATCADetailsController(IGridConstructor<IBaseRepo<FATCAContext, ArtFatcaCustomer>, FATCAContext, ArtFatcaCustomer> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

        public override IActionResult Index()
        {
            return View();
        }
        /*
private readonly FATCAContext context;
private readonly IPdfService _pdfSrv;
private readonly IDropDownService _dropSrv;
private readonly ICsvExport _csvSrv;
public FATCADetailsController(FATCAContext context, IPdfService pdfSrv, IDropDownService dropSrv, ICsvExport csvSrv)
{
   this.context = context;
   _pdfSrv = pdfSrv;
   _dropSrv = dropSrv;
   _csvSrv = csvSrv;
}

public IActionResult GetData([FromBody] KendoRequest request)
{
   IQueryable<ArtFatcaCustomer> data = context.ArtFatcaCustomers.AsQueryable();

   Dictionary<string, GridColumnConfiguration> DisplayNames = null;
   Dictionary<string, List<dynamic>> DropDownColumn = null;
   List<string> ColumnsToSkip = null;

   if (request.IsIntialize)
   {
       DisplayNames = ReportsConfig.CONFIG[nameof(FATCADetailsController).ToLower()].DisplayNames;

       DropDownColumn = new Dictionary<string, List<dynamic>>
       {
           //{"BranchName".ToLower(),_dropSrv.GetBranchNameDropDown().ToDynamicList() },

       };
   }
   ColumnsToSkip = ReportsConfig.CONFIG[nameof(FATCADetailsController).ToLower()].SkipList;

   KendoDataDesc<ArtFatcaCustomer> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

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

public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
{
   Microsoft.EntityFrameworkCore.DbSet<ArtFatcaCustomer> data = context.ArtFatcaCustomers;
   await _csvSrv.ExportAllCsv<ArtFatcaCustomer, FATCADetailsController, decimal>(data, User.Identity.Name, para);
   return new EmptyResult();
}


public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
{
   Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(FATCADetailsController).ToLower()].DisplayNames;
   List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(FATCADetailsController).ToLower()].SkipList;
   List<ArtFatcaCustomer> data = context.ArtFatcaCustomers.CallData(req).Data.ToList();
   ViewData["title"] = "FATCA Customers Report";
   ViewData["desc"] = "This report presents all Fatca Customers with the related information as below";
   byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                           , User.Identity.Name, ColumnsToSkip, DisplayNames);
   return File(pdfBytes, "application/pdf");
}

public IActionResult Index()
{
   return View();
}*/
    }
}




/*using DataGear_RV_Ver_1._7.dbfagpdb;
using DataGear_RV_Ver_1._7.Helpers;
using ART_PACKAGE.Helpers.Csv;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Hubs;
using DataGear_RV_Ver_1._7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

using Data.Services.Grid;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class FATCADetailsController : Controller
    {
        private readonly dbfagpdb.ModelContext dbfagpdb;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        private readonly IHubContext<ExportHub> _exportHub;
        private readonly ICsvExport _csvSrv;
        public FATCADetailsController(dbfagpdb.ModelContext dbfagpdb, IMemoryCache cache, IDropDownService dropDown, IHubContext<ExportHub> exportHub, ICsvExport csvSrv)
        {
            this.dbfagpdb = dbfagpdb;
            _cache = cache;
            this._dropDown = dropDown;
            _exportHub = exportHub;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtFatcaCustomer> data = dbfagpdb.ArtFatcaCustomers.AsQueryable();

            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;
            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(FATCADetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    //{"CaseStatus".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"CustClsFlag".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"MainNationality".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() }

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(FATCADetailsController).ToLower()].SkipList;
            }


            var Data = data.CallData<ArtFatcaCustomer>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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



        //public ContentResult GetData(string? CaseId, string? CaseStatus, string? CustomerId, string? CustomerName,
        //    string? BranchName, string? CustClsFlag, string? MainNationality,
        //    string? SignW8, string? SignW9,
        //    string? startCreateDate, string? endCreateDate, string? startW9SignDate, string? endW9SignDate, string? startW8SignDate, string? endW8SignDate,
        //    int page = 1)
        //{
        //    if (string.IsNullOrEmpty(CaseId))
        //    {
        //        CaseId = "";
        //    }
        //    if (string.IsNullOrEmpty(CaseStatus))
        //    {
        //        CaseStatus = "";
        //    }
        //    if (string.IsNullOrEmpty(CustomerId))
        //    {
        //        CustomerId = "";
        //    }
        //    if (string.IsNullOrEmpty(CustomerName))
        //    {
        //        CustomerName = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchName))
        //    {
        //        BranchName = "";
        //    }
        //    if (string.IsNullOrEmpty(CustClsFlag))
        //    {
        //        CustClsFlag = "";
        //    }
        //    if (string.IsNullOrEmpty(MainNationality))
        //    {
        //        MainNationality = "";
        //    }
        //    if (string.IsNullOrEmpty(SignW8))
        //    {
        //        SignW8 = "";
        //    }
        //    if (string.IsNullOrEmpty(SignW9))
        //    {
        //        SignW9 = "";
        //    }
        //    if (string.IsNullOrEmpty(startCreateDate))
        //    {
        //        startCreateDate = "2016-01-01";
        //    }
        //    if (string.IsNullOrEmpty(endCreateDate))
        //    {
        //        endCreateDate = DateTime.Now.ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(startW9SignDate))
        //    {
        //        startW9SignDate = "2016-01-01";
        //    }
        //    if (string.IsNullOrEmpty(endW9SignDate))
        //    {
        //        endW9SignDate = DateTime.Now.ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(startW8SignDate))
        //    {
        //        startW8SignDate = "2016-01-01";
        //    }
        //    if (string.IsNullOrEmpty(endW8SignDate))
        //    {
        //        endW8SignDate = DateTime.Now.ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(startCreateDate) && string.IsNullOrEmpty(endCreateDate) )
        //    {
        //        var result = db.ArtFatcaCustomers
        //       .Where(a => a.CaseId.Contains(CaseId))
        //       .Where(b => b.CaseStatus.Contains(CaseStatus))
        //       .Where(c => c.CustomerId.Contains(CustomerId))
        //       .Where(d => d.CustomerName.Contains(CustomerName))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //       .Where(f => f.CustClsFlag.Contains(CustClsFlag))
        //        .Where(j => j.MainNationality.Contains(MainNationality))
        //        .Where(l => l.SignW8.Contains(SignW8))
        //        .Where(m => m.SignW9.Contains(SignW9))
        //        //.Where(g => g.W8SignDate.Value >= Convert.ToDateTime(startW8SignDate) && g.W8SignDate.Value <= Convert.ToDateTime(endW8SignDate))
        //        .Where(g => g.W8SignDate.Date.Date >= Convert.ToDateTime(startW8SignDate).Date.Date && g.W8SignDate.Date.Date <= Convert.ToDateTime(endW8SignDate).Date.Date)
        //        .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result), "application/json");
        //    }
        //    //if (string.IsNullOrEmpty(startW9SignDate) && string.IsNullOrEmpty(endW9SignDate) && string.IsNullOrEmpty(startW8SignDate) && string.IsNullOrEmpty(endW8SignDate))
        //    //{
        //    //    var result = db.ArtFatcaCustomers
        //    //   .Where(a => a.CaseId.Contains(CaseId))
        //    //   .Where(b => b.CaseStatus.Contains(CaseStatus))
        //    //   .Where(c => c.CustomerId.Contains(CustomerId))
        //    //   .Where(d => d.CustomerName.Contains(CustomerName))
        //    //   .Where(e => e.BranchName.Contains(BranchName))
        //    //   .Where(f => f.CustClsFlag.Contains(CustClsFlag))
        //    //   //.Where(g => g.CreateDate.Value >= Convert.ToDateTime(startCreateDate) && g.CreateDate.Value <= Convert.ToDateTime(endCreateDate))
        //    //.Where(g => g.CreateDate.Date.Date >= Convert.ToDateTime(startCreateDate).Date.Date && g.CreateDate.Date.Date <= Convert.ToDateTime(endCreateDate).Date.Date)

        //    //    .Where(j => j.MainNationality.Contains(MainNationality))
        //    //    .Where(l => l.SignW8.Contains(SignW8))
        //    //    .Where(m => m.SignW9.Contains(SignW9))
        //    //    .ToPagedList(page, 600);
        //    //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //    //}
        //    //if ( string.IsNullOrEmpty(startW8SignDate) && string.IsNullOrEmpty(endW8SignDate))
        //    //{
        //    //    var result = db.ArtFatcaCustomers
        //    //   .Where(a => a.CaseId.Contains(CaseId))
        //    //   .Where(b => b.CaseStatus.Contains(CaseStatus))
        //    //   .Where(c => c.CustomerId.Contains(CustomerId))
        //    //   .Where(d => d.CustomerName.Contains(CustomerName))
        //    //   .Where(e => e.BranchName.Contains(BranchName))
        //    //   .Where(f => f.CustClsFlag.Contains(CustClsFlag))
        //    //   .Where(g => g.W9SignDate.Value >= Convert.ToDateTime(startW9SignDate) && g.W9SignDate.Value <= Convert.ToDateTime(endW9SignDate))
        //    //    .Where(j => j.MainNationality.Contains(MainNationality))
        //    //    .Where(l => l.SignW8.Contains(SignW8))
        //    //    .Where(m => m.SignW9.Contains(SignW9))
        //    //    .ToPagedList(page, 600);
        //    //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //    //}
        //    //if ( string.IsNullOrEmpty(startW9SignDate) && string.IsNullOrEmpty(endW9SignDate))
        //    //{
        //    //    var result = db.ArtFatcaCustomers
        //    //   .Where(a => a.CaseId.Contains(CaseId))
        //    //   .Where(b => b.CaseStatus.Contains(CaseStatus))
        //    //   .Where(c => c.CustomerId.Contains(CustomerId))
        //    //   .Where(d => d.CustomerName.Contains(CustomerName))
        //    //   .Where(e => e.BranchName.Contains(BranchName))
        //    //   .Where(f => f.CustClsFlag.Contains(CustClsFlag))
        //    //   .Where(g => g.W8SignDate.Value >= Convert.ToDateTime(startW8SignDate) && g.W8SignDate.Value <= Convert.ToDateTime(endW8SignDate))
        //    //    .Where(j => j.MainNationality.Contains(MainNationality))
        //    //    .Where(l => l.SignW8.Contains(SignW8))
        //    //    .Where(m => m.SignW9.Contains(SignW9))
        //    //    .ToPagedList(page, 600);
        //    //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //    //}
        //    var result_2 = db.ArtFatcaCustomers
        //       .Where(a => a.CaseId.Contains(CaseId))
        //       .Where(b => b.CaseStatus.Contains(CaseStatus))
        //       .Where(c => c.CustomerId.Contains(CustomerId))
        //       .Where(d => d.CustomerName.Contains(CustomerName))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //       .Where(f => f.CustClsFlag.Contains(CustClsFlag))
        //        .Where(j => j.MainNationality.Contains(MainNationality))
        //        .Where(l => l.SignW8.Contains(SignW8))
        //        .Where(m => m.SignW9.Contains(SignW9))
        //        .Where(g => g.CreateDate.Date.Date >= Convert.ToDateTime(startCreateDate).Date.Date && g.CreateDate.Date.Date <= Convert.ToDateTime(endCreateDate).Date.Date)
        //        //.Where(gg => gg.W8SignDate.Date.Date >= Convert.ToDateTime(startW8SignDate).Date.Date && gg.W8SignDate.Date.Date <= Convert.ToDateTime(endW8SignDate).Date.Date)

        //        .ToPagedList(page, 600);
        //    return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //}
        //public ContentResult getTotalCount()
        //{
        //    var result = db.ArtFatcaCustomers.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
*/