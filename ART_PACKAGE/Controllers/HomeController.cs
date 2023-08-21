using ART_PACKAGE.Models;
using Data.Data.ECM;
using Data.Data.SASAml;
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
        private readonly SasAmlContext _dbAml;
        private readonly IDbService _dbSrv;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IDbService dbSrv, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {

            _logger = logger;
            _dbSrv = dbSrv;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            List<string>? modules = _configuration.GetSection("Modules").Get<List<string>>();
            if (modules.Contains("SASAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                SasAmlContext amlService = scope.ServiceProvider.GetRequiredService<SasAmlContext>();
                _dbAml = amlService;
            }
            if (modules.Contains("SASAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                EcmContext ecmService = scope.ServiceProvider.GetRequiredService<EcmContext>();
                _db = ecmService;
            }
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
            int numberOfCustomers = _dbAml.ArtHomeNumberOfCustomers.FirstOrDefault()?.NumberOfCustomers ?? 0;
            int numberOfPepCustomers = _dbAml.ArtHomeNumberOfPepCustomers.FirstOrDefault()?.NumberOfPepCustomers ?? 0;
            int numberOfAccounts = _dbAml.ArtHomeNumberOfAccounts.FirstOrDefault()?.NumberOfAccounts ?? 0;
            int numberOfHighRiskCustomers = _dbAml.ArtHomeNumberOfHighRiskCustomers.FirstOrDefault()?.NumberOfHighRiskCustomers ?? 0;

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



        public IActionResult GetAmlChartsData()
        {
            var dateData = _dbAml.ArtHomeAlertsPerDates.ToList().GroupBy(x => x.Year).Select(x => new
            {
                year = x.Key.ToString(),
                value = x.Sum(x => x.NumberOfAlerts),
                monthData = x.GroupBy(m => m.Month).Select(m => new
                {
                    Month = m.Key.ToString(),
                    value = m.Sum(x => x.NumberOfAlerts)
                })
            });

            Microsoft.EntityFrameworkCore.DbSet<ArtHomeAlertsPerStatus> alertsPerStatus = _dbAml.ArtHomeAlertsPerStatuses;

            return Ok(new
            {
                dates = dateData,
                statuses = alertsPerStatus
            });
        }
    }
}