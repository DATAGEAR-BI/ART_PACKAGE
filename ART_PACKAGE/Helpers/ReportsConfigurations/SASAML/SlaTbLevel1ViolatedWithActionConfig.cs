using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaTbLevel1ViolatedWithActionConfig : ReportConfig
    {

        public SlaTbLevel1ViolatedWithActionConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "RoutingDate", new GridColumnConfiguration { DisplayName = "Routing Date" } },
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } },
                { "DisplayName", new GridColumnConfiguration { DisplayName = "Display Name" } },

            };
            ReportTitle = "Closed Level 1 (Maker)";
            ReportDescription = "Presents all AML closed alerts which exceeded the threshold for first routing alerts to level2 for non - staff customers";
        }


    }
}
