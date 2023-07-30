using Data.Constants;
using java.security;
using java.security.spec;
using javax.crypto;
using System.Text;

namespace ART_PACKAGE.Helpers.License
{
    public class LicenseReader : ILicenseReader
    {
        private readonly Cipher _cipher;
        private readonly PublicKey _publicKey;
        private readonly ILogger<LicenseReader> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LicenseReader(ILogger<LicenseReader> logger, IWebHostEnvironment webHostEnvironment)
        {
            _cipher = Cipher.getInstance("RSA");
            _publicKey = getDecodedPublicKey(LicenseConstants.PUBLIC_KEY);
            _cipher.init(2, _publicKey);
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public Security.License ReadFromPath(string path)
        {
            var appPath = _webHostEnvironment.ContentRootPath;
            var licPath = Path.Combine(appPath, Path.Combine("Licenses", path));
            try
            {
                var licEncodedString = File.ReadAllText(licPath);
                return this.ReadFromText(licEncodedString);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }


        }

        public Security.License ReadFromText(string encodedtext)
        {
            return Parse(DycreptLicense(encodedtext));
        }
        private byte[] DycreptLicense(string licenseEncoded)
        {
            byte[] encrypted = Convert.FromBase64String(licenseEncoded);
            byte[] original = _cipher.doFinal(encrypted);
            return original;
        }
        private Security.License Parse(byte[] data)
        {
            Security.License license = new Security.License();

            var timeBytes = data[..8];
            long timeValue = 0L;
            foreach (var @byte in timeBytes)
            {
                timeValue = (timeValue << 8) + (@byte & 255);
            }
            license.ValidUnti = timeValue;
            var client = data[12..];
            license.Client = Encoding.UTF8.GetString(client);
            return license;
        }

        private PublicKey getDecodedPublicKey(string encoded)
        {
            try
            {
                X509EncodedKeySpec x509EncodedKeySpec = new X509EncodedKeySpec(Convert.FromBase64String(encoded));
                PublicKey publicKey = KeyFactory.getInstance("RSA").generatePublic(x509EncodedKeySpec);
                return publicKey;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public IEnumerable<Security.License> ReadAllAppLicenses()
        {
            var licensesFiles = Directory
              .GetFiles(Path.Combine(_webHostEnvironment.ContentRootPath, "Licenses"));
            var licenseFilesNames = licensesFiles.Select(x => x.Replace(Path.Combine(_webHostEnvironment.ContentRootPath, "Licenses") + "\\", ""));
            var licenses = licenseFilesNames.Select(x => this.ReadFromPath(x));
            return licenses;
        }
    }
}
