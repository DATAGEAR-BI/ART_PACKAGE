using Data.Data.AmlAnalysis;
using Data.Services.Grid;

namespace Data.Services.AmlAnalysis;

public interface IAmlAnalysisRepo : IBaseRepo<AmlAnalysisContext,ArtAmlAnalysisViewTb>
{
    public IEnumerable<SelectItem> GetQueues();
    public IEnumerable<SelectItem> GetUsers(string queue);
    
    public Task<(bool isSucceed, IEnumerable<string>? RouteFailedEntities)> RouteAllAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ");

    public Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAllAlertsAsync(CloseRequest closeRequest, string userName, string alertStatusCode);
    
    
    public Task<bool> CreateAmlAnalysisTable();

    public Task ExecuteBatch();

    public Task<(bool isAllSucceed, IEnumerable<int> FailedRules)> ApplyRules(IEnumerable<int> rules);
    public Task<IEnumerable<TestRulesResult>> TestRules(IEnumerable<int> rules);
    
}