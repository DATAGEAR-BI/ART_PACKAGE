using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlCasesPerCategory : IChartDataEntity
    {
        public decimal? NUMBER_OF_CASES { get; set; }
        public string? CASE_CATEGORY { get; set; }
    }
}
