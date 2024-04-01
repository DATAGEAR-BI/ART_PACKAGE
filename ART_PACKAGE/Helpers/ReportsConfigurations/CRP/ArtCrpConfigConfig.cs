using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCrpConfigConfig : ReportConfig
    {
        public ArtCrpConfigConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "Maker", new GridColumnConfiguration { DisplayName = "Maker"}},
                    { "MakerDate", new GridColumnConfiguration { DisplayName = "Maker Date"}},
                    { "Checker", new GridColumnConfiguration { DisplayName = "Checker"}},
                    { "CheckerDate", new GridColumnConfiguration { DisplayName = "Checker Date"}},
                    { "CheckerAction", new GridColumnConfiguration { DisplayName = "Checker Action"}},
                    { "ActionDetail", new GridColumnConfiguration { DisplayName = "Action Detail", Template = "actionDetailTable"}},

            };
        }
    }
}
