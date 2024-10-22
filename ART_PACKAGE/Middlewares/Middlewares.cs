using ART_PACKAGE.Middlewares.License;
using ART_PACKAGE.Middlewares.Security;
using ART_PACKAGE.Middlewares.Tenant;

namespace ART_PACKAGE.Middlewares
{
    public static class Middlewares
    {
        public static IApplicationBuilder UseLicense(this WebApplication app)
        {
            return app.UseMiddleware<LicenseMiddleWare>();
        }

        public static IApplicationBuilder UseCustomAuthorization(this WebApplication app)
        {
            return app.UseMiddleware<CustomAuthorizationMiddleware>();
        }
        public static IApplicationBuilder UseTenantMiddleware(this WebApplication app)
        {
            return app.UseMiddleware<TenantMiddleware>();
        }
    }
}

