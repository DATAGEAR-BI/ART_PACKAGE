using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttifulljournalreportConfig : ReportConfig
    {
        public arttifulljournalreportConfig()
        {

            SkipList = new List<string>(){ "Mcmtcetype",
"Mcusername",
"AreaCode",
"Jkey",
"Mcowner",
"Entrytimeutc",
"Mcaction",
"Mcnote" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Dataitem" , new GridColumnConfiguration { DisplayName = "Data Item"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Username" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MtceType" , new GridColumnConfiguration { DisplayName = "Mode"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Mcmtcetype" , new GridColumnConfiguration { DisplayName = "Mcmtcetype"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Mcusername" , new GridColumnConfiguration { DisplayName = "Mcusername"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AreaCode" , new GridColumnConfiguration { DisplayName = "AreaCode"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Area" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Jkey" , new GridColumnConfiguration { DisplayName = "Jkey"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Datetime" , new GridColumnConfiguration { DisplayName = "Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Mcowner" , new GridColumnConfiguration { DisplayName = "Mcowner"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Entrytimeutc" , new GridColumnConfiguration { DisplayName = "Entrytimeutc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Mcaction" , new GridColumnConfiguration { DisplayName = "Mcaction"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Mcnote" , new GridColumnConfiguration { DisplayName = "Mcnote"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DataAfter" , new GridColumnConfiguration { DisplayName = "Details After"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = true   } },
{"Databefore" , new GridColumnConfiguration { DisplayName = "Details Before"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = true   } } };


            ReportTitle = "Full Journal Report";
            ReportDescription = "This report produces changes made to Fusion Trade Innovation system tailoring or static data";




        }
    }
}