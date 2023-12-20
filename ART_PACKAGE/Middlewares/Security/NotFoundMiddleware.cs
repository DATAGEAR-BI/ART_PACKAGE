namespace ART_PACKAGE.Middlewares.Security
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {

                context.Items["ErrorDetails"] = context.Request.Path.Value;

                // Redirect to the error handling Razor Page
                context.Response.Redirect("/NotFound");
            }
        }
    }


}
