namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class listofusersandgroupsroleConfig : ReportConfig
    {
        public listofusersandgroupsroleConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Email" , new GridColumnConfiguration { DisplayName = "Email"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MemberOfGroup" , new GridColumnConfiguration { DisplayName = "Member Of Group"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RoleOfGroup" , new GridColumnConfiguration { DisplayName = "Role Of Group"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}