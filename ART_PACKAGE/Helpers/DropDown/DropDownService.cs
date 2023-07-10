using Data.DGECM;
using Data.FCF71;
using Data.FCFKC;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ART_PACKAGE.Helpers.DropDown
{
    public class DropDownService : IDropDownService
    {
        private readonly IDbService _dbSrv;

        private static readonly List<string> SANCTION_TYPES_FILTER = new List<string> { "WEB", "BULK", "DELTA", "WHITELIST", "ACH", "SWIFT" };
        private static readonly List<string> SANCTION_STATUS_FILTER = new List<string> { "CSR", "MST", "CSC", "SC", "CST", "SM", "ST", "MSC", "SN" };
        public DropDownService(IDbService dbSrv)
        {
            _dbSrv = dbSrv;
        }


        public List<string> GetAlertStatusDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_ALERT_STATUS"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;
        }

        public List<string> GetPartyTypeDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.PartyTypeDesc == null || string.IsNullOrEmpty(x.PartyTypeDesc.Trim()) ? "UNKNOWN" : x.PartyTypeDesc.ToUpper()).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetScenarioNameDropDown()
        {
            //var distinct_value = dbfcfcore.ScenarioNmMatviews.Select(x => x.ScenarioName).ToList();
            //return distinct_value;

            var distinct_value = _dbSrv.KC.FskScenarios.Where(x => x.CurrentInd == "Y").Select(x => x.ScenarioName == null || string.IsNullOrEmpty(x.ScenarioName.Trim()) ? "UNKNOWN" : x.ScenarioName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetBranchNameDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscBranchDims
               .Where(a => a.ChangeCurrentInd.Contains("Y"))
               .Where(b => b.BranchTypeDesc.Contains("BRANCH")).Select(x => x.BranchName)
               .ToList();
            return distinct_value;

        }

        public List<string> GetCasePriorityDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("X_RT_PRIORITY"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;

        }
        public List<string> GetCaseStatusDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("FCF_CASE_STATUS"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;
        }
        public List<string> GetCaseCategoryDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
               .Where(a => a.LovTypeName.StartsWith("RT_CASE_CATEGORY"))
               .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
               .ToList();
            return distinct_value;

        }
        public List<string> GetCaseSubCategoryDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_CASE_SUBCATEGORY"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetEntityLevelDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_CASE_ENTITY_LEVEL"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetRiskClassificationDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                .Where(a => a.LovTypeName.StartsWith("RT_RISK_CLASSIFICATION"))
                .Where(b => b.LovLanguageDesc.Contains("en")).Select(x => x.LovTypeDesc)
                .ToList();
            return distinct_value;
        }

        public List<string> GetResidenceCountryNameDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.ResidenceCountryName == null || string.IsNullOrEmpty(x.ResidenceCountryName.Trim()) ? "UNKNOWN" : x.ResidenceCountryName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetCitizenshipCountryNameDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.CitizenshipCountryName == null || string.IsNullOrEmpty(x.CitizenshipCountryName.Trim()) ? "UNKNOWN" : x.CitizenshipCountryName).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetCustomerIdentificationTypeDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.PartyIdentificationTypeDesc == null || string.IsNullOrEmpty(x.PartyIdentificationTypeDesc.Trim()) ? "UNKNOWN" : x.PartyIdentificationTypeDesc).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetIndustryDescDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.IndustryDesc == null || string.IsNullOrEmpty(x.IndustryDesc.Trim()) ? "UNKNOWN" : x.IndustryDesc).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetOccupationDescDropDown()
        {
            var distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.OccupationDesc == null || string.IsNullOrEmpty(x.OccupationDesc.Trim()) ? "UNKNOWN" : x.OccupationDesc).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetCaseTypeDropDown()
        {
            var distinct_value = _dbSrv.ECM.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE") && SANCTION_TYPES_FILTER.Contains(a.ValCd))
                .Select(x => x.ValDesc)
                .ToList();
            return distinct_value;

        }
        public List<string> GetAssessmentTypeDropDown()
        {
            var distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentTypeCd).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetRiskStatusDropDown()
        {
            var distinct_value = _dbSrv.KC.FskLovs
                 .Where(a => a.LovTypeName.StartsWith("RT_ASMT_STATUS"))
                 .Where(b => b.LovLanguageDesc.Contains("en")).Select(g => g.LovTypeDesc)
                 .ToList();
            return distinct_value;

        }
        public List<string> GetAssessmentCategoryCdDropDown()
        {
            var distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentCategoryCd).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetAssessmentSubCategoryCdDropDown()
        {
            var distinct_value = _dbSrv.KC.FskRiskAssessments.Select(x => x.AssessmentSubcategoryCd == null || string.IsNullOrEmpty(x.AssessmentSubcategoryCd.Trim()) ? "UNKNOWN" : x.AssessmentSubcategoryCd).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetSystemCaseStatusDropDown()
        {


            var distinct_value = _dbSrv.ECM.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS") && SANCTION_STATUS_FILTER.Contains(a.ValCd))
                //.Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                .Select(x => x.ValDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetTransDirectionDropDown()
        {
            var distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionDirection == null || string.IsNullOrEmpty(x.TransactionDirection.Trim()) || x.TransactionDirection.ToLower() == "null" ? "UNKNOWN" : x.TransactionDirection).Distinct()
                .Select(x => x.ToUpper() == "I" ? "InComing" : x.ToUpper() == "O" ? "OutGoing" : x)
           .ToList();
            return distinct_value;

        }
        public List<string> GetTransTypeDropDown()
        {
            var distinct_value = _dbSrv.ECM.CaseLives.Select(x => x.TransactionType == null || string.IsNullOrEmpty(x.TransactionType.Trim()) || x.TransactionType.ToLower() == "null" ? "UNKNOWN" : x.TransactionType).Distinct().ToList();
            return distinct_value;

        }
        public List<string> GetPriorityDropDown()
        {
            var distinct_value = _dbSrv.ECM.RefTableVals
               .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
               .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x => x.ValDesc)
               .ToList();
            return distinct_value;

        }

        public List<string> GetUserCaseStatusDropDown()
        {
            var distinct_value = _dbSrv.ECM.RefTableVals
                            .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                            .Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST")).Select(x => x.ValDesc)
                            .ToList();
            return distinct_value;

        }

        public List<string> GetReportstatuscodeDropDown()
        {
            var distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportStatusCode == null || string.IsNullOrEmpty(x.ReportStatusCode.Trim()) ? "UNKNOWN" : x.ReportStatusCode).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetReportTypeDropDown()
        {
            var distinct_value = _dbSrv.GOAML.Reports.Select(x => x.ReportCode == null || string.IsNullOrEmpty(x.ReportCode.Trim()) ? "UNKNOWN" : x.ReportCode).Distinct().ToList();
            return distinct_value;

        }
        public List<string> GetReportPriorityDropDown()
        {
            var distinct_value = _dbSrv.GOAML.Reports.Select(x => x.Priority == null || string.IsNullOrEmpty(x.Priority.Trim()) ? "UNKNOWN" : x.Priority).Distinct().ToList();
            return distinct_value;

        }

        public List<string> GetReportIndicatorDropDown()
        {
            var distinct_value = _dbSrv.GOAML.ReportIndicatorTypes.Select(x => x.Indicator == null || string.IsNullOrEmpty(x.Indicator.Trim()) ? "UNKNOWN" : x.Indicator).Distinct().ToList();
            return distinct_value;
        }



        public List<string> GetNonREntityBranchDropDown()
        {
            var distinct_value = _dbSrv.GOAML.Reports.Select(x => x.RentityBranch == null || string.IsNullOrEmpty(x.RentityBranch.Trim()) ? "UNKNOWN" : x.RentityBranch).Distinct().ToList();
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
            var distinct_value = _dbSrv.GOAML.Taccounts.Select(x => x.Branch == null || string.IsNullOrEmpty(x.Branch.Trim()) ? "UNKNOWN" : x.Branch).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetOwnerDropDown()
        {
            var distinct_value = _dbSrv.KC.FskCases.Select(x => x.OwnerUserLongId == null || string.IsNullOrEmpty(x.OwnerUserLongId.Trim()) ? "UNKNOWN" : x.OwnerUserLongId).Distinct().ToList();
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
            var distinct_value = _dbSrv.AUDIT.GroupDgs.Where(x => !string.IsNullOrEmpty(x.GroupType)).Select(x => x.GroupType).Distinct().ToList();
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
            var distinct_value = _dbSrv.CORE.FscPartyDims.Select(x => x.PartyIdentificationTypeDesc == null || string.IsNullOrEmpty(x.PartyIdentificationTypeDesc.Trim()) ? "UNKNOWN" : x.PartyIdentificationTypeDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUpdateUserIdDropDown()
        {
            var distinct_value = _dbSrv.ECM.CaseLives.Where(x => SANCTION_TYPES_FILTER.Contains(x.CaseTypeCd)).Select(x => x.UpdateUserId == null || string.IsNullOrEmpty(x.UpdateUserId.Trim()) ? "UNKNOWN" : x.UpdateUserId).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetInvestagtorDropDown()
        {
            var distinct_value = _dbSrv.ECM.CaseLives.Where(x => SANCTION_TYPES_FILTER.Contains(x.CaseTypeCd)).Select(x => x.PrimaryOwner == null || string.IsNullOrEmpty(x.PrimaryOwner.Trim()) ? "UNKNOWN" : x.PrimaryOwner).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetGroupAudNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.GroupDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserAudNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.UserDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetRoleAudNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.RoleDgAuds.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetGroupNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.GroupDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.UserDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetRoleNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.RoleDgs.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserAudTypeDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.UserDgAuds.Where(x => !string.IsNullOrEmpty(x.UserType)).Select(x => x.UserType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetMemberUsersDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.AccountAuds.Where(x => !string.IsNullOrEmpty(x.AuthenticationDomain)).Select(x => x.AuthenticationDomain).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetAppNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.AppName)).Select(x => x.AppName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDeviceNameDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.DeviceName)).Select(x => x.DeviceName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDeviceTypeDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.LoggedUserAuds.Where(x => !string.IsNullOrEmpty(x.DeviceType)).Select(x => x.DeviceType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetUserTypeDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.UserDgs.Where(x => !string.IsNullOrEmpty(x.UserType)).Select(x => x.UserType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetRoleTypeDropDown()
        {
            var distinct_value = _dbSrv.AUDIT.RoleDgs.Where(x => !string.IsNullOrEmpty(x.RoleType)).Select(x => x.RoleType).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioCategoryDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioStatusDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_STATUS") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGProductTypeDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("PRODUCT_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioTypeDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioFrequencyDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("SCENARIO_FREQUENCY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGObjectLevelDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("OBJECT_LEVEL") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGAlarmTypeDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_TYPE") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGAlarmCategoryDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_CATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGAlarmSubcategoryDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcLkpTables.Where(x => x.LkpName.StartsWith("ALARM_SUBCATEGORY") && x.LkpLangDesc.Contains("en")).Select(x => x.LkpValDesc).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGCreateUserIdDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcScenarioEvents.Select(x => x.CreateUserId).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGScenarioNameDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcRoutines.Select(x => x.RoutineName).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGRiskFactDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcRoutines.Where(x=> !string.IsNullOrEmpty(x.RiskFactInd)).Select(x => x.RiskFactInd).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetDGBranchNameDropDown()
        {
            var distinct_value = _dbSrv.DGAML.Accounts.Where(x=> !string.IsNullOrEmpty(x.AcctPrimBranchName)).Select(x => x.AcctPrimBranchName).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGProfileRiskDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.RiskScoreCd)).Select(x => x.RiskScoreCd).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGOwnerDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcSuspectedObjects.Where(x => !string.IsNullOrEmpty(x.OwnerUid)).Select(x => x.OwnerUid).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGPoliticalExpPrsnIndDropDown()
        {
            var distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.PoliticalExpPrsnInd)).Select(x => x.PoliticalExpPrsnInd).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGRiskClassificationDropDown()
        {
            var distinct_value = _dbSrv.DGAML.Customers.Where(x => x.RiskClass != null).Select(x => x.RiskClass.ToString()).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGCitizenCountryNameDropDown()
        {
            var distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.CitizenCntryName)).Select(x => x.CitizenCntryName).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGCustIdentTypeDescDropDown()
        {
            var distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.CustIdentTypeDesc)).Select(x => x.CustIdentTypeDesc).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGOccupDescDropDown()
        {
            var distinct_value = _dbSrv.DGAML.Customers.Where(x => !string.IsNullOrEmpty(x.OccupDesc)).Select(x => x.OccupDesc).Distinct().ToList();
            return distinct_value;
        }
        public List<string> GetDGRoutineCreateUserIdDropDown()
        {
            var distinct_value = _dbSrv.DGAML.AcRoutines.Where(x => !string.IsNullOrEmpty(x.CreateUserId)).Select(x => x.CreateUserId).Distinct().ToList();
            return distinct_value;
        }
    }
}
