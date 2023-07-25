using ART_PACKAGE.Areas.Identity.Data.Configrations;
using ART_PACKAGE.Controllers;

namespace ART_PACKAGE.Helpers.License
{
    public static class ModulePerLicense
    {
        private static readonly List<string> SASAMLControllers = new List<string>() { nameof(AlertDetailsController).ToLower() };
        private static readonly List<string> BaseControllers = new List<string>() { nameof(HomeController).ToLower(),
                                                                                    nameof(ReportController).ToLower(),
                                                                                    };
        public static bool isBaseModule(string controllerName)
        {
            var controller = (controllerName + "Controller").ToLower();
            return BaseControllers.Contains(controller);
        }
        public static string GetModule(string controllerName)
        {
            var controller = (controllerName + "Controller").ToLower();
            if (SASAMLControllers.Contains(controller))
                return "SASAML";

            return string.Empty;
        }
    }
}
