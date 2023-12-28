using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlAlertsPerStatus : IChartDataEntity
    {
        public decimal? ALERTS_COUNT { get; set; }
        public string? ALERT_STATUS { get; set; }
    }
}
