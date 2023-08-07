namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public interface IAmlAnalysis
    {
        public Task<bool> CloseAlertsAsync(CloseRequest closeReq, string userName, string alertStatusCode);
        public Task<bool> RouteAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ");
    }
}
