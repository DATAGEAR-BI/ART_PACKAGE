namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public interface IAmlAnalysis
    {
        public Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAlertsAsync(CloseRequest closeReq, string userName, string alertStatusCode);
        public Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> RouteAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ");
        public Task<(bool isSucceed, IEnumerable<string>? RouteFailedEntities)> RouteAllAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ");

        public Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAllAlertsAsync(CloseRequest closeRequest, string userName, string alertStatusCode);
    }
}
