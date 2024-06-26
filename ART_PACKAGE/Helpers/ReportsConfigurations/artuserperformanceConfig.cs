using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artuserperformanceconfig : ReportConfig
    {
        public artuserperformanceconfig()
        {
            SkipList = new List<string>() { "CaseRk"};
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
                                                        {
                                                                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                                                                { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                                                                { "CaseDescription", new GridColumnConfiguration { DisplayName = "Case Description"}},
                                                                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                                                                { "Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                                                                { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number"}},
                                                                { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name"}},
                                                                { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                                                                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                                                                { "CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                                                                { "UpdatedBy", new GridColumnConfiguration { DisplayName = "Updated By"}},
                                                                { "AsssignedTime", new GridColumnConfiguration { DisplayName = "Assigned Time"}},
                                                                { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date"}},
                                                                { "ActionUser", new GridColumnConfiguration { DisplayName = "Action User"}},
                                                                { "Action", new GridColumnConfiguration { DisplayName = "Action"}},
                                                                { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                                                                { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                                                                { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                                                                { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}},
                                                        };
            ReportTitle = "User Performance Report";
            ReportDescription = "This report presents all sanction closed and terminated cases without the manually closed cases with the related information on user level as below";

        }
    }
}
