using Data.Services;

namespace Data.Data.SASAml
{
    public class ArtStAlertPerOwner : IChartDataEntity
    {
        public string? OWNER_USERID { get; set; }
        public decimal? ALERTS_CNT_SUM { get; set; }
    }
}
