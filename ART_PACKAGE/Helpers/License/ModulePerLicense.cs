using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.DGAML;
using ART_PACKAGE.Controllers.ECM;
using ART_PACKAGE.Controllers.GOAML;
using ART_PACKAGE.Controllers.SASAML;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Helpers.License
{
    public static class ModulePerLicense
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
            //nameof(SystemPerformanceController).ToLower() ,
            nameof(SystemPerformanceSummaryController).ToLower() ,
            nameof(UserPerformanceController).ToLower() ,
            nameof(UserPerformancePerActionUserController).ToLower() ,
            nameof(UserPerformancePerUserAndActionController).ToLower() ,
            nameof(UserPerformPerActionController).ToLower() ,
            //nameof(AlertedEntitiesController).ToLower() ,
        };





        private static readonly List<string> BaseControllers = new() {nameof(HomeController).ToLower(),
                                                                                    nameof(CustomReportController).ToLower(),
                                                                                    nameof(MyReportsController).ToLower(),
                                                                                    nameof(UserRoleController).ToLower(),
                                                                                    nameof(FilesController).ToLower(),
                                                                                    };
        public static bool isBaseModule(string controllerName)
        {
            string controller = (controllerName + "Controller").ToLower();
            return BaseControllers.Contains(controller);
        }
        public static string GetModule(string controllerName)
        {
            /* string controller = (controllerName + "Controller").ToLower();
             return SASAMLControllers.Contains(controller)
                 ? "SASAML"
                 : DGAMLControllers.Contains(controller)
                 ? "DGAML"
                 : GOAMLControllers.Contains(controller) ? "GOAML" : ECMControllers.Contains(controller) ? "ECM" : string.Empty;*/

            controllerName = (controllerName + "Controller").ToLower();

            // Get the currently loaded assemblies
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Search for the controller type in the loaded assemblies, case-insensitive
            var controllerType = assemblies
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name.Equals(controllerName, StringComparison.OrdinalIgnoreCase) && t.IsSubclassOf(typeof(Controller)));

            if (controllerType == null)
            {
                throw new ArgumentException($"Controller '{controllerName}' not found.");
            }

            // Get the namespace of the controller
            var namespacePath = controllerType.Namespace.Replace('.', Path.DirectorySeparatorChar);

            // Extract the last segment of the namespace path (parent directory name)
            var parentDirectoryName = Path.GetFileName(namespacePath);

            return parentDirectoryName;
        }
    }
}
