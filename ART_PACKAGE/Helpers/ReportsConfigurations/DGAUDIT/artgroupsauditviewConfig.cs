using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artgroupsauditviewConfig : ReportConfig
    {
        public artgroupsauditviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"GroupName" , new GridColumnConfiguration { DisplayName = "Group Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Description" , new GridColumnConfiguration { DisplayName = "Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedDate" , new GridColumnConfiguration { DisplayName = "Created Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedBy" , new GridColumnConfiguration { DisplayName = "Last Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedDate" , new GridColumnConfiguration { DisplayName = "Last Updated Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SubGroupNames" , new GridColumnConfiguration { DisplayName = "SubGroup Names"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RoleNames" , new GridColumnConfiguration { DisplayName = "Role Names"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MemberUsers" , new GridColumnConfiguration { DisplayName = "Member Users"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };


            ReportTitle = "ART Group Audit Report";
            ReportDescription = "This report Presents all events of groups with the related information as below";






        }
    }
}