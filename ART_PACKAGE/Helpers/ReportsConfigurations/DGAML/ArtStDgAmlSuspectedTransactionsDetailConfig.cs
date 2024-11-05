using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStDgAmlSuspectedTransactionsDetailConfig : ReportConfig
    {

        public ArtStDgAmlSuspectedTransactionsDetailConfig()
        {
            SkipList = new List<string>(){ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"ALARM_ID" , new GridColumnConfiguration { DisplayName = "Alarm ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"ACCOUNT_NUMBER" , new GridColumnConfiguration { DisplayName = "Account Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"TRANSACTION_REFERENCE" , new GridColumnConfiguration { DisplayName = "Transaction Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"TRANSACTION_TYPE" , new GridColumnConfiguration { DisplayName = "Transaction Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"TRANSACTION_DATE" , new GridColumnConfiguration { DisplayName = "Transaction Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"BASE_AMOUNT_EGP" , new GridColumnConfiguration { DisplayName = "Base Amount(EGP)"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"EQUIVALENT_AMOUNT" , new GridColumnConfiguration { DisplayName = "Equivalent Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"EQUIVALENT_CURRENCY" , new GridColumnConfiguration { DisplayName = "Equivalent Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
            };
            ReportTitle = "Suspected Transactions Detail Report";
            ReportDescription = "";

        }
    }
}
