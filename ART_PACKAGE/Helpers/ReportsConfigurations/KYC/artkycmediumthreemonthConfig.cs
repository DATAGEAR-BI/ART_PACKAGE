using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artkycmediumthreemonthConfig : ReportConfig
    {
        public artkycmediumthreemonthConfig()
        {

            SkipList = new List<string>() { "Month" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"ClientNumber" , new GridColumnConfiguration { DisplayName = "Client Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntityName" , new GridColumnConfiguration { DisplayName = "Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmlRisk" , new GridColumnConfiguration { DisplayName = "AML Risk"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Type" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskClassIndustry" , new GridColumnConfiguration { DisplayName = "Risk Class"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NextUpdateDate" , new GridColumnConfiguration { DisplayName = "Next Update Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            ReportTitle = "Medium risk within 3 months customers Report";
            ReportDescription = "presents all medium-risk customers need to be update their KYCs within 3 months with the related information below";



        }
    }
}