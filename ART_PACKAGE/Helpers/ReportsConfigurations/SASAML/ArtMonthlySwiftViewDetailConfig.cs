using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtMonthlySwiftViewDetailConfig : ReportConfig
    {

        public ArtMonthlySwiftViewDetailConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "TransactionId", new GridColumnConfiguration { DisplayName = "Transaction Id" } },
                { "TransactionDate", new GridColumnConfiguration { DisplayName = "Transaction Date" } },
                { "BankName", new GridColumnConfiguration { DisplayName = "Bank Name" } },
                { "Country", new GridColumnConfiguration { DisplayName = "Country" } }
            };
        }


    }
}
