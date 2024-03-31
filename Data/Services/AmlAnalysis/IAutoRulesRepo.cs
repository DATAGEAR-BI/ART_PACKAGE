using Data.Data.AmlAnalysis;
using Data.Services;

namespace Data.Services.AmlAnalysis;

public interface IAutoRulesRepo : IBaseRepo<AmlAnalysisContext, ArtAmlAnalysisRule>
{
    public IEnumerable<dynamic> GetQueryBuilderFields();
    public void AddRule(AddRuleRequest request);

    public bool ActivateRule(int ruleId, bool active);

    public void DeleteRule(int ruleId);

    public IEnumerable<TestRulesResult> TestRules(IEnumerable<int> rules);

    public Task<(bool isAllSucceed, IEnumerable<int> FailedRules)> ApplyRules(
        IEnumerable<int> rules
    );
}
