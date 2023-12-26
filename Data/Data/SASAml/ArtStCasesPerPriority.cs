using Data.Services;

namespace Data.Data.SASAml
{
    public class ArtStCasesPerPriority : IChartDataEntity
    {
        public string? CASE_PRIORITY { get; set; }
        public decimal? NUMBER_OF_CASES { get; set; }

    }
}
