using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.EXPORT_SCHEDULAR;
using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Controllers.FTI.DraftsReport;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.ARTDGAML;
using Data.Data.ExportSchedular;
using Data.Data.FTI;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper
{
    public class DropDownMapper : IDropDownMapper
    {
        private readonly IDropDownService _dropDown;
        private readonly FTIContext fti;
        private readonly ArtDgAmlContext artDgaml_;

        public DropDownMapper(IDropDownService dropDown, FTIContext fTI, ArtDgAmlContext artDgaml)
        {
            _dropDown = dropDown;
            fti = fTI;
            this.artDgaml_ = artDgaml;
        }

        public Dictionary<string, List<SelectItem>>? GetDorpDownForReport(string controller)
        {
            List<SelectItem> pipList = new() { new SelectItem { text = "Y", value = "Y" }, new SelectItem { text = "N", value = "N" } };


            return controller switch
            {
                nameof(GridController) => new Dictionary<string, List<SelectItem>>
                {
                    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown()},
                    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown() },
                    //{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown()},
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown() },
                    {"PoliticallyExposedPersonInd".ToLower(), new List<string>(){"Y","N"}.Select(x=> new SelectItem{ text = x,value = x }).ToList()  },
                    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown() }
                },


                nameof(SumCountryController) => new Dictionary<string, List<SelectItem>>
                {
                    { "C7CNM".ToLower() , new List<SelectItem> { new SelectItem  { text = "brrrrr" , value = "brrrrr" }, new SelectItem { text = "brrrrr", value = "brrrrr" }, } }
                },


                nameof(TasksController) => new Dictionary<string, List<SelectItem>> {
                { nameof(ExportTaskDto.Period).ToLower(), Enum.GetNames(typeof(TaskPeriod)).Select((x, i) => new SelectItem { text = x, value = i.ToString() }).ToList() },
                { nameof(ExportTaskDto.DayOfWeek).ToLower(), Enum.GetNames(typeof(DayOfWeek)).Select((x, i) => new SelectItem { text = x, value = i.ToString() }).ToList() },
                { nameof(ExportTaskDto.Month).ToLower(), Enum.GetNames(typeof(MonthsOfYear)).Select((x, i) => new SelectItem { text = x, value = i.ToString() }).ToList() },
                },





                nameof(AlertDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown() },
                    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown()    },
                    //{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown() },
                    {"PoliticallyExposedPersonInd".ToLower(), pipList},
                    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown() }
                },
                nameof(CasesDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                      {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                      {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() },
                      {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown() },
                      {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown() },
                      {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown() },
                      {"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown() },
                      {"Owner".ToLower(),_dropDown.GetOwnerDropDown() },
                     {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown() }
                },
                nameof(CustomersController) => new Dictionary<string, List<SelectItem>>
                {
                      {"CustomerType".ToLower(),_dropDown.GetPartyTypeDropDown() },
                      {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                      {"NonProfitOrgInd".ToLower(),pipList },
                      {"PoliticallyExposedPersonInd".ToLower(),pipList },
                      {"CharityDonationsInd".ToLower(),pipList },
                      {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown() },
                      {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                      {"IndustryDesc".ToLower(),_dropDown.GetIndustryDescDropDown() },
                      {"CustomerIdentificationType".ToLower(),_dropDown.GetCustomerIdentificationTypeDropDown() },
                      {"OccupationDesc".ToLower(),_dropDown.GetOccupationDescDropDown() },
                      {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown() }
                },
                nameof(HighRiskController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    {"PartyIdentificationTypeDesc".ToLower(),_dropDown.GetPartyIdentificationTypeDropDown() },
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown()},
                    {"RiskClassification".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    //{"PoliticallyExposedPersonInd".ToLower(),_dropDown.Getpo().ToDynamicList() },
                    {"ResidenceCountryName".ToLower(),_dropDown.GetResidenceCountryNameDropDown() },
                    {"CitizenshipCountryName".ToLower(),_dropDown.GetCitizenshipCountryNameDropDown() },
                    //{"MailingCityName".ToLower(),_dropDown.().ToDynamicList() },
                },
                nameof(RiskAssessmentController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    {"AssessmentTypeCd".ToLower(),_dropDown.GetAssessmentTypeDropDown() },
                    {"CreateUserId".ToLower(),_dropDown.GetOwnerDropDown() },
                    {"RiskStatus".ToLower(),_dropDown.GetRiskStatusDropDown() },
                    {"RiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    {"ProposedRiskClass".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    {"OwnerUserLongId".ToLower(),_dropDown.GetOwnerDropDown() }
                },
                nameof(TriageController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(), _dropDown.GetBranchNameDropDown() },
                    {"RiskScore".ToLower(),_dropDown.GetRiskClassificationDropDown() },
                    {"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown() }
                },
                nameof(ArtAuditCorporateController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtAuditIndividualsController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycExpiredIdController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycHighExpiredController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycHighThreeMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycHighTwoMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowExpiredController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowOneMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowThreeMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycLowTwoMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumExpiredController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumOneMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumThreeMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycMediumTwoMonthController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(ArtKycSummaryByRiskController) => new Dictionary<string, List<SelectItem>>
                {
                    //{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown() },
                    //{"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown() }
                },
                nameof(GOAMLReportIndicatorDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                      {"Indicator".ToLower(),_dropDown.GetReportIndicatorDropDown() },

                },
                nameof(GOAMLReportsDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown()},
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown() },
                    {"Priority".ToLower(),_dropDown.GetReportPriorityDropDown() },
                    {"Rentitybranch".ToLower(),_dropDown.GetNonREntityBranchDropDown() },
                },
                nameof(GOAMLReportsSuspectController) => new Dictionary<string, List<SelectItem>>
                {
                    {"Reportcode".ToLower(),_dropDown.GetReportTypeDropDown() },
                    {"Reportstatuscode".ToLower(),_dropDown.GetReportstatuscodeDropDown() },
                    {"Branch".ToLower(),_dropDown.GetReportAcctBranchDropDown() },
                },
                nameof(ACPostingsAccountController) => new Dictionary<string, List<SelectItem>>
                {
                    { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(ACPostingsCustomersController) => new Dictionary<string, List<SelectItem>>
                {
                    {"MasterRef".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AcctNo".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AccountType".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.AccountType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Shortname".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"DrCrFlg".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.DrCrFlg).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Ccy".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CusMnm".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Spsk".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Spsk).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Mainbanking".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.Mainbanking).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "BranchName".ToLower(), fti.ArtTiAcpostingsCustReports.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(ActivityController) => new Dictionary<string, List<SelectItem>>
                {
                   {"BranchName".ToLower(), fti.ArtTiActivityReports.Select(x=>x.BranchName).Distinct()    .Where(x=> x != null)   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Team".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Team).Distinct()                .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"MasterRef".ToLower(), fti.ArtTiActivityReports.Select(x=>x.MasterRef).Distinct()      .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Sovalue".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Sovalue).Distinct()          .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"EventRef".ToLower(), fti.ArtTiActivityReports.Select(x=>x.EventRef).Distinct()        .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"EventStatus".ToLower(), fti.ArtTiActivityReports.Select(x=>x.EventStatus).Distinct()  .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Ccy".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Ccy).Distinct()                  .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Address1".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Address1).Distinct()        .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Address12".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Address12).Distinct()      .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Lstmoduser".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Lstmoduser).Distinct()    .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                  {"Shortname".ToLower(), fti.ArtTiActivityReports.Select(x=>x.Shortname).Distinct()    .Where(x=> x != null)      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(AdvancePaymentUtilizationController) => new Dictionary<string, List<SelectItem>>
                {
                   {"PrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.PrincipalParty).Distinct()    .Where(x=> x != null)                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"NonPrincipalParty".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.NonPrincipalParty).Distinct()                .Where(x=> x != null)    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"AdvCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvCurrency).Distinct()      .Where(x=> x != null)                          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"UtilizationCurrency".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.UtilizationCurrency).Distinct()          .Where(x=> x != null)      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Branch".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.Branch).Distinct()        .Where(x=> x != null)                                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"AdvReference".ToLower(), fti.ArtTiAdvancePaymentUtilizationReports.Select(x=>x.AdvReference).Distinct()  .Where(x=> x != null)                            .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(AmortizationController) => new Dictionary<string, List<SelectItem>>
                {
                   { "MasterRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "AcctNo".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.AcctNo).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "AccountType".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.AccountType).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Shortname".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.Shortname).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "CusMnm".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x=>x.CusMnm).Distinct().Where(x=> x != null )             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Ccy".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Ccy).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "DrCrFlg".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.DrCrFlg).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Mainbanking".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Mainbanking).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "BranchName".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.BranchName).Distinct().Where(x=> x != null )   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "EventRef".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.EventRef).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   { "Spsk".ToLower(), fti.ArtTiAcpostingsAccReports.Select(x => x.Spsk).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(DiaryExceptionsController) => new Dictionary<string, List<SelectItem>>
                {
                   {"MasterRef".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Product".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Status".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Status).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"BranchName".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.BranchName).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Address1".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Address1).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"BranchCode".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.BranchCode).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Team".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Team).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Outstccy".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Outstccy).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Sovaluedesc".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Sovaluedesc).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Ccy".ToLower(), fti.ArtTiDiaryExceptionsReports.Select(x=>x.Ccy).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(EcmAuditTrialController) => new Dictionary<string, List<SelectItem>>
                {
                   {"EcmReference".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.EcmReference != null).Select(x=>x.EcmReference).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"FtiReference".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.FtiReference != null).Select(x=>x.FtiReference).Distinct().Where(x=> x != null )          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   //{"CutomerName".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.CutomerName != null).Select(x=>x.CutomerName).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Product".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.Product != null).Select(x=>x.Product).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Producttype".ToLower(), fti.ArtTiEcmAuditReports.Where(x => x.Producttype != null).Select(x=>x.Producttype).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"BranchId".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.BranchId).Distinct().Where(x=> x != null )                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EcmEvent".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EcmEvent).Distinct().Where(x=> x != null )                      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"TransactionCurrency".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"PrimaryOwner".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"CaseStatCd".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"UpdateUserId".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EventName".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventName).Distinct().Where(x=> x != null )                    .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EventStatus".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventStatus).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterAssignedTo".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.MasterAssignedTo).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"StepStatus".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.StepStatus).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"EventSteps".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventSteps).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(EcmTransactionsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"CaseId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseId).Distinct().Where(x=> x != null )                           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Product".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Product).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Producttype".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Producttype).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Behalfofbranch".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Behalfofbranch).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Eventname".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.Eventname).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"TransactionCurrency".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ) .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"PrimaryOwner".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CaseStatCd".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null )                   .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"UpdateUserId".ToLower(), fti.ArtTiEcmTransactionsReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(EcmWorkflowProgController) => new Dictionary<string, List<SelectItem>>
                {
                    {"EcmReference".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmReference).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"FtiReference".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.FtiReference).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    //{"CutomerName".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.CutomerName).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Product".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.Product).Distinct().Where(x=> x != null )                               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ProductType".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ProductType).Distinct().Where(x=> x != null )                       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"BranchId".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.BranchId).Distinct().Where(x=> x != null )                             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EcmEvent".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmEvent).Distinct().Where(x=> x != null )                             .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"TransactionCurrency".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null )       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"PrimaryOwner".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"CaseStatCd".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"UpdateUserId".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null )                     .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EcmRejectionReason".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmRejectionReason).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventName".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventName).Distinct().Where(x=> x != null )                           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventStatus).Distinct().Where(x=> x != null )                       .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AssignedTo".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AssignedTo).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"StepStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.StepStatus).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"EventSteps".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventSteps).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AssignmentType".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AssignmentType).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"Lstmoduser".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.Lstmoduser).Distinct().Where(x=> x != null )                         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"WarningOverridden".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.WarningOverridden).Distinct().Where(x=> x != null )           .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"InputSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.InputSlaStatus).Distinct().Where(x=> x != null )                 .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"AuthorizeSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AuthorizeSlaStatus).Distinct().Where(x=> x != null )         .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ReviewSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ReviewSlaStatus).Distinct().Where(x=> x != null )               .Select(x => new SelectItem { text = x, value = x }).ToList() },
                    {"ExternalReviewSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ExternalReviewSlaStatus).Distinct().Where(x=> x != null).Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(FinancingInterestAccrualsController) => new Dictionary<string, List<SelectItem>>
                {
                    {"BranchName".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.BranchName).Distinct().Where(x=> x != null )            .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"MasterRef".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"Prodcut".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Prodcut).Distinct().Where(x=> x != null )                  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"Recccy".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Recccy).Distinct().Where(x=> x != null )                    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"Address1".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.Address1).Distinct().Where(x=> x != null )                .Select(x => new SelectItem { text = x, value = x }).ToList()},
                    {"InterestRateType".ToLower(),fti.ArtTiFinanInterAccruals.Select(x=>x.InterestRateType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList()},
                },
                nameof(FullJournalController) => new Dictionary<string, List<SelectItem>>
                {
                    { "Username".ToLower(), fti.ArtTiFullJournalReports.Select(x=>x.Username).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "MtceType".ToLower(), fti.ArtTiFullJournalReports.Select(x=>x.MtceType).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList() },
                    { "Area".ToLower(), fti.ArtTiFullJournalReports.Select(x => x.Area).Distinct().Where(x=> x != null )      .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },
                nameof(MasterEventHistoryController) => new Dictionary<string, List<SelectItem>>
                {
                     {"BranchName".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.BranchName).Distinct().Where(x=> x != null ).Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"MasterRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.MasterRef).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Shortname".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Shortname).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"EventRef".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.EventRef).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Stepdescr".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Stepdescr).Distinct().Where(x=> x != null )  .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Status".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Status).Distinct().Where(x=> x != null )        .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Address1".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Address1).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"StatusEv".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.StatusEv).Distinct().Where(x=> x != null )    .Select(x => new SelectItem { text = x, value = x }).ToList()},
                     {"Ccy".ToLower(),fti.ArtTiMasterEventHistories.Select(x=>x.Ccy).Distinct().Where(x=> x != null )              .Select(x => new SelectItem { text = x, value = x }).ToList()},
                },
                nameof(OSActivityController) => new Dictionary<string, List<SelectItem>>
                {
                   {"BranchName".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.BranchName).Distinct()     .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Team".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Team).Distinct()                 .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"MasterRef".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.MasterRef).Distinct()       .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Product".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Product).Distinct()           .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Descrip".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Descrip).Distinct()           .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Address1".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Address1).Distinct()         .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                   {"Ccy".ToLower(),fti.ArtTiOsActivityReports.Select(x=>x.Ccy).Distinct()                   .Where(x=> x != null)          .Select(x => new SelectItem { text = x, value = x }).ToList() },
                },

                /*DGAML*/
                nameof(DGAMLAlertDetailsController) => new Dictionary<string, List<SelectItem>>
                {
                   {"AlertStatus".ToLower()                    ,(List<SelectItem>)artDgaml_.ArtDGAMLAlertDetailViews.Select(x => x.AlertStatus)          .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()        },
                   {"AlertSubcategory".ToLower()                    ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.AlertSubcategory) .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()        },
                   {"AlertCategory".ToLower()                    ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.AlertCategory)       .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()        },
                   //{"OwnerUserid".ToLower()                  ,_context.ArtDGAMLAlertDetailViews.Select(x =>x.)                      .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()                     },
                   {"BranchName".ToLower()                     ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.BranchName)            .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()                             },
                   {"ScenarioName".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.ScenarioName)          .Distinct()   .Where(x=> x != null)           .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"ClosedUserId".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.ClosedUserId)          .Distinct()   .Where(x=> x != null)        .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"CloseUserName".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.CloseUserName)        .Distinct()   .Where(x=> x != null)        .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"CloseReason".ToLower()                   ,artDgaml_.ArtDGAMLAlertDetailViews.Select(x =>x.CloseReason)            .Distinct()   .Where(x=> x != null)        .Select(x => new SelectItem { text = x, value = x }).ToList()         },
                   {"PoliticallyExposedPersonInd".ToLower()    ,new List<SelectItem>(){ new SelectItem { text = "Y", value = "Y" } ,new SelectItem { text = "N", value = "N" }}.ToList()                                               },
                   {"EmpInd".ToLower()    , new List<SelectItem>(){ new SelectItem { text = "Y", value = "Y" } ,new SelectItem { text = "N", value = "N" }}.ToList() }

                },
                nameof(DGAMLArtExternalCustomerDetailsController) => new Dictionary<string, List<SelectItem>>
                 {
                    {"BranchName".ToLower(),_dropDown.GetDGExternalCustomerBranchNameDropDown() },
                    {nameof(ArtExternalCustomerDetailView.CitizenshipCountryName).ToLower(),_dropDown .GetDGCitizenshipCountryNameDropDown() },
                    {nameof(ArtExternalCustomerDetailView.ResidenceCountryName).ToLower(),_dropDown .GetDGresidenceCountryNameDropDown()},
                // {"CntryName".ToLower(),_dropDown.GetDGStreetCountryNameDropDown() .ToDynamicList() },
                    {"CityName".ToLower(),_dropDown .GetDGCityNameDropDown()},
                    {"IdentTypeDesc".ToLower(),_dropDown.GetDGCustomerIdentificationTypeDropDown() },
                    {"ExtCustTypeDesc".ToLower(),_dropDown.GetDGCustomerTypeDropDown() },

                },

                _ => null
            };
        }
    }
}
