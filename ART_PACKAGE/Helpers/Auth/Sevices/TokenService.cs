using ART_PACKAGE.Helpers.DgUserManagement;
using Data.Setting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ART_PACKAGE.Helpers.Auth.Sevices
{
    public class TokenService:ITokenService
    {
        private readonly JWT _jwt;
        private readonly TenantSettings _tenantSettings;
        public TokenService(IOptions<JWT> jwt, IOptions<TenantSettings> tenantSettings)
        {
            _jwt = jwt.Value;
            _tenantSettings = tenantSettings.Value;
        }
        public string GenerateJwtToken(DgUserManagementResponse authResponse)
        {
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, authResponse.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, authResponse.Name)
    };

            // Add roles as claims
            foreach (var role in authResponse.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            IEnumerable<string> artBisnisUnits = authResponse.Roles.Where(x => x.Name.ToLower().StartsWith(_tenantSettings.Defaults.BusinessUnitPrefix.ToLower())).Select(s => s.Name.ToUpper().Replace(_tenantSettings.Defaults.BusinessUnitPrefix.ToUpper(), ""));

            if (artBisnisUnits != null && artBisnisUnits.Count() > 0)
            {
                claims.Add(new("tenant_idz", string.Join(",", artBisnisUnits)));
                claims.Add(new("tenant_id", artBisnisUnits.First()));
            }
            /*else
            {
                claims.Add(new("tenant_idz", string.Join(",", _tenantSettings.Tenants.Select(s => s.TId))));
                claims.Add(new("tenant_id", _tenantSettings.Tenants.Select(s => s.TId).First()));
            }*/

            /*  // Add custom claims
              foreach (var claim in authResponse.Claims)
              {
                  claims.Add(new Claim(claim.Key, claim.Value));
              }*/

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateJwtToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
