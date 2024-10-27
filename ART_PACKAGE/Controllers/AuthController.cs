using ART_PACKAGE.Helpers.Auth.Sevices;
using ART_PACKAGE.Helpers.DgUserManagement;
using ART_PACKAGE.Models;
using Data.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ART_PACKAGE.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDgUserManager _dgUM;
        private readonly TenantSettings _tenantSettings;
        private readonly ILogger<AuthController> _logger;
        private readonly ITokenService _tokenService; 


        public AuthController(IDgUserManager dgUM, IOptions<TenantSettings> tenantSettings, ILogger<AuthController> logger,ITokenService token)
        {
            this._dgUM = dgUM;
            _tenantSettings = tenantSettings.Value;
            _logger = logger;
            _tokenService= token;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model,[FromQuery]string? returnUrl= "~/")
        {
            if (!ModelState.IsValid)
                return View(model);

            DgResponse? info = await _dgUM.Authnticate(model.Email, model.Password);
            if (info == null || info.StatusCode != 200)
            {
                ModelState.AddModelError("", "something wrong happened while checking for your account");
                return View(model);
            }
            IEnumerable<Role> artRoles = info.DgUserManagementResponse.Roles.Where(x => x.Name.ToLower().StartsWith("art_"));
            IEnumerable<Group> artGroups = info.DgUserManagementResponse.Groups.Where(x => x.Name.ToLower().StartsWith("art_"));
            IEnumerable<string> artBisnisUnits = info.DgUserManagementResponse.Roles.Where(x => x.Name.ToLower().StartsWith(_tenantSettings.Defaults.BusinessUnitPrefix.ToLower())).Select(s => s.Name.ToUpper().Replace(_tenantSettings.Defaults.BusinessUnitPrefix.ToUpper(), ""));
            string? email = info.UserLoginInfo.ProviderKey;
            _logger.LogWarning("checking for user External Login");
            _logger.LogWarning("User Roles : ({roles})", string.Join(",", artRoles.Select(x => x.Name)));
            var token =_tokenService.GenerateJwtToken(info.DgUserManagementResponse);

            // Store the token in a cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddHours(1),
                Secure = true // Set to true if using HTTPS
            };

            Response.Cookies.Append("auth_token", token, cookieOptions);

            return Redirect(returnUrl); ;
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
         

            // Store the token in a cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddHours(1),
                Secure = true // Set to true if using HTTPS
            };

            Response.Cookies.Delete("auth_token", cookieOptions);

            return Redirect("/Auth/LogIn"); ;
        }

    

}
}
