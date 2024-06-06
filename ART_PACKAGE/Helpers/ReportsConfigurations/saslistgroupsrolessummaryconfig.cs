using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class saslistgroupsrolessummaryconfig : ReportConfig
    {
        public saslistgroupsrolessummaryconfig()
        {
            ReportTitle = "Groups & Roles Summary Report";
            ReportDescription = "Presents all SAS groups with their roles";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Groups" , new GridColumnConfiguration { DisplayName = "Groups"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Roles" , new GridColumnConfiguration { DisplayName = "Roles"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } }, 
            };



        }
    }
}