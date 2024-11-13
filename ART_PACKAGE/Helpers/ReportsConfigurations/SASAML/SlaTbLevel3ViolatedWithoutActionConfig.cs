using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaTbLevel3ViolatedWithoutActionConfig : ReportConfig
    {
        public SlaTbLevel3ViolatedWithoutActionConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "DisplayName", new GridColumnConfiguration { DisplayName = "Display Name" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } },
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date" } },
                { "CaseCloseDate", new GridColumnConfiguration { DisplayName = "Case Close Date" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
                { "CaseStatusCode", new GridColumnConfiguration { DisplayName = "Case Status Code" } },
            };
            ReportTitle = "SLA TB Level 3 (Compliance Checker Group)";
            ReportDescription = "Presents all AML alerts which exceeded the threshold for not closed cases\r\n            for non-staff customers with below information.";
        }
    }
}
