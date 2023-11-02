using ART_PACKAGE.Helpers.Aml_Analysis;

namespace ART_PACKAGE.BackGroundServices
{
    public class AmlAnalysisTableCreateService : BackgroundService
    {
        private readonly ILogger<AmlAnalysisWatcher> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeOnly startTime = TimeOnly.FromDateTime(new DateTime(2023, 1, 1, 00, 0, 0, 0));
        private readonly TimeOnly endTime = TimeOnly.FromDateTime(new DateTime(2023, 1, 1, 01, 0, 0, 0));
        public AmlAnalysisTableCreateService(ILogger<AmlAnalysisWatcher> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            using PeriodicTimer timer = new(TimeSpan.FromMinutes(10));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
                if (time.IsBetween(startTime, endTime))
                {
                    try
                    {

                        IServiceScope scope = _scopeFactory.CreateScope();
                        IAmlAnalysis _amlSrv = scope.ServiceProvider.GetRequiredService<IAmlAnalysis>();
                        bool updateRes = await _amlSrv.CreateAmlAnalysisTable();
                        if (updateRes)
                            _logger.LogInformation("Aml_analysis_Table created successfully");
                        else
                            _logger.LogCritical("Something wrong happend while creating Aml_analysis_Table");



                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Aml Analysis Batch Error: {ex}", ex.Message);
                    }
                }
            }
        }
    }
}
