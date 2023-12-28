using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlAlertPerOwner : IChartDataEntity
    {
        public string? OWNER_QUEUE { get; set; }
        public decimal? ALERTS_CNT_SUM { get; set; }
    }
}
