
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DgUserManagement;
using Data.Setting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
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
        private readonly TenantSettings _tenantSettings;


        public DgUserManagementAuthModel(SignInManager<AppUser> signInManager,
            ILogger<DgUserManagementAuthModel> logger,
            UserManager<AppUser> userManager, IDgUserManager dgUM, RoleManager<IdentityRole> roleManager, IOptions<TenantSettings> tenantSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.dgUM = dgUM;
            _roleManager = roleManager;
            _tenantSettings = tenantSettings.Value;
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
            var claims = new List<Claim>
                                {};

            _logger.LogWarning("user {email} tring to login at {time}", Input.Email, DateTime.Now.ToShortTimeString());
            try
            {
                if (ModelState.IsValid)
                {
                    DgResponse? info = await dgUM.Authnticate(Input.Email, Input.Password);
                    if (info == null || info.StatusCode != 200)
                    {

                        //_logger.LogInformation(info.StatusCode.ToString());
                        ModelState.AddModelError("", "something wrong happened while checking for your account");
                        return Page();
                    }
                    else
                    {
                        IEnumerable<Role> artRoles = info.DgUserManagementResponse.Roles.Where(x => x.Name.ToLower().StartsWith("art_"));
                        IEnumerable<Group> artGroups = info.DgUserManagementResponse.Groups.Where(x => x.Name.ToLower().StartsWith("art_"));
                        IEnumerable<string> artBisnisUnits = info.DgUserManagementResponse.Roles.Where(x => x.Name.ToLower().StartsWith(_tenantSettings.Defaults.BusinessUnitPrefix.ToLower())).Select(s=>s.Name.ToUpper().Replace(_tenantSettings.Defaults.BusinessUnitPrefix.ToUpper(), ""));
                       

                        string? email = info.UserLoginInfo.ProviderKey;
                        _logger.LogWarning("checking for user External Login");
                        _logger.LogWarning("User Roles : ({roles})", string.Join(",", artRoles.Select(x => x.Name)));
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.UserLoginInfo.LoginProvider, info.UserLoginInfo.ProviderKey, Input.RememberMe, true);

                        if (artBisnisUnits != null && artBisnisUnits.Count() > 0)
                        {
                            claims.Add(new("tenant_idz", string.Join(",", artBisnisUnits)));
                            claims.Add(new("tenant_id", artBisnisUnits.First()));
                        }
                        else
                        {
                            claims.Add(new("tenant_idz", string.Join(",", _tenantSettings.Tenants.Select(s => s.TId))));
                            claims.Add(new("tenant_id", _tenantSettings.Tenants.Select(s => s.TId).First()));
                        } 

                        if (result.Succeeded)
                        {
                            var user = await _userManager.FindByLoginAsync(info.UserLoginInfo.LoginProvider, info.UserLoginInfo.ProviderKey);
                            if (user != null)
                            {
                                var userClaims =await _userManager.GetClaimsAsync(user);
                                if (userClaims!=null )  await _userManager.RemoveClaimsAsync(user, userClaims);

                               
                               await _userManager.AddClaimsAsync(user, claims);
                                // Sign in with the custom claims
                                await _signInManager.SignInWithClaimsAsync(user, new AuthenticationProperties { IsPersistent = Input.RememberMe },claims); // Ensure this line uses claimsIdentity

                            }
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
                                        UserName = email,
                                        /*DgUserId = info.DgUserManagementResponse.Id,
                                        LastLoginDate = DateTime.Now,*/
                                    };
                                    IdentityResult createresult = await _userManager.CreateAsync(user);
                                    if (!createresult.Succeeded)
                                    {
                                        ModelState.AddModelError("", $"There is an error while creating an email for you");
                                        return Page();
                                    }
                                }
                             /*   if (user.DgUserId == null)
                                {
                                    user.DgUserId = info.DgUserManagementResponse.Id;
                                }
                                user.LastLoginDate = DateTime.Now;*/
                                _ = await _userManager.AddLoginAsync(user, info.UserLoginInfo);
                                _logger.LogWarning($"Adding roles to user");
                                await AddRolesAndGroupsToUser(user.Email, artRoles);

                                var userClaims = await _userManager.GetClaimsAsync(user);
                                if (userClaims != null) await _userManager.RemoveClaimsAsync(user, userClaims);
                                await _userManager.AddClaimsAsync(user, claims);

                                await _signInManager.SignInWithClaimsAsync(user, new AuthenticationProperties { IsPersistent = true }, claims);

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
