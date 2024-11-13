using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaClosedAlertsExceeded45DayConfig : ReportConfig
    {

        public SlaClosedAlertsExceeded45DayConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "TotalInvestigationDays", new GridColumnConfiguration { DisplayName = "Total Investigation Days" } },
                { "UserLevel3", new GridColumnConfiguration { DisplayName = "User Level 3" } },
                { "CaseCloseDate", new GridColumnConfiguration { DisplayName = "Case Close Date" } },
                { "InvestigationDaysLevel3", new GridColumnConfiguration { DisplayName = "Investigation Days Level 3" } },
                { "EntityNumber", new GridColumnConfiguration { DisplayName = "Entity Number" } },
                { "EntityName", new GridColumnConfiguration { DisplayName = "Entity Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk" } },
                { "UserLevel1", new GridColumnConfiguration { DisplayName = "User Level 1" } },
                { "AlertCreateDate", new GridColumnConfiguration { DisplayName = "Alert Create Date" } },
                { "RoutingDate", new GridColumnConfiguration { DisplayName = "Routing Date" } },
                { "UserLevel2", new GridColumnConfiguration { DisplayName = "User Level 2" } },
                { "AddToCaseDate", new GridColumnConfiguration { DisplayName = "Add To Case Date" } },
                { "InvestigationDaysLevel2", new GridColumnConfiguration { DisplayName = "Investigation Days Level 2" } },
                { "InvestigationDaysLevel1", new GridColumnConfiguration { DisplayName = "Investigation Days Level 1" } },
                { "UserLevel1ID", new GridColumnConfiguration { DisplayName = "User Level 1 ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "UserLevel2ID", new GridColumnConfiguration { DisplayName = "User Level 2 ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "UserLevel3ID", new GridColumnConfiguration { DisplayName = "User Level 3 ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },

            };
        }


    }
}
