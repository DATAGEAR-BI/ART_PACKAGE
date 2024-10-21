using ART_PACKAGE.Helpers.Aml_Analysis;
using ART_PACKAGE.Helpers.EmailService;

namespace ART_PACKAGE.BackGroundServices
{
    public class AmlAnalysisTableCreateService : BackgroundService
    {
        private readonly ILogger<AmlAnalysisWatcher> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IEmailService _emailService;
        private readonly TimeOnly startTime = TimeOnly.FromDateTime(new DateTime(2023, 1, 1, 00, 0, 0, 0));
        private readonly TimeOnly endTime = TimeOnly.FromDateTime(new DateTime(2025, 1, 1, 17, 0, 0, 0));
        public AmlAnalysisTableCreateService(ILogger<AmlAnalysisWatcher> logger, IServiceScopeFactory scopeFactory,IEmailService emailService)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            //using PeriodicTimer timer = new(TimeSpan.FromMinutes(10));
            using PeriodicTimer timer = new(TimeSpan.FromSeconds(10));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
                Console.Out.WriteLine(time);
                Console.Out.WriteLine(startTime);
                Console.Out.WriteLine(endTime);
                if (time.IsBetween(startTime, endTime))
                {
                    try
                    {

                        IServiceScope scope = _scopeFactory.CreateScope();
                        IAmlAnalysis _amlSrv = scope.ServiceProvider.GetRequiredService<IAmlAnalysis>();
                        bool updateRes = await _amlSrv.CreateAmlAnalysisTable();
                        if (updateRes)
                        {
                            _logger.LogInformation("Aml_analysis_Table created successfully");
                            await _emailService.SendEmailAsync("Status For Create Table 'ART_AML_ANALYSIS_VIEW_TB'", "'ART_AML_ANALYSIS_VIEW_TB' is created successfully");
                        }
                        else
                        {
                            _logger.LogCritical("Something wrong happend while creating Aml_analysis_Table");
                            await _emailService.SendEmailAsync("Status For Create Table 'ART_AML_ANALYSIS_VIEW_TB'", "Something wrong happend while creating 'ART_AML_ANALYSIS_VIEW_TB'");
                        }



                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Aml Analysis Batch Error: {ex}", ex.Message);
                        await _emailService.SendEmailAsync("Status For Create Table 'ART_AML_ANALYSIS_VIEW_TB'", $"Aml Analysis Batch Error: {ex.Message}");

                    }
                }
            }
        }
    }
}
