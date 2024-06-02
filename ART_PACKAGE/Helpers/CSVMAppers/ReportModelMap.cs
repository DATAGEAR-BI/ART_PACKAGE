using ART_PACKAGE.Controllers.AML_ANALYSIS;
using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.DGAUDIT;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.FTI;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.KYC;
using ART_PACKAGE.Controllers.SASAML;
using ART_PACKAGE.Controllers.SASAUDIT;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;

using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.SASAUDIT;
using ArtAmlAnalysisRule = Data.Data.AmlAnalysis.ArtAmlAnalysisRule;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public static class ReportModelMap
    {
        private static readonly Dictionary<string, List<Type>> Map = new()
        {
            //SASAML
            { nameof(AlertDetailsController).ToLower() , new List<Type> { typeof(ArtAmlAlertDetailView)  } },
            { nameof(CasesDetailsController).ToLower() , new List<Type> { typeof(ArtAmlCaseDetailsView)  } },
            { nameof(CustomersController).ToLower() , new List<Type> { typeof(ArtAmlCustomersDetailsView)  } },
            { nameof(HighRiskController).ToLower() , new List<Type> { typeof(ArtAmlHighRiskCustView)  } },
            { nameof(RiskAssessmentController).ToLower() , new List<Type> { typeof(ArtRiskAssessmentView)  } },
            { nameof(TriageController).ToLower() , new List<Type> { typeof(ArtAmlTriageView)  } },


            //KYC
            {nameof( ArtAuditCorporateController).ToLower() ,new List<Type>{ typeof(ArtAuditCorporateView) } }     ,
            {nameof( ArtAuditIndividualsController).ToLower() ,new List<Type>{typeof(ArtAuditIndividualsView) } }     ,
            {nameof( ArtKycExpiredIdController).ToLower() ,new List<Type>{typeof(ArtKycExpiredId) } }     ,
            {nameof( ArtKycHighExpiredController).ToLower() ,new List<Type>{typeof(ArtKycHighExpired) } }     ,
            {nameof( ArtKycHighOneMonthController).ToLower() ,new List<Type>{typeof(ArtKycHighOneMonth) } }     ,
            {nameof( ArtKycHighThreeMonthController).ToLower() ,new List<Type>{typeof(ArtKycHighThreeMonth) } }     ,
            {nameof( ArtKycHighTwoMonthController).ToLower() ,new List<Type>{typeof(ArtKycHighTwoMonth) } }     ,
            {nameof( ArtKycLowExpiredController).ToLower() ,new List<Type>{typeof(ArtKycLowExpired) } }     ,
            {nameof( ArtKycLowOneMonthController).ToLower() ,new List<Type>{typeof(ArtKycLowOneMonth) } }     ,
            {nameof( ArtKycLowThreeMonthController).ToLower() ,new List<Type>{typeof(ArtKycLowThreeMonth) } }     ,
            {nameof( ArtKycLowTwoMonthController).ToLower() ,new List<Type>{typeof(ArtKycLowTwoMonth) } }     ,
            {nameof( ArtKycMediumExpiredController).ToLower() ,new List<Type>{typeof(ArtKycMediumExpired) } }     ,
            {nameof( ArtKycMediumOneMonthController).ToLower() ,new List<Type>{typeof(ArtKycMediumOneMonth) } }     ,
            {nameof( ArtKycMediumThreeMonthController).ToLower() ,new List<Type>{typeof(ArtKycMediumThreeMonth) } }     ,
            {nameof( ArtKycMediumTwoMonthController).ToLower() ,new List<Type>{typeof(ArtKycMediumTwoMonth) } }     ,
            {nameof( ArtKycSummaryByRiskController).ToLower() ,new List<Type>{typeof(ArtKycSummaryByRisk) } }     ,




            //GOAML
            {nameof(GOAMLReportIndicatorDetailsController).ToLower() ,new List<Type>{ typeof(ArtGoamlReportsIndicator) } }     ,
            {nameof(GOAMLReportsDetailsController).ToLower() ,new List<Type>{ typeof(ArtGoamlReportsDetail) } }     ,
            {nameof(GOAMLReportsSuspectController).ToLower() ,new List<Type>{ typeof(ArtGoamlReportsSusbectParty) } }     ,


            //FTI
            { nameof(EcmAuditTrialController                  ).ToLower() ,    new List<Type>{ typeof(ArtTiEcmAuditReport) } }     ,
            { nameof(EcmWorkflowProgController                ).ToLower() ,    new List<Type>{ typeof(ArtTiEcmWorkflowProgReport) } }     ,
            { nameof(ACPostingsAccountController              ).ToLower() ,    new List<Type>{ typeof(ArtTiAcpostingsAccReport) } }     ,
            { nameof(ACPostingsCustomersController            ).ToLower() ,    new List<Type>{ typeof(ArtTiAcpostingsCustReport) } }     ,
            { nameof(ActivityController                       ).ToLower() ,    new List<Type>{ typeof(ArtTiActivityReport) } }     ,
            { nameof(AdvancePaymentUtilizationController      ).ToLower() ,    new List<Type>{ typeof(ArtTiAdvancePaymentUtilizationReport) } }     ,
            { nameof(AmortizationController                   ).ToLower() ,    new List<Type>{ typeof(ArtTiAmortizationReport) } }     ,
            { nameof(DiaryExceptionsController                ).ToLower() ,    new List<Type>{ typeof(ArtTiDiaryExceptionsReport) } }     ,
            { nameof(EcmTransactionsController                ).ToLower() ,    new List<Type>{ typeof(ArtTiEcmTransactionsReport) } }     ,
            { nameof(FinancingInterestAccrualsController      ).ToLower() ,    new List<Type>{ typeof(ArtTiFinanInterAccrual) } }     ,
            { nameof(FullJournalController                    ).ToLower() ,    new List<Type>{ typeof(ArtTiFullJournalReport) } }     ,
            { nameof(InterfaceDetailsController               ).ToLower() ,    new List<Type>{ typeof(ArtTiInterfaceDetailsReport) } }     ,
            { nameof(MasterEventHistoryController             ).ToLower() ,    new List<Type>{ typeof(ArtTiMasterEventHistory) } }     ,
            { nameof(OSActivityController                     ).ToLower() ,    new List<Type>{ typeof(ArtTiOsActivityReport) } }     ,
            { nameof(OSLiabilityController                    ).ToLower() ,    new List<Type>{ typeof(ArtTiOsLiabilityReport) } }     ,
            { nameof(OSTransactionsAwaitiApprlController      ).ToLower() ,    new List<Type>{ typeof(ArtTiOsTransAwaitiApprlReport) } }     ,
            { nameof(OSTransactionsByGatewayController        ).ToLower() ,    new List<Type>{ typeof(ArtTiOsTransByGatewayReport) } }     ,
            { nameof(OSTransactionsByNonPriController         ).ToLower() ,    new List<Type>{ typeof(ArtTiOsTransByNonpriReport) } }     ,
            { nameof(OSTransactionsByPrincipalController      ).ToLower() ,    new List<Type>{ typeof(ArtTiOsTransByPrincipalReport) } }     ,
            { nameof(OurChargesByCustomerController           ).ToLower() ,    new List<Type>{ typeof(ArtTiChargesByCustReport) } }     ,
            { nameof(OurChargesByMasterController             ).ToLower() ,    new List<Type>{ typeof(ArtTiChargesByMasterReport) } }     ,
            { nameof(OurChargesDetailsController              ).ToLower() ,    new List<Type>{ typeof(ArtTiChargesDetailsReport) } }     ,
            { nameof(PeriodicCHRGsController                  ).ToLower() ,    new List<Type>{ typeof(ArtTiPeriodicChrgsReport) } }     ,
            { nameof(PeriodicCHRGSPaymentController           ).ToLower() ,    new List<Type>{ typeof(ArtTiPeriodicChrgsPayReport) } }     ,
            { nameof(WatchlistOSCheckController               ).ToLower() ,    new List<Type>{ typeof(ArtTiWatchlistOsCheckReport) } }     ,
            { nameof(SystemTailoringController                ).ToLower() ,    new List<Type>{ typeof(ArtTiSystemTailoringReport) } }     ,

            //ECM
           { nameof(SystemPerformanceController).ToLower() , new List<Type>{ typeof(ArtSystemPerformance) } }     ,
           { nameof(UserPerformanceController).ToLower()  ,new List<Type>{ typeof(ArtUserPerformance) } }     ,
           { nameof(SwiftMessagesController).ToLower()  ,new List<Type>{ typeof(ArtSwiftMessagesView) } }     ,
           { nameof(MakerCheckerPerformenceDetailController).ToLower()  ,new List<Type>{ typeof(MakerCheckerPerformanceView) } }     ,



           //audit
          {nameof(ListOfUserController).ToLower()                         ,           new List<Type>{ typeof(ListOfUser) } }     ,
          { nameof(ListOfGroupsController).ToLower()                       ,              new List<Type>{ typeof(ListOfGroup) } }     ,
          { nameof(ListOfRoleController).ToLower()                         ,              new List<Type>{ typeof(ListOfRole) } }     ,
          { nameof(ListOfUsersAndGroupsRoleController).ToLower()           ,              new List<Type>{ typeof(ListOfUsersAndGroupsRole) } }     ,
          { nameof(ListOfUsersGroupController).ToLower()                   ,              new List<Type>{ typeof(ListOfUsersGroup) } }     ,
          { nameof(ListOfUsersRolesController).ToLower()                   ,              new List<Type>{ typeof(ListOfUsersRole) } }     ,
          { nameof(ListGroupsRolesSummaryController).ToLower()             ,              new List<Type>{ typeof(ListGroupsRolesSummary) } }     ,
          { nameof(ListGroupsSubGroupsSummaryController).ToLower()         ,              new List<Type>{ typeof(ListGroupsSubGroupsSummary) } }     ,
          { nameof(ListOfDeletedUsersController).ToLower()                 ,              new List<Type>{ typeof(ListOfDeletedUser) } }     ,
          { nameof(LastLoginPerDayController).ToLower()                    ,              new List<Type>{ typeof(LastLoginPerDayView) } }     ,
          { nameof(AuditUsersController).ToLower()                         ,              new List<Type>{ typeof(ArtUsersAuditView) } }     ,
          { nameof(AuditGroupsController).ToLower()                        ,              new List<Type>{ typeof(ArtGroupsAuditView) } }     ,
          { nameof(AuditRolesController).ToLower()                         ,              new List<Type>{ typeof(ArtRolesAuditView) } }     ,

          //SASAUDIT
          {nameof(SASAuditTrailActionController).ToLower()                         ,           new List<Type>{ typeof(SasAuditTrailReport) } }     ,
          {nameof(SASAuditListAppController).ToLower()                         ,           new List<Type>{ typeof(VaLicensedView) } }     ,
          {nameof(SASAuditTrailAccessGroupRoleController).ToLower()                         ,           new List<Type>{ typeof(SasListAccessRightPerProfile) } }     ,
          {nameof(SASAuditTrailAccessRoleController).ToLower()                         ,           new List<Type>{ typeof(SasListAccessRightPerRole) } }     ,
          {nameof(SASAuditTrailGroupsRolesSummaryController).ToLower()                         ,           new List<Type>{ typeof(SasListGroupsRolesSummary) } }     ,
          {nameof(SASAuditTrailUsersGroupsCapsController).ToLower()                         ,           new List<Type>{ typeof(SasListAccessUsersGroupsCap) } }     ,
          {nameof(SASAuditTrailUsersGroupsRoleController).ToLower()                         ,           new List<Type>{ typeof(SasListOfUsersAndGroupsRole) } }     ,
          {nameof(SASAuditTrailLastLoginController).ToLower()                         ,           new List<Type>{ typeof(VaLastLoginView) } }     ,



          //DGAML

          {  nameof(DGAMLAlertDetailsController).ToLower() ,                            new List<Type>{ typeof(ArtDgAmlAlertDetailView) } }     ,
          { nameof(DGAMLArtExternalCustomerDetailsController).ToLower() ,               new List<Type>{ typeof(ArtExternalCustomerDetailView) } }     ,
          { nameof(DGAMLArtScenarioAdminController).ToLower() ,                         new List<Type>{ typeof(ArtScenarioAdminView) } }     ,
          { nameof(DGAMLArtScenarioHistoryController).ToLower() ,                       new List<Type>{ typeof(ArtScenarioHistoryView) } }     ,
          { nameof(DGAMLArtSuspectDetailsController).ToLower() ,                        new List<Type>{ typeof(ArtSuspectDetailView) } }     ,
          { nameof(DGAMLCasesDetailsController).ToLower() ,                             new List<Type>{ typeof(ArtDgAmlCaseDetailView) } }     ,
          { nameof(DGAMLCustomersDetailsController).ToLower() ,                         new List<Type>{ typeof(ArtDgAmlCustomerDetailView) } }     ,
          { nameof(DGAMLTriageController).ToLower() ,                                   new List<Type>{ typeof(ArtDgAmlTriageView) } }     ,



          //AMLANALYSIS
          { nameof(AML_ANALYSISController).ToLower() ,                                   new List<Type>{ typeof(ArtAmlAnalysisViewTb)  , typeof(ArtAmlAnalysisRule) } }     ,


          //TASK_SCHEDULER




        };





        public static List<Type>? GetReportModels(string controller)
        {


            if (!Map.ContainsKey(controller))
                return null;

            return Map[controller];
        }
    }


}

