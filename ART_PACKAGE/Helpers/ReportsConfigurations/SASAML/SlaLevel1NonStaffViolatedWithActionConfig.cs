using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaLevel1NonStaffViolatedWithActionConfig : ReportConfig
    {

        public SlaLevel1NonStaffViolatedWithActionConfig()
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
            ReportTitle = "SAS NonStaff SLA Closed Level1 Report";
            ReportDescription = "Presents all AML closed alerts which exceeded the threshold for first routing alerts to level2 for non - staff customers";
        }


    }
}
