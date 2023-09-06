using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Models;
using ART_PACKAGE.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    [Authorize]
    public class LicenseController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILicenseReader _licReader;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LicenseController> _logger;

        public LicenseController(IWebHostEnvironment webHostEnvironment, ILicenseReader licReader, IConfiguration configuration, ILogger<LicenseController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _licReader = licReader;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IActionResult> UploadLic([FromForm] LicenseUpload lic)
        {

            string? client = _configuration.GetSection("Client")
                .Get<string>()?.ToLower();
            IEnumerable<string>? LicenseModules = _configuration.GetSection("Modules")
                .Get<List<string>>()?.Select(x => x.ToLower());
            using StreamReader reader = new(lic.License.OpenReadStream());
            string licText = reader.ReadToEnd();
            License license = _licReader.ReadFromText(licText);

            if (lic.Module == "base" && client != license.Client.ToLower())
            {
                return BadRequest(new Error("LiceError", "the license is not compatible with the module you selected"));
            }

            if (lic.Module != "base" && client + lic.Module.ToLower() != license.Client.ToLower())
            {
                return BadRequest(new Error("LiceError", "the license is not compatible with the module you selected"));
            }

            if (lic.Module != "base" && !LicenseModules.Contains(lic.Module.ToLower()))
            {
                return BadRequest(new Error("LiceError", "this module is not supported in the app configration"));
            }

            if (!license.IsValid())
            {
                return BadRequest(new Error("LiceError", "the license you tring to upload is expired"));
            }

            string licPath = Path.Combine(_webHostEnvironment.ContentRootPath, Path.Combine("Licenses", lic.License.FileName));
            bool isLicExist = System.IO.File
                .Exists(licPath);


            if (isLicExist)
            {
                System.IO.File.Delete(licPath);
            }

            try
            {
                using FileStream fileStream = new(licPath, FileMode.Create, FileAccess.ReadWrite);
                await lic.License.CopyToAsync(fileStream);
                return Ok(license);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new Error("LiceError", description: "Something wrong happened while saving the license"));

            }

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<License> licenses = _licReader.ReadAllAppLicenses().AsQueryable();
            KendoDataDesc<License> Data = licenses.CallData(request);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                doesNotContainAllFun = true,
                toolbar = new List<dynamic>
                {
                    new
                    {
                        text = "Add/Replace Module License",
                        id="addreplic",
                        show = User?.Identity?.Name?.ToLower() == "art_admin@datagearbi.com"
                    }
                },
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };

        }
    }
}
