namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artamltriageviewConfig : ReportConfig
    {
        public artamltriageviewConfig()
        {

            SkipList = new List<string>() { "AlertedEntityLevel" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AlertedEntityName" , new GridColumnConfiguration { DisplayName = "Alerted Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityNumber" , new GridColumnConfiguration { DisplayName = "Alerted Entity Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchNumber" , new GridColumnConfiguration { DisplayName = "Branch Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskScore" , new GridColumnConfiguration { DisplayName = "Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OwnerUserid" , new GridColumnConfiguration { DisplayName = "Owner"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AggregateAmt" , new GridColumnConfiguration { DisplayName = "Aggregate Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AgeOldestAlert" , new GridColumnConfiguration { DisplayName = "Alert Age"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertsCntSum" , new GridColumnConfiguration { DisplayName = "Alerts Count"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}