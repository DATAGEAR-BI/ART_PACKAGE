using ART_PACKAGE.Helpers.DBService;

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
            throw new NotImplementedException();
        }

        public List<string> GetAppLebalDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAppnameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAppNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAssessmentCategoryCdDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAssessmentSubCategoryCdDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAssessmentTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetBranchIDDropDown()
        {
            List<string?> distinct_value = _dbSrv.ECM.CaseLives.Where(x => x.Behalfofbranch != null).Select(x => x.Behalfofbranch).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetBranchNameDropDown()
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

        public List<string> GetCaseCategoryDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCasePriorityDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCaseStatusDropDown()
        {
            return _dbSrv.ECM.CaseLives.Where(x => x.CaseStatCd != null).Select(x => x.CaseStatCd).Distinct().ToList();
        }

        public List<string> GetCaseSubCategoryDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCaseTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCheckerCreatedByDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCheckerEventNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCitizenshipCountryNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCustomerIdentificationTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCustomerNameDropDown()
        {
            return _dbSrv.ECM.CaseLives.Where(x => x.Applicantname != null).Select(x => x.Applicantname).Distinct().ToList();
        }

        public List<string> GetDeviceNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDeviceTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGAlarmCategoryDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGAlarmSubcategoryDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGAlarmTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGBranchNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCitizenCountryNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCitizenshipCountryNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCityNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCreateUserIdDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCustIdentTypeDescDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCustomerIdentificationTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGCustomerTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGExternalCustomerBranchNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGObjectLevelDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGOccupDescDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGOwnerDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGParmTypeDescDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGParmValueDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGPoliticalExpPrsnIndDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGProductTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGProfileRiskDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGresidenceCountryNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGRiskClassificationDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGRiskFactDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGRoutineCreateUserIdDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGScenarioCategoryDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGScenarioFrequencyDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGScenarioNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGScenarioStatusDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGScenarioTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetDGStreetCountryNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetECMREFERNCEDropDown()
        {
            return _dbSrv.ECM.CaseLives.Where(x => x.CaseId != null).Select(x => x.CaseId).Distinct().ToList();
        }

        public List<string> GetEntityLevelDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupAudNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupRoleNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupsDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetIndustryDescDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetInvestagtorDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMakerCreatedByDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMakerEventNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMemberUsersDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetNonREntityBranchDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetOccupationDescDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetOwnerDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPartyIdentificationTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPartyTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPriorityDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetProductDropDown()
        {
            return _dbSrv.ECM.RefTableVals.Where(x => x.ValDesc != null && x.RefTableName == "ABK_FTI_PRODUCT").Select(x => x.ValDesc).Distinct().ToList();
        }

        public List<string> GetProductTypeDropDown()
        {
            return _dbSrv.ECM.RefTableVals.Where(x => x.ValDesc != null && x.RefTableName == "ABK_FTI_PRODUCT_TYPE").Select(x => x.ValDesc).Distinct().ToList();
        }

        public List<string> GetProTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetReportAcctBranchDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetReportIndicatorDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetReportPriorityDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetReportstatuscodeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetReportTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetResidenceCountryNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRiskClassificationDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRiskStatusDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRoleAudNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRoleNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRolesDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRoleTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetScenarioNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetSystemCaseStatusDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTransDirectionDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTransTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUpdateUserIdDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUserAudNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUserAudTypeDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUserCaseStatusDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUsernameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUserNameDropDown()
        {
            throw new NotImplementedException();
        }

        public List<string> GetUserTypeDropDown()
        {
            throw new NotImplementedException();
        }
    }
}
