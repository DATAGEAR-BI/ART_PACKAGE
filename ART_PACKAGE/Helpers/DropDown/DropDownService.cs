using Data.DGECM;
using Data.FCF71;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ART_PACKAGE.Helpers.DropDown
{
    public class DropDownService : IDropDownService
    {
        private readonly IDbService _dbSrv;

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
            var distinct_value = dbfcfcore.PartyTypeMatviews.Select(x => x.CustomerType).ToList();
            return distinct_value;
        }

        public List<string> GetScenarioNameDropDown()
        {
            //var distinct_value = dbfcfcore.ScenarioNmMatviews.Select(x => x.ScenarioName).ToList();
            //return distinct_value;

            var distinct_value = _dbSrv.KC.FskScenarios.Where(x => x.CurrentInd.Contains("Y")).Select(x => x.ScenarioName).ToList();
            return distinct_value;
        }

        public List<string> GetBranchNameDropDown()
        {
            var distinct_value = dbfcfcore.FscBranchDims
               .Where(a => a.ChangeCurrentInd.Contains("Y"))
               .Where(b => b.BranchTypeDesc.Contains("BRANCH")).Select(x => x.BranchName)
               .ToList();
            return distinct_value;

        }
        public List<string> GetOwnerDropDown()
        {
            var distinct_value = dbcmcaudit.VaPersonInfos.GroupBy(s => s.Name).Select(g => g.Key).ToList();
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
            var distinct_value = dbfcfcore.ResidenceCountryMatviews.Select(x => x.ResidenceCountryName).ToList();
            return distinct_value;

        }

        public List<string> GetCitizenshipCountryNameDropDown()
        {
            var distinct_value = dbfcfcore.CitizenshipCountryMatviews.Select(x => x.CitizenshipCountryName).ToList();
            return distinct_value;

        }

        public List<string> GetCustomerIdentificationTypeDropDown()
        {
            var distinct_value = dbfcfcore.PartyIdentificationTypeDescs.Select(x => x.PartyIdentificationTypeDesc1).ToList();
            return distinct_value;

        }

        public List<string> GetIndustryDescDropDown()
        {
            var distinct_value = dbfcfcore.IndustryDescMatviews.Select(x => x.IndustryDesc).ToList();
            return distinct_value;

        }

        public List<string> GetOccupationDescDropDown()
        {
            var distinct_value = dbfcfcore.OccupationDescMatviews.Select(x => x.OccupationDesc).ToList();
            return distinct_value;
        }
        public List<string> GetCaseTypeDropDown()
        {
            var distinct_value = dbdgcmgmt.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_TYPE"))
                .Where(b => b.DisplayOrdrNo == 0 || b.DisplayOrdrNo == 5).Select(x => x.ValDesc)
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
            var distinct_value = _dbSrv.KC.FskRiskAssessments.GroupBy(s => s.AssessmentSubcategoryCd).Select(g => g.Key).ToList();
            return distinct_value;

        }

        public List<string> GetSystemCaseStatusDropDown()
        {
            var distinct_value = dbdgcmgmt.RefTableVals
                .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                //.Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST"))
                .Where(b => b.DisplayOrdrNo == 0).Select(x => x.ValDesc)
                .ToList();
            return distinct_value;

        }

        public List<string> GetTransDirectionDropDown()
        {
            var distinct_value = dbdgcmgmt.TransDirectionVals.GroupBy(s => s.TransDirection).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetTransTypeDropDown()
        {
            var distinct_value = dbdgcmgmt.TransTypeVals.GroupBy(s => s.TransactionType).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetPriorityDropDown()
        {
            var distinct_value = dbdgcmgmt.RefTableVals
               .Where(a => a.RefTableName.StartsWith("X_RT_PRIORITY"))
               .Where(b => b.ValDesc.Equals("High") || b.ValDesc.Equals("Low") || b.ValDesc.Equals("Medium")).Select(x => x.ValDesc)
               .ToList();
            return distinct_value;

        }

        public List<string> GetUserCaseStatusDropDown()
        {
            var distinct_value = dbdgcmgmt.RefTableVals
                            .Where(a => a.RefTableName.StartsWith("RT_CASE_STATUS"))
                            .Where(b => b.ValCd.Equals("SC") || b.ValCd.Equals("ST")).Select(x => x.ValDesc)
                            .ToList();
            return distinct_value;

        }


        public List<string> GetReportstatuscodeDropDown()
        {
            var distinct_value = dbgoaml.GoamlReportStatusMatviews.GroupBy(s => s.ReportStatus).Select(g => g.Key).ToList();
            return distinct_value;

        }

        public List<string> GetReportTypeDropDown()
        {
            var distinct_value = dbgoaml.GoamlReportTypeMatviews.GroupBy(s => s.Reporttype).Select(g => g.Key).ToList();
            return distinct_value;

        }
        public List<string> GetReportPriorityDropDown()
        {
            var distinct_value = dbgoaml.GoamlReportPriorityMatviews.GroupBy(s => s.ReportPriority).Select(g => g.Key).ToList();
            return distinct_value;

        }

        public List<string> GetReportIndicatorDropDown()
        {
            var distinct_value = dbgoaml.ArtGoamlIndicatorFilterViews.GroupBy(s => s.Indicator).Select(g => g.Key).ToList();
            return distinct_value;
        }



        public List<string> GetNonREntityBranchDropDown()
        {
            var distinct_value = dbgoaml.GoamlReportEntitybranchMatviews.GroupBy(s => s.Rentitybranch).Select(g => g.Key).ToList();
            return distinct_value;

        }

        public List<string> GetReportAcctBranchDropDown()
        {
            var distinct_value = dbgoaml.GoamlReportAcctBranchMatviews.GroupBy(s => s.Branch).Select(g => g.Key).ToList();
            return distinct_value;

        }

        public List<string> GetAppLebalDropDown()
        {
            var distinct_value = dbcmcaudit.VaLicenseds.GroupBy(s => s.AppLebal).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;

        }
        public List<string> GetProTypeDropDown()
        {
            var distinct_value = dbcmcaudit.VaLicenseds.GroupBy(s => s.ProType).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;

        }
        public List<string> GetGroupTypeDropDown()
        {
            var distinct_value = dbcmcaudit.ListAccessRightPerProfiles.GroupBy(s => s.Grouptype).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetGroupsDropDown()
        {
            var distinct_value = dbcmcaudit.VaGroupInfos
                .Where(a => a.Grouptype.StartsWith("Group")).Select(s => s.Name)
                .OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetGroupRoleNameDropDown()
        {
            var distinct_value = dbcmcaudit.ListAccessRightPerProfiles.GroupBy(s => s.GroupName).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetRolesDropDown()
        {
            var distinct_value = dbcmcaudit.VaGroupInfos
                .Where(a => a.Grouptype.StartsWith("Role") || a.Grouptype.StartsWith("ROLE")).Select(g => g.Name)
                .OrderBy(s => s).ToList();
            return distinct_value;

        }
        public List<string> GetCapabilityGroupDropDown()
        {
            var distinct_value = dbcmcaudit.VaUsercapabilities.GroupBy(s => s.CapabilitiyGroupName).Select(g => g.Key)
                .OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetCapabilityNameDropDown()
        {
            var distinct_value = dbcmcaudit.VaUsercapabilities.GroupBy(s => s.CapName).Select(g => g.Key)
                .OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetUsernameDropDown()
        {
            var distinct_value = dbcmcaudit.VaLastLogins.GroupBy(s => s.Username).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetAppnameDropDown()
        {
            var distinct_value = dbcmcaudit.VaLastLogins.GroupBy(s => s.Appname).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }


        public List<string> GetMakerEventNameDropDown()
        {
            var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => a.EnventName.Contains("Waiting")).GroupBy(s => s.EnventName).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }
        public List<string> GetCheckerEventNameDropDown()
        {
            var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => !a.EnventName.Contains("Waiting")).GroupBy(s => s.EnventName).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }

        public List<string> GetMakerCreatedByDropDown()
        {
            var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => a.EnventName.Contains("Waiting")).GroupBy(s => s.Createdby).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }

        public List<string> GetCheckerCreatedByDropDown()
        {
            var distinct_value = dbdgsmcaudit.CheckereventAuds.Where(a => !a.EnventName.Contains("Waiting")).GroupBy(s => s.Createdby).Select(g => g.Key).OrderBy(s => s).ToList();
            return distinct_value;
        }
    }
}
