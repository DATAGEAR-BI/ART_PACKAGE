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
        private readonly IConfiguration _configuration;



        public LicenseReader(ILogger<LicenseReader> logger, IWebHostEnvironment webHostEnvironment, IConfiguration configuration )
        {
            _cipher = Cipher.getInstance("RSA");
            _publicKey = getDecodedPublicKey(LicenseConstants.PUBLIC_KEY);
            _cipher.init(2, _publicKey);
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }


        public ART_PACKAGE.Security.License ReadFromPath(string path)
        {
            string appPath = _webHostEnvironment.ContentRootPath;
            string licPath = Path.Combine(appPath, Path.Combine("Licenses", path));
            try
            {
                string licEncodedString = File.ReadAllText(licPath);
                return ReadFromText(licEncodedString);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }


        }

        public ART_PACKAGE.Security.License ReadFromText(string encodedtext)
        {
            return Parse(DycreptLicense(encodedtext));
        }
        private byte[] DycreptLicense(string licenseEncoded)
        {
            byte[] encrypted = Convert.FromBase64String(licenseEncoded);
            byte[] original = _cipher.doFinal(encrypted);
            return original;
        }
        private ART_PACKAGE.Security.License Parse(byte[] data)
        {
            ART_PACKAGE.Security.License license = new();

            byte[] timeBytes = data[..8];
            long timeValue = 0L;
            foreach (byte @byte in timeBytes)
            {
                timeValue = (timeValue << 8) + (@byte & 255);
            }
            license.ValidUnti = timeValue;
            byte[] client = data[12..];
            license.Client = Encoding.UTF8.GetString(client);
            return license;
        }

        private PublicKey getDecodedPublicKey(string encoded)
        {
            try
            {
                X509EncodedKeySpec x509EncodedKeySpec = new(Convert.FromBase64String(encoded));
                PublicKey publicKey = KeyFactory.getInstance("RSA").generatePublic(x509EncodedKeySpec);
                return publicKey;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public IEnumerable<ART_PACKAGE.Security.License> ReadAllAppLicenses()
        {
            string[] licensesFiles = Directory
              .GetFiles(Path.Combine(_webHostEnvironment.ContentRootPath, "Licenses"));
            IEnumerable<string> licenseFilesNames = licensesFiles.Select(x => x.Replace(Path.Combine(_webHostEnvironment.ContentRootPath, "Licenses") + "\\", ""));
            IEnumerable<ART_PACKAGE.Security.License> licenses = licenseFilesNames.Select(x => ReadFromPath(x));
            return licenses;
        }

        public async Task AddOrUpdateLicense(LicenseUpload lic)
        {
            string? client = _configuration.GetSection("Client")
                .Get<string>()?.ToLower();
            IEnumerable<string>? LicenseModules = _configuration.GetSection("Modules")
                .Get<List<string>>()?.Select(x => x.ToLower());
            using StreamReader reader = new(lic.License.OpenReadStream());
            string licText = reader.ReadToEnd();

            ART_PACKAGE.Security.License license = ReadFromText(licText);

            if (lic.Module == "base" && client != license.Client.ToLower())
            {
                throw new Exception();
            }

            if (lic.Module != "base" && client + lic.Module.ToLower() != license.Client.ToLower())
            {
                throw new Exception();
            }

            if (lic.Module != "base" && !LicenseModules.Contains(lic.Module.ToLower()))
            {
                throw new Exception();
            }

            if (!license.IsValid())
            {
                throw new Exception();
            }

            string licPath = Path.Combine(_webHostEnvironment.ContentRootPath, Path.Combine("Licenses", lic.License.FileName));
            bool isLicExist = File.Exists(licPath);

            if (isLicExist)
            {
                File.Delete(licPath);
            }

            using FileStream fileStream = new(licPath, FileMode.Create, FileAccess.ReadWrite);
            await lic.License.CopyToAsync(fileStream);

        }



    }
}
