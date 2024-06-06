using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class saslistaccessusersgroupscapconfig : ReportConfig
    {
        public saslistaccessusersgroupscapconfig()
        {
            ReportTitle = "List Users Groups Roles & Capabilities Report";
            ReportDescription = "Presents all SAS users with their groups roles and capabilities";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ggroup" , new GridColumnConfiguration { DisplayName = "Group"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Rrole" , new GridColumnConfiguration { DisplayName = "Role"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Capabilities" , new GridColumnConfiguration { DisplayName = "Capabilities"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
            };



        }
    }
}