using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artkycsummarybyriskConfig : ReportConfig
    {
        public artkycsummarybyriskConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AmlRisk" , new GridColumnConfiguration { DisplayName = "AML Risk"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Type" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NumberOfUpdatedKyc" , new GridColumnConfiguration { DisplayName = "Number Of Updated KYC"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NumberOfNotUpdatedKyc" , new GridColumnConfiguration { DisplayName = "Number Of Not Updated KYC"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Total" , new GridColumnConfiguration { DisplayName = "Total"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}