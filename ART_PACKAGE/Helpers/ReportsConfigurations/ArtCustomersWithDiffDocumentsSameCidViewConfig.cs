using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCustomersWithDiffDocumentsSameCidViewConfig : ReportConfig
    {
        public ArtCustomersWithDiffDocumentsSameCidViewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ 
                {"CustNo" , new GridColumnConfiguration { DisplayName = "Cust No"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CustIdentId" , new GridColumnConfiguration { DisplayName = "Cust Ident Id"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"PassPortNumber" , new GridColumnConfiguration { DisplayName = "Pass Port Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"KraPin" , new GridColumnConfiguration { DisplayName = "KRA Pin"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
            };
            ReportTitle = "Customers With Diff Documents Same CID Report";






        }
    }
}