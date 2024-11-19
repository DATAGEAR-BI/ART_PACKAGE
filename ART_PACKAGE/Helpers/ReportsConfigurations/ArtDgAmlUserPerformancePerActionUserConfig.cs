using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtDgAmlUserPerformancePerActionUserConfig : ReportConfig
    {
        public ArtDgAmlUserPerformancePerActionUserConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "ACTION_USER", new GridColumnConfiguration { DisplayName = "Action User" } },
                { "ACTION", new GridColumnConfiguration { DisplayName = "Action" } },
                { "TOTAL_NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Total Number Of Cases" } },
                { "DURATIONS_IN_SECONDS", new GridColumnConfiguration { DisplayName = "Durations In Seconds" } },
                { "AVG_DURATIONS_IN_SECONDS", new GridColumnConfiguration { DisplayName = "Avg Durations In Seconds" } },
                { "DURATIONS_IN_MINUTES", new GridColumnConfiguration { DisplayName = "Durations In Minutes" } },
                { "AVG_DURATIONS_IN_MINUTES", new GridColumnConfiguration { DisplayName = "Avg Durations In Minutes" } },
                { "DURATIONS_IN_HOURS", new GridColumnConfiguration { DisplayName = "Durations In Hours" } },
                { "AVG_DURATIONS_IN_HOURS", new GridColumnConfiguration { DisplayName = "Avg Durations In Hours" } },
                { "DURATIONS_IN_DAYS", new GridColumnConfiguration { DisplayName = "Durations In Days" } },
                { "AVG_DURATIONS_IN_DAYS", new GridColumnConfiguration { DisplayName = "Avg Durations In Days" } }
            };
        }
    }
}
