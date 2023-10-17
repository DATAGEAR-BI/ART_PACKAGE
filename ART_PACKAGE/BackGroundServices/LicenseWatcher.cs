using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.SignalR;
using License = ART_PACKAGE.Middlewares.License.License;

namespace ART_PACKAGE.BackGroundServices
{
    public class LicenseWatcher : BackgroundService
    {
        private readonly IHubContext<LicenseHub> _textContext;
        private readonly ILogger<LicenseWatcher> _logger;
        private readonly ILicenseReader _licReader;

        public LicenseWatcher(IHubContext<LicenseHub> textContext, ILogger<LicenseWatcher> logger, ILicenseReader licReader)
        {
            _textContext = textContext;
            _logger = logger;
            _licReader = licReader;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            using PeriodicTimer timer = new(TimeSpan.FromDays(1));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    _logger.LogInformation("Timed Hosted Service running.");
                    List<string> messages = new();
                    IEnumerable<License> licenses = _licReader.ReadAllAppLicenses();

                    foreach (License lic in licenses)
                    {
                        if (lic.RemainingDays <= 7)
                        {
                            messages.Add($"License For Module {lic.Client} is about to end Please Contact with Data Gear support");
                        }
                    }

                    if (messages.Count > 0)
                    {
                        await _textContext.Clients.All.SendAsync("ReceiveAlert", messages, stoppingToken);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Timed Hosted Service is stopping.");
            }



        }
    }
}
