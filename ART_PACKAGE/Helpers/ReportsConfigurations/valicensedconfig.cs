using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class valicensedconfig : ReportConfig
    {
        public valicensedconfig()
        {
            ReportTitle = "List SAS Applications Report";
            ReportDescription = "Presents all SAS applications with the related information";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AppLebal" , new GridColumnConfiguration { DisplayName = "App Lebal"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BeginDate" , new GridColumnConfiguration { DisplayName = "Begin Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ProType" , new GridColumnConfiguration { DisplayName = "Pro Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Fmtname" , new GridColumnConfiguration { DisplayName = "Fmt Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ProStart" , new GridColumnConfiguration { DisplayName = "Pro Start"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Diedate" , new GridColumnConfiguration { DisplayName = "Die date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
            };



        }
    }
}