using ART_PACKAGE.Controllers;

namespace ART_PACKAGE.Helpers.License
{
    public static class ModulePerLicense
    {
        private static readonly List<string> SASAMLControllers = new()
        {
            nameof(AlertDetailsController).ToLower() ,
            nameof(AlertSummaryController).ToLower() ,
            nameof(AlertedEntitiesController).ToLower() ,
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
            if (SASAMLControllers.Contains(controller))
            {
                return "SASAML";
            }

            return DGAMLControllers.Contains(controller)
                ? "DGAML"
                : GOAMLControllers.Contains(controller) ? "GOAML" : ECMControllers.Contains(controller) ? "ECM" : string.Empty;
        }
    }
}
