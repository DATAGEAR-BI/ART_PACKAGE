using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStAmlAlertAgeSummeryConfig : ReportConfig
    {
        public ArtStAmlAlertAgeSummeryConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "DataSource", new GridColumnConfiguration { DisplayName = "Data Source" } },
                { "Bucket1", new GridColumnConfiguration { DisplayName = "Bucket 1" } },
                { "Bucket2", new GridColumnConfiguration { DisplayName = "Bucket 2" } },
                { "Bucket3", new GridColumnConfiguration { DisplayName = "Bucket 3" } },
                { "Bucket4", new GridColumnConfiguration { DisplayName = "Bucket 4" } },
                { "Total", new GridColumnConfiguration { DisplayName = "Total" } },
                { "RISK_APPETITE", new GridColumnConfiguration { DisplayName = "Risk Appetite" } }
            };

        }
    }
}
