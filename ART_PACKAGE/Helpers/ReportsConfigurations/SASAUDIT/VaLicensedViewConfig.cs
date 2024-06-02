using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class VaLicensedViewConfig : ReportConfig
    {

        public VaLicensedViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                { "AppLebal", new GridColumnConfiguration { DisplayName = "App Label", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "BeginDate", new GridColumnConfiguration { DisplayName = "Begin Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "ProType", new GridColumnConfiguration { DisplayName = "Pro Type", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Fmtname", new GridColumnConfiguration { DisplayName = "Format Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "ProStart", new GridColumnConfiguration { DisplayName = "Pro Start", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
                { "Diedate", new GridColumnConfiguration { DisplayName = "Die Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }}
            };

        }
    }
}
