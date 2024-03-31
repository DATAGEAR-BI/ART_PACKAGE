using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class listgroupssubgroupssummaryConfig : ReportConfig
    {
        public listgroupssubgroupssummaryConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"SubGroupName" , new GridColumnConfiguration { DisplayName = "Sub Group Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GroupName" , new GridColumnConfiguration { DisplayName = "Group Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}