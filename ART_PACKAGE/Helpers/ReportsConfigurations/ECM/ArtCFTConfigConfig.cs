using ART_PACKAGE.Helpers.CSVMAppers;
using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCFTConfigConfig : ReportConfig
    {
        public ArtCFTConfigConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "Maker", new GridColumnConfiguration { DisplayName = "Maker"}},
                    { "MakerDate", new GridColumnConfiguration { DisplayName = "Maker Date"}},
                    { "Checker", new GridColumnConfiguration { DisplayName = "Checker"}},
                    { "CheckerDate", new GridColumnConfiguration { DisplayName = "Checker Date"}},
                    { "CheckerAction", new GridColumnConfiguration { DisplayName = "Checker Action"}},
                    { "ActionDetail", new GridColumnConfiguration { DisplayName = "Action Detail", Template = "actionDetailTable",Format="html"}},

            };
            ReportTitle = "CFT Config. Details";
            ReportDescription = "CFT Config. Details";
            MapperType = typeof(ArtCFTConfigMapper);

        }
    }
}
