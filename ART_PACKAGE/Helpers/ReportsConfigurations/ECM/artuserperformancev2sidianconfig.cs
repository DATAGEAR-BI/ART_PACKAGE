using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artuserperformancev2sidianconfig : ReportConfig
    {
        public artuserperformancev2sidianconfig()
        {
            SkipList = new List<string>() {  };
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
                                                        {
                                                                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                                                                { "CaseTypeCd", new GridColumnConfiguration { DisplayName = "Case Type"}},
                                                                { "CaseDesc", new GridColumnConfiguration { DisplayName = "Case Description"}},
                                                                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                                                                { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                                                                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                                                                { "UpdateUserId", new GridColumnConfiguration { DisplayName = "Updated By"}},
                                                                { "AsssignedTime", new GridColumnConfiguration { DisplayName = "Assigned Time"}},
                                                                { "ActionUser", new GridColumnConfiguration { DisplayName = "Action User"}},
                                                                { "Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                                                { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date"}},
                                                                { "CaseRk", new GridColumnConfiguration { DisplayName = "Case Rk"}},
                                                                { "ValidFromDate", new GridColumnConfiguration { DisplayName = "Valid From Date"}},
                                                                { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User ID"}},
                                                        };
            ReportTitle = "User Performance V2 Report";
            ReportDescription = "This report presents all sanction closed and terminated cases without the manually closed cases with the related information on user level as below";

        }
    }
}
