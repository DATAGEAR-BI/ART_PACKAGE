using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artsystemperformanceConfig : ReportConfig
    {
        public artsystemperformanceConfig()
        {

            SkipList = new List<string>(){ "CaseRk",
"ValidFromDate" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CaseId" , new GridColumnConfiguration { DisplayName = "Case ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseType" , new GridColumnConfiguration { DisplayName = "Case Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseDesc" , new GridColumnConfiguration { DisplayName = "Case Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseStatus" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Priority" , new GridColumnConfiguration { DisplayName = "Priority"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"HitsCount" , new GridColumnConfiguration { DisplayName = "Hits Count"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionDirection" , new GridColumnConfiguration { DisplayName = "Transaction Direction"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionType" , new GridColumnConfiguration { DisplayName = "Transaction Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionAmount" , new GridColumnConfiguration { DisplayName = "Transaction Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionCurrency" , new GridColumnConfiguration { DisplayName = "Transaction Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwiftReference" , new GridColumnConfiguration { DisplayName = "Swift Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ClientName" , new GridColumnConfiguration { DisplayName = "Party Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IdentityNum" , new GridColumnConfiguration { DisplayName = "Party Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LockedBy" , new GridColumnConfiguration { DisplayName = "Locked By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"InvestrUserId" , new GridColumnConfiguration { DisplayName = "Investigator"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdateUserId" , new GridColumnConfiguration { DisplayName = "Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EcmLastStatusDate" , new GridColumnConfiguration { DisplayName = "Ecm Last Status Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInSeconds" , new GridColumnConfiguration { DisplayName = "Durations In Seconds"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInMinutes" , new GridColumnConfiguration { DisplayName = "Durations In Minutes"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInHours" , new GridColumnConfiguration { DisplayName = "Durations In Hours"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInDays" , new GridColumnConfiguration { DisplayName = "Durations In Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}