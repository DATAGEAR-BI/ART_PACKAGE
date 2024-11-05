using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStDgAmlCommentsDetailConfig : ReportConfig
    {

        public ArtStDgAmlCommentsDetailConfig()
        {
            SkipList = new List<string>(){ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"ALARM_ID" , new GridColumnConfiguration { DisplayName = "Alarm ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"RUN_DATE" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"COMMENT" , new GridColumnConfiguration { DisplayName = "Comment"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"COMMENT_USER" , new GridColumnConfiguration { DisplayName = "Comment User"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"COMMENT_DATE" , new GridColumnConfiguration { DisplayName = "Comment Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
            };
            ReportTitle = "Comments Detail Report";
            ReportDescription = "";

        }
    }
}
