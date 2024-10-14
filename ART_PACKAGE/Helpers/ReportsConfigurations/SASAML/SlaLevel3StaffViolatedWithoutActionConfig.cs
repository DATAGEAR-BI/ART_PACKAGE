using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaLevel3StaffViolatedWithoutActionConfig : ReportConfig
    {
        public SlaLevel3StaffViolatedWithoutActionConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date" } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status" } },
                { "AlertCloseDate", new GridColumnConfiguration { DisplayName = "Alert Close Date" } },
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" } },
                { "CaseCloseDate", new GridColumnConfiguration { DisplayName = "Case Close Date" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
            };
            ReportTitle = "SAS AML Staff SLA Report";

        }
    }
}
