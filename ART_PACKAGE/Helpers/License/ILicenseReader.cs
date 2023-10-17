using License = ART_PACKAGE.Middlewares.License.License;

public interface ILicenseReader
{
    public License ReadFromText(string encodedtext);

    public License ReadFromPath(string path);

    public IEnumerable<License> ReadAllAppLicenses();
}
