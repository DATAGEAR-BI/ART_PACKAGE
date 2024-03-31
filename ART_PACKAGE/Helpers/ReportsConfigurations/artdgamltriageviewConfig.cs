using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamltriageviewConfig : ReportConfig
    {
        public artdgamltriageviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AlertedEntityName" , new GridColumnConfiguration { DisplayName = "Alerted Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityNumber" , new GridColumnConfiguration { DisplayName = "Alerted Entity Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskScore" , new GridColumnConfiguration { DisplayName = "Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"QueueCode" , new GridColumnConfiguration { DisplayName = "Queue Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OwnerUserid" , new GridColumnConfiguration { DisplayName = "Owner User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityLevel" , new GridColumnConfiguration { DisplayName = "Alerted Entity Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AggregateAmt" , new GridColumnConfiguration { DisplayName = "Aggregate Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AgeOldestAlert" , new GridColumnConfiguration { DisplayName = "Age Oldest Alert"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertsCntSum" , new GridColumnConfiguration { DisplayName = "Alerts Count Sum"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}