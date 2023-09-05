using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers.CustomReportHelpers;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportsConfig
    {
        public static readonly Dictionary<string, ReportConfig> CONFIG = new()
        {
            {
                nameof(ReportController).ToLower(),new ReportConfig
                {
                   SkipList =  new List<string>()
              {
                  nameof(ArtSavedCustomReport.User),
                  nameof(ArtSavedCustomReport.UserId),
                nameof(ArtSavedCustomReport.Schema),
                nameof(ArtSavedCustomReport.Columns),
                nameof(ArtSavedCustomReport.Charts),

             }
            }
            },
            {
                nameof(ArtCasesInitiatedFromBranchController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "EcmReference",new DisplayNameAndFormat { DisplayName ="Ecm Reference"}},
                        {  "BranchId",new DisplayNameAndFormat { DisplayName ="Branch ID"}},
                        {  "CaseCreationDate",new DisplayNameAndFormat { DisplayName ="Case Creation Date"}},
                        {  "CustomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                        {  "Amount",new DisplayNameAndFormat { DisplayName ="Transaction Amount"}},
                        {  "Currency",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                        {  "PrimaryOwner",new DisplayNameAndFormat { DisplayName ="Primary Owner"}},
                        {  "CaseStatus",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                        {  "LastActionTokenBy",new DisplayNameAndFormat { DisplayName ="Last Action Token By"}},
                        {  "Product",new DisplayNameAndFormat { DisplayName = "Product"}},
                        {  "ProductType",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                        {  "EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                        {  "ApplicantId",new DisplayNameAndFormat { DisplayName ="Applicant ID"}},
                        {  "ExpiryDate",new DisplayNameAndFormat { DisplayName ="Expiry Date"}},
                        {  "BeneficiaryName",new DisplayNameAndFormat { DisplayName ="Beneficiary Name"}},

                    }
                }
            },
            {
                nameof(ArtDgecmActivityController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "EcmReference",new DisplayNameAndFormat { DisplayName ="Ecm Reference"}},
                        {  "BranchId",new DisplayNameAndFormat { DisplayName ="Branch ID"}},
                        {  "CaseCreationDate",new DisplayNameAndFormat { DisplayName ="Case Creation Date"}},
                        {  "CustomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                        {  "Amount",new DisplayNameAndFormat { DisplayName ="Transaction Amount"}},
                        {  "Currency",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                        {  "PrimaryOwner",new DisplayNameAndFormat { DisplayName ="Primary Owner"}},
                        {  "CaseStatus",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                        {  "CaseComments",new DisplayNameAndFormat { DisplayName ="Case Comments"}},
                        {  "Product",new DisplayNameAndFormat { DisplayName = "Product"}},
                        {  "ProductType",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                        {  "EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                        {  "ParentCaseId",new DisplayNameAndFormat { DisplayName ="Parent Case Id"}},
                        {  "Reference",new DisplayNameAndFormat { DisplayName ="Reference"}},

                    }
                }
            },
            {
                nameof(ArtEcmFtiFullCycleController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "EcmReference",new DisplayNameAndFormat { DisplayName ="Ecm Reference"}},
                        {  "BranchId",new DisplayNameAndFormat { DisplayName ="Branch ID"}},
                        {  "CaseCreationDate",new DisplayNameAndFormat { DisplayName ="Case Creation Date"}},
                        {  "CustomerName",new DisplayNameAndFormat { DisplayName ="Customer Name"}},
                        {  "Amount",new DisplayNameAndFormat { DisplayName ="Transaction Amount"}},
                        {  "Currency",new DisplayNameAndFormat { DisplayName ="Transaction Currency"}},
                        {  "PrimaryOwner",new DisplayNameAndFormat { DisplayName ="Primary Owner"}},
                        {  "Product",new DisplayNameAndFormat { DisplayName = "Product"}},
                        {  "ProductType",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                        {  "EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                        {  "EventStatus",new DisplayNameAndFormat { DisplayName ="Event Status"}},
                        {  "CaseStatus",new DisplayNameAndFormat { DisplayName ="Case Status"}},
                        {  "Name",new DisplayNameAndFormat { DisplayName ="Name"}},
                        {  "FtiReference",new DisplayNameAndFormat { DisplayName ="Fti Reference"}},
                        {  "EventCreationDate",new DisplayNameAndFormat { DisplayName ="Event Creation Date"}},
                        {  "MasterAssignedTo",new DisplayNameAndFormat { DisplayName ="Master Assigned To"}},
                        {  "EventSteps",new DisplayNameAndFormat { DisplayName ="Event Steps"}},
                        {  "StepStatus",new DisplayNameAndFormat { DisplayName ="Step Status"}},
                        {  "LastActionTokenBy",new DisplayNameAndFormat { DisplayName ="Last Action Token By"}},
                        {  "StartdTime",new DisplayNameAndFormat { DisplayName ="Started Time"}},
                        {  "LstModTime",new DisplayNameAndFormat { DisplayName ="Last Modify Time"}},
                        {  "LstModUser",new DisplayNameAndFormat { DisplayName ="Last Modify User"}},

                    }
                }
            },
            {
                nameof(ArtFtiActivityController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "EcmReference",new DisplayNameAndFormat { DisplayName ="Ecm Reference"}},
                        {  "FtiReference",new DisplayNameAndFormat { DisplayName ="Fti Reference"}},
                        {  "EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                        {  "EventStatus",new DisplayNameAndFormat { DisplayName ="Event Status"}},
                        {  "EventCreationDate",new DisplayNameAndFormat { DisplayName ="Event Creation Date"}},
                        {  "MasterAssignedTo",new DisplayNameAndFormat { DisplayName ="Master Assigned To"}},
                        {  "EventSteps",new DisplayNameAndFormat { DisplayName ="Event Steps"}},
                        {  "StepStatus",new DisplayNameAndFormat { DisplayName = "Step Status"}},
                        {  "Product",new DisplayNameAndFormat { DisplayName = "Product"}},

                    }
                }
            },
             {
                nameof(ArtFtiEcmTransactionController).ToLower(),new ReportConfig{
                    SkipList = new List<string>()
                    {
                    },
                    DisplayNames =new Dictionary<string, DisplayNameAndFormat>{
                        {  "EcmReference",new DisplayNameAndFormat { DisplayName ="Ecm Reference"}},
                        {  "Product",new DisplayNameAndFormat { DisplayName ="Product"}},
                        {  "ProductType",new DisplayNameAndFormat { DisplayName ="Product Type"}},
                        {  "Amount",new DisplayNameAndFormat { DisplayName ="Amount"}},
                        {  "Currency",new DisplayNameAndFormat { DisplayName ="Currency"}},
                        {  "FtiReference",new DisplayNameAndFormat { DisplayName ="Fti Reference"}},
                        {  "EventName",new DisplayNameAndFormat { DisplayName ="Event Name"}},
                        {  "EventStatus",new DisplayNameAndFormat { DisplayName = "Event Status"}},
                        {  "EventCreationDate",new DisplayNameAndFormat { DisplayName = "Event Creation Date"}},
                        {  "FirstLineParty",new DisplayNameAndFormat { DisplayName = "First Line Party"}},
                        {  "TradeInstructions",new DisplayNameAndFormat { DisplayName = "Trade Instructions"}},
                        {  "FirstLineInstructions",new DisplayNameAndFormat { DisplayName = "First Line Instructions"}},

                    }
                }
            },
        };

    }
}

