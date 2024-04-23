namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiecmauditreportConfig : ReportConfig
    {
        public arttiecmauditreportConfig()
        {

            SkipList = new List<string>(){ "Product",
"Sovaluecode",
"Gfcun",
"CusMnm",
"SwBank",
"SwCtr",
"SwLoc",
"SwBranch",
"Active",
"CtrctDate",
"Outstamt",
"Outccyced",
"Outstccy",
"OutstamtEgp",
"Relmstrref",
"CcyCed",
"CreatedAt",
"RefnoPfix",
"RefnoSerl" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"EcmReference" , new GridColumnConfiguration { DisplayName = "ECM Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchId" , new GridColumnConfiguration { DisplayName = "Branch ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EcmCaseCreationDate" , new GridColumnConfiguration { DisplayName = "ECM Case Creation Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CutomerName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Product" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Producttype" , new GridColumnConfiguration { DisplayName = "Product Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EcmEvent" , new GridColumnConfiguration { DisplayName = "Ecm Event"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionAmount" , new GridColumnConfiguration { DisplayName = "Transaction Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionCurrency" , new GridColumnConfiguration { DisplayName = "Transaction Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PrimaryOwner" , new GridColumnConfiguration { DisplayName = "Primary Owner"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseStatCd" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdateUserId" , new GridColumnConfiguration { DisplayName = "Last Action taken by"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Comments" , new GridColumnConfiguration { DisplayName = "Comments"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FtiReference" , new GridColumnConfiguration { DisplayName = "Fti Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventName" , new GridColumnConfiguration { DisplayName = "Event Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventStatus" , new GridColumnConfiguration { DisplayName = "Event Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventCreationDate" , new GridColumnConfiguration { DisplayName = "Event Creation Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterAssignedTo" , new GridColumnConfiguration { DisplayName = "Master Assigned To"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventSteps" , new GridColumnConfiguration { DisplayName = "Event Steps"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StepStatus" , new GridColumnConfiguration { DisplayName = "Step Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}