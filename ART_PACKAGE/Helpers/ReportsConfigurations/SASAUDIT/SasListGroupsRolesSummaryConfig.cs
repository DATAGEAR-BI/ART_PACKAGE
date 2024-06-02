using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SasListGroupsRolesSummaryConfig : ReportConfig
    {
        public SasListGroupsRolesSummaryConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
               { "Groups", new GridColumnConfiguration { DisplayName = "Groups", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
               { "Roles", new GridColumnConfiguration { DisplayName = "Roles", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }}
            };

        }
    }
}
