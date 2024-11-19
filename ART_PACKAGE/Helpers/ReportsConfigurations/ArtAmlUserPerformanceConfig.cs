using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAmlUserPerformanceConfig : ReportConfig
    {
        public ArtAmlUserPerformanceConfig()
        {

            SkipList = new List<string>() {  };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ 
                {"AlarmId" , new GridColumnConfiguration { DisplayName = "Alert ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"AlertStatus" , new GridColumnConfiguration { DisplayName = "Alert Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"RunDate" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"AssignDate" , new GridColumnConfiguration { DisplayName = "Assign Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"ReleasedDate" , new GridColumnConfiguration { DisplayName = "Released Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"UserName" , new GridColumnConfiguration { DisplayName = "User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DurationsInSeconds" , new GridColumnConfiguration { DisplayName = "Durations In Seconds"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DurationsInMinutes" , new GridColumnConfiguration { DisplayName = "Durations In Minutes"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DurationsInHours" , new GridColumnConfiguration { DisplayName = "Durations In Hours"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DurationsInDays" , new GridColumnConfiguration { DisplayName = "Durations In Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }
            };
            ReportTitle = "Aml User Performance Report";






        }
    }
}