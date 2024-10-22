using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ART_PACKAGE.Controllers
{
    public class TenantController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public TenantController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTenantClaim(string tenantId)
        {
            var user = await _userManager.GetUserAsync(User);
           
            if (user != null)
            {
              
                var userClaims = await _userManager.GetClaimsAsync(user);
                var existingClaim = userClaims
                    .FirstOrDefault(c => c.Type == "tenant_id");

                if (existingClaim != null)
                {
                    await _userManager.RemoveClaimAsync(user, existingClaim);
                }

                var newClaim = new Claim("tenant_id", tenantId);
                await _userManager.AddClaimAsync(user, newClaim);
                await _signInManager.SignInAsync(user, isPersistent: false);

                var newTenant = (await _userManager.GetClaimsAsync(user))
                    .FirstOrDefault(c => c.Type == "tenant_id");
                var d = HttpContext.User.Claims.ToList();
                return Ok(new { message = "Tenant updated"+newTenant.Value });
            }

            return BadRequest(new { message = "User not found" });
        }
    }
}
