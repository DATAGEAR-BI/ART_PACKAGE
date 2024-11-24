using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCrpSystemPerformanceConfig : ReportConfig
    {
        public ArtCrpSystemPerformanceConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            { { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" }},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type" }},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" }},
                    { "CreateUserId", new GridColumnConfiguration { DisplayName = "Create User ID" }},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" }},
                    { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name" }},
                    { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number" }},
                    { "CaseCurrentRate", new GridColumnConfiguration { DisplayName = "Case Current Rate" }},
                    { "Casetargetrate", new GridColumnConfiguration { DisplayName = "Case Target Rate" }},
                    { "EcmLastStatusDate", new GridColumnConfiguration { DisplayName = "Ecm Last Status Date" }},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds" }},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes" }},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours" }},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days" }} };
            SkipList = new List<string> { "CaseCurrentRate", "Casetargetrate" };
            ReportTitle = "CRP System Performance Details";
        }

    }
}
