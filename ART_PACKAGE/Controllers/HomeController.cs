﻿using ART_PACKAGE.Helpers.DBService;
using ART_PACKAGE.Models;
using Data.Data;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.ECM;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ArtGoAmlContext _dbGoAml;

        //private readonly IBaseRepo<FCFKCAmlAnalysisContext, FskAlert> repo;


        public HomeController(ILogger<HomeController> logger, IDbService dbSrv, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory/*, IBaseRepo<FCFKCAmlAnalysisContext, FskAlert> repo*/)
        {

            _logger = logger;
            _dbSrv = dbSrv;
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
            modules = _configuration.GetSection("Modules").Get<List<string>>();
            if (modules is not null)
            {
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
                if (modules.Contains("GOAML"))
                {
                    IServiceScope scope = _serviceScopeFactory.CreateScope();
                    ArtGoAmlContext goamlService = scope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();
                    _dbGoAml = goamlService;
                }

            }

            //this.repo = repo;
        }



        public IActionResult Test()
        {


            return Ok(/*repo.GetAll().Take(200)*/);



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


/*
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
*/
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

        public IActionResult GetGOAmlChartsData()
        {

            var dateData = _dbGoAml.ArtHomeGoamlReportsDates.ToList().GroupBy(x => x.Year).Select(x => new
            {
                year = x.Key.ToString(),
                value = x.Sum(x => x.CountOfReportId),
                monthData = x.GroupBy(m => m.Month).Select(m =>
                new
                {
                    Month = m.Key.ToString(),
                    value = m.Sum(x => x.CountOfReportId)
                })
            });
            var typesData = _dbGoAml.ArtHomeGoamlReportsPerTypes.Select(x => new { ReportType = x.ReportType ?? "Unkown", x.NumberOfReports, year = x.Year }); ;



            return Ok(new
            {
                dates = dateData,
                types = typesData
            });


        }
    }
}