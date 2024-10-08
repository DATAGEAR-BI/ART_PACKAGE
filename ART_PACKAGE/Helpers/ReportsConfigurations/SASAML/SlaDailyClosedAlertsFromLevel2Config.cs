using Data.Services.Grid;
using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class sladailyclosedalertsfromlevel2Config : ReportConfig
    {
        public sladailyclosedalertsfromlevel2Config()
        {
            SkipList = new List<string>() { /* Add properties to skip here */ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "EntityNumber", new GridColumnConfiguration { DisplayName = "Entity Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "EntityName", new GridColumnConfiguration { DisplayName = "Entity Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AssignedDate", new GridColumnConfiguration { DisplayName = "Assigned Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "LastActionDate", new GridColumnConfiguration { DisplayName = "Last Action Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
                { "LevelOfRisk", new GridColumnConfiguration { DisplayName = "Level Of Risk", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } }
            };
        }
    }
}
