using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStAccountsOpenedClosedWithin6MonthsConfig : ReportConfig
    {
        public ArtStAccountsOpenedClosedWithin6MonthsConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "ACCT_NO", new GridColumnConfiguration { DisplayName = "Acct No" } },
                { "ACCT_NAME", new GridColumnConfiguration { DisplayName = "Acct Name" } },
                { "CUST_NO", new GridColumnConfiguration { DisplayName = "Cust No" } },
                { "IDENTIFICATION_NUMBER", new GridColumnConfiguration { DisplayName = "Identification Number" } },
                { "ACCT_PRIM_BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Acct Prim Branch Name" } },
                { "ACCT_OPEN_DATE", new GridColumnConfiguration { DisplayName = "Acct Open Date" } },
                { "ACCT_CLOSE_DATE", new GridColumnConfiguration { DisplayName = "Acct Close Date" } },
                { "ACCOUNT_STATUS", new GridColumnConfiguration { DisplayName = "Account Status" } },
            };
        }
    }
}
