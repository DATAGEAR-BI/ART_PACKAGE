using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<AppUser> _um;

        public BaseController(UserManager<AppUser> um)
        {
            _um = um;
        }

        protected async Task<AppUser> GetUser()
        {
            return await _um.GetUserAsync(User);
        }
    }
}