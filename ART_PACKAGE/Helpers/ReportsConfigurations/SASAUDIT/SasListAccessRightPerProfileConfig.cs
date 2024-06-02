using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SasListAccessRightPerProfileConfig : ReportConfig
    {
        public SasListAccessRightPerProfileConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
               { "GroupName", new GridColumnConfiguration { DisplayName = "Group Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "GroupDescription", new GridColumnConfiguration { DisplayName = "Group Description", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Grouptype", new GridColumnConfiguration { DisplayName = "Group Type", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "CapabilityId", new GridColumnConfiguration { DisplayName = "Capability ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "CapabilitiyGroupName", new GridColumnConfiguration { DisplayName = "Capability Group Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "CapName", new GridColumnConfiguration { DisplayName = "Capability Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "ComponentName", new GridColumnConfiguration { DisplayName = "Component Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }}
            };

        }
    }
}
