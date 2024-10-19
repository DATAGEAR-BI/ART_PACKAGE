using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaLevel2NonStaffViolatedWithActionConfig : ReportConfig
    {

        public SlaLevel2NonStaffViolatedWithActionConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status" } },
                { "LastActionDate", new GridColumnConfiguration { DisplayName = "Last Action Date" } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } }
            };
            ReportTitle = "SAS NonStaff SLA Closed Level2 Report";
            ReportDescription = "Presents all AML closed alerts which exceeded the threshold for closing alerts or add to case for non - staff customers";
        }


    }
}
