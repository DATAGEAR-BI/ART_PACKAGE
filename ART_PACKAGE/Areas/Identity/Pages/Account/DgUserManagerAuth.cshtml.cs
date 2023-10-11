
using System.ComponentModel.DataAnnotations;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DgUserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ART_PACKAGE.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class DgUserManagementAuthModel : PageModel
    {
        private readonly IDgUserManager dgUM;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<DgUserManagementAuthModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DgUserManagementAuthModel(SignInManager<AppUser> signInManager,
            ILogger<DgUserManagementAuthModel> logger,
            UserManager<AppUser> userManager, IDgUserManager dgUM, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.dgUM = dgUM;
            _roleManager = roleManager;
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
                DgResponse? info = await dgUM.Authnticate(Input.Email, Input.Password);

                if (info == null || info.StatusCode != 200)
                {
                    ModelState.AddModelError("", "something wrong happened while checking your account on the server");
                    return Page();
                }
                else
                {
                    string? email = info.UserLoginInfo.ProviderKey;
                    //if (email is not null )
                    //{
                    //    user = await uM.FindByEmailAsync(email);
                    //    if (user is not null && user.EmailConfirmed is not true)
                    //    {
                    //        ModelState.AddModelError("", $"Email not confirmed");
                    //        return View("login", model);
                    //    }
                    //}
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.UserLoginInfo.LoginProvider, info.UserLoginInfo.ProviderKey, Input.RememberMe, true);

                    if (result.Succeeded)
                    {
                        foreach (Role role in info.DgUserManagementResponse.Roles)
                        {
                            bool roleExists = await _roleManager.RoleExistsAsync(role.Name);

                            // If the role doesn't exist, create it
                            if (!roleExists)
                            {
                                _ = await _roleManager.CreateAsync(new IdentityRole(role.Name));
                            }
                            // Find the user by username
                            AppUser user = await _userManager.FindByNameAsync(email);

                            // If the user exists, add the role to the user
                            if (user != null)
                            {
                                _ = await _userManager.AddToRoleAsync(user, role.Name);
                                Console.WriteLine($"Role '{role.Name}' added to user '{email}'.");
                            }
                            else
                            {
                                Console.WriteLine($"User '{email}' not found.");
                            }
                        }
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
                            _ = await _userManager.AddLoginAsync(user, info.UserLoginInfo);
                            foreach (Role role in info.DgUserManagementResponse.Roles)
                            {
                                bool roleExists = await _roleManager.RoleExistsAsync(role.Name);

                                // If the role doesn't exist, create it
                                if (!roleExists)
                                {
                                    _ = await _roleManager.CreateAsync(new IdentityRole(role.Name));
                                }
                                // Find the user by username

                                // If the user exists, add the role to the user
                                if (user != null)
                                {
                                    _ = await _userManager.AddToRoleAsync(user, role.Name);
                                    Console.WriteLine($"Role '{role.Name}' added to user '{email}'.");
                                }
                                else
                                {
                                    Console.WriteLine($"User '{email}' not found.");
                                }
                            }
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
