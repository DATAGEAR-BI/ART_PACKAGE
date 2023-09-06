namespace ART_PACKAGE.Helpers.License
{
    public interface ILicenseReader
    {
        public Security.License ReadFromText(string encodedtext);

        public Security.License ReadFromPath(string path);

        public IEnumerable<Security.License> ReadAllAppLicenses();
    }
}
