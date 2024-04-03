using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtTradeBaseSummaryConfig : ReportConfig
    {
        public ArtTradeBaseSummaryConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    {"EntityNumber", new GridColumnConfiguration { DisplayName ="Entity Number"}},
                    {"EntityName", new GridColumnConfiguration { DisplayName ="Entity Name"}},
                    {"Active", new GridColumnConfiguration { DisplayName ="Active"}},
                    {"AddedToCase", new GridColumnConfiguration { DisplayName ="Added To Case"}},
                    {"Closed", new GridColumnConfiguration { DisplayName ="Closed"}},
                    {"SuppressedAlert", new GridColumnConfiguration { DisplayName ="Suppressed Alert"}},

            };
        }
    }
}
