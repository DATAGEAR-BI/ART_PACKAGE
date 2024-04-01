using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtFatcaIrsReportConfig : ReportConfig
    {
        public ArtFatcaIrsReportConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "Accountnumber", new GridColumnConfiguration { DisplayName = "Account Number" } },
                { "Accountclosed", new GridColumnConfiguration { DisplayName = "Account Closed" } },
                { "Countrycode", new GridColumnConfiguration { DisplayName = "Country Code" } },
                { "Tin", new GridColumnConfiguration { DisplayName = "TIN" } },
                { "Middlename", new GridColumnConfiguration { DisplayName = "Middle Name" } },
                { "Firstname", new GridColumnConfiguration { DisplayName = "First Name" } },
                { "Lastname", new GridColumnConfiguration { DisplayName = "Last Name" } },
                { "Countrycodeadd", new GridColumnConfiguration { DisplayName = "Country Code Address" } },
                { "AddressfreeI", new GridColumnConfiguration { DisplayName = "Address Free I" } },
                { "AddressfreeE", new GridColumnConfiguration { DisplayName = "Address Free E" } },
                { "Birthdate", new GridColumnConfiguration { DisplayName = "Birth Date" } },
                { "Nationality", new GridColumnConfiguration { DisplayName = "Nationality" } },
                { "Accountbalance", new GridColumnConfiguration { DisplayName = "Account Balance" } },
                { "Accountholdertype", new GridColumnConfiguration { DisplayName = "Account Holder Type" } },
                { "Accounttype", new GridColumnConfiguration { DisplayName = "Account Type" } },
                { "OwnerFirstName", new GridColumnConfiguration { DisplayName = "Owner First Name" } },
                { "OwnerLastName", new GridColumnConfiguration { DisplayName = "Owner Last Name" } },
                { "OwnerTin", new GridColumnConfiguration { DisplayName = "Owner TIN" } },
                { "OwnerResCountryCode", new GridColumnConfiguration { DisplayName = "Owner Res Country Code" } },
                { "OwnerAddress", new GridColumnConfiguration { DisplayName = "Owner Address" } },
                { "Paymentamnt501", new GridColumnConfiguration { DisplayName = "Payment Amount 501" } },
                { "Paymentamnt502", new GridColumnConfiguration { DisplayName = "Payment Amount 502" } },
                { "Paymentamnt503", new GridColumnConfiguration { DisplayName = "Payment Amount 503" } },
                { "Paymentamnt504", new GridColumnConfiguration { DisplayName = "Payment Amount 504" } },
                { "AccountcountFatca201", new GridColumnConfiguration { DisplayName = "Account Count FATCA 201" } },
                { "PoolbalanceFatca201", new GridColumnConfiguration { DisplayName = "Pool Balance FATCA 201" } },
                { "AccountcountFatca202", new GridColumnConfiguration { DisplayName = "Account Count FATCA 202" } },
                { "PoolbalanceFatca202", new GridColumnConfiguration { DisplayName = "Pool Balance FATCA 202" } },
                { "AccountcountFatca203", new GridColumnConfiguration { DisplayName = "Account Count FATCA 203" } },
                { "PoolbalanceFatca203", new GridColumnConfiguration { DisplayName = "Pool Balance FATCA 203" } },
                { "AccountcountFatca204", new GridColumnConfiguration { DisplayName = "Account Count FATCA 204" } },
                { "PoolbalanceFatca204", new GridColumnConfiguration { DisplayName = "Pool Balance FATCA 204" } },
                { "AccountcountFatca205", new GridColumnConfiguration { DisplayName = "Account Count FATCA 205" } },
                { "PoolbalanceFatca205", new GridColumnConfiguration { DisplayName = "Pool Balance FATCA 205" } },
                { "AccountcountFatca206", new GridColumnConfiguration { DisplayName = "Account Count FATCA 206" } },
                { "PoolbalanceFatca206", new GridColumnConfiguration { DisplayName = "Pool Balance FATCA 206" } },
                { "SignW8", new GridColumnConfiguration { DisplayName = "SignW8" } },
                { "SignW9", new GridColumnConfiguration { DisplayName = "SignW9" } }
            };
        }
    }
}