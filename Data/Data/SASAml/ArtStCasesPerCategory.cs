using Data.Services;

namespace Data.Data.SASAml
{
    public class ArtStCasesPerCategory : IChartDataEntity
    {
        public string? CASE_CATEGORY { get; set; }
        public decimal? NUMBER_OF_CASES { get; set; }
    }
}
