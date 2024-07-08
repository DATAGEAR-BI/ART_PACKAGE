﻿using ART_PACKAGE.Areas.Identity.Data;
 using ART_PACKAGE.Controllers;
 using Microsoft.AspNetCore.Identity;
using static iTextSharp.text.pdf.AcroFields;

 namespace ART_PACKAGE.Middlewares.Security
{
    public class CustomAuthorizationRequirmentHandler : AuthorizationHandler<CustomAuthorizationRequirment>
    {

        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly UserManager<AppUser> _userManger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<CustomAuthorizationRequirmentHandler> _logger;



        public CustomAuthorizationRequirmentHandler(RoleManager<IdentityRole> roleManger, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManger,ILogger<CustomAuthorizationRequirmentHandler> log)
        {

            _roleManger = roleManger;
            _httpContextAccessor = httpContextAccessor;
            _userManger = userManger;
            _logger= log;
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

            string roleName = GetControllerRole(controller + "controller");

            //IEnumerable<string> groups = (await _roleManger.GetClaimsAsync(routeRole)).Where(c => c.Type == "GROUP").Select(x => x.Value);
            //&& context.User.Claims.Where(c => c.Type == "GROUP").Select(x => x.Value).Distinct().All(x => !groups.Contains(x))
            if (string.IsNullOrEmpty(roleName))
            {
                context.Succeed(requirement);
                return;
            }
            
           
            AppUser user = await _userManger.GetUserAsync(context.User);
            _logger.LogCritical("controller name from header is : " + controller);
            _logger.LogCritical("roleName name of controller is : " + roleName);
            _logger.LogCritical("user name now is : " + user.Email);
            var isInRole = await _userManger.IsInRoleAsync(user, roleName);
            var roles =await _userManger.GetRolesAsync(user);
            _logger.LogCritical("roleS------NUMBER : " + roles.Count()); 
            foreach (var item in roles)
            {
                _logger.LogCritical("role------name : " + item);
            }
            
            _logger.LogCritical("user is in role : " + isInRole);

            if (!await _userManger.IsInRoleAsync(user, roleName))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }

        private string GetControllerRole(string controller)
        {
            if (!controller.ToLower().EndsWith("controller"))
                return "";


            if (controller.ToLower() == nameof(CustomReportController).ToLower() || controller.ToLower() == nameof(MyReportsController).ToLower())
                return "art_customreport".ToLower();

            if (controller.ToLower() == nameof(UserRoleController).ToLower())
                return "art_admin".ToLower();

            if (controller.ToLower() == nameof(LicenseController).ToLower())
                return "art_superadmin".ToLower();
            
            if (controller.ToLower() == nameof(FilesController).ToLower())
                return string.Empty;
            
            

            return $"art_{controller.Replace("controller", "")}".ToLower();
        }
    }
}