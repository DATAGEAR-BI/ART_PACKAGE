namespace ART_PACKAGE.Helpers.License
{
    public interface ILicenseReader
    {
        public Middlewares.License.License ReadFromText(string encodedtext);

        public Middlewares.License.License ReadFromPath(string path);

        public IEnumerable<Middlewares.License.License> ReadAllAppLicenses();
    }
}
