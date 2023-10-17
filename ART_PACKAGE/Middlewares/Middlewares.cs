using ART_PACKAGE.Middlewares.License;
using ART_PACKAGE.Middlewares.Security;

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
    }
}

