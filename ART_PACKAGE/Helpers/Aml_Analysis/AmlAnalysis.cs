using ART_PACKAGE.Extentions.IEnumerableExtentions;
using Data.Data.AmlAnalysis;
using Data.FCFKC.AmlAnalysis;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class AmlAnalysis : IAmlAnalysis
    {
        private readonly ILogger<IAmlAnalysis> _logger;
        private readonly FCFKCAmlAnalysisContext _fcfkc;
        private readonly object _lock = new();
        private readonly AmlAnalysisContext _context;
        private readonly AmlAnalysisUpdateTableIndecator _updateInd;

        public AmlAnalysis(ILogger<IAmlAnalysis> logger, IServiceScopeFactory scopeFactory, FCFKCAmlAnalysisContext fcfkc, AmlAnalysisContext context, AmlAnalysisUpdateTableIndecator updateInd)
        {
            _logger = logger;
            _fcfkc = fcfkc;
            _context = context;
            _updateInd = updateInd;
        }
        public async Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAlertsAsync(CloseRequest closeReq, string userName, string alertStatusCode)
        {



            try
            {
                (bool isSucceed, IEnumerable<decimal>? AlertsIds) = await SetAlertStatus(closeReq.Entities);
                if (!isSucceed)
                {

                    return (false, closeReq.Entities);
                }
                bool eventRes = await CreateAlertsEvents(AlertsIds, closeReq.Desc, userName);
                if (!eventRes)
                {

                    return (false, closeReq.Entities);
                }
                bool clearAlertsRes = await ClearAlertsCount(closeReq.Entities);
                if (!clearAlertsRes)
                {

                    return (false, closeReq.Entities);
                }
                bool commentsRes = await AddComments(closeReq.Entities, closeReq.Comment, userName);
                if (!commentsRes)
                    return ((bool isSucceed, IEnumerable<string>? ColseFailedEntities))(false, closeReq.Entities);
                _ = await _fcfkc.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {

                _logger.LogCritical("Something wrong happend while closing : {exception}", ex.Message);
                return (false, closeReq.Entities);
            }



        }
        public async Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> RouteAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ")
        {

            try
            {
                bool isEntityQueueSucceed = await SaveEntityQueue(routeReq.Entities, routeReq.QueueCode, routeReq.OwnerId);
                if (!isEntityQueueSucceed)
                {

                    return (false, routeReq.Entities);
                }
                bool isCreateEventsSucceed = await CreateEntityEvents(routeReq.Entities, desc, $@"{routeReq.QueueCode}--{routeReq.OwnerId}", userName);
                if (!isCreateEventsSucceed)
                {

                    return (false, routeReq.Entities);
                }
                bool isAddCommentsSucceed = await AddComments(routeReq.Entities, routeReq.Comment, userName);
                if (!isAddCommentsSucceed)
                {

                    return (false, routeReq.Entities);
                }
                _ = await _fcfkc.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {

                _logger.LogCritical("Something wrong happend while routing : {exception}", ex.Message);
                return (false, routeReq.Entities);
            }
        }
        private async Task<bool> CreateEntityEvents(IEnumerable<string> entitiesNumber, string eventTypeCode, string eventDescription, string userName)
        {
            int maxEntityEvent = _fcfkc.FskEntityEvents.Max(x => x.EventId);

            IEnumerable<FskEntityEvent> events = entitiesNumber.Select(a => new FskEntityEvent
            {
                CaseId = null,
                CreateDate = DateTime.UtcNow,
                CreateUserId = userName,
                EventTypeCode = eventTypeCode,
                EntityLevelCode = _fcfkc?.FskAlertedEntities?.Select(s => s.AlertedEntityLevelCode).FirstOrDefault() ?? "",
                EntityNumber = a,
                EventDescription = eventDescription,
                EventId = ++maxEntityEvent
            });
            await _fcfkc.AddRangeAsync(events);

            return await _fcfkc.SaveChangesAsync() > 0;
        }
        private async Task<bool> SaveEntityQueue(IEnumerable<string> entities, string? ownerId, string? queueCode)
        {
            try
            {
                IQueryable<string> existingQueues = _fcfkc.FskEntityQueues.Where(q => entities.Contains(q.AlertedEntityNumber)).Select(q => q.AlertedEntityNumber);
                IEnumerable<string> newQueuesAlertedNumbers = entities.Except(existingQueues);
                if (existingQueues is not null && existingQueues.Count() != 0)
                {
                    string sqlServerQeury = "SELECT TOP(1) alerted_entity_level_code FROM dbo.FSK_ALERTED_ENTITY a WHERE a.alerted_entity_number = alerted_entity_number";
                    string oracleQeury = "SELECT alerted_entity_level_code FROM dbo.FSK_ALERTED_ENTITY a WHERE a.alerted_entity_number = alerted_entity_number FETCH FIRST  ROW ONLY";
                    string sql = _fcfkc.Database.IsOracle() ? oracleQeury : sqlServerQeury;
                    int updateRes = await _fcfkc.Database.ExecuteSqlRawAsync($@"UPDATE dbo.FSK_ENTITY_QUEUE
                                                                            SET queue_code = '{queueCode}' , owner_userid = '{ownerId}' 
                                                                            , alerted_entity_level_code = ({sql})
                                                                            WHERE alerted_entity_number IN ({string.Join(",", existingQueues.Select(x => $"'{x}'"))})");
                }

                IEnumerable<FskEntityQueue>? newEntitiesQueues = newQueuesAlertedNumbers?.Select(a => new FskEntityQueue
                {
                    AlertedEntityLevelCode = _fcfkc?.FskAlertedEntities?.FirstOrDefault(x => x.AlertedEntityNumber == a)?.AlertedEntityLevelCode ?? "",
                    AlertedEntityNumber = a,
                    OwnerUserid = ownerId,
                    QueueCode = queueCode
                });
                if (newEntitiesQueues is not null && newEntitiesQueues.Count() != 0)
                {
                    int res = await _fcfkc.Database.ExecuteSqlRawAsync($@"INSERT INTO dbo.FSK_ENTITY_QUEUE(alerted_entity_level_code , alerted_entity_number , owner_userid , queue_code)
                                                                              VALUES {string.Join(",", newEntitiesQueues.Select(x => x.InsertString))}");

                    return res > 0;
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Somthing Went Wrong when setting entity queues: {Exception}", ex.Message);
                return false;
            }
        }

        private async Task<bool> AddComments(IEnumerable<string> partyNumbers, string comment, string userName)
        {
            lock (_lock)
            {
                decimal maxCommentId = _fcfkc.FskComments.Max(x => x.CommentId);
                IEnumerable<FskComment> comments = partyNumbers.Select(x => new FskComment
                {
                    CommentId = ++maxCommentId,
                    ObjectTypeCd = "PTY",
                    ObjectId = x,
                    CommentText = comment,
                    CommentCategoryCd = "GEN",
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = userName,
                    LstupdateUserId = userName,
                    LstupdateDate = DateTime.UtcNow,
                    LogicalDeleteInd = "N"
                });
                _fcfkc.FskComments.AddRange(comments);
                int res = _fcfkc.SaveChanges();
                return res > 0;
            }

        }
        private async Task<bool> ClearAlertsCount(IEnumerable<string> alertedEntities)
        {
            try
            {
                int rowEffected = await _fcfkc.Database.ExecuteSqlRawAsync($@"UPDATE dbo.FSK_ALERTED_ENTITY 
                                                         SET alerts_cnt = 0 , transactions_cnt = 0
                                                         WHERE alerted_entity_number IN ({string.Join(",", alertedEntities.Select(x => $"'{x}'"))})");
                return rowEffected > 0;
            }
            catch (Exception ex)
            {

                _logger.LogCritical("Something wrong happend : {exception}", ex.Message);
                return false;
            }

        }

        public async Task<bool> RemoveEntitiesFromBkTable(IEnumerable<string> AlertedEntities)
        {
            int res = await _context.Database.ExecuteSqlRawAsync($@"DELETE FROM ART_DB.ART_AML_ANALYSIS_VIEW_TB
                                                                        WHERE PARTY_NUMBER IN ({string.Join(",", AlertedEntities)})");
            return res > 0;
        }

        private async Task<bool> CreateAlertsEvents(IEnumerable<decimal>? alertsIds, string desc, string userName)
        {
            IEnumerable<FskAlertEvent> events;
            lock (_lock)
            {
                decimal maxAlertEventId = _fcfkc.FskAlertEvents.Max(x => x.EventId);
                events = alertsIds.Select(x => new FskAlertEvent
                {
                    AlertId = x,
                    EventId = ++maxAlertEventId,
                    CreateDate = DateTime.UtcNow,
                    CreateUserId = userName,
                    EventTypeCode = "CLP",
                    EventDescription = desc
                });
                _fcfkc.AddRange(events);
                decimal res = _fcfkc.SaveChanges();

                return res > 0;
            }


        }
        private async Task<(bool isSucceed, IEnumerable<decimal>? AlertsIds)> SetAlertStatus(IEnumerable<string> alertedEntities, string Status = "CLP")
        {
            try
            {
                if (alertedEntities.Count() > 1000)
                {
                    throw new ArgumentException("Max number of entities is 1000 per time");
                }

                IQueryable<decimal> alertIds = _fcfkc.FskAlerts
                            .Where(x => alertedEntities.Contains(x.AlertedEntityNumber)
                                        && x.AlertStatusCode.ToLower() == "act").Select(x => x.AlertId);
                if (alertIds.Count() <= 0)
                {
                    _logger.LogCritical("there is no alerts with 'CLP' on this entites ({AEN})", string.Join(",", alertedEntities));
                    return (false, null);
                }
                IEnumerable<decimal> alertIdsCoppy = alertIds.ToList();
                (bool, IEnumerable<decimal>) res = (true, alertIdsCoppy);
                int rowEffected = await _fcfkc.Database.ExecuteSqlRawAsync($@"UPDATE dbo.FSK_ALERT 
                                                         SET alert_status_code = '{Status}'
                                                         WHERE alert_id IN ({string.Join(",", alertIds)})");

                return rowEffected > 0 ? res : (false, null);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Something wrong happend : {exception}", ex.Message);
                return (false, null);

            }
        }

        public async Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAllAlertsAsync(CloseRequest closeRequest, string userName, string alertStatusCode)
        {
            IEnumerable<CloseRequest> requests = closeRequest.Entities.Partition(1000).Select(x => new CloseRequest
            {
                Entities = x,
                Comment = closeRequest.Comment,
                Desc = closeRequest.Desc,
            });
            using IDbContextTransaction trans = _fcfkc.Database.BeginTransaction();
            using IDbContextTransaction arTrans = _context.Database.BeginTransaction();

            List<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> res = new();
            try
            {
                foreach (CloseRequest request in requests)
                {
                    res.Add(await CloseAlertsAsync(request, userName, "CLP"));
                }

                if (res.All(x => x.isSucceed))
                {

                    foreach (CloseRequest request in requests)
                    {
                        bool deleteFromBkRes = await RemoveEntitiesFromBkTable(request.Entities);
                        if (!deleteFromBkRes)
                            throw new InvalidOperationException($"Error While deleting entities from Table : ({string.Join(",", request.Entities)})");
                    }
                    arTrans.Commit();
                    trans.Commit();
                    return (true, null);
                }
                else
                {
                    throw new Exception("Something wrong happend");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("something wrong happend {ex}", ex.Message);
                arTrans.Rollback();
                trans.Rollback();
                return (false, res.SelectMany(x => x.ColseFailedEntities));
            }


        }

        public async Task<(bool isSucceed, IEnumerable<string>? RouteFailedEntities)> RouteAllAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ")
        {
            IEnumerable<RouteRequest> requests = routeReq.Entities.Partition(1000).Select(x => new RouteRequest
            {
                Entities = x,
                Comment = routeReq.Comment,
                OwnerId = routeReq.OwnerId,
                QueueCode = routeReq.QueueCode,
            });
            using IDbContextTransaction trans = _fcfkc.Database.BeginTransaction();
            List<(bool isSucceed, IEnumerable<string>? RouteFailedEntities)> res = new();
            try
            {
                foreach (RouteRequest request in requests)
                {
                    res.Add(await RouteAlertsAsync(request, userName));
                }

                if (res.All(x => x.isSucceed))
                {
                    trans.Commit();
                    return (true, null);
                }
                else
                {
                    throw new Exception("Something wrong happend");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("something wrong happend {ex}", ex.Message);
                trans.Rollback();
                return (false, res.SelectMany(x => x.RouteFailedEntities));
            }

        }

        public async Task<bool> CreateAmlAnalysisTable()
        {


            string oracleSql = $@"declare
   c int;
begin
   select count(*) into c from user_tables where table_name = upper('ART_AML_ANALYSIS_VIEW_TB');
   if c > 0 then
      execute immediate 'drop table ART_AML_ANALYSIS_VIEW_TB';
   end if;
     execute immediate 'CREATE TABLE ART_AML_ANALYSIS_VIEW_TB AS SELECT * FROM ART_AML_ANALYSIS_VIEW';
end;";
            string msSql = "drop table ART_DB.ART_AML_ANALYSIS_VIEW_TB; SELECT * INTO ART_DB.ART_AML_ANALYSIS_VIEW_TB FROM ART_DB.ART_AML_ANALYSIS_VIEW;";

            string sql = _context.Database.IsOracle() ? oracleSql : msSql;
            try
            {
                if (!_updateInd.PerformInd)
                    throw new InvalidOperationException("the update indecator is false can't call create aml analysis table");
                int res = await _context.Database.ExecuteSqlRawAsync(sql);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogCritical("something wrong jappend while creating aml analysis table : {ex}", ex.Message);
                return false;
            }
        }

        public async Task ExecuteBatch()
        {
            IQueryable<ArtAmlAnalysisRule> closeRules = _context.ArtAmlAnalysisRules.Where(x => x.Active && !x.Deleted && x.Action == AmlAnalysisAction.Close.ToString());
            List<string> closeEntities = new();
            List<(bool isSucceed, IEnumerable<string>? FailedEntities)> failedRules = new();
            foreach (ArtAmlAnalysisRule rule in closeRules)
            {
                List<string> AENs = _context.ArtAmlAnalysisViewTbs.FromSqlRaw($"Select * From {rule.TableName} Where {rule.Sql}").Select(a => a.PartyNumber).ToList();
                closeEntities.AddRange(AENs);
                (bool isSucceed, IEnumerable<string>? ColseFailedEntities) = await CloseAllAlertsAsync(new CloseRequest
                {
                    Entities = AENs,
                    Comment = $"Closed By AmlAnalysis Auto-Rules :{rule.Id}",
                    Desc = $"{rule.Id}--CLA"
                }, "ART-SRV", "CLA");

                if (!isSucceed)
                    _logger.LogCritical("rule number {rule} failed cause this entities caused an issue : ({AENS})", rule.Id, string.Join(",", ColseFailedEntities));
            }

            IQueryable<ArtAmlAnalysisRule> routeRules = _context.ArtAmlAnalysisRules.Where(x => x.Active && !x.Deleted && x.Action == AmlAnalysisAction.Route.ToString());
            foreach (ArtAmlAnalysisRule rule in routeRules)
            {
                IEnumerable<string> ruleEntities = _context.ArtAmlAnalysisViewTbs.FromSqlRaw($"Select * From {rule.TableName} Where {rule.Sql}").Select(a => a.PartyNumber).ToList().Where(x => !closeEntities.Contains(x));
                string[] queue_owner = rule.RouteToUser.Split("--");

                (bool isSucceed, IEnumerable<string>? RouteFailedEntities) = await RouteAllAlertsAsync(new RouteRequest
                {
                    Entities = ruleEntities.ToList(),
                    Comment = $"Routed From AmlAnalysis Auto Rule :{rule.Id}",
                    OwnerId = queue_owner[1],
                    QueueCode = queue_owner[0]
                }, "ART-SRV", $"{rule.Id}--RTQ--FAAR-Apply");

                if (!isSucceed)
                    _logger.LogCritical("rule number {rule} failed cause this entities caused an issue : ({AENS})", rule.Id, string.Join(",", RouteFailedEntities));
            }
        }

        public async Task<IEnumerable<TestRulesResult>> TestRules(IEnumerable<int> rules)
        {
            List<ArtAmlAnalysisRule> Rules = _context.ArtAmlAnalysisRules.Where(r => rules.Contains(r.Id)).ToList();

            IEnumerable<TestRulesResult> result = Rules.Select(x =>
            {
                List<string> aens = _context.ArtAmlAnalysisViewTbs.FromSqlRaw($"Select * From ART_DB.{x.TableName} Where {x.Sql}").Select(x => x.PartyNumber).ToList();
                TestRulesResult ruleRes = new()
                {
                    Id = x.Id,
                    AlertedEntities = aens.Count(),
                    Alerts = _fcfkc.FskAlerts.Where(a => aens.Contains(a.AlertedEntityNumber) && a.AlertStatusCode.ToUpper() == "ACT").Count()
                };

                return ruleRes;
            });
            return result;
        }

        public async Task<(bool isAllSucceed, IEnumerable<int> FailedRules)> ApplyRules(IEnumerable<int> rules)
        {
            List<int> allFailedRules = new();
            bool allSucceed = true;
            IQueryable<ArtAmlAnalysisRule> closeRules = _context.ArtAmlAnalysisRules.Where(x => x.Active && !x.Deleted && x.Action == AmlAnalysisAction.Close.ToString() && rules.Contains(x.Id));
            List<string> closeEntities = new();
            List<(bool isSucceed, IEnumerable<string>? FailedEntities)> failedRules = new();
            foreach (ArtAmlAnalysisRule rule in closeRules)
            {
                List<string> AENs = _context.ArtAmlAnalysisViewTbs.FromSqlRaw($"Select * From {rule.TableName} Where {rule.Sql}").Select(a => a.PartyNumber).ToList();
                closeEntities.AddRange(AENs);
                (bool isSucceed, IEnumerable<string>? ColseFailedEntities) = await CloseAllAlertsAsync(new CloseRequest
                {
                    Entities = AENs,
                    Comment = $"Closed By AmlAnalysis Auto-Rules :{rule.Id}",
                    Desc = $"{rule.Id}--CLA"
                }, "ART-SRV", "CLA");

                if (!isSucceed)
                {
                    _logger.LogCritical("rule number {rule} failed cause this entities caused an issue : ({AENS})", rule.Id, string.Join(",", ColseFailedEntities));
                    allSucceed = false;
                    allFailedRules.Add(rule.Id);
                }
            }

            IQueryable<ArtAmlAnalysisRule> routeRules = _context.ArtAmlAnalysisRules.Where(x => x.Active && !x.Deleted && x.Action == AmlAnalysisAction.Route.ToString() && rules.Contains(x.Id));
            foreach (ArtAmlAnalysisRule rule in routeRules)
            {
                IEnumerable<string> ruleEntities = _context.ArtAmlAnalysisViewTbs.FromSqlRaw($"Select * From {rule.TableName} Where {rule.Sql}").Select(a => a.PartyNumber).ToList().Where(x => !closeEntities.Contains(x));
                string[] queue_owner = rule.RouteToUser.Split("--");
                (bool isSucceed, IEnumerable<string>? RouteFailedEntities) = await RouteAllAlertsAsync(new RouteRequest
                {
                    Entities = ruleEntities.ToList(),
                    Comment = $"Routed From AmlAnalysis Auto Rule :{rule.Id}",
                    OwnerId = queue_owner[1],
                    QueueCode = queue_owner[0]
                }, "ART-SRV", $"{rule.Id}--RTQ--FAAR-Apply");

                if (!isSucceed)
                {
                    _logger.LogCritical("rule number {rule} failed cause this entities caused an issue : ({AENS})", rule.Id, string.Join(",", RouteFailedEntities));
                    allSucceed = false;
                    allFailedRules.Add(rule.Id);
                }
            }


            return allSucceed ? new(allSucceed, null) : new(allSucceed, allFailedRules);
        }
    }
}


