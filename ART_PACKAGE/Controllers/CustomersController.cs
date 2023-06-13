using DataGear_RV_Ver_1._7.dbfcfcore;
using DataGear_RV_Ver_1._7.dbfcfkc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using System.Text;

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

    public class CustomersController : Controller
    {
        //dbfcfcore.ModelContext db = new dbfcfcore.ModelContext();
        //dbfcfkc.ModelContext dbfcfkc = new dbfcfkc.ModelContext();

        private readonly dbfcfcore.ModelContext dbfcfcore;
        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        public CustomersController(dbfcfcore.ModelContext dbfcfcore, IMemoryCache cache, IDropDownService dropDown)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
            this._dropDown = dropDown;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AmlCustomersDetail> data = dbfcfcore.AmlCustomersDetails.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].DisplayNames;
                var Indlist = new List<dynamic>()
                    {
                        "Y","N"
                    };
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"CustomerType".ToLower(),_dropDown.GetPartyTypeDropDown().ToDynamicList() },
                    {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown().ToDynamicList() },
                    {"NonProfitOrgInd".ToLower(),Indlist.ToDynamicList() },
                    {"PoliticallyExposedPersonInd".ToLower(),Indlist.ToDynamicList() },
                    {"CharityDonationsInd".ToLower(),Indlist.ToDynamicList() },
                    {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"IndustryDesc".ToLower(),_dropDown.GetIndustryDescDropDown().ToDynamicList() },
                    {"CustomerIdentificationType".ToLower(),_dropDown.GetCustomerIdentificationTypeDropDown().ToDynamicList() },
                    {"OccupationDesc".ToLower(),_dropDown.GetOccupationDescDropDown().ToDynamicList() },
                    {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown().ToDynamicList() }
                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(CustomersController).ToLower()].SkipList;
            }


            var Data = data.CallData<AmlCustomersDetail>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            var data = dbfcfcore.AmlCustomersDetails.AsQueryable();
            var bytes = await data.ExportToCSV<AmlCustomersDetail, GenericCsvClassMapper<AmlCustomersDetail, CustomersController>>(para.Req);
            return File(bytes, "text/csv");
        }
        /* public IActionResult Export([FromBody] ExportDto<decimal> req)
         {
             var data = dbfcfcore.AmlCustomersDetails.AsQueryable();
             var bytes = data.ExportToCSV<AmlCustomersDetail>(req.Req);
             return File(bytes, "test/csv");
         }*/

        //public FileResult Export()
        //{
        //    List<object> export_data = FilteredResult;


        //    //List<object> party_data = (from tags in db.AmlCustomersDetails
        //    //                           select new[]
        //    //                           {
        //    //                               tags.CustomerName,
        //    //                               tags.CustomerNumber,
        //    //                               tags.CustomerType,
        //    //                               tags.CustomerIdentificationId,
        //    //                           }.Where(t=>tags.CustomerName.Contains(Glob_CustomerName))).ToList<object>();

        //    var result = (from tags in db.AmlCustomersDetails.Where(t => t.CustomerName.Contains(Glob_CustomerName))
        //                  select new[]
        //                  {
        //                                   tags.CustomerName,
        //                                   tags.CustomerNumber,
        //                                   tags.CustomerType,
        //                                   tags.CustomerIdentificationId

        //                     }).ToList<object>();
        //    //Insert the Column Names.
        //    result.Insert(0, new string[4] { "Customer Name", "Customer ID", "City", "Country" });

        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < result.Count; i++)
        //    {
        //        string[] customer = (string[])result[i];
        //        for (int j = 0; j < customer.Length; j++)
        //        {
        //            //Append data with separator.
        //            sb.Append(customer[j] + ',');
        //        }

        //        //Append new line character.
        //        sb.Append("\r\n");

        //    }

        //    return File(Encoding.Latin1.GetBytes(sb.ToString()), "text/csv", "Grid.csv");

        //}



        //string Glob_CustomerName = "";
        //string Glob_CustomerNumber = "";
        //string Glob_CUSTOMER_TYPE = "";
        //string Glob_NON_PROFIT_ORG_IND = "";
        //string Glob_POLITICALLY_EXPOSED_PERSON_IND = "";
        //string Glob_CHARITY_DONATIONS_IND = "";
        //string Glob_RISK_CLASSIFICATION = "";
        //string Glob_CITIZENSHIP_COUNTRY_NAME = "";
        //string Glob_RESIDENCE_COUNTRY_NAME = "";
        //string Glob_IndustryDesc = "";
        //string Glob_OccupationDesc = "";
        //string Glob_BRANCH_NAME = "";
        //string Glob_BranchNumber = "";
        //string Glob_CUSTOMER_IDENTIFICATION_ID = "";
        //string Glob_CUSTOMER_IDENTIFICATION_TYPE = "";
        //string Glob_CjoinDate = "";
        //string Glob_CendDate = "";

        //public void updateParmas(string? CustomerName, string? CustomerNumber, string? CUSTOMER_TYPE, string? NON_PROFIT_ORG_IND,
        //    string? POLITICALLY_EXPOSED_PERSON_IND, string? CHARITY_DONATIONS_IND, string? RISK_CLASSIFICATION, string? RESIDENCE_COUNTRY_NAME,
        //    string? CITIZENSHIP_COUNTRY_NAME, string? IndustryDesc, string? OccupationDesc,
        //    string? BRANCH_NAME,
        //    string? BranchNumber,
        //    string? CUSTOMER_IDENTIFICATION_ID, string? CUSTOMER_IDENTIFICATION_TYPE,
        //    string? CjoinDate, string? CendDate)
        //{
        //    Glob_CustomerName = CustomerName;
        //    Glob_CustomerNumber = CustomerNumber;
        //    Glob_CUSTOMER_TYPE = CUSTOMER_TYPE;
        //    Glob_NON_PROFIT_ORG_IND = NON_PROFIT_ORG_IND;
        //    Glob_POLITICALLY_EXPOSED_PERSON_IND = POLITICALLY_EXPOSED_PERSON_IND;
        //    Glob_CHARITY_DONATIONS_IND = CHARITY_DONATIONS_IND;
        //    Glob_RISK_CLASSIFICATION = RISK_CLASSIFICATION;
        //    Glob_CITIZENSHIP_COUNTRY_NAME = CITIZENSHIP_COUNTRY_NAME;
        //    Glob_RESIDENCE_COUNTRY_NAME = RESIDENCE_COUNTRY_NAME;
        //    Glob_IndustryDesc = IndustryDesc;
        //    Glob_OccupationDesc = OccupationDesc;
        //    Glob_BRANCH_NAME = BRANCH_NAME;
        //    Glob_BranchNumber = BranchNumber;
        //    Glob_CUSTOMER_IDENTIFICATION_ID = CUSTOMER_IDENTIFICATION_ID;
        //    Glob_CUSTOMER_IDENTIFICATION_TYPE = CUSTOMER_IDENTIFICATION_TYPE;
        //    Glob_CjoinDate = CjoinDate;
        //    Glob_CendDate = CendDate;

        //}


        //List<object> FilteredResult;
        //public void updateResult(List<object> result)
        //{
        //    FilteredResult = result;
        //}
        //public ContentResult GetData(
        //    string? CustomerName, string? CustomerNumber, string? CUSTOMER_TYPE, string? NON_PROFIT_ORG_IND,
        //    string? POLITICALLY_EXPOSED_PERSON_IND, string? CHARITY_DONATIONS_IND, string? RISK_CLASSIFICATION, string? RESIDENCE_COUNTRY_NAME,
        //    string? CITIZENSHIP_COUNTRY_NAME, string? IndustryDesc, string? OccupationDesc,
        //    string? BRANCH_NAME,
        //    string? BranchNumber,
        //    string? CUSTOMER_IDENTIFICATION_ID, string? CUSTOMER_IDENTIFICATION_TYPE,
        //    string? CjoinDate, string? CendDate,
        //    int page = 1)
        //{



        //    if (string.IsNullOrEmpty(CustomerName))
        //    {
        //        CustomerName = "";
        //    }
        //    if (string.IsNullOrEmpty(CustomerNumber))
        //    {
        //        CustomerNumber = "";
        //    }
        //    if (string.IsNullOrEmpty(CUSTOMER_TYPE))
        //    {
        //        CUSTOMER_TYPE = "";
        //    }
        //    if (string.IsNullOrEmpty(NON_PROFIT_ORG_IND))
        //    {
        //        NON_PROFIT_ORG_IND = "";
        //    }
        //    if (string.IsNullOrEmpty(POLITICALLY_EXPOSED_PERSON_IND))
        //    {
        //        POLITICALLY_EXPOSED_PERSON_IND = "";
        //    }
        //    if (string.IsNullOrEmpty(CHARITY_DONATIONS_IND))
        //    {
        //        CHARITY_DONATIONS_IND = "";
        //    }
        //    if (string.IsNullOrEmpty(RISK_CLASSIFICATION))
        //    {
        //        RISK_CLASSIFICATION = "";
        //    }
        //    if (string.IsNullOrEmpty(RESIDENCE_COUNTRY_NAME))
        //    {
        //        RESIDENCE_COUNTRY_NAME = "";
        //    }
        //    if (string.IsNullOrEmpty(CITIZENSHIP_COUNTRY_NAME))
        //    {
        //        CITIZENSHIP_COUNTRY_NAME = "";
        //    }

        //    if (string.IsNullOrEmpty(IndustryDesc))
        //    {
        //        IndustryDesc = "";
        //    }
        //    if (string.IsNullOrEmpty(OccupationDesc))
        //    {
        //        OccupationDesc = "";
        //    }
        //    if (string.IsNullOrEmpty(BRANCH_NAME))
        //    {
        //        BRANCH_NAME = "";
        //    }
        //    if (string.IsNullOrEmpty(BranchNumber))
        //    {
        //        BranchNumber = "";
        //    }
        //    if (string.IsNullOrEmpty(CUSTOMER_IDENTIFICATION_ID))
        //    {
        //        CUSTOMER_IDENTIFICATION_ID = "";
        //    }
        //    if (string.IsNullOrEmpty(CUSTOMER_IDENTIFICATION_TYPE))
        //    {
        //        CUSTOMER_IDENTIFICATION_TYPE = "";
        //    }

        //    if (string.IsNullOrEmpty(CjoinDate) && string.IsNullOrEmpty(CendDate))
        //    {
        //        var result_emptySinceDate = db.AmlCustomersDetails
        //       .Where(a => a.CustomerName.Contains(CustomerName))
        //       .Where(b => b.CustomerNumber.Contains(CustomerNumber))
        //       .Where(c => c.CustomerType.Contains(CUSTOMER_TYPE))
        //       .Where(d => d.NonProfitOrgInd.Contains(NON_PROFIT_ORG_IND))
        //       .Where(e => e.PoliticallyExposedPersonInd.Contains(POLITICALLY_EXPOSED_PERSON_IND))
        //       .Where(f => f.CharityDonationsInd.Contains(CHARITY_DONATIONS_IND))
        //       .Where(g => g.RiskClassification.Contains(RISK_CLASSIFICATION))
        //       .Where(h => h.ResidenceCountryName.Contains(RESIDENCE_COUNTRY_NAME))
        //       .Where(i => i.CitizenshipCountryName.Contains(CITIZENSHIP_COUNTRY_NAME))
        //       .Where(j => j.IndustryDesc.Contains(IndustryDesc))
        //       .Where(k => k.BranchName.Contains(BRANCH_NAME))
        //       .Where(k1 => k1.BranchNumber.Contains(BranchNumber))
        //       .Where(l => l.CustomerIdentificationId.Contains(CUSTOMER_IDENTIFICATION_ID))
        //       .Where(m => m.CustomerIdentificationType.Contains(CUSTOMER_IDENTIFICATION_TYPE))
        //       .Where(n => n.OccupationDesc.Contains(OccupationDesc))
        //       .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_emptySinceDate), "application/json");
        //    }
        //    else if (string.IsNullOrEmpty(CjoinDate))
        //    {
        //        var result_emptySinceDate = db.AmlCustomersDetails
        //       .Where(a => a.CustomerName.Contains(CustomerName))
        //       .Where(b => b.CustomerNumber.Contains(CustomerNumber))
        //       .Where(c => c.CustomerType.Contains(CUSTOMER_TYPE))
        //       .Where(d => d.NonProfitOrgInd.Contains(NON_PROFIT_ORG_IND))
        //       .Where(e => e.PoliticallyExposedPersonInd.Contains(POLITICALLY_EXPOSED_PERSON_IND))
        //       .Where(f => f.CharityDonationsInd.Contains(CHARITY_DONATIONS_IND))
        //       .Where(g => g.RiskClassification.Contains(RISK_CLASSIFICATION))
        //       .Where(h => h.ResidenceCountryName.Contains(RESIDENCE_COUNTRY_NAME))
        //       .Where(i => i.CitizenshipCountryName.Contains(CITIZENSHIP_COUNTRY_NAME))
        //       .Where(j => j.IndustryDesc.Contains(IndustryDesc))
        //       .Where(k => k.BranchName.Contains(BRANCH_NAME))
        //       .Where(k1 => k1.BranchNumber.Contains(BranchNumber))
        //       .Where(l => l.CustomerIdentificationId.Contains(CUSTOMER_IDENTIFICATION_ID))
        //       .Where(m => m.CustomerIdentificationType.Contains(CUSTOMER_IDENTIFICATION_TYPE))
        //       .Where(n => n.CustomerSinceDate.Value <= Convert.ToDateTime(CendDate))
        //       .Where(o => o.OccupationDesc.Contains(OccupationDesc))
        //       .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_emptySinceDate), "application/json");
        //    }
        //    else if (string.IsNullOrEmpty(CendDate))
        //    {
        //        var result_emptySinceDate = db.AmlCustomersDetails
        //       .Where(a => a.CustomerName.Contains(CustomerName))
        //       .Where(b => b.CustomerNumber.Contains(CustomerNumber))
        //       .Where(c => c.CustomerType.Contains(CUSTOMER_TYPE))
        //       .Where(d => d.NonProfitOrgInd.Contains(NON_PROFIT_ORG_IND))
        //       .Where(e => e.PoliticallyExposedPersonInd.Contains(POLITICALLY_EXPOSED_PERSON_IND))
        //       .Where(f => f.CharityDonationsInd.Contains(CHARITY_DONATIONS_IND))
        //       .Where(g => g.RiskClassification.Contains(RISK_CLASSIFICATION))
        //       .Where(h => h.ResidenceCountryName.Contains(RESIDENCE_COUNTRY_NAME))
        //       .Where(i => i.CitizenshipCountryName.Contains(CITIZENSHIP_COUNTRY_NAME))
        //       .Where(j => j.IndustryDesc.Contains(IndustryDesc))
        //       .Where(k => k.BranchName.Contains(BRANCH_NAME))
        //       .Where(k1 => k1.BranchNumber.Contains(BranchNumber))
        //       .Where(l => l.CustomerIdentificationId.Contains(CUSTOMER_IDENTIFICATION_ID))
        //       .Where(m => m.CustomerIdentificationType.Contains(CUSTOMER_IDENTIFICATION_TYPE))
        //       .Where(n => n.CustomerSinceDate.Value >= Convert.ToDateTime(CjoinDate))
        //       .Where(o => o.OccupationDesc.Contains(OccupationDesc))
        //       .ToPagedList(page, 600);
        //        return Content(JsonConvert.SerializeObject(result_emptySinceDate), "application/json");
        //    }

        //    updateParmas(CustomerName, CustomerNumber, CUSTOMER_TYPE, NON_PROFIT_ORG_IND, POLITICALLY_EXPOSED_PERSON_IND, CHARITY_DONATIONS_IND, RISK_CLASSIFICATION, RESIDENCE_COUNTRY_NAME,
        //  CITIZENSHIP_COUNTRY_NAME, IndustryDesc, OccupationDesc, BRANCH_NAME, BranchNumber, CUSTOMER_IDENTIFICATION_ID, CUSTOMER_IDENTIFICATION_TYPE, CjoinDate, CendDate);
        //    var ExportResult = db.AmlCustomersDetails
        //       .Where(a => a.CustomerName.Contains(CustomerName))
        //       .Where(b => b.CustomerNumber.Contains(CustomerNumber))
        //       .Where(c => c.CustomerType.Contains(CUSTOMER_TYPE))
        //       .Where(d => d.NonProfitOrgInd.Contains(NON_PROFIT_ORG_IND))
        //       .Where(e => e.PoliticallyExposedPersonInd.Contains(POLITICALLY_EXPOSED_PERSON_IND))
        //       .Where(f => f.CharityDonationsInd.Contains(CHARITY_DONATIONS_IND))
        //       .Where(g => g.RiskClassification.Contains(RISK_CLASSIFICATION))
        //       .Where(h => h.ResidenceCountryName.Contains(RESIDENCE_COUNTRY_NAME))
        //       .Where(i => i.CitizenshipCountryName.Contains(CITIZENSHIP_COUNTRY_NAME))
        //       .Where(j => j.IndustryDesc.Contains(IndustryDesc))
        //       .Where(k => k.BranchName.Contains(BRANCH_NAME))
        //       .Where(k1 => k1.BranchNumber.Contains(BranchNumber))
        //       .Where(l => l.CustomerIdentificationId.Contains(CUSTOMER_IDENTIFICATION_ID))
        //       .Where(m => m.CustomerIdentificationType.Contains(CUSTOMER_IDENTIFICATION_TYPE))
        //       .Where(n => n.CustomerSinceDate.Value >= Convert.ToDateTime(CjoinDate) && n.CustomerSinceDate.Value <= Convert.ToDateTime(CendDate))
        //       .Where(o => o.OccupationDesc.Contains(OccupationDesc));
        //    //updateResult(ExportResult.ToList<object>());


        //    var result_2 = db.AmlCustomersDetails
        //       .Where(a => a.CustomerName.Contains(CustomerName))
        //       .Where(b => b.CustomerNumber.Contains(CustomerNumber))
        //       .Where(c => c.CustomerType.Contains(CUSTOMER_TYPE))
        //       .Where(d => d.NonProfitOrgInd.Contains(NON_PROFIT_ORG_IND))
        //       .Where(e => e.PoliticallyExposedPersonInd.Contains(POLITICALLY_EXPOSED_PERSON_IND))
        //       .Where(f => f.CharityDonationsInd.Contains(CHARITY_DONATIONS_IND))
        //       .Where(g => g.RiskClassification.Contains(RISK_CLASSIFICATION))
        //       .Where(h => h.ResidenceCountryName.Contains(RESIDENCE_COUNTRY_NAME))
        //       .Where(i => i.CitizenshipCountryName.Contains(CITIZENSHIP_COUNTRY_NAME))
        //       .Where(j => j.IndustryDesc.Contains(IndustryDesc))
        //       .Where(k => k.BranchName.Contains(BRANCH_NAME))
        //       .Where(k1 => k1.BranchNumber.Contains(BranchNumber))
        //       .Where(l => l.CustomerIdentificationId.Contains(CUSTOMER_IDENTIFICATION_ID))
        //       .Where(m => m.CustomerIdentificationType.Contains(CUSTOMER_IDENTIFICATION_TYPE))
        //       .Where(n => n.CustomerSinceDate.Value >= Convert.ToDateTime(CjoinDate) && n.CustomerSinceDate.Value <= Convert.ToDateTime(CendDate))
        //       .Where(o => o.OccupationDesc.Contains(OccupationDesc))
        //       .ToPagedList(page, 600);
        //    return Content(JsonConvert.SerializeObject(result_2), "application/json");
        //}

        //public ContentResult getTotalCount()
        //{
        //    var result = db.AmlCustomersDetails.Count();

        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult Aml_Cust_Per_Risk()
        //{
        //    var result = db.AmlCustSummPerRisks.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult Aml_Cust_Per_Type()
        //{
        //    var result = db.AmlCustSummPerTypes.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult Aml_Cust_Per_City()
        //{
        //    var result = db.AmlCustSummPerCities.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult Aml_Cust_Per_Branch()
        //{
        //    var result = db.AmlCustSummPerBranches.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        //Get DropDown Filters Data
        //public ContentResult GetBranchDropDown()
        //{
        //    var distinct_value = db.FscBranchDims
        //       .Where(a => a.ChangeCurrentInd.Contains("Y"))
        //       .Where(b => b.BranchTypeDesc.Contains("BRANCH"))
        //       .ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");
        //}
        //public ContentResult GetCustomerTypeDropDown()
        //{
        //    var distinct_value = db.PartyTypeMatviews.ToList();
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

        //public ContentResult GetResidenceCountryNameDropDown()
        //{
        //    var distinct_value = db.ResidenceCountryMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public ContentResult GetCitizenshipCountryNameDropDown()
        //{
        //    var distinct_value = db.CitizenshipCountryMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public ContentResult GetCustomerIdentificationTypeDropDown()
        //{
        //    var distinct_value = db.PartyIdentificationTypeDescs.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public ContentResult GetIndustryDescDropDown()
        //{
        //    var distinct_value = db.IndustryDescMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");

        //}

        //public ContentResult GetOccupationDescDropDown()
        //{
        //    var distinct_value = db.OccupationDescMatviews.ToList();
        //    return Content(JsonConvert.SerializeObject(distinct_value), "application/json");
        //}
        /////////////////////////////////////////////////////////

        public IActionResult Index()
        {
            return View();
        }
    }
}
