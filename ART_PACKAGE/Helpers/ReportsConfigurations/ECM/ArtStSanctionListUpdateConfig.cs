using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStSanctionListUpdateConfig : ReportConfig
    {

        public ArtStSanctionListUpdateConfig()
        {
            SkipList = new List<string>(){ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"STATUS_DATE" , new GridColumnConfiguration { DisplayName = "Status Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Entity_Number" , new GridColumnConfiguration { DisplayName = "Entity Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"ENTITY_NAME" , new GridColumnConfiguration { DisplayName = "Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"WATCH_LIST_NAME" , new GridColumnConfiguration { DisplayName = "Watch List Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"ENTITY_TYPE" , new GridColumnConfiguration { DisplayName = "Entity Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"NUMBER_OF_ACTIONS" , new GridColumnConfiguration { DisplayName = "Number Of Actions"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"STATUS" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"PROGRAMS" , new GridColumnConfiguration { DisplayName = "Programs"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
            };
            ReportTitle = "List Update Report";
            ReportDescription = "";

        }
    }
}
