using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class valastloginviewconfig : ReportConfig
    {
        public valastloginviewconfig()
        {
            ReportTitle = "SAS Last Login Report";
            ReportDescription = "Presents each user with last login date";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Username" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Appname" , new GridColumnConfiguration { DisplayName = "App Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Logindatetime" , new GridColumnConfiguration { DisplayName = "Login Date Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Logindate" , new GridColumnConfiguration { DisplayName = "Login Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
            };



        }
    }
}