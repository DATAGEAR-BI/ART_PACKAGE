using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStMakerCheckerPerformenceSummaryConfig : ReportConfig
    {
        public ArtStMakerCheckerPerformenceSummaryConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "PROGRAM", new GridColumnConfiguration { DisplayName = "Program"}},
                    { "CASE_USER", new GridColumnConfiguration { DisplayName = "Case User"}},
                    { "CHECKER", new GridColumnConfiguration { DisplayName = "Checker"}},
                    { "Maker", new GridColumnConfiguration { DisplayName = "Maker"}},
            };
        }
    }
}
