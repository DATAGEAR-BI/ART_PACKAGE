using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;

namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public class DgUserManager : IDgUserManager
    {
        private readonly HttpClient _httpClient;

        private readonly string authUrl;
        private readonly ILogger<DgUserManager> _logger;
        public DgUserManager(IConfiguration config, ILogger<DgUserManager> logger, HttpClient httpClient)
        {
            authUrl = config.GetSection("DgUserManagementAuth:authUrl").Value;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<DgResponse?> Authnticate(string uid, string password)
        {
            try
            {

                var model = new
                {
                    name = uid,
                    password
                };


                // Serialize the model to JSON
                string jsonModel = JsonConvert.SerializeObject(model);

                // Create StringContent from JSON
                StringContent content = new(jsonModel, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(authUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    DgUserManagementResponse? userManagementResponse = JsonConvert.DeserializeObject<DgUserManagementResponse>(responseBody);

                    if (userManagementResponse != null)
                    {
                        DgResponse dgResponse = new()
                        {
                            StatusCode = 200,
                            UserLoginInfo = new UserLoginInfo("DGUM", uid, "DGUM"),
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
                    return null;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"LDap Search Error --------- {ex.Message}");
                return null;
            }

        }


    }
}
