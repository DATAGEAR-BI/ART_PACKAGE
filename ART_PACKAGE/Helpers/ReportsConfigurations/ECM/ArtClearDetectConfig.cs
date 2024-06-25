using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtClearDetectConfig : ReportConfig
    {
        public ArtClearDetectConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    {"RequestUid", new GridColumnConfiguration { DisplayName ="Request ID"}},
                    {"RequestDate", new GridColumnConfiguration { DisplayName ="Request Date"}},
                    {"SearchMatch", new GridColumnConfiguration { DisplayName ="Search Match"}},
                    {"SourceType", new GridColumnConfiguration { DisplayName ="Source Type"}},
                    {"CaseId", new GridColumnConfiguration { DisplayName ="Case ID"}},

            };
            ReportTitle = "Clear Detect Report";
            ReportDescription = "This report presents all Clear Detects";
            defaultSortOption = new()
            {
                field = "RequestUid",
                dir = "asc"
            };
        }
    }
}
