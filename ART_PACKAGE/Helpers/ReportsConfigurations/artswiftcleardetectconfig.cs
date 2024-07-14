using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artswiftcleardetectconfig : ReportConfig
    {
        public artswiftcleardetectconfig()
        {
            ReportTitle = "SWIFT Clear Detect Report";
            ReportDescription = "This report presents all success and not matched SWIFT requests with the related information as below";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"RequestUid" , new GridColumnConfiguration { DisplayName = "Request UID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RequestDate" , new GridColumnConfiguration { DisplayName = "Request Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Direction" , new GridColumnConfiguration { DisplayName = "Direction"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Correspondent" , new GridColumnConfiguration { DisplayName = "Correspondent"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Type" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reference" , new GridColumnConfiguration { DisplayName = "Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CurrencyAmount" , new GridColumnConfiguration { DisplayName = "Currency Amount"  , Format = ""  ,  Filter = "" , Template = "mixedArabicAndEnglish" , AggText = ""  , isLargeText = false   } },
{"InstanceType" , new GridColumnConfiguration { DisplayName = "Instance Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"Sender" , new GridColumnConfiguration { DisplayName = "Sender"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"Branch" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"Body" , new GridColumnConfiguration { DisplayName = "Body"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, };



        }
    }
}