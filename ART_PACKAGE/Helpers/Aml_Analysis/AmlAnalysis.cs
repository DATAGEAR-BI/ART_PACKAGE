using ART_PACKAGE.Extentions.IEnumerableExtentions;
using Data.FCFKC;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class AmlAnalysis : IAmlAnalysis
    {
        private readonly ILogger<IAmlAnalysis> _logger;
        private readonly IServiceScopeFactory scopeFactory;
        private readonly FCFKC _fcfkc;
        private readonly object _lock = new();

        public AmlAnalysis(ILogger<IAmlAnalysis> logger, IServiceScopeFactory scopeFactory, FCFKC fcfkc)
        {
            _logger = logger;
            this.scopeFactory = scopeFactory;
            _fcfkc = fcfkc;
        }

        public async Task<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> CloseAlertsAsync(CloseRequest closeReq, string userName, string alertStatusCode)
        {



            try
            {
                (bool isSucceed, IEnumerable<decimal>? AlertsIds) = await SetAlertStatus(closeReq.Entities, _fcfkc);
                if (!isSucceed)
                {

                    return (false, closeReq.Entities);
                }
                bool eventRes = await CreateAlertsEvents(AlertsIds, closeReq.Desc, userName, _fcfkc);
                if (!eventRes)
                {

                    return (false, closeReq.Entities);
                }
                bool clearAlertsRes = await ClearAlertsCount(closeReq.Entities, _fcfkc);
                if (!clearAlertsRes)
                {

                    return (false, closeReq.Entities);
                }
                bool commentsRes = await AddComments(closeReq.Entities, closeReq.Comment, userName, _fcfkc);
                if (!commentsRes)
                {

                    return (false, closeReq.Entities);
                }
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
            decimal maxEntityEvent = _fcfkc.FskEntityEvents.Max(x => x.EventId);
            IEnumerable<FskEntityEvent> events = entitiesNumber.Select(a => new FskEntityEvent
            {
                CaseId = null,
                CreateDate = DateTime.UtcNow,
                CreateUserId = userName,
                EventTypeCode = eventTypeCode,
                EntityLevelCode = _fcfkc?.FskAlertedEntities?.FirstOrDefault(x => x.AlertedEntityNumber == a)?.AlertedEntityLevelCode ?? "",
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
                    int updateRes = await _fcfkc.Database.ExecuteSqlRawAsync($@"UPDATE FCFKC.FSK_ENTITY_QUEUE
                                                                            SET queue_code = '{queueCode}' , owner_userid = '{ownerId}' 
                                                                            , alerted_entity_level_code = (SELECT TOP(1) alerted_entity_level_code FROM FCFKC.FSK_ALERTED_ENTITY a WHERE a.alerted_entity_number = alerted_entity_number)
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
                    int res = await _fcfkc.Database.ExecuteSqlRawAsync($@"INSERT INTO FCFKC.FSK_ENTITY_QUEUE(alerted_entity_level_code , alerted_entity_number , owner_userid , queue_code)
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
                int rowEffected = await _fcfkc.Database.ExecuteSqlRawAsync($@"UPDATE FCFKC.FSK_ALERTED_ENTITY 
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
                int res = _fcfkc.SaveChanges();

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
                IEnumerable<decimal> alertIdsCoppy = alertIds.ToList();
                (bool, IEnumerable<decimal>) res = (true, alertIdsCoppy);
                int rowEffected = await _fcfkc.Database.ExecuteSqlRawAsync($@"UPDATE FCFKC.FSK_ALERT 
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
            IEnumerable<CloseRequest> requests = closeRequest.Entities.Partition(2).Select(x => new CloseRequest
            {
                Entities = x,
                Comment = closeRequest.Comment,
                Desc = closeRequest.Desc,
            });
            using IDbContextTransaction trans = _fcfkc.Database.BeginTransaction();
            List<(bool isSucceed, IEnumerable<string>? ColseFailedEntities)> res = new();
            try
            {
                foreach (CloseRequest request in requests)
                {
                    res.Add(await CloseAlertsAsync(request, userName, "CLP"));
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
                return (false, res.SelectMany(x => x.ColseFailedEntities));
            }


        }

        public async Task<(bool isSucceed, IEnumerable<string>? RouteFailedEntities)> RouteAllAlertsAsync(RouteRequest routeReq, string userName, string desc = "RTQ")
        {
            IEnumerable<RouteRequest> requests = routeReq.Entities.Partition(2).Select(x => new RouteRequest
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
    }
}
