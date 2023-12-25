using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.EXPORT_SCHEDULAR;
using ART_PACKAGE.Controllers.FTI.DraftsReport;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.ExportSchedular;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper
{
    public class DropDownMapper : IDropDownMapper
    {
        private readonly IDropDownService _dropDown;

        public DropDownMapper(IDropDownService dropDown)
        {
            _dropDown = dropDown;
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
                _ => null
            };
        }
    }
}
