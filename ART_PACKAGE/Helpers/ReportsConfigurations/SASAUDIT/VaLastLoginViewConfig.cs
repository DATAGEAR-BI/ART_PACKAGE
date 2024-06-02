using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class VaLastLoginViewConfig : ReportConfig
    {
        public VaLastLoginViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "Username", new GridColumnConfiguration { DisplayName = "Username", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Appname", new GridColumnConfiguration { DisplayName = "App Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Logindatetime", new GridColumnConfiguration { DisplayName = "Login DateTime", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Logindate", new GridColumnConfiguration { DisplayName = "Login Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Status", new GridColumnConfiguration { DisplayName = "Status", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }}
            };
        }
    }
}
