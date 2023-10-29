using ART_PACKAGE.Helpers.DBService;
using ART_PACKAGE.Helpers.Mail;
using ART_PACKAGE.Models;
using Data.Data;
using Data.Data.ARTDGAML;
using Data.Data.ECM;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbService _dbSrv;
        private readonly EcmContext _db;
        private readonly SasAmlContext _dbAml;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConfiguration _configuration;
        private readonly ArtDgAmlContext _dgaml;
        private readonly List<string>? modules;
        private readonly MailConfiguration mailConfig;
        private readonly IMailSender _mailSender;
        public HomeController(ILogger<HomeController> logger, IDbService dbSrv, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, IOptions<MailConfiguration> mailConfig, IMailSender mailSender)
        {

            _logger = logger;
            _dbSrv = dbSrv;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            modules = _configuration.GetSection("Modules").Get<List<string>>();
            if (modules.Contains("SASAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                SasAmlContext amlService = scope.ServiceProvider.GetRequiredService<SasAmlContext>();
                _dbAml = amlService;
            }
            if (modules.Contains("ECM"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                EcmContext ecmService = scope.ServiceProvider.GetRequiredService<EcmContext>();
                _db = ecmService;
            }
            if (modules.Contains("DGAML"))
            {
                IServiceScope scope = _serviceScopeFactory.CreateScope();
                ArtDgAmlContext dgamlService = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();
                _dgaml = dgamlService;
            }

            this.mailConfig = mailConfig.Value;
            _mailSender = mailSender;
        }



        public IActionResult SendTestMail()
        {
            Message message = new(new List<string> { "islam.khalil@datagearbi.com", "hossam.eldin@datagearbi.com" }, "Test email", "This a test mail sent from art package.");


            bool sent = _mailSender.SendEmail(message);
            return Ok(sent);
        }



        public IActionResult Index()
        {

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
            if (modules.Contains("SASAML"))
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

                DbSet<ArtHomeAlertsPerStatus> alertsPerStatus = _dbAml.ArtHomeAlertsPerStatuses;

                return Ok(new
                {
                    dates = dateData,
                    statuses = alertsPerStatus
                });
            }
            else
            {
                var dateData = _dgaml.ArtHomeDgamlAlertsPerDates.ToList().GroupBy(x => x.Year).Select(x => new
                {
                    year = x.Key.ToString(),
                    value = x.Sum(x => x.NumberOfAlerts),
                    monthData = x.GroupBy(m => m.Month).Select(m => new
                    {
                        Month = m.Key.ToString(),
                        value = m.Sum(x => x.NumberOfAlerts)
                    })
                });

                DbSet<ArtHomeDgamlAlertsPerStatus> alertsPerStatus = _dgaml.ArtHomeDgamlAlertsPerStatuses;

                return Ok(new
                {
                    dates = dateData,
                    statuses = alertsPerStatus
                });
            }

        }
    }
}