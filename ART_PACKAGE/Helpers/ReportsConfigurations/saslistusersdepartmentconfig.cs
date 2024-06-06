using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class saslistusersdepartmentconfig : ReportConfig
    {
        public saslistusersdepartmentconfig()
        {
            ReportTitle = "List Users Department Report";
            ReportDescription = "Presents all SAS users with their departments";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserId" , new GridColumnConfiguration { DisplayName = "User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UserDisplayName" , new GridColumnConfiguration { DisplayName = "User Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UserTitle" , new GridColumnConfiguration { DisplayName = "User Title"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UserDesccription" , new GridColumnConfiguration { DisplayName = "User Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Department" , new GridColumnConfiguration { DisplayName = "Department"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Appname" , new GridColumnConfiguration { DisplayName = "App Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Logindatetime" , new GridColumnConfiguration { DisplayName = "Login datetime"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
            };



        }
    }
}