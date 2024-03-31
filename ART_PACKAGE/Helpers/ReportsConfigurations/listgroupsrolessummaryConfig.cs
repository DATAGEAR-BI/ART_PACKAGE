using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class listgroupsrolessummaryConfig : ReportConfig
    {
        public listgroupsrolessummaryConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"RoleName" , new GridColumnConfiguration { DisplayName = "Role Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GroupName" , new GridColumnConfiguration { DisplayName = "Group Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}