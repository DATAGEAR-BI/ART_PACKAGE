using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlExternalCustomerPerBranch : IChartDataEntity
    {
        public string? BRANCH_NAME { get; set; }
        public decimal? NUMBER_OF_CUSTOMERS { get; set; }
    }
}
