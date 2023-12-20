namespace ART_PACKAGE.Middlewares.Security
{
    public class AccessDeniedMiddleware
    {
        private readonly RequestDelegate _next;

        public AccessDeniedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {


            if (context.Response.StatusCode == 403 && !context.Response.HasStarted)
            {
                // Redirect to the error handling Razor Page
                context.Response.Redirect("/Identity/Account/AccessDenied");
            }
            else
            {

                await _next(context);
            }
        }
    }
}
