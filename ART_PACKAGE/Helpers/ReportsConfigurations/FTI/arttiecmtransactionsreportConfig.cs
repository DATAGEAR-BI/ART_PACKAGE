using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiecmtransactionsreportConfig : ReportConfig
    {
        public arttiecmtransactionsreportConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CaseId" , new GridColumnConfiguration { DisplayName = "EcmReference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Behalfofbranch" , new GridColumnConfiguration { DisplayName = "Branch ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Case Creation Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Applicantname" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Product" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Producttype" , new GridColumnConfiguration { DisplayName = "Product Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Eventname" , new GridColumnConfiguration { DisplayName = "Event"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionAmount" , new GridColumnConfiguration { DisplayName = "Transaction Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionCurrency" , new GridColumnConfiguration { DisplayName = "Transaction Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PrimaryOwner" , new GridColumnConfiguration { DisplayName = "Primary Owner"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseStatCd" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdateUserId" , new GridColumnConfiguration { DisplayName = "Last Action taken by"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };


            ReportTitle = "ECM Transactions Report";
            ReportDescription = "";




        }
    }
}