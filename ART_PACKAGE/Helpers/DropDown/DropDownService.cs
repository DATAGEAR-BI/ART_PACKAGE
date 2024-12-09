
using ART_PACKAGE.Helpers.DBService;
using Castle.Core.Internal;
using Data.Services.Grid;
using Microsoft.IdentityModel.Tokens;

namespace ART_PACKAGE.Helpers.DropDown
{
    public class DropDownService : IDropDownService
    {
        private readonly IDbService _dbSrv;

        private static readonly List<string> SANCTION_TYPES_FILTER = new() { "WEB", "BULK", "DELTA", "WHITELIST", "ACH", "SWIFT" };
        private static readonly List<string> SANCTION_STATUS_FILTER = new() { "CSR", "MST", "CSC", "SC", "CST", "SM", "ST", "MSC", "SN" };
        public DropDownService(IDbService dbSrv)
        {
            _dbSrv = dbSrv;
        }
        public List<SelectItem> GetCloseUserNameForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAdmin.Users.Select(x => x.UserName).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetActionNameSanctionSensitivityFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGECMFilters.ArtSanctionSensitivityActionNameFilterTbs.Select(x => x.ActionName).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetAlertedEntityLevelForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtDgAmlAlertedEntityLevelFilters.Where(x => x.AlertedEntityLevel != null && x.AlertedEntityLevel != "").Select(x => x.AlertedEntityLevel).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetRiskScoreDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtDgAmlRiskScoreFilters.Where(x => x.RiskScore != null && x.RiskScore != "").Select(x => x.RiskScore).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCustomerStatusForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtCustomerStatusFilterTbs.Where(x => x.CustomerStatus != null && x.CustomerStatus != "").Select(x => x.CustomerStatus).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCustomerCityNameForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtCustomerCityFilterTbs.Where(x => x.CityName != null && x.CityName != "").Select(x => x.CityName).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetMoneyLaunderingScoreForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtMoneyLaunderingRiskScoreFilterTbs.Select(x => x.MoneyLaunderingRiskScore).Distinct().Select(x => new SelectItem { text = x.ToString(), value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCasePriorityForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtDgAmlCasePriorityFilterTbs.Select(x => x.CasePriority).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCaseStatusForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtDgAmlCaseStatusFilterTbs.Select(x => x.CaseStatus).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCaseCategoryForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtDgAmlCaseCategoryFilterTbs.Select(x => x.CaseCategory).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetEntityLevelForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtDgAmlEntityLevelFilterTbs.Select(x => x.EntityLevel).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCustomerIdentificationTypeForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtCustomerIdentificationTypeFilterTbs.Select(x => x.CustomerIdentificationType).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCustomerRiskClassificationForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtCustomerRiskClassificationFilterTbs.Where(x => x.CustomerRiskClassification != null).Select(x => x.CustomerRiskClassification).Distinct().Select(x => new SelectItem { text = x.Value.ToString(), value = x.Value.ToString() }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCustomerIndustryForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtCustomerIndustryFilterTbs.Where(x => x.IndustryDesc != null && x.IndustryDesc != "").Select(x => x.IndustryDesc).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCustomerOccupationForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLFilters.ArtCustomerOccupationFilterTbs.Where(x => x.OccupationDesc != null && x.OccupationDesc != "").Select(x => x.OccupationDesc).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCategorySanctionSensitivityFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGECMFilters.ArtSanctionSensitivityCategoryFilterTbs.Select(x => x.Category).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetActionEcmFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGECMFilters.ArtActionFilterTbs.Select(x => x.Action).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCaseStatusEcmFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGECMFilters.ArtCaseStatusFilterTbs.Select(x => x.CaseStatus).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCaseTypeEcmFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGECMFilters.ArtCaseTypeFilterTbs.Select(x => x.CaseType).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCrpActionFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGCRP.ArtCrpActionFilterTbs.Select(x => x.Action).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCrpCaseStatusFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGCRP.ArtCrpCaseStatusFilters.Select(x => x.CaseStatus).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetCrpCaseTypeFilter()
        {
            List<SelectItem> distinct_value = _dbSrv.DGCRP.ArtCrpCaseTypeFilters.Select(x => x.CaseType).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetAlertStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_ALERT_STATUS"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetAlertTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
               .Where(a => a.LovTypeName.StartsWith("RT_ALERT_STATUS"))
               .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetPartyTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
               .Where(a => a.LovTypeName.StartsWith("FCF_PARTY_TYPE"))
               .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }

        public List<SelectItem> GetScenarioNameDropDown()
        {
            //var distinct_value = dbfcfcore.ScenarioNmMatviews.Select(x => x.ScenarioName).ToList();
            //return distinct_value;

            List<SelectItem> distinct_value = _dbSrv.KC.FskScenarios.Where(x => x.CurrentInd == "Y").Select(x => x.ScenarioName == null || string.IsNullOrEmpty(x.ScenarioName.Trim()) ? "UNKNOWN" : x.ScenarioName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetBranchNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscBranchDims
                .Where(a => a.ChangeCurrentInd.Contains("Y") && a.BranchName != null &&!string.IsNullOrEmpty(a.BranchName.Trim()))
                //.Where(b => b.BranchTypeDesc.Contains("BRANCH"))
                .Select(x => x.BranchName)
                .Select(x => new SelectItem { text = x, value = x }).ToList();
            distinct_value.Add(new SelectItem { text = "Unknown", value = "Unknown" });
            return distinct_value;

        }

        public List<SelectItem> GetCasePriorityDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("X_RT_PRIORITY"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetCaseStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("FCF_CASE_STATUS"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
              .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetCaseCategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
               .Where(a => a.LovTypeName.StartsWith("RT_CASE_CATEGORY"))
               .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetCaseSubCategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_CASE_SUBCATEGORY"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetEntityLevelDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_CASE_ENTITY_LEVEL"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetRiskClassificationDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetResidenceCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.ResidenceCountryName == null || string.IsNullOrEmpty(x.ResidenceCountryName.Trim()) ? "UNKNOWN" : x.ResidenceCountryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetCitizenshipCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.CitizenshipCountryName == null || string.IsNullOrEmpty(x.CitizenshipCountryName.Trim()) ? "UNKNOWN" : x.CitizenshipCountryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetCustomerIdentificationTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.PartyIdentificationTypeDesc == null || string.IsNullOrEmpty(x.PartyIdentificationTypeDesc.Trim()) ? "UNKNOWN" : x.PartyIdentificationTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetIndustryDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.IndustryDesc == null || string.IsNullOrEmpty(x.IndustryDesc.Trim()) ? "UNKNOWN" : x.IndustryDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetOccupationDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.OccupationDesc == null || string.IsNullOrEmpty(x.OccupationDesc.Trim()) ? "UNKNOWN" : x.OccupationDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetCaseTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE"))
                // .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE") && SANCTION_TYPES_FILTER.Contains(a.ValCd))
                .Select(x => x.ValDesc)
               .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetAssessmentTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentTypeCd).Select(g => g.Key).Where(s=>s!=null).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetRiskStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                 .Where(a => a.LovTypeName.StartsWith("RT_ASMT_STATUS"))
                 .Where(b => b.LovLanguageDesc.Contains("en")).Select(g => g.LovTypeDesc)
                 .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetAssessmentCategoryCdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentCategoryCd).Select(g => g.Key).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetAssessmentSubCategoryCdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskRiskAssessments.Select(x => x.AssessmentSubcategoryCd == null || string.IsNullOrEmpty(x.AssessmentSubcategoryCd.Trim()) ? "UNKNOWN" : x.AssessmentSubcategoryCd).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetSystemCaseStatusDropDown()
        {


            List<SelectItem> distinct_value = _dbSrv.ECM.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                //.Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                .Select(x => x.ValDesc)
                .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetTransDirectionDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionDirection == null || string.IsNullOrEmpty(x.TransactionDirection.Trim()) || x.TransactionDirection.ToLower() == "null" ? "UNKNOWN" : x.TransactionDirection).Distinct()
                .Select(x => x.ToUpper() == "I" ? "InComing" : x.ToUpper() == "O" ? "OutGoing" : x)
         .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetTransTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionType == null || string.IsNullOrEmpty(x.TransactionType.Trim()) || x.TransactionType.ToLower() == "null" ? "UNKNOWN" : x.TransactionType).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetPriorityDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.RefTableVals
               .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
               .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x => x.ValDesc)
              .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetUserCaseStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.RefTableVals
                            .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                            .Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST")).Select(x => x.ValDesc)
                           .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetReportstatuscodeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportStatusCode).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetReportTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportCode).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetReportPriorityDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.Priority).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetCurrencyCodeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.CurrencyCodeLocal).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetReportPersonTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportingPersonType).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }

        public List<SelectItem> GetReportIndicatorDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.ReportIndicatorTypes.Select(x => x.Indicator == null || string.IsNullOrEmpty(x.Indicator.Trim()) ? "UNKNOWN" : x.Indicator).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }



        public List<SelectItem> GetNonREntityBranchDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.RentityBranch == null || string.IsNullOrEmpty(x.RentityBranch.Trim()) ? "UNKNOWN" : x.RentityBranch).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        //public List<SelectItem> GetOwnerDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList();
        //    return distinct_value;
        //}

        //public List<SelectItem> GetAppLebalDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLicenseds.GroupBy(s => s.AppLebal).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;

        //}
        //public List<SelectItem> GetProTypeDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLicenseds.GroupBy(s => s.ProType).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;

        //}
        //public List<SelectItem> GetGroupTypeDropDown()
        //{
        //    var distinct_value = dbcmcaudit.ListAccessRightPerProfiles.GroupBy(s => s.Grouptype).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetGroupsDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaGroupInfos
        //        .Where(a => a.Grouptype.StartsWith("Group")).Select(s => s.Name)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetGroupRoleNameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.ListAccessRightPerProfiles.GroupBy(s => s.GroupName).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetRolesDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaGroupInfos
        //        .Where(a => a.Grouptype.StartsWith("Role") || a.Grouptype.StartsWith("ROLE")).Select(g => g.Name)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;

        //}
        //public List<SelectItem> GetCapabilityGroupDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaUsercapabilities.GroupBy(s => s.CapabilitiyGroupName).Select(g => g.Key)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetCapabilityNameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaUsercapabilities.GroupBy(s => s.CapName).Select(g => g.Key)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetUsernameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLastLogins.GroupBy(s => s.Username).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetAppnameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLastLogins.GroupBy(s => s.Appname).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        public List<SelectItem> GetReportTypeForgoamlReportsSusbectDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Lookups.Where(x => x.LookupName=="report_type" && x.LookupKey != null).Select(x => x.LookupKey).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetReportStatusForgoamlReportsSusbectDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Lookups.Where(x => x.LookupName == "report_status" && x.LookupKey != null).Select(x => x.LookupKey).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetReportActivityForgoamlReportsSusbectDropDown()
        {
            List<SelectItem> distinct_value = new List<string>() { "To Person",
                "Account",
                "Entity",
                "From Account",
                "From Entity",
                "To Account",
                "From Person",
                "Person",
                "To Entity" }.Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetCustTypeDescForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = new List<string>() { "INDIVIDUAL",
                "ORGANIZATION"}.Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }

        //public List<SelectItem> GetMakerEventNameDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => a.EnventName.Contains("Waiting")).GroupBy(s => s.EnventName).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<SelectItem> GetCheckerEventNameDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => !a.EnventName.Contains("Waiting")).GroupBy(s => s.EnventName).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}

        //public List<SelectItem> GetMakerCreatedByDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => a.EnventName.Contains("Waiting")).GroupBy(s => s.Createdby).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}

        //public List<SelectItem> GetCheckerCreatedByDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => !a.EnventName.Contains("Waiting")).GroupBy(s => s.Createdby).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}

        public List<SelectItem> GetReportAcctBranchDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.GOAML.Taccounts.Select(x => x.Branch == null || string.IsNullOrEmpty(x.Branch.Trim()) ? "UNKNOWN" : x.Branch).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetOwnerDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskCases.Select(x => x.OwnerUserLongId == null || string.IsNullOrEmpty(x.OwnerUserLongId.Trim()) ? "UNKNOWN" : x.OwnerUserLongId).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetCasesDetailsCreatedByDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskCases.Select(x => x.CreateUserId == null || string.IsNullOrEmpty(x.CreateUserId.Trim()) ? "UNKNOWN" : x.CreateUserId).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetAlertOwnerDropDown()
        {
            List<SelectItem> distinct_value = new List<SelectItem>();

            return distinct_value;
        }
        public List<SelectItem> GetQueuesDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskQueues.Select(x => x.QueueCode).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }

        public List<SelectItem> GetAppLebalDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetProTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetGroupTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.GroupDgs.Where(x => !string.IsNullOrEmpty(x.GroupType)).Select(x => x.GroupType).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetGroupsDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetGroupRoleNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetRolesDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetCapabilityGroupDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetCapabilityNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetUsernameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetAppnameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetMakerEventNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetCheckerEventNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetMakerCreatedByDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetCheckerCreatedByDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetPartyIdentificationTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.PartyIdentificationTypeDesc == null || string.IsNullOrEmpty(x.PartyIdentificationTypeDesc.Trim()) ? "UNKNOWN" : x.PartyIdentificationTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetUpdateUserIdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.UpdateUserId == null || string.IsNullOrEmpty(x.UpdateUserId.Trim()) ? "UNKNOWN" : x.UpdateUserId).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetInvestagtorDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.PrimaryOwner == null || string.IsNullOrEmpty(x.PrimaryOwner.Trim()) ? "UNKNOWN" : x.PrimaryOwner).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetGroupAudNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.GroupDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetUserAudNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.UserDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetRoleAudNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.RoleDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetGroupNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.GroupDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetUserNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.UserDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDisplayNameForUserManagement()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.UserDgs.Where(x => !string.IsNullOrEmpty(x.DisplayName)).Distinct().Select(x => x.DisplayName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetNameForUserManagement()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.UserDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Distinct().Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetRoleNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.RoleDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetUserAudTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.UserDgAuds.Where(x => !string.IsNullOrEmpty(x.UserType)).Select(x => x.UserType).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetMemberUsersDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.AccountAuds.Where(x => !string.IsNullOrEmpty(x.AuthenticationDomain)).Select(x => x.AuthenticationDomain).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetAppNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.AppName)).Select(x => x.AppName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDeviceNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.DeviceName)).Select(x => x.DeviceName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDeviceTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMTAUD.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.DeviceType)).Select(x => x.DeviceType).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetUserTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.UserDgs.Where(x => !string.IsNullOrEmpty(x.UserType)).Select(x => x.UserType).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetRoleTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGMGMT.RoleDgs.Where(x => !string.IsNullOrEmpty(x.RoleType)).Select(x => x.RoleType).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetActionForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("AUDIT_EVENT") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetAlertStatusForDGAMLDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_STATUS") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioCategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_STATUS") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGProductTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("PRODUCT_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioFrequencyDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_FREQUENCY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGObjectLevelDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("OBJECT_LEVEL") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGAlarmTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGAlarmCategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGAlarmSubcategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_SUBCATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCreateUserIdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcScenarioEvents.Select(x => x.CreateUserId).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcRoutines.Select(x => x.RoutineName).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGRiskFactDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcRoutines.Where(x => !string.IsNullOrEmpty(x.RiskFactInd)).Select(x => x.RiskFactInd).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGBranchNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.Branches.Where(x => !string.IsNullOrEmpty(x.BranchName)).Select(x => x.BranchName).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGProfileRiskDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.RiskScoreCd)).Select(x => x.RiskScoreCd).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGOwnerDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.OwnerUid)).Select(x => x.OwnerUid).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGPoliticalExpPrsnIndDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.Customers.Where(x => !string.IsNullOrEmpty(x.PoliticalExpPrsnInd)).Select(x => x.PoliticalExpPrsnInd).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGRiskClassificationDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.Customers.Where(x => x.RiskClass != null).Select(x => x.RiskClass.ToString()).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGCitizenCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.Customers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGCustIdentTypeDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.Customers.Where(x => !string.IsNullOrEmpty(x.CustIdentTypeDesc)).Select(x => x.CustIdentTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGOccupDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.Customers.Where(x => !string.IsNullOrEmpty(x.OccupDesc)).Select(x => x.OccupDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGRoutineCreateUserIdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcRoutines.Where(x => !string.IsNullOrEmpty(x.CreateUserId)).Select(x => x.CreateUserId).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGCustomerTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.ExtCustTypeDesc)).Select(x => x.ExtCustTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCustomerIdentificationTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.IdentTypeDesc)).Select(x => x.IdentTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCityNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CityName)).Select(x => x.CityName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGStreetCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CntryName)).Select(x => x.CntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGresidenceCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.ResidCntryName)).Select(x => x.ResidCntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCitizenshipCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGExternalCustomerBranchNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.BranchName)).Select(x => x.BranchName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGParmValueDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcRoutineParameters.Where(x => !string.IsNullOrEmpty(x.ParmValue)).Select(x => x.ParmValue).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGParmTypeDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLAC.AcRoutineParameters.Where(x => !string.IsNullOrEmpty(x.ParmTypeDesc)).Select(x => x.ParmTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        
        public List<SelectItem> GetOwner_RiskAssessmentDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskRiskAssessments.Select(x => x.OwnerUserLongId).Distinct().Where(x => x != null && !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetCreatedByDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskRiskAssessments.Select(x => x.CreateUserId).Distinct().Where(x => x != null && !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetAlertedEntityLevelDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_ENTITY_LEVEL"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(g => g.LovTypeDesc)
                .Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetOwner_AlertedEntityDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskEntityQueues.Select(x => x.OwnerUserid).Distinct().Where(x => x != null && !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        
        public List<SelectItem> GetCustomerStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.PartyStatusDesc).Distinct().Where(x => x != null && !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetMaritalStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.MaritalStatusDesc).Distinct().Where(x => x != null && !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetCustomerTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.PartyKey != -1).Select(x => x.PartyTypeDesc.ToUpper() == "ORGNIZATION" ? "ORGANIZATION" : x.PartyTypeDesc.ToUpper()).Distinct().Where(x => x != null && !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }

        public List<SelectItem> GetBranchNumberDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAMLCORE.CountryLkps.Where(x => !string.IsNullOrEmpty(x.CntryName)).Select(x => x.CntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetPartyType_AlertDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetCloseRsnDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetEmployeeIndDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetTransactionTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetTypeOfSwiftClearDetectDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetDirectionOfSwiftClearDetectDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetActionForUserPerf()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetLast10YearsDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetReportTypeForTopsAndBottomsDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetReportTypeForStaffAndNonStaffSummariesDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetAlertsOwnerDropDown()
        {
            throw new NotImplementedException();
        }

        public List<SelectItem> GetGOAMLReportAccountTypesDropDown()
        {
            throw new NotImplementedException();
        }
    }
}
