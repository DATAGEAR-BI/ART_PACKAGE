using Data.Services;

namespace Data.Data.SASAml
{
    public class ArtStAlertsPerStatus : IChartDataEntity
    {
        public string? ALERT_STATUS { get; set; }
        public decimal? ALERTS_COUNT { get; set; }
    }
}
