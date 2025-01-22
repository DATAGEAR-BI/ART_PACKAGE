using ART_PACKAGE.Controllers;

using ART_PACKAGE.Controllers.ECM;


using ART_PACKAGE.Controllers.KYC;

using Data.Constants.AppModules;

namespace ART_PACKAGE.Helpers.License
{
    public static class ReportPerModule
    {
        private static readonly List<string> SASAMLControllers = new()
        {
            nameof(AlertDetailsController).ToLower() ,
            nameof(AlertSummaryController).ToLower() ,

            nameof(TriageController).ToLower() ,
            nameof(HighRiskController).ToLower() ,
            nameof(CustomersController).ToLower() ,
            nameof(CustomersSummaryController).ToLower() ,
            nameof(RiskSummaryController).ToLower() ,
            nameof(RiskAssessmentController).ToLower() ,
            nameof(CasesDetailsController).ToLower() ,
            nameof(CasesSummaryController).ToLower() ,
        };
        private static readonly List<string> DGAMLControllers = new()
        {
            nameof(DGAMLAlertDetailsController).ToLower() ,
            nameof(DGAMLAlertSummaryController).ToLower() ,
            nameof(DGAMLArtExternalCustomerDetailsController).ToLower() ,
            nameof(DGAMLArtScenarioAdminController).ToLower() ,
            nameof(DGAMLArtScenarioHistoryController).ToLower() ,
            nameof(DGAMLArtSuspectDetailsController).ToLower() ,
            nameof(DGAMLCasesDetailsController).ToLower() ,
            nameof(DGAMLCasesSummaryController).ToLower() ,
            nameof(DGAMLCustomersDetailsController).ToLower() ,
            nameof(DGAMLCustomerSummaryController).ToLower() ,
            nameof(DGAMLExternalCustomerSummaryController).ToLower() ,
            nameof(DGAMLTriageController).ToLower() ,
        };
        private static readonly List<string> GOAMLControllers = new()
        {
            nameof(GOAMLReportIndicatorDetailsController).ToLower() ,
            nameof(GOAMLReportsDetailsController).ToLower() ,
            nameof(GOAMLReportsSummaryController).ToLower() ,
            nameof(GOAMLReportsSuspectController).ToLower() ,
        };
        private static readonly List<string> ECMControllers = new()
        {
            nameof(SystemPerformanceController).ToLower() ,
            //nameof(SystemPerformanceNewSummaryController).ToLower() ,
            nameof(UserPerformanceController).ToLower() ,
            nameof(UserPerformancePerActionUserController).ToLower() ,
            nameof(UserPerformancePerUserAndActionController).ToLower() ,
            nameof(UserPerformPerActionController).ToLower() ,
            //nameof(AlertedEntitiesController).ToLower() ,
        };

        private static readonly List<string> SEGControllers = new()
        {

            nameof(AllSegmentsOutliersNewController).ToLower() ,
            nameof(SegmentationChartsController).ToLower() ,

        };
        // private static readonly List<string> SchedularControllers = new()
        // {
        //
        //     nameof(TasksController).ToLower() ,
        //
        //
        // };
        private static readonly List<string> AmlAnalysisControllers = new()
        {

            nameof(AML_ANALYSISController).ToLower() ,


        };
        private static readonly List<string> AuditControllers = new()
        {

            nameof(ListOfUserController).ToLower()                         ,
            nameof(ListOfGroupsController).ToLower()                       ,
            nameof(ListOfRoleController).ToLower()                         ,
            nameof(ListOfUsersAndGroupsRoleController).ToLower()           ,
            nameof(ListOfUsersGroupController).ToLower()                   ,
            nameof(ListOfUsersRolesController).ToLower()                   ,
            nameof(ListGroupsRolesSummaryController).ToLower()             ,
            nameof(ListGroupsSubGroupsSummaryController).ToLower()         ,
            nameof(ListOfDeletedUsersController).ToLower()                 ,
            nameof(LastLoginPerDayController).ToLower()                    ,
            nameof(AuditUsersController).ToLower()                         ,
            nameof(AuditGroupsController).ToLower()                        ,
            nameof(AuditRolesController).ToLower()                         ,

        };
        private static readonly List<string> KYCControllers = new()
        {
            nameof(ArtKycHighExpiredU1Controller).ToLower() ,
            nameof(ArtKycHighExpiredU2Controller).ToLower() ,
            nameof(ArtKycHighExpiredU3Controller).ToLower() ,
            nameof(ArtKycHighExpiredU4Controller).ToLower() ,
            nameof(ArtKycHighOneMonthU1Controller).ToLower() ,
            nameof(ArtKycHighOneMonthU2Controller).ToLower() ,
            nameof(ArtKycHighOneMonthU3Controller).ToLower() ,
            nameof(ArtKycHighOneMonthU4Controller).ToLower() ,
            nameof(ArtKycHighThreeMonthU1Controller).ToLower() ,
            nameof(ArtKycHighThreeMonthU2Controller).ToLower() ,
            nameof(ArtKycHighThreeMonthU3Controller).ToLower() ,
            nameof(ArtKycHighThreeMonthU4Controller).ToLower() ,
            nameof(ArtKycHighTwoMonthU1Controller).ToLower() ,
            nameof(ArtKycHighTwoMonthU2Controller).ToLower() ,
            nameof(ArtKycHighTwoMonthU3Controller).ToLower() ,
            nameof(ArtKycHighTwoMonthU4Controller).ToLower() ,
            nameof(ArtKycLowExpiredU1Controller).ToLower() ,
            nameof(ArtKycLowExpiredU2Controller).ToLower() ,
            nameof(ArtKycLowExpiredU3Controller).ToLower() ,
            nameof(ArtKycLowExpiredU4Controller).ToLower() ,
            nameof(ArtKycLowOneMonthU1Controller).ToLower() ,
            nameof(ArtKycLowOneMonthU2Controller).ToLower() ,
            nameof(ArtKycLowOneMonthU3Controller).ToLower() ,
            nameof(ArtKycLowOneMonthU4Controller).ToLower() ,
            nameof(ArtKycLowThreeMonthU1Controller).ToLower() ,
            nameof(ArtKycLowThreeMonthU2Controller).ToLower() ,
            nameof(ArtKycLowThreeMonthU3Controller).ToLower() ,
            nameof(ArtKycLowThreeMonthU4Controller).ToLower() ,
            nameof(ArtKycLowTwoMonthU1Controller).ToLower() ,
            nameof(ArtKycLowTwoMonthU2Controller).ToLower() ,
            nameof(ArtKycLowTwoMonthU3Controller).ToLower() ,
            nameof(ArtKycLowTwoMonthU4Controller).ToLower() ,
            nameof(ArtKycMediumExpiredU1Controller).ToLower() ,
            nameof(ArtKycMediumExpiredU2Controller).ToLower() ,
            nameof(ArtKycMediumExpiredU3Controller).ToLower() ,
            nameof(ArtKycMediumExpiredU4Controller).ToLower() ,
            nameof(ArtKycMediumOneMonthU1Controller).ToLower() ,
            nameof(ArtKycMediumOneMonthU2Controller).ToLower() ,
            nameof(ArtKycMediumOneMonthU3Controller).ToLower() ,
            nameof(ArtKycMediumOneMonthU4Controller).ToLower() ,
            nameof(ArtKycMediumThreeMonthU1Controller).ToLower() ,
            nameof(ArtKycMediumThreeMonthU2Controller).ToLower() ,
            nameof(ArtKycMediumThreeMonthU3Controller).ToLower() ,
            nameof(ArtKycMediumThreeMonthU4Controller).ToLower() ,
            nameof(ArtKycMediumTwoMonthU1Controller).ToLower() ,
            nameof(ArtKycMediumTwoMonthU2Controller).ToLower() ,
            nameof(ArtKycMediumTwoMonthU3Controller).ToLower() ,
            nameof(ArtKycMediumTwoMonthU4Controller).ToLower() ,
            nameof(CustomersRenewalPerMonthU1Controller).ToLower() ,
            nameof(CustomersRenewalPerMonthU2Controller).ToLower() ,
            nameof(CustomersRenewalPerMonthU3Controller).ToLower() ,
            nameof(CustomersRenewalPerMonthU4Controller).ToLower() ,
            nameof(CustomersRenewalU1Controller).ToLower() ,
            nameof(CustomersRenewalU2Controller).ToLower() ,
            nameof(CustomersRenewalU3Controller).ToLower() ,
            nameof(CustomersRenewalU4Controller).ToLower() ,
            nameof(CustomersWithExpiredDocumentU1Controller).ToLower() ,
            nameof(CustomersWithExpiredDocumentU2Controller).ToLower() ,
            nameof(CustomersWithExpiredDocumentU3Controller).ToLower() ,
            nameof(CustomersWithExpiredDocumentU4Controller).ToLower() ,
            nameof(GeographicalDistributionU1Controller).ToLower() ,
            nameof(GeographicalDistributionU2Controller).ToLower() ,
            nameof(GeographicalDistributionU3Controller).ToLower() ,
            nameof(GeographicalDistributionU4Controller).ToLower() ,



        };

        private static readonly List<string> FTIControllers = new()
        {
            nameof(EcmAuditTrialController                  ).ToLower() ,
            nameof(EcmWorkflowProgController                ).ToLower() ,
            nameof(ACPostingsAccountController              ).ToLower() ,
            nameof(ACPostingsCustomersController            ).ToLower() ,
            nameof(ActivityController                       ).ToLower() ,
            nameof(AdvancePaymentUtilizationController      ).ToLower() ,
            nameof(AmortizationController                   ).ToLower() ,
            nameof(DiaryExceptionsController                ).ToLower() ,
            nameof(EcmTransactionsController                ).ToLower() ,
            nameof(FinancingInterestAccrualsController      ).ToLower() ,
            nameof(FullJournalController                    ).ToLower() ,
            nameof(InterfaceDetailsController               ).ToLower() ,
            nameof(MasterEventHistoryController             ).ToLower() ,
            nameof(OSActivityController                     ).ToLower() ,
            nameof(OSLiabilityController                    ).ToLower() ,
            nameof(OSTransactionsAwaitiApprlController      ).ToLower() ,
            nameof(OSTransactionsByGatewayController        ).ToLower() ,
            nameof(OSTransactionsByNonPriController         ).ToLower() ,
            nameof(OSTransactionsByPrincipalController      ).ToLower() ,
            nameof(OurChargesByCustomerController           ).ToLower() ,
            nameof(OurChargesByMasterController             ).ToLower() ,
            nameof(OurChargesDetailsController              ).ToLower() ,
            nameof(PeriodicCHRGsController                  ).ToLower() ,
            nameof(PeriodicCHRGSPaymentController           ).ToLower() ,
            nameof(WatchlistOSCheckController               ).ToLower() ,
            nameof(SystemTailoringController                ).ToLower() ,




        };





        private static readonly List<string> BaseControllers = new() { nameof(HomeController).ToLower(),
                                                                                    nameof(CustomersController).ToLower(), 
                                                                                    };
        public static bool isBaseModule(string controllerName)
        {
            string controller = (controllerName + "Controller").ToLower();
            return BaseControllers.Contains(controller);
        }
        public static string GetModule(string controllerName)
        {
            string controller = (controllerName + "Controller").ToLower();
            return SASAMLControllers.Contains(controller) ? AppModules.SASAML
                : DGAMLControllers.Contains(controller) ? AppModules.DGAML
                : GOAMLControllers.Contains(controller) ? AppModules.GOAML
                : ECMControllers.Contains(controller) ? AppModules.ECM
                : FTIControllers.Contains(controller) ? AppModules.FTI
                : KYCControllers.Contains(controller) ? AppModules.KYC
                : AuditControllers.Contains(controller) ? AppModules.DGAUDIT
                : AmlAnalysisControllers.Contains(controller) ? AppModules.AMLANALYSIS
                //: SchedularControllers.Contains(controller) ? AppModules.EXPORT_SCHEDULAR
                : SEGControllers.Contains(controller) ? AppModules.SEG
                : string.Empty;
        }
    }
}
