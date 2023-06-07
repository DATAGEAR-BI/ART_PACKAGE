using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.DropDown
{
    public interface IDropDownService
    {
        public List<string> GetAlertStatusDropDown();
        public List<string> GetPartyTypeDropDown();
        public List<string> GetScenarioNameDropDown();
        public List<string> GetBranchNameDropDown();
        public List<string> GetOwnerDropDown();
        public List<string> GetCasePriorityDropDown();
        public List<string> GetCaseStatusDropDown();
        public List<string> GetCaseCategoryDropDown();
        public List<string> GetCaseSubCategoryDropDown();
        public List<string> GetEntityLevelDropDown();
        public List<string> GetRiskClassificationDropDown();
        public List<string> GetCaseTypeDropDown();
        public List<string> GetResidenceCountryNameDropDown();
        public List<string> GetIndustryDescDropDown();
        public List<string> GetCustomerIdentificationTypeDropDown();
        public List<string> GetOccupationDescDropDown();
        public List<string> GetCitizenshipCountryNameDropDown();
        public List<string> GetAssessmentTypeDropDown();
        public List<string> GetRiskStatusDropDown();
        public List<string> GetAssessmentCategoryCdDropDown();
        public List<string> GetAssessmentSubCategoryCdDropDown();
        public List<string> GetSystemCaseStatusDropDown();
        public List<string> GetTransDirectionDropDown();
        public List<string> GetTransTypeDropDown();
        public List<string> GetPriorityDropDown();
        public List<string> GetUserCaseStatusDropDown();

        public List<string> GetReportstatuscodeDropDown();

        public List<string> GetReportTypeDropDown();
        public List<string> GetReportPriorityDropDown();
        public List<string> GetNonREntityBranchDropDown();
        public List<string> GetReportAcctBranchDropDown();
        public List<string> GetAppLebalDropDown();
        public List<string> GetProTypeDropDown();
        public List<string> GetGroupTypeDropDown();
        public List<string> GetGroupsDropDown();
        public List<string> GetGroupRoleNameDropDown();
        public List<string> GetRolesDropDown();
        public List<string> GetCapabilityGroupDropDown();
        public List<string> GetCapabilityNameDropDown();
        public List<string> GetUsernameDropDown();
        public List<string> GetAppnameDropDown();

        public List<string> GetReportIndicatorDropDown();

        public List<string> GetMakerEventNameDropDown();
        public List<string> GetCheckerEventNameDropDown();

        public List<string> GetMakerCreatedByDropDown();

        public List<string> GetCheckerCreatedByDropDown();

    }
}
