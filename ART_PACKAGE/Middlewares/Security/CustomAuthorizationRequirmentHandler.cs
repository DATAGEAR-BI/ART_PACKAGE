﻿using ART_PACKAGE.Areas.Identity.Data;
 using ART_PACKAGE.Controllers;
 using Microsoft.AspNetCore.Identity;

 namespace ART_PACKAGE.Middlewares.Security
{
    public class CustomAuthorizationRequirmentHandler : AuthorizationHandler<CustomAuthorizationRequirment>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomAuthorizationRequirmentHandler( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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

             if (string.IsNullOrEmpty(roleName))
            {
                context.Succeed(requirement);
                return;
            }

            if (!_httpContextAccessor.HttpContext.User.IsInRole( roleName))
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


            if (controller.ToLower() == nameof(CustomReportController).ToLower() || controller.ToLower() == nameof(MyReportsController).ToLower() || controller.ToLower() == nameof(ReportCategoryController).ToLower())
                return "art_customreport".ToLower();


            if (controller.ToLower() == nameof(LicenseController).ToLower())
                return "art_superadmin".ToLower();
            
            if (controller.ToLower() == nameof(FilesController).ToLower())
                return string.Empty;
            
            

            return $"art_{controller.Replace("controller", "")}".ToLower();
        }
    }
}