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

                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl + endPoint, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    DgUserManagementResponse? userManagementResponse = JsonConvert.DeserializeObject<DgUserManagementResponse>(responseBody);

                    if (userManagementResponse != null)
                    {
                        DgResponse dgResponse = new()
                        {
                            StatusCode = int.Parse(response.StatusCode.ToString()),
                            UserLoginInfo = new UserLoginInfo("DGUM", uid, "DGUM"),
                            DgUserManagementResponse = userManagementResponse
                        };
                        return dgResponse;
                    }
                    return new()
                    {
                        StatusCode = int.Parse(response.StatusCode.ToString()),

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
