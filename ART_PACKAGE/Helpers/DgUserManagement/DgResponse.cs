using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public class DgResponse
    {
        public int StatusCode { get; set; }
        public DgUserManagementResponse? DgUserManagementResponse { get; set; }
        public UserLoginInfo? UserLoginInfo { get; set; }
    }
}
