using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class saslistofusersandgroupsroleconfig : ReportConfig
    {
        public saslistofusersandgroupsroleconfig()
        {
            ReportTitle = "List Users Groups and Roles Report";
            ReportDescription = "Presents all SAS users with their groups and roles";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserId" , new GridColumnConfiguration { DisplayName = "User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"JobTitle" , new GridColumnConfiguration { DisplayName = "Job Title"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Email" , new GridColumnConfiguration { DisplayName = "Email"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Description" , new GridColumnConfiguration { DisplayName = "Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MemberOfGroup" , new GridColumnConfiguration { DisplayName = "Member Of Group"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RoleDisplayName" , new GridColumnConfiguration { DisplayName = "Role Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"UserRole" , new GridColumnConfiguration { DisplayName = "User Role"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
{"GroupDisplayName" , new GridColumnConfiguration { DisplayName = "Group Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
            };



        }
    }
}