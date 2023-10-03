
using System.ComponentModel.DataAnnotations;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.LDap;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ART_PACKAGE.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LDapAuthModel : PageModel
    {
        private readonly LDapUserManager ldapUM;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LDapAuthModel> _logger;

        public LDapAuthModel(SignInManager<AppUser> signInManager,
            ILogger<LDapAuthModel> logger,
            UserManager<AppUser> userManager, LDapUserManager ldapUM)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.ldapUM = ldapUM;
        }

        [BindProperty]
        public InputModel Input { get; set; }



        public string ReturnUrl { get; set; }


        public class InputModel
        {
            [Required]

            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public IActionResult OnGet(string ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                UserLoginInfo? info = ldapUM.Authnticate(Input.Email, Input.Password);
                if (info is null)
                {
                    ModelState.AddModelError("", "something wrong happened while checking your account on the server");
                    return Page();
                }
                else
                {
                    string? email = info.ProviderKey;
                    //if (email is not null )
                    //{
                    //    user = await uM.FindByEmailAsync(email);
                    //    if (user is not null && user.EmailConfirmed is not true)
                    //    {
                    //        ModelState.AddModelError("", $"Email not confirmed");
                    //        return View("login", model);
                    //    }
                    //}
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, Input.RememberMe, true);

                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {

                        if (email is not null)
                        {
                            AppUser user = await _userManager.FindByEmailAsync(email);
                            if (user is null)
                            {
                                user = new AppUser()
                                {
                                    Email = email,
                                    UserName = email
                                };
                                IdentityResult createresult = await _userManager.CreateAsync(user);
                                if (!createresult.Succeeded)
                                {
                                    ModelState.AddModelError("", $"There is an error while creating an email for you");
                                    return Page();
                                }
                            }
                            _ = await _userManager.AddLoginAsync(user, info);
                            await _signInManager.SignInAsync(user, true);

                        }
                        return LocalRedirect(returnUrl);
                    }

                }


            }
            return Page();
        }
    }
}
