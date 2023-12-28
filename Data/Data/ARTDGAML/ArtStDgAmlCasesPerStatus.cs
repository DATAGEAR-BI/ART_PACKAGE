using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlCasesPerStatus : IChartDataEntity
    {
        public string? CASE_STATUS { get; set; }
        public decimal? NUMBER_OF_CASES { get; set; }
    }
}
