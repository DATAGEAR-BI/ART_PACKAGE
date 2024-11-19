using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtDgAmlUserPerformPerActionConfig : ReportConfig
    {
        public ArtDgAmlUserPerformPerActionConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "action", new GridColumnConfiguration { DisplayName = "Action" } },
                { "Total_Number_Of_Cases", new GridColumnConfiguration { DisplayName = "Total Number Of Cases" } },
                { "durations_in_seconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds" } },
                { "AVG_durations_in_seconds", new GridColumnConfiguration { DisplayName = "Avg Durations In Seconds" } },
                { "durations_in_minutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes" } },
                { "AVG_durations_in_minutes", new GridColumnConfiguration { DisplayName = "Avg Durations In Minutes" } },
                { "durations_in_hours", new GridColumnConfiguration { DisplayName = "Durations In Hours" } },
                { "AVG_durations_in_hours", new GridColumnConfiguration { DisplayName = "Avg Durations In Hours" } },
                { "durations_in_days", new GridColumnConfiguration { DisplayName = "Durations In Days" } },
                { "AVG_durations_in_days", new GridColumnConfiguration { DisplayName = "Avg Durations In Days" } }
            };
        }
    }
}
