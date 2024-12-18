using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artrolesauditviewConfig : ReportConfig
    {
        public artrolesauditviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"RoleName" , new GridColumnConfiguration { DisplayName = "Role Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Description" , new GridColumnConfiguration { DisplayName = "Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedDate" , new GridColumnConfiguration { DisplayName = "Created Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedBy" , new GridColumnConfiguration { DisplayName = "Last Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedDate" , new GridColumnConfiguration { DisplayName = "Last Updated Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GroupNames" , new GridColumnConfiguration { DisplayName = "Group Names"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MemberUsers" , new GridColumnConfiguration { DisplayName = "Member Users"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };




            ReportTitle = "ART Role Audit Report";
            ReportDescription = "This report Presents all events of roles with the related information as below";




        }
    }
}