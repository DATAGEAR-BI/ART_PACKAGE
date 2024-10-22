namespace ART_PACKAGE.Middlewares.Tenant
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tenantId = context.User.FindFirst("tenant_id")?.Value;

            if (tenantId != null)
            {
                // Add tenant ID to the header or other storage for every request
                context.Items["tenant_id"] = tenantId;
            }

            await _next(context);
        }
    }
}
