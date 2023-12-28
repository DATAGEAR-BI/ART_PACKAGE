using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlAlertsPerBranch : IChartDataEntity
    {
        public string? BRANCH_NAME { get; set; }
        public decimal? ALERTS_COUNT { get; set; }
    }
}
