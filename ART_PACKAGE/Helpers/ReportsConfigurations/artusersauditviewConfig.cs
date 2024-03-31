using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artusersauditviewConfig : ReportConfig
    {
        public artusersauditviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address" , new GridColumnConfiguration { DisplayName = "Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Description" , new GridColumnConfiguration { DisplayName = "Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Email" , new GridColumnConfiguration { DisplayName = "Email"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Phone" , new GridColumnConfiguration { DisplayName = "Phone"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedDate" , new GridColumnConfiguration { DisplayName = "Created Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedBy" , new GridColumnConfiguration { DisplayName = "Last Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedDate" , new GridColumnConfiguration { DisplayName = "Last Updated Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastLoginDate" , new GridColumnConfiguration { DisplayName = "Last Login Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastFailedLogin" , new GridColumnConfiguration { DisplayName = "Last Failed Login"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Enable" , new GridColumnConfiguration { DisplayName = "Enable"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GroupNames" , new GridColumnConfiguration { DisplayName = "Group Names"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MemberUsers" , new GridColumnConfiguration { DisplayName = "Member Users"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DomainAccounts" , new GridColumnConfiguration { DisplayName = "Domain Accounts"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}