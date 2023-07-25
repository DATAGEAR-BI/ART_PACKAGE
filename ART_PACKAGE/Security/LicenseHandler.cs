using ART_PACKAGE.Helpers.License;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ART_PACKAGE.Security
{
    public class LicenseHandler : AuthorizationHandler<LicenseRequirment>
    {
        private readonly ILicenseReader licenseReader;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LicenseHandler(ILicenseReader licenseReader, IHttpContextAccessor httpContextAccessor)
        {
            this.licenseReader = licenseReader;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LicenseRequirment requirement)
        {
            //check if Datagear admin user 
            if (context.User is not null && context.User?.Identity?.Name?.ToLower() == "art_admin@datagearbi.com")
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            //app License
            var applic = licenseReader.ReadFromPath("license.dg");
            if (applic is null || !applic.IsValid())
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //getting the route user want to access
            var routeData = _httpContextAccessor.HttpContext?.GetRouteData();
            var controllerName = routeData?.Values["controller"]?.ToString();
            var controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;

            //checking if empty route or controller is basemodule like home or custom report
            if (string.IsNullOrEmpty(controller) || ModulePerLicense.isBaseModule(controller))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            //getting the module the route is in
            var module = ModulePerLicense.GetModule(controller);
            //checking if the app configuration supports that module
            if (!requirement.Modules.Contains(module))
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //getting module license since all modlue lisenes should be (modulename+"license.dg")
            var moduleLic = licenseReader.ReadFromPath(module + "license.dg");
            //checking if the license is valid
            if (moduleLic is null || !moduleLic.IsValid())
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //all license are correct and valid
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
