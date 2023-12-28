using Data.Services;

namespace Data.Data.ECM
{
    public class ArtSystemPerfPerDate : IChartDataEntity
    {
        public decimal YEAR { get; set; }
        public string MONTH { get; set; } = null!;
        public decimal DAY { get; set; }
        public decimal NUMBER_OF_CASES { get; set; }
    }
}
