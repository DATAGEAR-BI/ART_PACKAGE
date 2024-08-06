using Data.Data.AmlAnalysis;
using Data.FCFKC.AmlAnalysis;
using Data.Services;
using Data.Services.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Services.AmlAnalysis;

public class AutoRulesRepo : BaseRepo<AmlAnalysisContext, ArtAmlAnalysisRule>, IAutoRulesRepo
{
    private readonly ILogger<AutoRulesRepo> _logger;
    private readonly FCFKCAmlAnalysisContext _fcfkc;
    private readonly IAmlAnalysis _amlAnalysis;

    public AutoRulesRepo(
        AmlAnalysisContext context,
        ILogger<AutoRulesRepo> logger,
        FCFKCAmlAnalysisContext fcfkc,
        IAmlAnalysis amlAnalysis
    )
        : base(context)
    {
        _logger = logger;
        _fcfkc = fcfkc;
        _amlAnalysis = amlAnalysis;
    }

    public IEnumerable<dynamic> GetQueryBuilderFields()
    {
        Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType =
            _context.Model.FindEntityType(typeof(ArtAmlAnalysisViewTb));
        IEnumerable<dynamic> data = entityType
            .GetProperties()
            .Select(x =>
            {
                string type = x.PropertyInfo.PropertyType.GetQueryBuilderType();
                string name = x.GetColumnName();
                var f = new
                {
                    paraName = name,
                    paraDisplayName = name,
                    isMulti = false,
                    type
                };
                return f;
            });
        return data;
    }

    public void AddRule(AddRuleRequest request)
    {
        if (request.Action.ToLower() != "close" && request.Action.ToLower() != "route")
            throw new InvalidOperationException("action not supported");
        var entity = _context.ArtAmlAnalysisViewTbs;
        var tableEntityType = entity.EntityType;
        var tableName = string.Join(
            ".",
            tableEntityType.GetSchema(),
            tableEntityType.GetTableName()
        );

        var rule = new ArtAmlAnalysisRule()
        {
            Action = request.Action,
            Active = true,
            Deleted = false,
            Sql = request.Sql,
            CreatedDate = DateTime.UtcNow,
            TableName = tableName,
            ReadableOutPut = request.ReadableOutPut,
            RouteToUser = request.RouteToUser
        };
        _context.Add(rule);
        _context.SaveChanges();
    }

    public bool ActivateRule(int ruleId, bool active)
    {
        try
        {
            var rule = _context.ArtAmlAnalysisRules.Find(ruleId);
            rule.Active = active;
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError("error changing active for rule {id} : {ex}", ruleId, e.Message);
            throw;
        }
    }

    public void DeleteRule(int ruleId)
    {
        try
        {
            var rule = _context.ArtAmlAnalysisRules.Find(ruleId);
            rule.Deleted = true;
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError("error deleting rule {id} : {ex}", ruleId, e.Message);
            throw;
        }
    }

    public IEnumerable<TestRulesResult> TestRules(IEnumerable<int> rules)
    {
        try
        {
            List<ArtAmlAnalysisRule> Rules = _context
                .ArtAmlAnalysisRules.Where(r => rules.Contains(r.Id))
                .ToList();
            var entity = _context.ArtAmlAnalysisViewTbs;
            var tableEntityType = entity.EntityType;
            var tableName = string.Join(
                ".",
                tableEntityType.GetSchema(),
                tableEntityType.GetTableName()
            );
            IEnumerable<TestRulesResult> result = Rules.Select(x =>
            {
                var sql = $"Select * From {tableName} Where {x.Sql}";
                IQueryable<ArtAmlAnalysisViewTb> d = entity.FromSqlRaw(
                    $"Select * From {tableName} Where {x.Sql}"
                );

                var aens = d.Select(x => x.PartyNumber).ToList();
                TestRulesResult ruleRes =
                    new()
                    {
                        Id = x.Id,
                        AlertedEntities = aens.Count(),
                        Alerts = _fcfkc
                            .FskAlerts.Where(a =>
                                aens.Contains(a.AlertedEntityNumber)
                                && a.AlertStatusCode.ToUpper() == "ACT"
                            )
                            .Count()
                    };

                return ruleRes;
            });
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("error testing rules {id} : {ex}", string.Join(",", rules), e.Message);
            throw;
        }
    }

    public async Task<(bool isAllSucceed, IEnumerable<int> FailedRules)> ApplyRules(
        IEnumerable<int> rules
    )
    {
        return await _amlAnalysis.ApplyRules(rules);
    }
}
