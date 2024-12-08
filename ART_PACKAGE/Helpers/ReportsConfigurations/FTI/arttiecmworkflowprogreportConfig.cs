using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiecmworkflowprogreportConfig : ReportConfig
    {
        public arttiecmworkflowprogreportConfig()
        {

            SkipList = new List<string>(){ "Comments",
"Product",
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
{"EcmCaseCreationDate" , new GridColumnConfiguration { DisplayName = "ECM Case Creation Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchId" , new GridColumnConfiguration { DisplayName = "Branch ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CutomerName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Product" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ProductType" , new GridColumnConfiguration { DisplayName = "Product Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EcmEvent" , new GridColumnConfiguration { DisplayName = "ECM Event"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionAmount" , new GridColumnConfiguration { DisplayName = "Transaction Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionCurrency" , new GridColumnConfiguration { DisplayName = "Transaction Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PrimaryOwner" , new GridColumnConfiguration { DisplayName = "Primary Owner"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseStatCd" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdateUserId" , new GridColumnConfiguration { DisplayName = "Last Action taken by"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EcmRejectionType" , new GridColumnConfiguration { DisplayName = "ECM Rejection Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EcmRejectionReason" , new GridColumnConfiguration { DisplayName = "ECM Rejection Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FtiReference" , new GridColumnConfiguration { DisplayName = "FTI Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventName" , new GridColumnConfiguration { DisplayName = "Event Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventStatus" , new GridColumnConfiguration { DisplayName = "Event Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventCreationDate" , new GridColumnConfiguration { DisplayName = "Event Creation Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AssignedTo" , new GridColumnConfiguration { DisplayName = "Assigned To"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AssignmentType" , new GridColumnConfiguration { DisplayName = "Assignment Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventSteps" , new GridColumnConfiguration { DisplayName = "Event Steps"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StepStatus" , new GridColumnConfiguration { DisplayName = "Step Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Lstmodtime" , new GridColumnConfiguration { DisplayName = "Last Modification Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Lstmoduser" , new GridColumnConfiguration { DisplayName = "Last Modification By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"WarningOverridden" , new GridColumnConfiguration { DisplayName = "Warning Overridden"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RejectionReason" , new GridColumnConfiguration { DisplayName = "Rejection Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = true   } },
{"SlaDeadline" , new GridColumnConfiguration { DisplayName = "SLA Deadline"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"InputStepTime" , new GridColumnConfiguration { DisplayName = "Input Step Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"InputSlaStatus" , new GridColumnConfiguration { DisplayName = "Input SLA Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"InputMaxTime" , new GridColumnConfiguration { DisplayName = "Input Max Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExternalReviewStepTime" , new GridColumnConfiguration { DisplayName = "External Review Step Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExternalReviewSlaStatus" , new GridColumnConfiguration { DisplayName = "External Review SLA Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ReviewStepTime" , new GridColumnConfiguration { DisplayName = "Review Step Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ReviewSlaStatus" , new GridColumnConfiguration { DisplayName = "Review SLA Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AuthorizeStepTime" , new GridColumnConfiguration { DisplayName = "Authorize Step Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AuthorizeSlaStatus" , new GridColumnConfiguration { DisplayName = "Authorize SLA Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SlaDashboardAmber" , new GridColumnConfiguration { DisplayName = "SLA Dashboard Amber"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SlaDashboardRed" , new GridColumnConfiguration { DisplayName = "SLA Dashboard Red"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SlaRemainingTime" , new GridColumnConfiguration { DisplayName = "SLA Remaining TIme"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };




            ReportTitle = "ECM Workflow Progression Report";
            ReportDescription = "";


        }
    }
}