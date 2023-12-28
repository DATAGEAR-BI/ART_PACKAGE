using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlAlertsPerScenario : IChartDataEntity
    {
        public string? SCENARIO_NAME { get; set; }
        public decimal? ALERTS_COUNT { get; set; }
    }
}
