using ART_PACKAGE.Helpers.DBService;

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


        public List<string> GetAlertStatusDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_ALERT_STATUS"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;
        }

        public List<string> GetPartyTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.PartyTypeDesc == null || string.IsNullOrEmpty(x.PartyTypeDesc.Trim()) ? "UNKNOWN" : x.PartyTypeDesc.ToUpper()).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetScenarioNameDropDown()
        {
            //var distinct_value = dbfcfcore.ScenarioNmMatviews.Select(x => x.ScenarioName).ToList();
            //return distinct_value;

            List<string> distinct_value = _dbSrv.KC.FskScenarios.Where(x => x.CurrentInd == "Y").Select(x => x.ScenarioName == null || string.IsNullOrEmpty(x.ScenarioName.Trim()) ? "UNKNOWN" : x.ScenarioName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetBranchNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.CORE.FscBranchDims
               .Where(a => a.ChangeCurrentInd.Contains("Y"))
               .Where(b => b.BranchTypeDesc.Contains("BRANCH")).Select(x => x.BranchName)
               .ToList();
            return distinct_value;

        }

        public List<string> GetCasePriorityDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("X_RT_PRIORITY"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;

        }
        public List<string> GetCaseStatusDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("FCF_CASE_STATUS"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;
        }
        public List<string> GetCaseCategoryDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
               .Where(a => a.LovTypeName.StartsWith("RT_CASE_CATEGORY"))
               .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .ToList();
            return distinct_value;

        }
        public List<string> GetCaseSubCategoryDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_CASE_SUBCATEGORY"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetEntityLevelDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_CASE_ENTITY_LEVEL"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetRiskClassificationDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;
        }

        public List<string> GetResidenceCountryNameDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.ResidenceCountryName == null || string.IsNullOrEmpty(x.ResidenceCountryName.Trim()) ? "UNKNOWN" : x.ResidenceCountryName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetCitizenshipCountryNameDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.CitizenshipCountryName == null || string.IsNullOrEmpty(x.CitizenshipCountryName.Trim()) ? "UNKNOWN" : x.CitizenshipCountryName).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetCustomerIdentificationTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.PartyIdentificationTypeDesc == null || string.IsNullOrEmpty(x.PartyIdentificationTypeDesc.Trim()) ? "UNKNOWN" : x.PartyIdentificationTypeDesc).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetIndustryDescDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.IndustryDesc == null || string.IsNullOrEmpty(x.IndustryDesc.Trim()) ? "UNKNOWN" : x.IndustryDesc).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetOccupationDescDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.OccupationDesc == null || string.IsNullOrEmpty(x.OccupationDesc.Trim()) ? "UNKNOWN" : x.OccupationDesc).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetCaseTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE"))
                // .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE") && SANCTION_TYPES_FILTER.Contains(a.ValCd))
                .Select(x => x.ValDesc)
                .ToList();
            return distinct_value;

        }
        public List<string> GetAssessmentTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentTypeCd).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetRiskStatusDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskLovs
                 .Where(a => a.LovTypeName.StartsWith("RT_ASMT_STATUS"))
                 .Where(b => b.LovLanguageDesc.Contains("en")).Select(g => g.LovTypeDesc)
                 .ToList();
            return distinct_value;

        }
        public List<string> GetAssessmentCategoryCdDropDown()
        {
            List<string?> distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentCategoryCd).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetAssessmentSubCategoryCdDropDown()
        {
            List<string> distinct_value = _dbSrv.KC.FskRiskAssessments.Select(x => x.AssessmentSubcategoryCd == null || string.IsNullOrEmpty(x.AssessmentSubcategoryCd.Trim()) ? "UNKNOWN" : x.AssessmentSubcategoryCd).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetSystemCaseStatusDropDown()
        {


            List<string> distinct_value = _dbSrv.ECM.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                //.Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                .Select(x => x.ValDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetTransDirectionDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionDirection == null || string.IsNullOrEmpty(x.TransactionDirection.Trim()) || x.TransactionDirection.ToLower() == "null" ? "UNKNOWN" : x.TransactionDirection).Distinct()
                .Select(x => x.ToUpper() == "I" ? "InComing" : x.ToUpper() == "O" ? "OutGoing" : x)
           .ToList();
            return distinct_value;

        }
        public List<string> GetTransTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionType == null || string.IsNullOrEmpty(x.TransactionType.Trim()) || x.TransactionType.ToLower() == "null" ? "UNKNOWN" : x.TransactionType).Distinct().ToList();
            return distinct_value;

        }
        public List<string> GetPriorityDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.RefTableVals
               .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
               .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x => x.ValDesc)
               .ToList();
            return distinct_value;

        }

        public List<string> GetUserCaseStatusDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.RefTableVals
                            .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                            .Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST")).Select(x => x.ValDesc)
                            .ToList();
            return distinct_value;

        }

        public List<string> GetReportstatuscodeDropDown()
        {
            List<string> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportStatusCode == null || string.IsNullOrEmpty(x.ReportStatusCode.Trim()) ? "UNKNOWN" : x.ReportStatusCode).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetReportTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportCode == null || string.IsNullOrEmpty(x.ReportCode.Trim()) ? "UNKNOWN" : x.ReportCode).Distinct().ToList();
            return distinct_value;

        }
        public List<string> GetReportPriorityDropDown()
        {
            List<string> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.Priority == null || string.IsNullOrEmpty(x.Priority.Trim()) ? "UNKNOWN" : x.Priority).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetReportIndicatorDropDown()
        {
            List<string> distinct_value = _dbSrv.GOAML.ReportIndicatorTypes.Select(x => x.Indicator == null || string.IsNullOrEmpty(x.Indicator.Trim()) ? "UNKNOWN" : x.Indicator).Distinct().ToList();
            return distinct_value;
        }



        public List<string> GetNonREntityBranchDropDown()
        {
            List<string> distinct_value = _dbSrv.GOAML.Reports.Select(x => x.RentityBranch == null || string.IsNullOrEmpty(x.RentityBranch.Trim()) ? "UNKNOWN" : x.RentityBranch).Distinct().ToList();
            return distinct_value;

        }
        //public List<string> GetOwnerDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList();
        //    return distinct_value;
        //}

        //public List<string> GetAppLebalDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLicenseds.GroupBy(s => s.AppLebal).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;

        //}
        //public List<string> GetProTypeDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLicenseds.GroupBy(s => s.ProType).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;

        //}
        //public List<string> GetGroupTypeDropDown()
        //{
        //    var distinct_value = dbcmcaudit.ListAccessRightPerProfiles.GroupBy(s => s.Grouptype).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetGroupsDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaGroupInfos
        //        .Where(a => a.Grouptype.StartsWith("Group")).Select(s => s.Name)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetGroupRoleNameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.ListAccessRightPerProfiles.GroupBy(s => s.GroupName).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetRolesDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaGroupInfos
        //        .Where(a => a.Grouptype.StartsWith("Role") || a.Grouptype.StartsWith("ROLE")).Select(g => g.Name)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;

        //}
        //public List<string> GetCapabilityGroupDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaUsercapabilities.GroupBy(s => s.CapabilitiyGroupName).Select(g => g.Key)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetCapabilityNameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaUsercapabilities.GroupBy(s => s.CapName).Select(g => g.Key)
        //        .OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetUsernameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLastLogins.GroupBy(s => s.Username).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetAppnameDropDown()
        //{
        //    var distinct_value = dbcmcaudit.VaLastLogins.GroupBy(s => s.Appname).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}


        //public List<string> GetMakerEventNameDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => a.EnventName.Contains("Waiting")).GroupBy(s => s.EnventName).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}
        //public List<string> GetCheckerEventNameDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => !a.EnventName.Contains("Waiting")).GroupBy(s => s.EnventName).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}

        //public List<string> GetMakerCreatedByDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => a.EnventName.Contains("Waiting")).GroupBy(s => s.Createdby).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}

        //public List<string> GetCheckerCreatedByDropDown()
        //{
        //    var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => !a.EnventName.Contains("Waiting")).GroupBy(s => s.Createdby).Select(g => g.Key).OrderBy(s => s).ToList();
        //    return distinct_value;
        //}

        public List<string> GetReportAcctBranchDropDown()
        {
            List<string> distinct_value = _dbSrv.GOAML.Taccounts.Select(x => x.Branch == null || string.IsNullOrEmpty(x.Branch.Trim()) ? "UNKNOWN" : x.Branch).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetOwnerDropDown()
        {
            List<string> distinct_value = _dbSrv.KC.FskCases.Select(x => x.OwnerUserLongId == null || string.IsNullOrEmpty(x.OwnerUserLongId.Trim()) ? "UNKNOWN" : x.OwnerUserLongId).Distinct().ToList();
            return distinct_value;
        }


        public List<string> GetAppLebalDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.DGMGMT.GroupDgs.Where(x => !string.IsNullOrEmpty(x.GroupType)).Select(x => x.GroupType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetGroupsDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupRoleNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRolesDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCapabilityGroupDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCapabilityNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUsernameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAppnameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMakerEventNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCheckerEventNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMakerCreatedByDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCheckerCreatedByDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPartyIdentificationTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.PartyIdentificationTypeDesc == null || string.IsNullOrEmpty(x.PartyIdentificationTypeDesc.Trim()) ? "UNKNOWN" : x.PartyIdentificationTypeDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUpdateUserIdDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.UpdateUserId == null || string.IsNullOrEmpty(x.UpdateUserId.Trim()) ? "UNKNOWN" : x.UpdateUserId).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetInvestagtorDropDown()
        {
            List<string> distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.PrimaryOwner == null || string.IsNullOrEmpty(x.PrimaryOwner.Trim()) ? "UNKNOWN" : x.PrimaryOwner).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetGroupAudNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.GroupDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserAudNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.UserDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetRoleAudNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.RoleDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetGroupNameDropDown()
        {
            List<string> distinct_value = _dbSrv.DGMGMT.GroupDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserNameDropDown()
        {
            List<string> distinct_value = _dbSrv.DGMGMT.UserDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetRoleNameDropDown()
        {
            List<string> distinct_value = _dbSrv.DGMGMT.RoleDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserAudTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.UserDgAuds.Where(x => !string.IsNullOrEmpty(x.UserType)).Select(x => x.UserType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetMemberUsersDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.AccountAuds.Where(x => !string.IsNullOrEmpty(x.AuthenticationDomain)).Select(x => x.AuthenticationDomain).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetAppNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.AppName)).Select(x => x.AppName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDeviceNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.DeviceName)).Select(x => x.DeviceName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDeviceTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGMGMTAUD.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.DeviceType)).Select(x => x.DeviceType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.DGMGMT.UserDgs.Where(x => !string.IsNullOrEmpty(x.UserType)).Select(x => x.UserType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetRoleTypeDropDown()
        {
            List<string> distinct_value = _dbSrv.DGMGMT.RoleDgs.Where(x => !string.IsNullOrEmpty(x.RoleType)).Select(x => x.RoleType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioCategoryDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioStatusDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_STATUS") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGProductTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("PRODUCT_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioFrequencyDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_FREQUENCY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGObjectLevelDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("OBJECT_LEVEL") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGAlarmTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGAlarmCategoryDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGAlarmSubcategoryDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_SUBCATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGCreateUserIdDropDown()
        {
            List<string> distinct_value = _dbSrv.DGAML.AcScenarioEvents.Select(x => x.CreateUserId).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioNameDropDown()
        {
            List<string> distinct_value = _dbSrv.DGAML.AcRoutines.Select(x => x.RoutineName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGRiskFactDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcRoutines.Where(x => !string.IsNullOrEmpty(x.RiskFactInd)).Select(x => x.RiskFactInd).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGBranchNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.Accounts.Where(x => !string.IsNullOrEmpty(x.AcctPrimBranchName)).Select(x => x.AcctPrimBranchName).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGProfileRiskDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.RiskScoreCd)).Select(x => x.RiskScoreCd).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGOwnerDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.OwnerUid)).Select(x => x.OwnerUid).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGPoliticalExpPrsnIndDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.PoliticalExpPrsnInd)).Select(x => x.PoliticalExpPrsnInd).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGRiskClassificationDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.Customers.Where(x => x.RiskClass != null).Select(x => x.RiskClass.ToString()).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGCitizenCountryNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGCustIdentTypeDescDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.CustIdentTypeDesc)).Select(x => x.CustIdentTypeDesc).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGOccupDescDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.OccupDesc)).Select(x => x.OccupDesc).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGRoutineCreateUserIdDropDown()
        {
            List<string> distinct_value = _dbSrv.DGAML.AcRoutines.Where(x => !string.IsNullOrEmpty(x.CreateUserId)).Select(x => x.CreateUserId).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGCustomerTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.ExtCustTypeDesc)).Select(x => x.ExtCustTypeDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGCustomerIdentificationTypeDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.IdentTypeDesc)).Select(x => x.IdentTypeDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGCityNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CityName)).Select(x => x.CityName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGStreetCountryNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CntryName)).Select(x => x.CntryName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGresidenceCountryNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.ResidCntryName)).Select(x => x.ResidCntryName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGCitizenshipCountryNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGExternalCustomerBranchNameDropDown()
        {
            List<string?> distinct_value = _dbSrv.DGAML.ExternalCustomers.Where(x => !string.IsNullOrEmpty(x.BranchName)).Select(x => x.BranchName).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGParmValueDropDown()
        {
            List<string> distinct_value = _dbSrv.DGAML.AcRoutineParameters.Where(x => !string.IsNullOrEmpty(x.ParmValue)).Select(x => x.ParmValue).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGParmTypeDescDropDown()
        {
            List<string> distinct_value = _dbSrv.DGAML.AcRoutineParameters.Where(x => !string.IsNullOrEmpty(x.ParmTypeDesc)).Select(x => x.ParmTypeDesc).Distinct().ToList();
            return distinct_value;
        }
    }
}
