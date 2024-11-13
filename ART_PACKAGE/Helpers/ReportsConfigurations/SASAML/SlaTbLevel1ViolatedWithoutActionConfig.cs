using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaTbLevel1ViolatedWithoutActionConfig : ReportConfig
    {
        public SlaTbLevel1ViolatedWithoutActionConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "DisplayName", new GridColumnConfiguration { DisplayName = "Display Name" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date" } },
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } },
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
            };
            ReportTitle = "SLA TB Level 1 (Maker)";
            ReportDescription = "Presents all TB AML alerts which exceeded the threshold for first manual routing alerts to\r\n            level 2 (Checker) with below information.";
        }
    }
}
