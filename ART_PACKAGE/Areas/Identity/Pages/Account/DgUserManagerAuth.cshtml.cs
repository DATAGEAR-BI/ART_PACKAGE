
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DgUserManagement;
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
            if (ModelState.IsValid)
            {
                DgResponse? info = await dgUM.Authnticate(Input.Email, Input.Password);
                IEnumerable<Role> artRoles = info.DgUserManagementResponse.Roles.Where(x => x.Name.ToLower().StartsWith("art_"));
                IEnumerable<Group> artGroups = info.DgUserManagementResponse.Groups.Where(x => x.Name.ToLower().StartsWith("art_"));
                if (info == null || info.StatusCode != 200)
                {
                    ModelState.AddModelError("", "something wrong happened while checking for your account");
                    return Page();
                }
                else
                {
                    string? email = info.UserLoginInfo.ProviderKey;
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.UserLoginInfo.LoginProvider, info.UserLoginInfo.ProviderKey, Input.RememberMe, true);

                    if (result.Succeeded)
                    {
                        AppUser currentUser = await _userManager.FindByEmailAsync(email);
                        //await dgUM.ConfigureGroupsAndRoles();
                        await AddRolesAndGroupsToUser(currentUser, artRoles);
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
                            AppUser currentUser = await _userManager.FindByEmailAsync(email);
                            _ = await _userManager.AddLoginAsync(user, info.UserLoginInfo);
                            //await dgUM.ConfigureGroupsAndRoles();
                            await AddRolesAndGroupsToUser(currentUser, artRoles);
                            await _signInManager.SignInAsync(user, true);

                        }
                        return LocalRedirect(returnUrl);
                    }

                }


            }
            return Page();
        }




        private async Task AddRolesAndGroupsToUser(AppUser currentUser, IEnumerable<Role> userRoles)
        {
            //IEnumerable<System.Security.Claims.Claim> userGroupsClaims = (await _userManager.GetClaimsAsync(currentUser)).Where(x => x.Type == "GROUP");
            //_ = await _userManager.RemoveClaimsAsync(currentUser, userGroupsClaims);
            //foreach (Group group in userGroups)
            //{
            //    _ = await _userManager.AddClaimAsync(currentUser, new("GROUP", group.Name.ToUpper()));
            //}
            IList<string> userroles = await _userManager.GetRolesAsync(currentUser);
            _ = await _userManager.RemoveFromRolesAsync(currentUser, userroles);

            foreach (Role role in userRoles)
            {
                bool roleExists = await _roleManager.RoleExistsAsync(role.Name.ToLower());

                // If the role doesn't exist, create it
                if (!roleExists)
                {
                    _ = await _roleManager.CreateAsync(new IdentityRole(role.Name.ToLower()));
                    _ = await _userManager.AddToRoleAsync(currentUser, role.Name.ToLower());
                }
                else
                {
                    if (!await _userManager.IsInRoleAsync(currentUser, role.Name.ToLower()))
                        _ = await _userManager.AddToRoleAsync(currentUser, role.Name.ToLower());

                }

            }
        }
    }







}
