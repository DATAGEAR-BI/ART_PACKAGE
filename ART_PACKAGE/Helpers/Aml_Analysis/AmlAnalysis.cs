namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class AmlAnalysis : IAmlAnalysis
    {
        private readonly ILogger<IAmlAnalysis> _logger;

        public AmlAnalysis(ILogger<IAmlAnalysis> logger)
        {
            _logger = logger;
        }

        public Task<bool> CloseAlertsAsync(CloseRequest closeReq, string userName, string alertStatusCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RouteAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ")
        {
            throw new NotImplementedException();
        }


        private async Task<bool> SetAlertStatus(IEnumerable<string> alertedEntities, string Status = "CLP")
        {
            try
            {

            }
            catch (Exception ex)
            {

                return false;

            }
        }
    }
}
