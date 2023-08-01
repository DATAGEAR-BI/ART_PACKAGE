using Data.Constants;
using Microsoft.AspNetCore.Authorization;

namespace ART_PACKAGE.Security
{
    public class LicenseMiddleWare
    {
        private readonly RequestDelegate next;

        public LicenseMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IAuthorizationService authorizationService)
        {

            if (context.Request.Path.HasValue && context.GetRouteData().Values["controller"]?.ToString()?.ToLower() == "license" && context?.User?.Identity?.Name?.ToLower() != "art_admin@datagearbi.com")
            {
                context?.Response.Redirect("/Identity/Account/AccessDenied");
                return;
            }
            AuthorizationResult authorizationResult = context.Request.Path.HasValue && (context.Request.Path.Value.Contains("/license/ExpiredLicense") || context.Request.Path.Value.ToLower().Contains("account"))
                ? AuthorizationResult.Success()
                : await authorizationService.AuthorizeAsync(context.User, null, LicenseConstants.LICENSE_POLICY);
            if (authorizationResult.Succeeded)
            {
                await next(context);
            }
            else
            {
                context.Response.Redirect("/license/ExpiredLicense");

            }
        }
    }
}
