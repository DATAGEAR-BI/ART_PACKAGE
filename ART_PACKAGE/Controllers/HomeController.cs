using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Models;
using Data.DGCMGMT;
using Data.FCF71;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Data.Constants.StoredProcs;
using Microsoft.Data.SqlClient;
using System.Data;
using Data.Data;
using Oracle.ManagedDataAccess.Client;

namespace ART_PACKAGE.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthContext _db;
        private readonly IDbService _dbSrv;
        public HomeController(ILogger<HomeController> logger, AuthContext db/*, FCF71Context fcf71*/, IDbService dbSrv)
        {
            _logger = logger;
            this._db = db;
            _dbSrv = dbSrv;
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
            var numberOfCustomers = _db.ArtHomeDgamlNumberOfCustomers.FirstOrDefault()?.NumberOfCustomers ?? 0;
            var numberOfPepCustomers = _db.ArtHomeDgamlNumberOfPepCustomers.FirstOrDefault()?.NumberOfPepCustomers ?? 0;
            var numberOfAccounts = _db.ArtHomeDgamlNumberOfAccounts.FirstOrDefault()?.NumberOfAccounts ?? 0;
            var numberOfHighRiskCustomers = _db.ArtHomeDgamlNumberOfHighRiskCustomers.FirstOrDefault()?.NumberOfHighRiskCustomers ?? 0;

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
            var statusData = _db.ArtHomeCasesStatuses.Select(x => new { CaseStatus = x.CaseStatus ?? "Unkown", NumberOfCases = x.NumberOfCases, year = x.YEAR });
            var typesData = _db.ArtHomeCasesTypes.Select(x => new { CaseType = x.CaseType ?? "Unkown", NumberOfCases = x.NumberOfCases, year = x.YEAR }); ;



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

            var distinct_value = _dbSrv.CORE.FscPartyDims.Where(x => x.ChangeCurrentInd == "Y").Select(x => x.ResidenceCountryName == null || string.IsNullOrEmpty(x.ResidenceCountryName.Trim()) ? "UNKNOWN" : x.ResidenceCountryName).Distinct().ToList();
            return Ok(distinct_value);
        }

        public IActionResult GetAmlChartsData()
        {
            var dateData = _db.ArtHomeDgamlAlertsPerDates.ToList().GroupBy(x => x.Year).Select(x => new
            {
                year = x.Key.ToString(),
                value = x.Sum(x => x.NumberOfAlerts),
                monthData = x.GroupBy(m => m.Month).Select(m => new
                {
                    Month = m.Key.ToString(),
                    value = m.Sum(x => x.NumberOfAlerts)
                })
            });

            var alertsPerStatus = _db.ArtHomeDgamlAlertsPerStatuses;

            return Ok(new
            {
                dates = dateData,
                statuses = alertsPerStatus
            });
        }
    }
}