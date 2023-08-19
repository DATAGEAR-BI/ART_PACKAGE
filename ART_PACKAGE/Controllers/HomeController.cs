using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Models;
using Data.Data.ECM;
using Data.FCF71;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EcmContext _db;
        private readonly AuthContext _dbAuth;
        private readonly IDbService _dbSrv;
        public HomeController(ILogger<HomeController> logger, EcmContext db/*, FCF71Context fcf71*/, IDbService dbSrv, AuthContext dbAuth)
        {
            _logger = logger;
            _db = db;
            _dbSrv = dbSrv;
            _dbAuth = dbAuth;
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
            int numberOfCustomers = _dbAuth.ArtHomeNumberOfCustomers.FirstOrDefault()?.NumberOfCustomers ?? 0;
            int numberOfPepCustomers = _dbAuth.ArtHomeNumberOfPepCustomers.FirstOrDefault()?.NumberOfPepCustomers ?? 0;
            int numberOfAccounts = _dbAuth.ArtHomeNumberOfAccounts.FirstOrDefault()?.NumberOfAccounts ?? 0;
            int numberOfHighRiskCustomers = _dbAuth.ArtHomeNumberOfHighRiskCustomers.FirstOrDefault()?.NumberOfHighRiskCustomers ?? 0;

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
            var statusData = _db.ArtHomeCasesStatuses.Select(x => new { CaseStatus = x.CaseStatus ?? "Unkown", x.NumberOfCases, year = x.YEAR });
            var typesData = _db.ArtHomeCasesTypes.Select(x => new { CaseType = x.CaseType ?? "Unkown", x.NumberOfCases, year = x.YEAR }); ;



            return Ok(new
            {
                dates = dateData,
                status = statusData,
                types = typesData
            });

        }

        public IActionResult Test()
        {
            //var sdch2 = new SqlParameter("@V_START_DATE", SqlDbType.Date)
            //{
            //    Value = DateTime.Parse("2020-01-01")
            //};
            //var edch2 = new SqlParameter("@V_END_DATE", SqlDbType.Date)
            //{
            //    Value = DateTime.Parse("2023-01-01")
            //};

            //var data = _db.ExecuteProc<ArtStGoAmlReportsPerCreator>(SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_CREATOR, sdch2, edch2);
            //return Ok(data);

            List<string> distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.ResidenceCountryName == null || string.IsNullOrEmpty(x.ResidenceCountryName.Trim()) ? "UNKNOWN" : x.ResidenceCountryName).Distinct().ToList();
            return Ok(distinct_value);
        }

        public IActionResult GetAmlChartsData()
        {
            var dateData = _dbAuth.ArtHomeAlertsPerDates.ToList().GroupBy(x => x.Year).Select(x => new
            {
                year = x.Key.ToString(),
                value = x.Sum(x => x.NumberOfAlerts),
                monthData = x.GroupBy(m => m.Month).Select(m => new
                {
                    Month = m.Key.ToString(),
                    value = m.Sum(x => x.NumberOfAlerts)
                })
            });

            Microsoft.EntityFrameworkCore.DbSet<ArtHomeAlertsPerStatus> alertsPerStatus = _dbAuth.ArtHomeAlertsPerStatuses;

            return Ok(new
            {
                dates = dateData,
                statuses = alertsPerStatus
            });
        }
    }
}