using Data.Services;

namespace Data.Data.SASAml
{
    public class ArtStCasesPerSubcat : IChartDataEntity
    {
        public string? CASE_SUBCATEGORY { get; set; }
        public decimal? NUMBER_OF_CASES { get; set; }
    }
}
