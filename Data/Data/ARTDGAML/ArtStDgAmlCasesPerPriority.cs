using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlCasesPerPriority : IChartDataEntity
    {
        public string? CASE_PRIORITY { get; set; }
        public decimal? NUMBER_OF_CASES { get; set; }
    }
}
