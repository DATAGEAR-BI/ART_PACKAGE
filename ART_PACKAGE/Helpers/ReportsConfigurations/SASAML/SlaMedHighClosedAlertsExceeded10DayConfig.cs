using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class slamedhighclosedalertsexceeded10dayConfig : ReportConfig
    {
        public slamedhighclosedalertsexceeded10dayConfig()
        {
            SkipList = new List<string>() { /* Add properties to skip here */ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "EntityNumber", new GridColumnConfiguration { DisplayName = "Entity Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "EntityName", new GridColumnConfiguration { DisplayName = "Entity Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "UserLevel1", new GridColumnConfiguration { DisplayName = "User Level 1", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertCreateDate", new GridColumnConfiguration { DisplayName = "Alert Create Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "RoutingDate", new GridColumnConfiguration { DisplayName = "Routing Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "InvestigationDaysLevel1", new GridColumnConfiguration { DisplayName = "Investigation Days Level 1", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "UserLevel2", new GridColumnConfiguration { DisplayName = "User Level 2", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "LastActionDate", new GridColumnConfiguration { DisplayName = "Last Action Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "InvestigationDaysLevel2", new GridColumnConfiguration { DisplayName = "Investigation Days Level 2", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "TotalInvestigationDays", new GridColumnConfiguration { DisplayName = "Total Investigation Days", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } }
            };
        }
    }
}
