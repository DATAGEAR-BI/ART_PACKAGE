using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtUserPerformanceConfig : ReportConfig
    {
        public ArtUserPerformanceConfig()
        {
            SkipList = new List<string>() { "CaseRk", "ValidFromDate" };
            defaultSortOption = new() { field = "CaseId", dir = "asc" };
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
                                                        {
                                                                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                                                                { "CaseTypeCd", new GridColumnConfiguration { DisplayName = "Case Type"}},
                                                                { "CaseDesc", new GridColumnConfiguration { DisplayName = "Case Description"}},
                                                                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                                                                { "Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                                                                { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                                                                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                                                                { "UpdateUserId", new GridColumnConfiguration { DisplayName = "Updated By"}},
                                                                { "CreateUserId", new GridColumnConfiguration { DisplayName = "Created By"}},
                                                                { "AsssignedTime", new GridColumnConfiguration { DisplayName = "Assigned Time"}},
                                                                { "ActionUser", new GridColumnConfiguration { DisplayName = "Action User"}},
                                                                { "Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                                                { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date"}},
                                                                { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                                                                { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                                                                { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                                                                { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}}
                                                        };
            ReportTitle = "User Performance Report";
            ReportDescription = "This report presents all sanction closed and terminated cases without the manually closed cases with the related information on user level as below";

        }
    }
}
