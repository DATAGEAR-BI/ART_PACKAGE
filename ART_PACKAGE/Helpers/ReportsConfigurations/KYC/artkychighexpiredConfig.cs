using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artkychighexpiredConfig : ReportConfig
    {
        public artkychighexpiredConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"ClientNumber" , new GridColumnConfiguration { DisplayName = "Client Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntityName" , new GridColumnConfiguration { DisplayName = "Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmlRisk" , new GridColumnConfiguration { DisplayName = "AML Risk"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Type" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NextUpdateDate" , new GridColumnConfiguration { DisplayName = "Next Update Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };
            ReportTitle = "High risk expired customers Report";
            ReportDescription = "presents all high-risk customers need to be update their expired KYCs with the related information below";






        }
    }
}