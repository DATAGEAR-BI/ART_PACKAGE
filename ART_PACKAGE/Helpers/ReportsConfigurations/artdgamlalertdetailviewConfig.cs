using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlalertdetailviewconfig : ReportConfig
    {
        public artdgamlalertdetailviewconfig()
        {

            SkipList = new List<string>() { };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ 
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "AlertDescription", new GridColumnConfiguration { DisplayName = "Alert Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "ScenarioId", new GridColumnConfiguration { DisplayName = "Scenario ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "ScenarioName", new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "MoneyLaunderingRiskScore", new GridColumnConfiguration { DisplayName = "Money Laundering Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "RunDate", new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "ClosedUserId", new GridColumnConfiguration { DisplayName = "Closed User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "ClosedUserName", new GridColumnConfiguration { DisplayName = "Closed User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "CloseDate", new GridColumnConfiguration { DisplayName = "Close Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "ReportCloseReason", new GridColumnConfiguration { DisplayName = "Report Close Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
            };

            ReportTitle = "Alert Details";
            ReportDescription = "Presents the alerts details";





        }
    }
}