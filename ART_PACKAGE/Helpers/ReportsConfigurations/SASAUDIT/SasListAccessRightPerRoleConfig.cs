using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SasListAccessRightPerRoleConfig : ReportConfig
    {
        public SasListAccessRightPerRoleConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "Role", new GridColumnConfiguration { DisplayName = "Role", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "RoleDescription", new GridColumnConfiguration { DisplayName = "Role Description", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "CapabilityId", new GridColumnConfiguration { DisplayName = "Capability ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "CapName", new GridColumnConfiguration { DisplayName = "Capability Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "CapabilitiyGroupName", new GridColumnConfiguration { DisplayName = "Capability Group Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "ComponentName", new GridColumnConfiguration { DisplayName = "Component Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }}
            };

        }
    }
}
