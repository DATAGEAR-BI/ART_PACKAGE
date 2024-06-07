using ART_PACKAGE.Areas.Identity.Data;
using Data.Data.ARTAUDIT;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Middlewares.Audit
{
    public class ReportAuditMiddleware
    {
        private readonly RequestDelegate next;
        // private readonly ARTAUDITContext _auditContext;
        // private readonly UserManager<AppUser> _um;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;

        public ReportAuditMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
            /* if (modules.Contains("ARTAUDIT"))
             {
                 IServiceScope scope = _serviceScopeFactory.CreateScope();
                 ARTAUDITContext aud = 

                 this._auditContext = aud;
             }
             
             IServiceScope umScope = _serviceScopeFactory.CreateScope();
             UserManager<AppUser> um = umScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

             this._um = um;*/
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            List<string>? modules = _configuration.GetSection("Modules").Get<List<string>>();

            if (modules != null && modules.Contains("ARTAUDIT"))
            {



                var routeData = context.GetRouteData();
                var controllerName = routeData?.Values["controller"]?.ToString();
                var actionName = routeData?.Values["action"]?.ToString();

                // Extract user information
                var currentUser = context.User;
                if (controllerName != null && controllerName.ToUpper() != "HOME" && (actionName == null || (actionName != null && actionName.ToUpper() == "INDEX")))
                {
                    using (var umScope = serviceProvider.CreateScope())
                    {
                        var _um = umScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


                        var user = currentUser.Identity.IsAuthenticated ? await _um.FindByNameAsync(currentUser.Identity.Name) : null;

                        if (user != null && user.DgUserId != null)
                        {

                            using (var audScope = serviceProvider.CreateScope())
                            {

                                var _auditContext = audScope.ServiceProvider.GetRequiredService<ARTAUDITContext>(); ;
                                _auditContext.ArtAuditUserAccessLogs.Add(new()
                                {
                                    UserNumber = user.DgUserId,
                                    UserName = user.UserName,
                                    ReportName = controllerName,
                                    LastLoginDate = user.LastLoginDate,

                                });
                                await _auditContext.SaveChangesAsync();
                            }
                        }
                    }
                }


            }
            await next(context);
        }
    }
}
