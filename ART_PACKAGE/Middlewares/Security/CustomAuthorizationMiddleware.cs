﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;

namespace ART_PACKAGE.Middlewares.Security
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IOptions<CookieAuthenticationOptions> _cookieAuthenticationOptions;
        private string _redirectUri;
        private readonly IConfiguration _configuration;

        private readonly List<string> _allowedUris = new()
        {
            "/Identity/Account/AccessDenied".ToLower() ,
            "/Account/DgUMAuth/login".ToLower(),
            "/Account/Ldapauth/login".ToLower(),
           "/Account/login".ToLower(),
           "/Tenant/UpdateTenantClaim".ToLower()
        };
        public CustomAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IAuthorizationService authorizationService)
        {
            ControllerActionDescriptor? iscontroller = context.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>();
            if (iscontroller == null)
            {
                await next(context);
                return;
            }
            if (_allowedUris.Contains(context.Request.Path.Value.ToLower()))
            {
                await next(context);
                return;
            }

            if (!context.User.Identity.IsAuthenticated)
            {
                string LoginProvider = _configuration.GetSection("LoginProvider").Value;
                if (LoginProvider == "DGUM") _redirectUri = new PathString("/Account/DgUMAuth/login");
                else if (LoginProvider == "LDAP") _redirectUri = new PathString("/Account/Ldapauth/login");

                context.Response.Redirect(_redirectUri);
                return;
            }
            AuthorizationResult res = await authorizationService.AuthorizeAsync(context.User, null, "CustomAuthorization");
            if (!res.Succeeded)
            {
                context?.Response.Redirect("/Identity/Account/AccessDenied");
                return;
            }
            await next(context);
        }
    }
}