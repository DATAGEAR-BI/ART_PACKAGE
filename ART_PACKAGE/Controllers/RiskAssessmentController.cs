using DataGear_RV_Ver_1._7.dbfcfcore;
using DataGear_RV_Ver_1._7.dbfcfkc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using System.Data;
using DataGear_RV_Ver_1._7.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Services;
using System.Linq.Dynamic.Core;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Helpers.CSVMAppers;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class RiskAssessmentController : Controller
    {
        private readonly dbfcfcore.ModelContext dbfcfcore;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        public RiskAssessmentController(dbfcfcore.ModelContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
            this._dropDown = dropDown;
        }

        //private dbfcfkc.ModelContext dbfcfkc = new dbfcfkc.ModelContext();
        //private dbfcfcore.ModelContext dbfcfcore = new dbfcfcore.ModelContext();
        //private dbcmcaudit.ModelContext dbcmcaudit = new();


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AmlRiskAssessment> data = dbfcfcore.AmlRiskAssessments.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"AssessmentTypeCd".ToLower(),_dropDown.GetAssessmentTypeDropDown().ToDynamicList() },
                    {"CreateUserId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"RiskStatus".ToLower(),_dropDown.GetRiskStatusDropDown().ToDynamicList() },
                    {"RiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"ProposedRiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"OwnerUserLongId".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() }

                };
            }


            var ColumnsToSkip = ReportsConfig.CONFIG[nameof(RiskAssessmentController).ToLower()].SkipList;
            var Data = data.CallData<AmlRiskAssessment>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfcore.AmlRiskAssessments.AsQueryable();
            var bytes = await data.ExportToCSV<AmlRiskAssessment, GenericCsvClassMapper<AmlRiskAssessment, RiskAssessmentController>>(req.Req);
            return File(bytes, "test/csv");
        }


        //public ContentResult GetData(string? RiskStatus,
        //    string? RiskClass, string? ProposedRiskClass, string? BranchName,
        //    string? RiskAssessmentId, string? PartyNumber, string? PartyName, string? RiskAssessmentDuration, string? CreateUserId,
        //    string? AssessmentTypeCd, string? AssessmentCategoryCd, string? AssessmentSubcategoryCd, string? OwnerUserLongId, string? cstartdate, string? cenddate, string? ExportedColumns,
        //    int page = 1)
        //{
        //    if (string.IsNullOrEmpty(RiskStatus))
        //    {
        //        RiskStatus = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskClass))
        //    {
        //        RiskClass = "";
        //    }
        //    if (string.IsNullOrEmpty(ProposedRiskClass))
        //    {
        //        ProposedRiskClass = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchName))
        //    {
        //        BranchName = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskAssessmentId))
        //    {
        //        RiskAssessmentId = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyNumber))
        //    {
        //        PartyNumber = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyName))
        //    {
        //        PartyName = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskAssessmentDuration))
        //    {
        //        RiskAssessmentDuration = "";
        //    }
        //    if (string.IsNullOrEmpty(cstartdate))
        //    {
        //        cstartdate = "2018-01-01";
        //    }
        //    if (string.IsNullOrEmpty(cenddate))
        //    {
        //        cenddate = DateTime.Now.ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(CreateUserId))
        //    {
        //        CreateUserId = "";
        //    }

        //    if (string.IsNullOrEmpty(AssessmentTypeCd))
        //    {
        //        AssessmentTypeCd = "";
        //    }
        //    if (string.IsNullOrEmpty(AssessmentCategoryCd))
        //    {
        //        AssessmentCategoryCd = "";
        //    }
        //    if (string.IsNullOrEmpty(AssessmentSubcategoryCd))
        //    {
        //        AssessmentSubcategoryCd = "";
        //    }
        //    if (string.IsNullOrEmpty(OwnerUserLongId))
        //    {
        //        OwnerUserLongId = "";
        //    }




        //    if (page==0)
        //    {

        //        var result = dbfcfcore.AmlRiskAssessments.Select(s => s)

        //       .Where(b => b.RiskStatus.Contains(RiskStatus))
        //       .Where(c => c.RiskClass.Contains(RiskClass))
        //       .Where(d => d.ProposedRiskClass.Contains(ProposedRiskClass))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //      .Where(f => f.RiskAssessmentId.Contains(RiskAssessmentId))
        //       .Where(g => g.PartyNumber.Contains(PartyNumber))
        //       .Where(h => h.PartyName.Contains(PartyName))
        //       .Where(i => i.CreateDate.Value.Date >= Convert.ToDateTime(cstartdate).Date && i.CreateDate.Value.Date <= Convert.ToDateTime(cenddate).Date)
        //       .Where(j => j.CreateUserId.Contains(CreateUserId))
        //       .Where(k => k.AssessmentTypeCd.Contains(AssessmentTypeCd))
        //       .Where(l => l.AssessmentCategoryCd.Contains(AssessmentCategoryCd))
        //       .Where(m => m.AssessmentSubcategoryCd.Contains(AssessmentSubcategoryCd))
        //       .Where(n => n.OwnerUserLongId.Contains(OwnerUserLongId)).ToList();



        //        return Content(JsonConvert.SerializeObject(result), "application/json");

        //    }


        //    var result_2 = dbfcfcore.AmlRiskAssessments
        //       .Where(b => b.RiskStatus.Contains(RiskStatus))
        //       .Where(c => c.RiskClass.Contains(RiskClass))
        //       .Where(d => d.ProposedRiskClass.Contains(ProposedRiskClass))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //      .Where(f => f.RiskAssessmentId.Contains(RiskAssessmentId))
        //       .Where(g => g.PartyNumber.Contains(PartyNumber))
        //       .Where(h => h.PartyName.Contains(PartyName))
        //       .Where(i => i.CreateDate.Value >= Convert.ToDateTime(cstartdate) && i.CreateDate.Value <= Convert.ToDateTime(cenddate))
        //       .Where(j => j.CreateUserId.Contains(CreateUserId))
        //       .Where(k => k.AssessmentTypeCd.Contains(AssessmentTypeCd))
        //       .Where(l => l.AssessmentCategoryCd.Contains(AssessmentCategoryCd))
        //       .Where(m => m.AssessmentSubcategoryCd.Contains(AssessmentSubcategoryCd))
        //       .Where(n => n.OwnerUserLongId.Contains(OwnerUserLongId))
        //       .ToPagedList(page, 600);
        //    return Content(JsonConvert.SerializeObject(result_2), "application/json");

        //}


        //public ContentResult getTotalCount()
        //{
        //    var result = dbfcfcore.AmlRiskAssessments.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        //public ContentResult GetBranchNameDropDown()
        //{
        //    var distinct_value = dbfcfcore.FscBranchDims
        //       .Where(a => a.ChangeCurrentInd.Contains("Y"))
        //       .Where(b => b.BranchTypeDesc.Contains("BRANCH"))
        //       .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetAssessmentTypeDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskRiskAssessments.GroupBy(s => s.AssessmentTypeCd).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetCreateUserIDDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetRiskClassDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskLovs
        //        .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
        //        .Where(b => b.LovLanguageDesc.Contains("en"))
        //        .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetRiskStatusDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskLovs
        //         .Where(a => a.LovTypeName.StartsWith("RT_ASMT_STATUS"))
        //         .Where(b => b.LovLanguageDesc.Contains("en"))
        //         .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetProposedRiskClassDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskLovs
        //        .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
        //        .Where(b => b.LovLanguageDesc.Contains("en"))
        //        .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");
        //}
        //public ContentResult GetAssessmentCategoryCdDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskRiskAssessments.GroupBy(s => s.AssessmentCategoryCd).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetAssessmentSubCategoryCdDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskRiskAssessments.GroupBy(s => s.AssessmentSubcategoryCd).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetOwnerUserLongIdDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public IActionResult Export(string? RiskStatus,
        //    string? RiskClass, string? ProposedRiskClass, string? BranchName,
        //    string? RiskAssessmentId, string? PartyNumber, string? PartyName, string? RiskAssessmentDuration, string? CreateUserId,
        //    string? AssessmentTypeCd, string? AssessmentCategoryCd, string? AssessmentSubcategoryCd, string? OwnerUserLongId, string? cstartdate, string? cenddate, string[] ColumnsNames, string? ExportedColumns)
        //{
        //    var cr = GetData( RiskStatus,
        //     RiskClass,  ProposedRiskClass, BranchName,
        //     RiskAssessmentId,  PartyNumber,  PartyName,  RiskAssessmentDuration, CreateUserId,
        //     AssessmentTypeCd,  AssessmentCategoryCd,  AssessmentSubcategoryCd,  OwnerUserLongId, cstartdate,  cenddate, ExportedColumns
        //     , 0).Content;
        //    DataTable dt = JsonConvert.DeserializeObject<DataTable>(cr);


        //    var csvString = FileUtils.ExportFileClientSide(_env.WebRootPath, dt, "CustomerDetails", Request,ColumnsNames);
        //    return File(csvString,"text/csv");
        //    //var fileName = FileUtils.ExportFile(dt, "CustomersDetails");
        //    //return Ok(new { fileName = fileName });


        //}
        //public ContentResult test(string? RiskStatus,
        //    string? RiskClass, string? ProposedRiskClass, string? BranchName,
        //    string? RiskAssessmentId, string? PartyNumber, string? PartyName, string? RiskAssessmentDuration, string? CreateUserId,
        //    string? AssessmentTypeCd, string? AssessmentCategoryCd, string? AssessmentSubcategoryCd, string? OwnerUserLongId, string? cstartdate, string? cenddate)
        //{

        //    if (string.IsNullOrEmpty(RiskStatus))
        //    {
        //        RiskStatus = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskClass))
        //    {
        //        RiskClass = "";
        //    }
        //    if (string.IsNullOrEmpty(ProposedRiskClass))
        //    {
        //        ProposedRiskClass = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchName))
        //    {
        //        BranchName = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskAssessmentId))
        //    {
        //        RiskAssessmentId = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyNumber))
        //    {
        //        PartyNumber = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyName))
        //    {
        //        PartyName = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskAssessmentDuration))
        //    {
        //        RiskAssessmentDuration = "";
        //    }
        //    if (string.IsNullOrEmpty(cstartdate))
        //    {
        //        cstartdate = "2022-08-01";
        //    }
        //    if (string.IsNullOrEmpty(cenddate))
        //    {
        //        cenddate = DateTime.Now.ToShortDateString();
        //    }
        //    if (string.IsNullOrEmpty(CreateUserId))
        //    {
        //        CreateUserId = "";
        //    }

        //    if (string.IsNullOrEmpty(AssessmentTypeCd))
        //    {
        //        AssessmentTypeCd = "";
        //    }
        //    if (string.IsNullOrEmpty(AssessmentCategoryCd))
        //    {
        //        AssessmentCategoryCd = "";
        //    }
        //    if (string.IsNullOrEmpty(AssessmentSubcategoryCd))
        //    {
        //        AssessmentSubcategoryCd = "";
        //    }
        //    if (string.IsNullOrEmpty(OwnerUserLongId))
        //    {
        //        OwnerUserLongId = "";
        //    }
        //    try
        //    {
        //        var result = dbfcfcore.AmlRiskAssessments.Select(s => s)

        //       .Where(b => b.RiskStatus.Contains(RiskStatus))
        //       .Where(c => c.RiskClass.Contains(RiskClass))
        //       .Where(d => d.ProposedRiskClass.Contains(ProposedRiskClass))
        //       .Where(e => e.BranchName.Contains(BranchName))
        //      .Where(f => f.RiskAssessmentId.Contains(RiskAssessmentId))
        //       .Where(g => g.PartyNumber.Contains(PartyNumber))
        //       .Where(h => h.PartyName.Contains(PartyName))
        //       .Where(i => i.CreateDate.Value.Date >= Convert.ToDateTime(cstartdate).Date && i.CreateDate.Value.Date <= Convert.ToDateTime(cenddate).Date)
        //       .Where(j => j.CreateUserId.Contains(CreateUserId))
        //       .Where(k => k.AssessmentTypeCd.Contains(AssessmentTypeCd))
        //       .Where(l => l.AssessmentCategoryCd.Contains(AssessmentCategoryCd))
        //       .Where(m => m.AssessmentSubcategoryCd.Contains(AssessmentSubcategoryCd))
        //       .Where(n => n.OwnerUserLongId.Contains(OwnerUserLongId)).ToList();
        //        return Content(JsonConvert.SerializeObject(result), "application/json");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }

        //}


        public IActionResult Index()
        {
            return View();
        }
    }
}
