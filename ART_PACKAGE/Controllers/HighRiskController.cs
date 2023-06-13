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
using DataGear_RV_Ver_1._7.Helpers.CSVMAppers;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class HighRiskController : Controller
    {
        private readonly dbfcfcore.ModelContext dbfcfcore;
        private readonly IMemoryCache _cache; private readonly IDropDownService _dropDown;
        public HighRiskController(dbfcfcore.ModelContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache; this._dropDown = dropDown;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AmlHighRiskCust> data = dbfcfcore.AmlHighRiskCusts.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(HighRiskController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //{"BranchName".ToLower(),dgcmgmt.ArtCaseTypesViews.Select(x => x.CaseType).ToDynamicList() },
                    //{"PartyIdentificationTypeDesc".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"PartyTypeDesc".ToLower(),dgcmgmt.ArtCreateUserFilters.Select(m => m.CreateUserId).ToDynamicList() },
                    //{"RiskClassification".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"PoliticallyExposedPersonInd".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"ResidenceCountryName".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"CitizenshipCountryName".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },
                    //{"MailingCityName".ToLower(),dgcmgmt.ArtCasesStatusFilters.Select(m => m.CaseStatus).ToDynamicList() },

                };
            }


            var ColumnsToSkip = new List<string>
            {

            };
            var Data = data.CallData<AmlHighRiskCust>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfcore.AmlHighRiskCusts.AsQueryable();
            var bytes = await data.ExportToCSV<AmlHighRiskCust, GenericCsvClassMapper<AmlHighRiskCust, HighRiskController>>(para.Req);
            return File(bytes, "text/csv");
        }

        //public ContentResult GetData(string? PartyNumber,
        //    string? PartyTypeDesc, string? PartyTaxId, string? PartyIdentificationId, string? PartyIdentificationTypeDesc,
        //    string? PartyName, string? StreetAddress1, string? StreetCityName, string? MailingAddress1, string? MailingCityName,
        //    string? ResidenceCountryName, string? CitizenshipCountryName, string? PhoneNumber1, string? PoliticallyExposedPersonInd, string? RiskClassification,
        //    string? BranchName, string? BranchNumber,
        //    string? birtstartdate, string? birthenddate,
        //    int page = 1)
        //{
        //    if (string.IsNullOrEmpty(PartyNumber))
        //    {
        //        PartyNumber = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyTypeDesc))
        //    {
        //        PartyTypeDesc = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyTaxId))
        //    {
        //        PartyTaxId = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyIdentificationId))
        //    {
        //        PartyIdentificationId = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyIdentificationTypeDesc))
        //    {
        //        PartyIdentificationTypeDesc = "";
        //    }
        //    if (string.IsNullOrEmpty(PartyName))
        //    {
        //        PartyName = "";
        //    }
        //    if (string.IsNullOrEmpty(StreetAddress1))
        //    {
        //        StreetAddress1 = "";
        //    }
        //    if (string.IsNullOrEmpty(StreetCityName))
        //    {
        //        StreetCityName = "";
        //    }
        //    if (string.IsNullOrEmpty(MailingAddress1))
        //    {
        //        MailingAddress1 = "";
        //    }
        //    if (string.IsNullOrEmpty(MailingCityName))
        //    {
        //        MailingCityName = "";
        //    }
        //    if (string.IsNullOrEmpty(ResidenceCountryName))
        //    {
        //        ResidenceCountryName = "";
        //    }
        //    if (string.IsNullOrEmpty(CitizenshipCountryName))
        //    {
        //        CitizenshipCountryName = "";
        //    }
        //    if (string.IsNullOrEmpty(PhoneNumber1))
        //    {
        //        PhoneNumber1 = "";
        //    }
        //    if (string.IsNullOrEmpty(PoliticallyExposedPersonInd))
        //    {
        //        PoliticallyExposedPersonInd = "";
        //    }
        //    if (string.IsNullOrEmpty(RiskClassification))
        //    {
        //        RiskClassification = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchName))
        //    {
        //        BranchName = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchNumber))
        //    {
        //        BranchNumber = "";
        //    }
        //    if (string.IsNullOrEmpty(birtstartdate) && string.IsNullOrEmpty(birthenddate))
        //    {
        //        var result_emptyBirthDate = dbfcfcore.AmlHighRiskCusts
        //           .Where(a => a.PartyNumber.Contains(PartyNumber))
        //           .Where(b => b.PartyTaxId.Contains(PartyTaxId))
        //           .Where(c => c.PartyIdentificationId.Contains(PartyIdentificationId))
        //           .Where(d => d.PartyIdentificationTypeDesc.Contains(PartyIdentificationTypeDesc))
        //           .Where(f => f.PartyName.Contains(PartyName))
        //           .Where(g => g.StreetCityName.Contains(StreetCityName))
        //           .Where(h => h.MailingAddress1.Contains(MailingAddress1))
        //           .Where(i => i.MailingCityName.Contains(MailingCityName))
        //           .Where(j => j.ResidenceCountryName.Contains(ResidenceCountryName))
        //           .Where(k => k.CitizenshipCountryName.Contains(CitizenshipCountryName))
        //           .Where(l => l.PhoneNumber1.Contains(PhoneNumber1))
        //           .Where(m => m.PoliticallyExposedPersonInd.Contains(PoliticallyExposedPersonInd))
        //           .Where(n => n.RiskClassification.Contains(RiskClassification))
        //           .Where(o => o.BranchName.Contains(BranchName))
        //           .Where(p => p.BranchNumber.Contains(BranchNumber))
        //           .Where(q => q.PartyTypeDesc.Contains(PartyTypeDesc))
        //           .Where(r => r.StreetAddress1.Contains(StreetAddress1))

        //           .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_emptyBirthDate), "application/json");
        //    }

        //    else if (string.IsNullOrEmpty(birtstartdate))
        //    {
        //        var result_emptyBirthDate = dbfcfcore.AmlHighRiskCusts
        //               .Where(a => a.PartyNumber.Contains(PartyNumber))
        //               .Where(b => b.PartyTaxId.Contains(PartyTaxId))
        //               .Where(c => c.PartyIdentificationId.Contains(PartyIdentificationId))
        //               .Where(d => d.PartyIdentificationTypeDesc.Contains(PartyIdentificationTypeDesc))
        //               .Where(e => e.PartyDateOfBirth.Value <= Convert.ToDateTime(birthenddate))
        //               .Where(f => f.PartyName.Contains(PartyName))
        //               .Where(g => g.StreetCityName.Contains(StreetCityName))
        //               .Where(h => h.MailingAddress1.Contains(MailingAddress1))
        //               .Where(i => i.MailingCityName.Contains(MailingCityName))
        //               .Where(j => j.ResidenceCountryName.Contains(ResidenceCountryName))
        //               .Where(k => k.CitizenshipCountryName.Contains(CitizenshipCountryName))
        //               .Where(l => l.PhoneNumber1.Contains(PhoneNumber1))
        //               .Where(m => m.PoliticallyExposedPersonInd.Contains(PoliticallyExposedPersonInd))
        //               .Where(n => n.RiskClassification.Contains(RiskClassification))
        //               .Where(o => o.BranchName.Contains(BranchName))
        //               .Where(p => p.BranchNumber.Contains(BranchNumber))
        //               .Where(q => q.PartyTypeDesc.Contains(PartyTypeDesc))
        //               .Where(r => r.StreetAddress1.Contains(StreetAddress1))
        //               .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_emptyBirthDate), "application/json");
        //    }
        //    else if (string.IsNullOrEmpty(birthenddate))
        //    {
        //        var result_emptyBirthDate = dbfcfcore.AmlHighRiskCusts
        //               .Where(a => a.PartyNumber.Contains(PartyNumber))
        //               .Where(b => b.PartyTaxId.Contains(PartyTaxId))
        //               .Where(c => c.PartyIdentificationId.Contains(PartyIdentificationId))
        //               .Where(d => d.PartyIdentificationTypeDesc.Contains(PartyIdentificationTypeDesc))
        //               .Where(e => e.PartyDateOfBirth.Value >= Convert.ToDateTime(birtstartdate))
        //               .Where(f => f.PartyName.Contains(PartyName))
        //               .Where(g => g.StreetCityName.Contains(StreetCityName))
        //               .Where(h => h.MailingAddress1.Contains(MailingAddress1))
        //               .Where(i => i.MailingCityName.Contains(MailingCityName))
        //               .Where(j => j.ResidenceCountryName.Contains(ResidenceCountryName))
        //               .Where(k => k.CitizenshipCountryName.Contains(CitizenshipCountryName))
        //               .Where(l => l.PhoneNumber1.Contains(PhoneNumber1))
        //               .Where(m => m.PoliticallyExposedPersonInd.Contains(PoliticallyExposedPersonInd))
        //               .Where(n => n.RiskClassification.Contains(RiskClassification))
        //               .Where(o => o.BranchName.Contains(BranchName))
        //               .Where(p => p.BranchNumber.Contains(BranchNumber))
        //               .Where(q => q.PartyTypeDesc.Contains(PartyTypeDesc))
        //               .Where(r => r.StreetAddress1.Contains(StreetAddress1))

        //               .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_emptyBirthDate), "application/json");
        //    }
        //    var result_2 = dbfcfcore.AmlHighRiskCusts
        //       .Where(a => a.PartyNumber.Contains(PartyNumber))
        //       .Where(b => b.PartyTaxId.Contains(PartyTaxId))
        //       .Where(c => c.PartyIdentificationId.Contains(PartyIdentificationId))
        //       .Where(d => d.PartyIdentificationTypeDesc.Contains(PartyIdentificationTypeDesc))
        //       .Where(e => e.PartyDateOfBirth.Value >= Convert.ToDateTime(birtstartdate) && e.PartyDateOfBirth.Value <= Convert.ToDateTime(birthenddate))
        //       .Where(f => f.PartyName.Contains(PartyName))
        //       .Where(g => g.StreetCityName.Contains(StreetCityName))
        //       .Where(h => h.MailingAddress1.Contains(MailingAddress1))
        //       .Where(i => i.MailingCityName.Contains(MailingCityName))
        //       .Where(j => j.ResidenceCountryName.Contains(ResidenceCountryName))
        //       .Where(k => k.CitizenshipCountryName.Contains(CitizenshipCountryName))
        //       .Where(l => l.PhoneNumber1.Contains(PhoneNumber1))
        //       .Where(m => m.PoliticallyExposedPersonInd.Contains(PoliticallyExposedPersonInd))
        //       .Where(n => n.RiskClassification.Contains(RiskClassification))
        //       .Where(o => o.BranchName.Contains(BranchName))
        //       .Where(p => p.BranchNumber.Contains(BranchNumber))
        //       .Where(q => q.PartyTypeDesc.Contains(PartyTypeDesc))
        //       .Where(r => r.StreetAddress1.Contains(StreetAddress1))

        //       .ToPagedList(page, 600);
        //    return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //}

        //public ContentResult getTotalCount()
        //{
        //    var result = dbfcfcore.AmlHighRiskCusts.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}


        ////Get DropDown Filters Data
        //public ContentResult GetBranchDropDown()
        //{
        //    var distinct_value = dbfcfcore.FscBranchDims
        //       .Where(a => a.ChangeCurrentInd.Contains("Y"))
        //       .Where(b => b.BranchTypeDesc.Contains("BRANCH"))
        //       .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public ContentResult GetPartyIdentificationTypeDropDown()
        //{
        //    var distinct_value = dbfcfcore.PartyIdentificationTypeDescs.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetRiskClassificationDropDown()
        //{
        //    var distinct_value = dbfcfkc.FskLovs
        //        .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
        //        .Where(b => b.LovLanguageDesc.Contains("en"))
        //        .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetPartyTypeDescDropDown()
        //{
        //    var distinct_value = dbfcfcore.PartyTypeMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetResidenceCountryNameDropDown()
        //{
        //    var distinct_value = dbfcfcore.ResidenceCountryMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}
        //public ContentResult GetMailingCityNameDropDown()
        //{
        //    var distinct_value = dbfcfcore.MailingCityMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public ContentResult GetCitizenshipCountryNameDropDown()
        //{
        //    var distinct_value = dbfcfcore.CitizenshipCountryMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
