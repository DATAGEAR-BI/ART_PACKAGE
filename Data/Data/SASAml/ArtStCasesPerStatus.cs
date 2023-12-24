using Data.Services;

namespace Data.Data.SASAml
{
    public class ArtStCasesPerStatus : IChartDataEntity
    {
        public string? CASE_STATUS { get; set; }
        public decimal? NUMBER_OF_CASES { get; set; }
    }
}
