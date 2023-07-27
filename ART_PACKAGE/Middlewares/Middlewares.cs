using ART_PACKAGE.Security;

namespace ART_PACKAGE.Middlewares
{
    public static class Middlewares
    {
        public static IApplicationBuilder UseLicense(this WebApplication app)
        {
            return app.UseMiddleware<LicenseMiddleWare>();
        }
    }
}
