using ART_PACKAGE.Controllers;

namespace ART_PACKAGE.Helpers.License
{
    public static class ModulePerLicense
    {
        private static readonly List<string> SASAMLControllers = new();
        private static readonly List<string> DGAMLControllers = new();
        private static readonly List<string> GOAMLControllers = new();
        private static readonly List<string> ECMControllers = new();





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
            return SASAMLControllers.Contains(controller)
                ? "SASAML"
                : DGAMLControllers.Contains(controller)
                ? "DGAML"
                : GOAMLControllers.Contains(controller) ? "GOAML" : ECMControllers.Contains(controller) ? "ECM" : string.Empty;
        }
    }
}
