using ART_PACKAGE.Helpers.Aml_Analysis;

namespace ART_PACKAGE.BackGroundServices
{
    public class AmlAnalysisWatcher : BackgroundService
    {
        private readonly ILogger<AmlAnalysisWatcher> _logger;
        private readonly IAmlAnalysis _amlSrv;
        public AmlAnalysisWatcher(ILogger<AmlAnalysisWatcher> logger, IAmlAnalysis amlSrv)
        {
            _logger = logger;
            _amlSrv = amlSrv;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new(TimeSpan.FromMinutes(10));
        }
    }
}
