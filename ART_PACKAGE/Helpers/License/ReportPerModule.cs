using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.AML_ANALYSIS;
using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.DGAUDIT;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.EXPORT_SCHEDULAR;
using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Controllers.SASAML.AlertSummaryReport;
using ART_PACKAGE.Controllers.SEG;
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
            nameof(SystemPerformanceSummaryController).ToLower() ,
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
        private static readonly List<string> SchedularControllers = new()
        {

            nameof(TasksController).ToLower() ,


        };
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
          nameof( ArtAuditCorporateController        ).ToLower() ,
          nameof( ArtAuditIndividualsController      ).ToLower() ,
          nameof( ArtKycExpiredIdController          ).ToLower() ,
          nameof( ArtKycHighExpiredController        ).ToLower() ,
          nameof( ArtKycHighOneMonthController       ).ToLower() ,
          nameof( ArtKycHighThreeMonthController     ).ToLower() ,
          nameof( ArtKycHighTwoMonthController       ).ToLower() ,
          nameof( ArtKycLowExpiredController         ).ToLower() ,
          nameof( ArtKycLowOneMonthController        ).ToLower() ,
          nameof( ArtKycLowThreeMonthController      ).ToLower() ,
          nameof( ArtKycLowTwoMonthController        ).ToLower() ,
          nameof( ArtKycMediumExpiredController      ).ToLower() ,
          nameof( ArtKycMediumOneMonthController     ).ToLower() ,
          nameof( ArtKycMediumThreeMonthController   ).ToLower() ,
          nameof( ArtKycMediumTwoMonthController     ).ToLower() ,
          nameof( ArtKycSummaryByRiskController      ).ToLower() ,


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
                                                                                    nameof(ReportController).ToLower(),
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
                : SchedularControllers.Contains(controller) ? AppModules.EXPORT_SCHEDULAR
                : SEGControllers.Contains(controller) ? AppModules.SEG
                : string.Empty;
        }
    }
}
