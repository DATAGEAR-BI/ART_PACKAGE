using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ART_PACKAGE.Areas.Identity.Pages.Account
{
    public class LicenseExpiredModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
