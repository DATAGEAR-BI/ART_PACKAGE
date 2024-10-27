using ART_PACKAGE.Helpers.DgUserManagement;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Auth.Sevices
{
    public interface ITokenService
    {
        public string GenerateJwtToken(DgUserManagementResponse user);
        public string GenerateJwtToken(List<Claim> claims);

    }
}
