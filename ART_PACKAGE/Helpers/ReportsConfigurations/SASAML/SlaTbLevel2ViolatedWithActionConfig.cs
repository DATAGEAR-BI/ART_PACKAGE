using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaTbLevel2ViolatedWithActionConfig : ReportConfig
    {
        public SlaTbLevel2ViolatedWithActionConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "DisplayName", new GridColumnConfiguration { DisplayName = "Display Name" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } },
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status" } },
                { "LastActionDate", new GridColumnConfiguration { DisplayName = "Last Action Date" } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
            };
            ReportTitle = "Closed Level 2 (Checker)";
            ReportDescription = "Presents all TB AML closed alerts which exceeded the threshold for closed alerts or add to\r\n            case with below information.";

        }
    }
}
