using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_UNUSAL_ACTIVITIESConfig:ReportConfig
    {

        public ART_ST_YEARLY_UNUSAL_ACTIVITIESConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "NUMBER_OF_ALERTS", new GridColumnConfiguration { DisplayName = "Number Of Alerts" } },
                { "TYPE_OF_ACTIVITY", new GridColumnConfiguration { DisplayName = "Type of Acivity" } }
            };
        }
    }
}
