
using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Middlewares.License;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Controllers
{

    public class LicenseController : BaseReportController<IGridConstructor<ILicenseReader, DbContext, License>, ILicenseReader, DbContext, License>
    {
        private readonly ILogger<LicenseController> _logger;
        public LicenseController(IGridConstructor<ILicenseReader, DbContext, License> gc, ILogger<LicenseController> logger) : base(gc)
        {
            _logger = logger;
        }


        public override IActionResult Index()
        {
            return View();
        }



        public async Task<IActionResult> UploadLic([FromForm] LicenseUpload lic)
        {
            try
            {
                await _gridConstructor.Repo.AddOrUpdateLicense(lic);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

        }
    }
}
