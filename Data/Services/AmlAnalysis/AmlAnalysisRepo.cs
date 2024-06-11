using Data.Data.AmlAnalysis;
using Data.Services.Grid;
using Newtonsoft.Json;

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
        //var result = fcfcore.ArtSasQueues.Select(Q => Q.Queuecode);
        var result = _context.VaGroupInfos.Where(x => x.Name.ToLower().StartsWith("branch_") && !x.Name.ToLower().EndsWith("_role")).Select(x => new { x.Name, x.Displayname });
        
        return result.Select(s => new SelectItem(){text = s.Name, value = s.Displayname });
    }

    public IEnumerable<SelectItem> GetUsers(string queue)
    {

        if (string.IsNullOrEmpty(queue) ||queue.Equals("all"))
        {
            var result = _context.VaPersonInfos.Select(U => string.IsNullOrEmpty(U.Displayname) ? U.Name : U.Name + " , " + U.Displayname).Distinct();
            return result.Select(s => new SelectItem() { text = s, value = s });

        }
        else
        {
            var result = _context.LstOfUsersAndGroupsRoles.Where(Q => Q.GroupName.ToLower() == queue.ToLower()).Select(U => string.IsNullOrEmpty(U.DisplayName) ? U.UserName : U.UserName + " , " + U.DisplayName);
            return result.Select(s => new SelectItem() { text = s, value = s });
        }
              
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