
using ART_PACKAGE.Helpers.DBService;
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
               .Where(a => a.ChangeCurrentInd.Contains("Y"))
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
        public List<SelectItem> GetCustomerTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.PartyTypeDesc != null && x.PartyTypeDesc != string.Empty).Select(x => x.PartyTypeDesc.ToUpper() == "ORGNIZATION" ? "ORGANIZATION" : x.PartyTypeDesc.ToUpper()).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetCustomerStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.PartyStatusDesc != null && x.PartyStatusDesc != string.Empty).Select(x => x.PartyStatusDesc).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;

        }
        public List<SelectItem> GetMaritalStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.MaritalStatusDesc != null && x.MaritalStatusDesc != string.Empty).Select(x => x.MaritalStatusDesc).Distinct().Select(x => new SelectItem { text = x, value = x }).ToList();
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
            List<SelectItem> distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentTypeCd).Select(g => g.Key).Select(x => new SelectItem { text = x, value = x }).ToList();
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
        public List<SelectItem> GetAlertedEntityLevelDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.KC.FskLovs
                 .Where(a => a.LovTypeName.StartsWith("RT_ENTITY_LEVEL"))
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
            List<SelectItem> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionType == null || string.IsNullOrEmpty(x.TransactionType.Trim()) || x.TransactionType.ToLower() == "null" ? "UNKNOWN" : x.TransactionType).Select(x => new SelectItem { text = x, value = x }).ToList();
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
        public List<SelectItem> GetReportTypeForTopsAndBottomsDropDown()
        {
            List<SelectItem> distinct_value = new List<string>() { "DTET, SARAF or STRTF", "SAR or STR" }.Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;

        }
        public List<SelectItem> GetReportTypeForStaffAndNonStaffSummariesDropDown()
        {
            List<SelectItem> distinct_value = new List<string>() { "DTET", "SARAF", "STRTF" }.Select(x => new SelectItem { text = x, value = x }).ToList();

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
            List<SelectItem> distinct_value = _dbSrv.KC.FskCases.Select(x => x.OwnerUserLongId == null || string.IsNullOrEmpty(x.OwnerUserLongId.Trim()) ? "UNKNOWN" : x.OwnerUserLongId).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetAlertOwnerDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.SasAML.ArtAmlAlertDetailViews.Select(x => x.OwnerUserid).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

            return distinct_value;
        }
        public List<SelectItem> GetQueuesDropDown()
        {
            List<SelectItem> distinct_value = new List<SelectItem>(); //_dbSrv.KC.FskQueues.Select(x => x.QueueCode).Distinct().Where(x => !string.IsNullOrEmpty(x.Trim())).Select(x => new SelectItem { text = x, value = x }).ToList();

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

        public List<SelectItem> GetDGScenarioCategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioStatusDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_STATUS") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGProductTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("PRODUCT_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioFrequencyDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_FREQUENCY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGObjectLevelDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("OBJECT_LEVEL") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGAlarmTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGAlarmCategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGAlarmSubcategoryDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_SUBCATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCreateUserIdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcScenarioEvents.Select(x => x.CreateUserId).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGScenarioNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcRoutines.Select(x => x.RoutineName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGRiskFactDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcRoutines.Where(x => !string.IsNullOrEmpty(x.RiskFactInd)).Select(x => x.RiskFactInd).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGBranchNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.Accounts.Where(x => !string.IsNullOrEmpty(x.AcctPrimBranchName)).Select(x => x.AcctPrimBranchName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGProfileRiskDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.RiskScoreCd)).Select(x => x.RiskScoreCd).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGOwnerDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.OwnerUid)).Select(x => x.OwnerUid).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGPoliticalExpPrsnIndDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.PoliticalExpPrsnInd)).Select(x => x.PoliticalExpPrsnInd).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGRiskClassificationDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.Customers.Where(x => x.RiskClass != null).Select(x => x.RiskClass.ToString()).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGCitizenCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGCustIdentTypeDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.CustIdentTypeDesc)).Select(x => x.CustIdentTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGOccupDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.OccupDesc)).Select(x => x.OccupDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGRoutineCreateUserIdDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcRoutines.Where(x => !string.IsNullOrEmpty(x.CreateUserId)).Select(x => x.CreateUserId).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGCustomerTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.ExtCustTypeDesc)).Select(x => x.ExtCustTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetLast10YearsDropDown()
        {
            var currentYear = DateTime.Now.Year;
            var years = Enumerable.Range(currentYear - 9, 10).OrderByDescending(s=>s)
                .Select(year => new SelectItem { text = year.ToString(), value = year.ToString() })
                .ToList();

            return years;
        }

        public List<SelectItem> GetDGCustomerIdentificationTypeDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.IdentTypeDesc)).Select(x => x.IdentTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCityNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CityName)).Select(x => x.CityName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGStreetCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CntryName)).Select(x => x.CntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGresidenceCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.ResidCntryName)).Select(x => x.ResidCntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGCitizenshipCountryNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }

        public List<SelectItem> GetDGExternalCustomerBranchNameDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.BranchName)).Select(x => x.BranchName).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGParmValueDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcRoutineParameters.Where(x => !string.IsNullOrEmpty(x.ParmValue)).Select(x => x.ParmValue).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
        public List<SelectItem> GetDGParmTypeDescDropDown()
        {
            List<SelectItem> distinct_value = _dbSrv.DGAML.AcRoutineParameters.Where(x => !string.IsNullOrEmpty(x.ParmTypeDesc)).Select(x => x.ParmTypeDesc).Select(x => new SelectItem { text = x, value = x }).ToList();
            return distinct_value;
        }
    }
}
