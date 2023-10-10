using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Text;

namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public class DgUserManager : IDgUserManager
    {
        private readonly HttpClient _httpClient;

        private readonly string apiUrl;
        private readonly string endPoint;
        private readonly ILogger<DgUserManager> _logger;
        public DgUserManager(IConfiguration config, ILogger<DgUserManager> logger, HttpClient httpClient)
        {
            apiUrl = config.GetSection("DgUserManagementAuth:apiUrl").Value;
            endPoint = config.GetSection("DgUserManagementAuth:endPoint").Value;
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

                HttpResponseMessage response = await _httpClient.PostAsync("http://192.168.1.20:9999/dg-userManagement-console/security/signIn", content);
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
