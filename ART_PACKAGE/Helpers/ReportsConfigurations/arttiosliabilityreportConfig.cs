namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiosliabilityreportConfig : ReportConfig
    {
        public arttiosliabilityreportConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Gfcun" , new GridColumnConfiguration { DisplayName = "Customer"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LiabCcy" , new GridColumnConfiguration { DisplayName = "Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Totliabamt" , new GridColumnConfiguration { DisplayName = "Total Per Customer"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TotliabamtEgp" , new GridColumnConfiguration { DisplayName = "Total Per Customer Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}