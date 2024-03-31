using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class listofgroupConfig : ReportConfig
    {
        public listofgroupConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"GroupName" , new GridColumnConfiguration { DisplayName = "Group Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"GroupType" , new GridColumnConfiguration { DisplayName = "Group Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedDate" , new GridColumnConfiguration { DisplayName = "Created Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Display Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedBy" , new GridColumnConfiguration { DisplayName = "Last Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastUpdatedDate" , new GridColumnConfiguration { DisplayName = "Last Updated Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}