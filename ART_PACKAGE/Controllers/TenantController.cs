using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Auth.Sevices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ART_PACKAGE.Controllers
{
    public class TenantController : Controller
    {
        private readonly ITokenService _tokenService;

        public TenantController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTenantClaim(string tenantId)
        {

           
            if (User != null)
            {
              
                var userClaims = User.Claims.ToList();
                var existingClaim = userClaims
                    .FirstOrDefault(c => c.Type == "tenant_id");

                if (existingClaim != null)
                {
                    userClaims.Remove(existingClaim);
                }

                var newClaim = new Claim("tenant_id", tenantId);
                userClaims.Add(newClaim);

               string token=_tokenService.GenerateJwtToken(userClaims);

                // Store the token in a cookie
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddHours(1),
                    Secure = true // Set to true if using HTTPS
                };

                Response.Cookies.Append("auth_token", token, cookieOptions);
                var d = HttpContext.User.Claims.ToList();
                return Ok(new { message = "Tenant updated"});
            }

            return BadRequest(new { message = "User not found" });
        }
    }
}
