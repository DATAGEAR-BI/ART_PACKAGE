using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;
using AuthContext = ART_PACKAGE.Areas.Identity.Data.AuthContext;

namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public class DgUserManager : IDgUserManager
    {
        private readonly HttpClient _httpClient;

        private readonly string authUrl;
        private readonly ILogger<DgUserManager> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AuthContext authContext;
        public DgUserManager(IConfiguration config, ILogger<DgUserManager> logger, HttpClient httpClient, RoleManager<IdentityRole> roleManager, AuthContext authContext)
        {
            authUrl = config.GetSection("DgUserManagementAuth:authUrl").Value;

            _httpClient = httpClient;
            _logger = logger;
            _roleManager = roleManager;
            this.authContext = authContext;
        }

        public async Task<DgResponse?> Authnticate(string name, string password)
        {
            try
            {

                var model = new
                {
                    name,
                    password
                };


                // Serialize the model to JSON
                string jsonModel = JsonConvert.SerializeObject(model);

                // Create StringContent from JSON
                StringContent content = new(jsonModel, Encoding.UTF8, "application/json");
                _logger.LogWarning("sending req to DGUM with body  : {ReqBody}", await content.ReadAsStringAsync());
                HttpResponseMessage response = await _httpClient.PostAsync(authUrl + "/dg-userManagement-console/security/signIn", content);
                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();
                    _logger.LogWarning("res received from DGUM with body  : {ReqBody}", responseBody);
                    DgUserManagementResponse? userManagementResponse = JsonConvert.DeserializeObject<DgUserManagementResponse>(responseBody);

                    if (userManagementResponse != null)
                    {
                        DgResponse dgResponse = new()
                        {
                            StatusCode = 200,
                            UserLoginInfo = new UserLoginInfo("DGUM", name, "DGUM"),
                            DgUserManagementResponse = userManagementResponse
                        };
                        return dgResponse;
                    }
                    return new()
                    {
                        StatusCode = 500,

                    };
                }
                else
                {
                    _logger.LogWarning("res received from DGUM with Status Code : {StatusCode} , Error  : {Error}", response.StatusCode, await response.Content.ReadAsStringAsync());

                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("User Managment Search Error --------- {Message}", ex.Message);
                return null;
            }

        }
        //public async Task ConfigureGroupsAndRoles()
        //{

        //    var model = new
        //    {
        //        name = "um_admin@dgpw",
        //        password = "um_admin1"
        //    };



        //    // Serialize the model to JSON
        //    string jsonModel = JsonConvert.SerializeObject(model);

        //    // Create StringContent from JSON
        //    StringContent content = new(jsonModel, Encoding.UTF8, "application/json");
        //    HttpResponseMessage authRes = await _httpClient.PostAsync(authUrl + "/dg-userManagement-console/security/authenticate", content);
        //    string token = string.Empty;
        //    if (authRes.IsSuccessStatusCode)
        //    {
        //        string responseBody = await authRes.Content.ReadAsStringAsync();
        //        AuthRes? userManagementResponse = JsonConvert.DeserializeObject<AuthRes>(responseBody);
        //        token = userManagementResponse.Token;
        //    }
        //    _httpClient.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", token);
        //    string resString = string.Empty;
        //    HttpResponseMessage res = await _httpClient.GetAsync(authUrl + "/dg-userManagement-console/Group/findGroups");
        //    if (!res.IsSuccessStatusCode)
        //        return;
        //    resString = await res.Content.ReadAsStringAsync();


        //    IEnumerable<GroupsRes>? groupsRes = JsonConvert.DeserializeObject<List<GroupsRes>>(resString).Where(x => x.Name.ToLower().StartsWith("art_"));

        //    res = await _httpClient.GetAsync(authUrl + "/dg-userManagement-console/Role/UsersGroupsOfRole");
        //    if (!res.IsSuccessStatusCode)
        //        return;
        //    resString = await res.Content.ReadAsStringAsync();
        //    IEnumerable<RoleRes>? rolesRes = JsonConvert.DeserializeObject<List<RoleRes>>(resString).Where(x => x.Name.ToLower().StartsWith("art_"));

        //    List<string> ExistingRoles = _roleManager.Roles.Select(x => x.Name).ToList();

        //    foreach (string role in ExistingRoles)
        //    {
        //        RoleRes? umRole = rolesRes.FirstOrDefault(x => x.Name.ToLower() == role.ToLower());
        //        if (umRole == null)
        //        {
        //            continue;
        //        }

        //        res = await _httpClient.GetAsync(authUrl + "/dg-userManagement-console/Role/UserGroups/" + umRole.Id);
        //        resString = await res.Content.ReadAsStringAsync();
        //        IEnumerable<string> roleGroups = groupsRes.Where(x => JsonConvert.DeserializeObject<RoleGroupsRes>(resString).Groups.Contains(x.Id)).Select(x => x.Name.ToUpper());

        //        if (await _roleManager.RoleExistsAsync(role))
        //        {
        //            IdentityRole roundRole = await _roleManager.FindByNameAsync(role);
        //            _ = await _roleManager.DeleteAsync(roundRole);
        //        }

        //        IdentityRole roleToAdd = new(role);
        //        _ = await _roleManager.CreateAsync(roleToAdd);
        //        foreach (string? group in roleGroups)
        //        {
        //            _ = await _roleManager.AddClaimAsync(roleToAdd, new Claim("GROUP", group));
        //        }
        //    }

        //}

    }
}
