using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlalertdetailviewConfig : ReportConfig
    {
        public artdgamlalertdetailviewConfig()
        {

            SkipList = new List<string>() { "ActualValuesText", "OwnerUid" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AlarmId" , new GridColumnConfiguration { DisplayName = "Alert ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityNumber" , new GridColumnConfiguration { DisplayName = "Alerted Entity Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityName" , new GridColumnConfiguration { DisplayName = "Alerted Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertDescription" , new GridColumnConfiguration { DisplayName = "Alert Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioId" , new GridColumnConfiguration { DisplayName = "Scenario ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioName" , new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MoneyLaunderingRiskScore" , new GridColumnConfiguration { DisplayName = "Money Laundering Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertCategory" , new GridColumnConfiguration { DisplayName = "Alert Category"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertSubcategory" , new GridColumnConfiguration { DisplayName = "Alert Sub Category"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertStatus" , new GridColumnConfiguration { DisplayName = "Alert Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RunDate" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PoliticallyExposedPersonInd" , new GridColumnConfiguration { DisplayName = "PEP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmpInd" , new GridColumnConfiguration { DisplayName = "Emp Indication"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ClosedUserId" , new GridColumnConfiguration { DisplayName = "Closed User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CloseUserName" , new GridColumnConfiguration { DisplayName = "Close User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CloseDate" , new GridColumnConfiguration { DisplayName = "Close Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CloseReason" , new GridColumnConfiguration { DisplayName = "Close Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"InvestigationDays" , new GridColumnConfiguration { DisplayName = "Investigation Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };


            ReportTitle = "Data Gear Aml Alert Details";
            ReportDescription = "Presents the alerts details";



        }
    }
}