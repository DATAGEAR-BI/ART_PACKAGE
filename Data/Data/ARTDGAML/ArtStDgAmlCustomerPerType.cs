using Data.Services;

namespace Data.Data.ARTDGAML
{
    public class ArtStDgAmlCustomerPerType : IChartDataEntity
    {
        public decimal? NUMBER_OF_CUSTOMERS { get; set; }
        public string? CUSTOMER_TYPE { get; set; }
    }
}
