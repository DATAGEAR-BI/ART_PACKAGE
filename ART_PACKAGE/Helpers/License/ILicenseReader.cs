using Data.Services;
using Microsoft.EntityFrameworkCore;
namespace ART_PACKAGE.Helpers.License
{
    public interface ILicenseReader : IBaseRepo<DbContext, Middlewares.License.License>
    {
        public Middlewares.License.License ReadFromText(string encodedtext);

        public Middlewares.License.License ReadFromPath(string path);

        public IEnumerable<Middlewares.License.License> ReadAllAppLicenses();

        public Task AddOrUpdateLicense(LicenseUpload lic);
    }
}
