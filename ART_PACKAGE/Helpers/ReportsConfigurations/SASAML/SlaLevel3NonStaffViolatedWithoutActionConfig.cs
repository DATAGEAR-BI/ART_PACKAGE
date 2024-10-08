using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class slalevel3nonstaffviolatedwithoutactionConfig : ReportConfig
    {
        public slalevel3nonstaffviolatedwithoutactionConfig()
        {
            SkipList = new List<string>() { /* Add properties to skip here */ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "CaseCloseDate", new GridColumnConfiguration { DisplayName = "Case Close Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } }
            };
        }
    }
}
