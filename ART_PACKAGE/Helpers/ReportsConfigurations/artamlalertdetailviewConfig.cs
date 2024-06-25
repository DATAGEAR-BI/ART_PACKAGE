using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artamlalertdetailviewConfig : ReportConfig
    {
        public artamlalertdetailviewConfig()
        {

            SkipList = new List<string>(){ "Val",
"AlertsNotesFlag","PartyTypeDesc","AlertTypeCd",
    "BranchNumber",
    "AlertDescription",
    "ScenarioId",
    "ReportCloseRsn",
    "EmployeeInd",
    "InvestigationDays" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){   {"AlertId" , new GridColumnConfiguration { DisplayName = "Alert ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"AlertedEntityName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"AlertedEntityNumber" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"PartyTypeDesc" , new GridColumnConfiguration { DisplayName = "Party Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"PoliticallyExposedPersonInd" , new GridColumnConfiguration { DisplayName = "PEP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"RunDate" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"CloseDate" , new GridColumnConfiguration { DisplayName = "Closed Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"MoneyLaunderingRiskScore" , new GridColumnConfiguration { DisplayName = "Money Laundering RiskScore"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"AlertTypeCd" , new GridColumnConfiguration { DisplayName = "Alert Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"AlertSubCat" , new GridColumnConfiguration { DisplayName = "Alert Sub-Category"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"AlertStatus" , new GridColumnConfiguration { DisplayName = "Alert Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"CasesStatus" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"AlertDescription" , new GridColumnConfiguration { DisplayName = "Alert Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"ScenarioName" , new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"ReportCloseRsn" , new GridColumnConfiguration { DisplayName = "Report Close Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"ActualValuesText" , new GridColumnConfiguration { DisplayName = "Scenario Message"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"OwnerUserid" , new GridColumnConfiguration { DisplayName = "Owner "  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                                                                                {"InvestigationDays" , new GridColumnConfiguration { DisplayName = "Investigation Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } ,
                                                                                { "Queue" , new GridColumnConfiguration { DisplayName = "Queue", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } }
        };
            ReportTitle = "Alert Details";
            ReportDescription = "Presents the alerts details";

            defaultSortOption = new SortOption()
            {
                dir= "asc",
                field= "AlertId"
            };





        }
    }
}