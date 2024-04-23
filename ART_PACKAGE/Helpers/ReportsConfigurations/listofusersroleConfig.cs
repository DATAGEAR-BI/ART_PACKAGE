namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class listofusersroleConfig : ReportConfig
    {
        public listofusersroleConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Email" , new GridColumnConfiguration { DisplayName = "Email"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UserRole" , new GridColumnConfiguration { DisplayName = "User Role"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}