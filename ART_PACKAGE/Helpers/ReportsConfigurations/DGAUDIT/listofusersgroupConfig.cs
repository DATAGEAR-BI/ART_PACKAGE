using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class listofusersgroupConfig : ReportConfig
    {
        public listofusersgroupConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Email" , new GridColumnConfiguration { DisplayName = "Email"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MemberOfGroup" , new GridColumnConfiguration { DisplayName = "Member Of Group"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };




            ReportTitle = "List Of Users Groups";
            ReportDescription = "This Report presents all users with their groups";


        }
    }
}