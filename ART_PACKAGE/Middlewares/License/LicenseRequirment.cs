using Microsoft.AspNetCore.Authorization;

namespace ART_PACKAGE.Middlewares.License
{
    public class LicenseRequirment : IAuthorizationRequirement
    {
        public List<string> Modules { get; set; } = new List<string>() { "ART" };

    }
}
