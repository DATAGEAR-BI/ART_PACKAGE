using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class saslistaccessrightperroleconfig : ReportConfig
    {
        public saslistaccessrightperroleconfig()
        {
            ReportTitle = "Roles & Capabilities Details Report";
            ReportDescription = "Presents all SAS roles with their capability groups and components";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Role" , new GridColumnConfiguration { DisplayName = "Role"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RoleDescription" , new GridColumnConfiguration { DisplayName = "Role Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CapabilityId" , new GridColumnConfiguration { DisplayName = "Capability ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CapName" , new GridColumnConfiguration { DisplayName = "Cap Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CapabilitiyGroupName" , new GridColumnConfiguration { DisplayName = "Capability Group Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ComponentName" , new GridColumnConfiguration { DisplayName = "Component Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
            };



        }
    }
}