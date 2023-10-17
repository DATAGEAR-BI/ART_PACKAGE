using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Middlewares.Security
{
    public class CustomAuthorizationRequirmentHandler : AuthorizationHandler<CustomAuthorizationRequirment>
    {

        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly UserManager<AppUser> _userManger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthorizationRequirmentHandler(RoleManager<IdentityRole> roleManger, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManger)
        {

            _roleManger = roleManger;
            _httpContextAccessor = httpContextAccessor;
            _userManger = userManger;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirment requirement)
        {
            RouteData? routeData = _httpContextAccessor.HttpContext?.GetRouteData();
            string? controllerName = routeData?.Values["controller"]?.ToString();
            string controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;

            if (string.IsNullOrEmpty(controller))
            {
                context.Succeed(requirement);
                return;
            }
            string roleName = controller.ToLower() == "userrole".ToLower()
                                ? "art_admin".ToLower()
                                : controller.ToLower() == "report".ToLower()
                                ? "art_customreport".ToLower()
                                : controller.ToLower() == "License".ToLower() ? "art_superadmin".ToLower() : $"art_{controller}".ToLower();



            //IEnumerable<string> groups = (await _roleManger.GetClaimsAsync(routeRole)).Where(c => c.Type == "GROUP").Select(x => x.Value);
            //&& context.User.Claims.Where(c => c.Type == "GROUP").Select(x => x.Value).Distinct().All(x => !groups.Contains(x))
            AppUser user = await _userManger.GetUserAsync(context.User);
            if (!await _userManger.IsInRoleAsync(user, roleName))
            {
                context.Fail();
                return;
            }
            context.Succeed(requirement);
        }
    }
}
