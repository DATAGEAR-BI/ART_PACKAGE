using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SasListAccessUsersGroupsCapConfig : ReportConfig
    {
        public SasListAccessUsersGroupsCapConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "DisplayName", new GridColumnConfiguration { DisplayName = "Display Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Ggroup", new GridColumnConfiguration { DisplayName = "Group", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Rrole", new GridColumnConfiguration { DisplayName = "Role", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Capabilities", new GridColumnConfiguration { DisplayName = "Capabilities", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }}
            };
        }
    }
}
