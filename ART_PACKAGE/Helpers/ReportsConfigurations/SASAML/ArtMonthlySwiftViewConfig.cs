using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtMonthlySwiftViewConfig : ReportConfig
    {

        public ArtMonthlySwiftViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "Month", new GridColumnConfiguration { DisplayName = "Month" } },
                { "BankName", new GridColumnConfiguration { DisplayName = "Bank Name" } },
                { "Country", new GridColumnConfiguration { DisplayName = "Country" } },
                { "NumberOfTransactions", new GridColumnConfiguration { DisplayName = "Number of Transactions" } }
            };
        }


    }
}
