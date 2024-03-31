using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiadvancepaymentutilizationreportConfig : ReportConfig
    {
        public arttiadvancepaymentutilizationreportConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Branch" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AdvReference" , new GridColumnConfiguration { DisplayName = "Advance Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PrincipalParty" , new GridColumnConfiguration { DisplayName = "Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NonPrincipalParty" , new GridColumnConfiguration { DisplayName = "Non Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreationDate" , new GridColumnConfiguration { DisplayName = "CreationDate"  , Format = "{0:dd/MM/yyyy}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExpiryDate" , new GridColumnConfiguration { DisplayName = "Expiry Date"  , Format = "{0:dd/MM/yyyy}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UtilizationTrn" , new GridColumnConfiguration { DisplayName = "Utilization Transaction"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AdvAmount" , new GridColumnConfiguration { DisplayName = "Advance Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AdvCurrency" , new GridColumnConfiguration { DisplayName = "Advance Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UtilizationAmount" , new GridColumnConfiguration { DisplayName = "Utilization Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UtilizationCurrency" , new GridColumnConfiguration { DisplayName = "Utilization Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OutstandingAmount" , new GridColumnConfiguration { DisplayName = "Outstanding Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}