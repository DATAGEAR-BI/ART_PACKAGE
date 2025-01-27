using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.FTI;

namespace ART_PACKAGE.Helpers.License
{
    public static class ModulePerLicense
    {
        private static readonly List<string> FTIControllers = new()
        {
            nameof(ArtCasesInitiatedFromBranchController).ToLower() ,
            nameof(ArtDgecmActivityController).ToLower() ,
            nameof(ArtEcmFtiFullCycleController).ToLower() ,
            nameof(ArtEcmPendingCasesController).ToLower() ,
            nameof(ArtEcmSlaViolatedCasesController).ToLower() ,
            nameof(ArtFtiActivityController).ToLower() ,
            nameof(ArtFtiEcmTransactionController).ToLower() ,
            nameof(ArtFtiEndToEndController).ToLower() ,
            nameof(ArtFtiEndToEndNewController).ToLower() ,
            nameof(ArtFtiSummaryController).ToLower() ,
        };




        private static readonly List<string> BaseControllers = new() { nameof(HomeController).ToLower(),
                                                                                    nameof(ReportController).ToLower(),
                                                                                    nameof(HomeController).ToLower(),
                                                                                    nameof(UserRoleController).ToLower(),
                                                                                    };
        public static bool isBaseModule(string controllerName)
        {
            string controller = (controllerName + "Controller").ToLower();
            return BaseControllers.Contains(controller);
        }
         public static string GetModule(string controllerName)
         {
             string controller = (controllerName + "Controller").ToLower();
             return FTIControllers.Contains(controller)
                 ? "FTI" : string.Empty;
         }
    }
        
}
