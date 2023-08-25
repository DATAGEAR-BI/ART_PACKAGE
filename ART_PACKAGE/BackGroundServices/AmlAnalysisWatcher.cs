using ART_PACKAGE.Helpers.Aml_Analysis;

namespace ART_PACKAGE.BackGroundServices
{
    public class AmlAnalysisWatcher : BackgroundService
    {
        private readonly ILogger<AmlAnalysisWatcher> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly AmlAnalysisUpdateTableIndecator _updateInd;
        public AmlAnalysisWatcher(ILogger<AmlAnalysisWatcher> logger, IServiceScopeFactory scopeFactory, AmlAnalysisUpdateTableIndecator updateInd)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _updateInd = updateInd;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new(TimeSpan.FromMinutes(1));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {


                try
                {

                    if (_updateInd.PerformInd)
                    {
                        IServiceScope scope = _scopeFactory.CreateScope();
                        IAmlAnalysis _amlSrv = scope.ServiceProvider.GetRequiredService<IAmlAnalysis>();
                        bool updateRes = await _amlSrv.CreateAmlAnalysisTable();
                        _updateInd.PerformInd = !updateRes ? throw new InvalidOperationException("something went Wrong while creating aml analysis table") : false;
                        await _amlSrv.ExecuteBatch();
                        _logger.LogInformation("Batches has been succeeded");

                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Aml Analysis Batch Error: {ex}", ex.Message);
                }
            }

        }
    }
}
