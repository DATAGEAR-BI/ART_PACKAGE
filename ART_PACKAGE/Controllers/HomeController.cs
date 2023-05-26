using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Models;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ART_PACKAGE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthContext _db;
        /*private readonly DGCMGMTContext dgcmgmt;
        private readonly FCF71Context fcf71;*/
        public HomeController(ILogger<HomeController> logger, AuthContext db/*, FCF71Context fcf71*/)
        {
            _logger = logger;
            this._db = db;
            /*this.dgcmgmt = dgcmgmt;
            this.fcf71 = fcf71;*/
        }

        public IActionResult Index()
        {
            _logger.LogInformation("info");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CardsData()
        {
            var numberOfCustomers = _db.ArtHomeNumberOfCustomers.FirstOrDefault()?.NumberOfCustomers ?? 0;
            var numberOfPepCustomers = _db.ArtHomeNumberOfPepCustomers.FirstOrDefault()?.NumberOfPepCustomers ?? 0;
            var numberOfAccounts = _db.ArtHomeNumberOfAccounts.FirstOrDefault()?.NumberOfAccounts ?? 0;
            var numberOfHighRiskCustomers = _db.ArtHomeNumberOfHighRiskCustomers.FirstOrDefault()?.NumberOfHighRiskCustomers ?? 0;

            return Ok(new
            {
                NumberOfCustomers = numberOfCustomers,
                NumberOfPepCustomers = numberOfPepCustomers,
                NumberOfAccounts = numberOfAccounts,
                NumberOfHighRiskCustomers = numberOfHighRiskCustomers
            });
        }

        public IActionResult getChartsData()
        {

            var dateData = _db.ArtHomeCasesDates.ToList().GroupBy(x => x.Year).Select(x => new
            {
                year = x.Key.ToString(),
                value = x.Sum(x => x.NumberOfCases),
                monthData = x.GroupBy(m => m.Month).Select(m => new
                {
                    Month = m.Key.ToString(),
                    value = m.Sum(x => x.NumberOfCases)
                })
            });
            var statusData = _db.ArtHomeCasesStatuses.Select(x => new { CaseStatus = x.CaseStatus ?? "Unkown", NumberOfCases = x.NumberOfCases });
            var typesData = _db.ArtHomeCasesTypes.Select(x => new { CaseType = x.CaseType ?? "Unkown", NumberOfCases = x.NumberOfCases }); ;



            return Ok(new
            {
                dates = dateData,
                status = statusData,
                types = typesData
            });

        }
    }
}