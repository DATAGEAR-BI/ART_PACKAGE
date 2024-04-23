using Data.Data.AmlAnalysis;
using Data.Services.Grid;

namespace Data.Services.AmlAnalysis;

public class AmlAnalysisRepo : BaseRepo<AmlAnalysisContext,ArtAmlAnalysisViewTb>, IAmlAnalysisRepo
{
    private readonly IAmlAnalysis _amlAnalysis;
    public AmlAnalysisRepo(AmlAnalysisContext context, IAmlAnalysis amlAnalysis) : base(context)
    {
        _amlAnalysis = amlAnalysis;
    }

    public IEnumerable<SelectItem> GetQueues()
    {
        List<string> result = new() { "TestQ", "TestQ1", "TestQ2" };
        return result.Select(s => new SelectItem(){text = s, value = s});
    }

    public IEnumerable<SelectItem> GetUsers(string queue)
    {
        List<string> Qs = new() { "TestQ", "TestQ1", "TestQ2" };
        Dictionary<string, List<string>> usersDict = new()
        {
            { "TestQ" , new List<string> { "TestU1" , "TestU2" } },
            { "TestQ1" , new List<string> { "TestU3" , "TestU4" } },
            { "TestQ2" , new List<string> { "TestU5"  } },
        };
        if (queue == "all")
            return usersDict.Values.SelectMany(x => x.Select(s => new SelectItem(){text = s, value = s}));
        
       
            return usersDict[queue].Select(s => new SelectItem(){text = s, value = s});
           
        
    }

    public async Task<(bool isSucceed, IEnumerable<string>? RouteFailedEntities)> RouteAllAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ")
    {
        return await _amlAnalysis.RouteAllAlertsAsync(routeReq,userName,desc);
    }

    public async Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAllAlertsAsync(CloseRequest closeRequest, string userName, string alertStatusCode)
    {
        return  await _amlAnalysis.CloseAllAlertsAsync(closeRequest,userName,alertStatusCode);
    }

    public async Task<bool> CreateAmlAnalysisTable()
    {
        return await _amlAnalysis.CreateAmlAnalysisTable();
    }

    public async Task ExecuteBatch()
    {
         await _amlAnalysis.ExecuteBatch();
    }

    public async Task<(bool isAllSucceed, IEnumerable<int> FailedRules)> ApplyRules(IEnumerable<int> rules)
    {
        return await _amlAnalysis.ApplyRules(rules);
    }

    public async Task<IEnumerable<TestRulesResult>> TestRules(IEnumerable<int> rules)
    {
        return await _amlAnalysis.TestRules(rules);
    }
}