using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStSanctionScreeningStatusConfig : ReportConfig
    {

        public ArtStSanctionScreeningStatusConfig()
        {
            SkipList = new List<string>(){ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"REQUEST_ID" , new GridColumnConfiguration { DisplayName = "Request ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"REQUEST_DATE" , new GridColumnConfiguration { DisplayName = "Request Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"MATCH_STATUS" , new GridColumnConfiguration { DisplayName = "Match Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"SEARCH_MESSAGE" , new GridColumnConfiguration { DisplayName = "Search Message"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"SOURCE_TYPE" , new GridColumnConfiguration { DisplayName = "Source Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
                {"Screening_List" , new GridColumnConfiguration { DisplayName = "Screening List"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                               
            };
            ReportTitle = " Screening Status Report";
            ReportDescription = "";

        }
    }
}
