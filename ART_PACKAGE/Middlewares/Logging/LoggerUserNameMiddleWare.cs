using Serilog.Context;

namespace ART_PACKAGE.Middlewares.Logging
{
    public class LogUserNameMiddleware
    {
        private readonly RequestDelegate next;

        public LogUserNameMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            string user = "Unkown";
            if (context.User is not null && context.User.Identity is not null && context.User.Identity.Name is not null)
            {
                user = context.User.Identity.Name;
            }
            _ = LogContext.PushProperty("User", user);

            return next(context);
        }
    }
}
