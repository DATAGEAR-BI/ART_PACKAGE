using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttichargesbymasterreportConfig : ReportConfig
    {
        public arttichargesbymasterreportConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Hvbad1" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Longname" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TotoalPeriodicBilledChgDue" , new GridColumnConfiguration { DisplayName = "Periodic/Billed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TotoalBilledChgDue" , new GridColumnConfiguration { DisplayName = "Billed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TotoalPaidChgDue" , new GridColumnConfiguration { DisplayName = "Paid"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = "TotalCharges  "  , isLargeText = false   } },
{"TotoalClaimedChgDue" , new GridColumnConfiguration { DisplayName = "Claimed"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = "TotalCharges  "  , isLargeText = false   } },
{"TotoalOutstandingChgDue" , new GridColumnConfiguration { DisplayName = "Outstanding"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = "TotalCharges  "  , isLargeText = false   } },
{"TotoalWaivedChgDue" , new GridColumnConfiguration { DisplayName = "Waived"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = "TotalCharges  "  , isLargeText = false   } } };







        }
    }
}