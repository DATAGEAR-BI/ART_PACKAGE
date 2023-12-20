
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ART_PACKAGE.Areas.Identity.Pages.Account
{
    public class NotFoundModel : PageModel
    {
        public string? ErrorDetails { get; set; }
        public void OnGet()
        {
            if (HttpContext.Items.ContainsKey("ErrorDetails"))
            {
                ErrorDetails = HttpContext.Items["ErrorDetails"] as string;
            }
        }
    }
}
