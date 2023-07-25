using Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Serilog.Context;

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
            AuthorizationResult authorizationResult = null;
            if (context.Request.Path.HasValue && context.Request.Path.Value.Contains("/license/ExpiredLicense"))
                authorizationResult = AuthorizationResult.Success();
            else
                authorizationResult = await authorizationService.AuthorizeAsync(context.User, null, LicenseConstants.LICENSE_POLICY);

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
