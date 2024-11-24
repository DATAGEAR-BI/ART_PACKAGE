using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCrpUserPerformanceConfig : ReportConfig
    {
        public ArtCrpUserPerformanceConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                    { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User ID"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "AsssignedTime", new GridColumnConfiguration { DisplayName = "Assigned Time"}},
                    { "ActionUser", new GridColumnConfiguration { DisplayName = "Action User"}},
                    { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name"}},
                    { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number"}},
                    { "CaseCurrentRate", new GridColumnConfiguration { DisplayName = "Case Current Rate"}},
                    { "Casetargetrate", new GridColumnConfiguration { DisplayName = "Case Target Rate"}},
                    { "Action", new GridColumnConfiguration { DisplayName = "Action"}},
                    { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date"}},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}}
            };
            SkipList = new List<string> { "CaseCurrentRate", "Casetargetrate" };
            ReportTitle = "CRP User Performance Details";
        }
    }
}
