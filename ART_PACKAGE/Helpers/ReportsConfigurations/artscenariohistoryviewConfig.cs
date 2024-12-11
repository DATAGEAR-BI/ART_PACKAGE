using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artscenariohistoryviewConfig : ReportConfig
    {
        public artscenariohistoryviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"RoutineName" , new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RoutineShortDesc" , new GridColumnConfiguration { DisplayName = "Scenario Short Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventDesc" , new GridColumnConfiguration { DisplayName = "Event Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateUserName" , new GridColumnConfiguration { DisplayName = "Create User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            ReportTitle = "Art Scenario History";
            ReportDescription = "Presents the art scenario history details";



        }
    }
}