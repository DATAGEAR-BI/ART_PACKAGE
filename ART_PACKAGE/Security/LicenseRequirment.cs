namespace ART_PACKAGE.Security
{
    public class LicenseRequirment : IAuthorizationRequirement
    {
        public List<string> Modules { get; set; } = new List<string>() { "ART" };

    }
}
