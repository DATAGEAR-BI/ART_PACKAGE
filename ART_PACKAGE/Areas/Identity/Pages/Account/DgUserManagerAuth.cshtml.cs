
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DgUserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Role = ART_PACKAGE.Helpers.DgUserManagement.Role;

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
        public InputModel? Input { get; set; }



        public string? ReturnUrl { get; set; }


        public class InputModel
        {
            [Required]

            public string? Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public IActionResult OnGet(string? ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ReturnUrl = returnUrl;
            _logger.LogWarning("user {email} tring to login at {time}", Input.Email, DateTime.Now.ToShortTimeString());
            try
            {
                if (ModelState.IsValid)
                {
                    DgResponse? info = await dgUM.Authnticate(Input.Email, Input.Password);
                    if (info == null || info.StatusCode != 200)
                    {

                        _logger.LogInformation(info.StatusCode.ToString());
                        ModelState.AddModelError("", "something wrong happened while checking for your account");
                        return Page();
                    }
                    else
                    {
                        IEnumerable<Role> artRoles = info.DgUserManagementResponse.Roles.Where(x => x.Name.ToLower().StartsWith("art_"));
                        IEnumerable<Group> artGroups = info.DgUserManagementResponse.Groups.Where(x => x.Name.ToLower().StartsWith("art_"));

                        string? email = info.UserLoginInfo.ProviderKey;
                        _logger.LogWarning("checking for user External Login");
                        _logger.LogWarning("User Roles : ({roles})", string.Join(",", artRoles.Select(x => x.Name)));
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.UserLoginInfo.LoginProvider, info.UserLoginInfo.ProviderKey, Input.RememberMe, true);

                        if (result.Succeeded)
                        {
                            _logger.LogInformation($"Success {email}");
                            _logger.LogWarning($"Adding roles to user");
                            await AddRolesAndGroupsToUser(email, artRoles);
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
                                _logger.LogWarning($"Adding roles to user");
                                string mail = user.Email;
                                await AddRolesAndGroupsToUser(mail, artRoles);
                                await _signInManager.SignInAsync(user, true);

                            }
                            return LocalRedirect(returnUrl);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error");
                _logger.LogInformation(ReturnUrl);
                _logger.LogInformation(ex.ToString());
                _logger.LogInformation(ex.Message);
            }
            return Page();
        }




        private async Task AddRolesAndGroupsToUser(string currentUserEmail, IEnumerable<Role> userRoles)
        {
            AppUser currentUser = await _userManager.FindByEmailAsync(currentUserEmail);

            if (currentUser == null)
            {
                // Handle the case where the user doesn't exist
                return;
            }

            // Remove all existing roles from the user
            IList<string> userRolesToRemove = await _userManager.GetRolesAsync(currentUser);
            if (userRolesToRemove.Any())
            {
                _ = await _userManager.RemoveFromRolesAsync(currentUser, userRolesToRemove);
            }

            foreach (Role role in userRoles)
            {
                string normalizedRoleName = role.Name.ToLower();

                bool roleExists = await _roleManager.RoleExistsAsync(normalizedRoleName);

                // If the role doesn't exist, create it
                if (!roleExists)
                {
                    _ = await _roleManager.CreateAsync(new IdentityRole(normalizedRoleName));
                }

                // Add the user to the role
                if (!await _userManager.IsInRoleAsync(currentUser, normalizedRoleName))
                {
                    _ = await _userManager.AddToRoleAsync(currentUser, normalizedRoleName);
                }
            }
        }
    }







}
