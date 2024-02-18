using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Middlewares.License;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Controllers
{

    public class LicenseController : BaseReportController<IGridConstructor<ILicenseReader, DbContext, License>, ILicenseReader, DbContext, License>
    {
        public LicenseController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IGridConstructor<ILicenseReader, DbContext, License> gc, UserManager<AppUser> um, ILogger<LicenseController> logger) : base(gc, um)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _logger = logger;
        }


        public override IActionResult Index()
        {
            return View();
        }

        private readonly IWebHostEnvironment _webHostEnvironment;
        // private readonly ILicenseReader _licReader;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LicenseController> _logger;
        //
        // public LicenseController(IWebHostEnvironment webHostEnvironment, ILicenseReader licReader, IConfiguration configuration, ILogger<LicenseController> logger)
        // {
        //     _webHostEnvironment = webHostEnvironment;
        //     _licReader = licReader;
        //     _configuration = configuration;
        //     _logger = logger;
        // }
        //
        public async Task<IActionResult> UploadLic([FromForm] LicenseUpload lic)
        {
            string? client = _configuration.GetSection("Client")
                .Get<string>()?.ToLower();
            IEnumerable<string>? LicenseModules = _configuration.GetSection("Modules")
                .Get<List<string>>()?.Select(x => x.ToLower());
            using StreamReader reader = new(lic.License.OpenReadStream());
            string licText = reader.ReadToEnd();
            License license = _gridConstructor.Repo.ReadFromText(licText);

            if (lic.Module == "base" && client != license.Client.ToLower())
            {
                return BadRequest();
            }

            if (lic.Module != "base" && client + lic.Module.ToLower() != license.Client.ToLower())
            {
                return BadRequest();
            }

            if (lic.Module != "base" && !LicenseModules.Contains(lic.Module.ToLower()))
            {
                return BadRequest();
            }

            if (!license.IsValid())
            {
                return BadRequest();
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
                return BadRequest();

            }

        }
    }
}
