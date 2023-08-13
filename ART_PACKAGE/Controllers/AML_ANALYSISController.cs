using ART_PACKAGE.Extentions.IEnumerableExtentions;
using ART_PACKAGE.Helpers.Aml_Analysis;
using ART_PACKAGE.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace DataGear_RV_Ver_1._7.Controllers
{

    [Authorize(Roles = "AmlAnalysis", Policy = "Licensed")]
    public class AML_ANALYSISController : Controller
    {
        private readonly IConfiguration _config;
        private readonly List<string> Descs = new() { "FPO", "MLI", "MLS", "OTH" };
        private readonly ILogger<AML_ANALYSISController> logger;
        private readonly IAmlAnalysis _amlSrv;
        private readonly IHubContext<AmlAnalysisHub> _amlHub;
        public AML_ANALYSISController(ILogger<AML_ANALYSISController> logger, IConfiguration config, IAmlAnalysis amlSrv, IHubContext<AmlAnalysisHub> amlHub)
        {

            this.logger = logger;
            _config = config;
            _amlSrv = amlSrv;
            _amlHub = amlHub;
        }




        public ContentResult QueryBuilderData()
        {
            var entityType = fcfcore.Model.FindEntityType(typeof(ArtAmlAnalysisView));


            var data = entityType.GetProperties().Select(x =>
            {

                var type = x.PropertyInfo.PropertyType.GetQueryBuilderType();
                var name = x.GetColumnName();
                return new QueryBuilderFilter
                {
                    id = name,
                    field = name,
                    type = type,
                    label = name,
                    value_separator = ",",

                };
            });
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Rules()
        {
            return View();
        }

        //public ContentResult GetData([FromBody] KendoRequest obj)
        //{
        //    //var entitis = fcfcore.ArtAmlAnalysisViews.Select(x => x.PartyNumber);
        //    //var alertscount = fcfkc.FskAlertedEntities.Where(x => entitis.Contains(x.AlertedEntityNumber)).Select(a => a.AlertsCnt);
        //    IQueryable<ArtAmlAnalysisView> _data = fcfcore.ArtAmlAnalysisViews;

        //    string controllerName = nameof(ReportController).Replace("Controller", "");
        //    List<string> temp = new List<string>
        //    {
        //        "PartyNumber",
        //        "SegmentSorted",
        //        "AlertsCount",
        //        "AlertsCnt",
        //        "ClosedAlertsCount",
        //        "TotalWireCAmt"         ,
        //        "MaxMls",
        //        "PartyName",
        //        "PartyTypeDesc",
        //        "OccupationDesc",
        //        "TotalWireDAmt"           ,
        //        "EmployeeInd"          ,
        //        "OwnerUserId"          ,
        //        "BranchName"          ,
        //        "IndustryDesc"          ,
        //        "TotalCreditAmount"          ,
        //        "TotalDebitAmount"          ,
        //        "TotalCreditCnt"         ,
        //        "TotalDebitCnt"           ,
        //        "TotalAmount"          ,
        //        "TotalCnt"          ,
        //        "AvgWireCAmt"          ,
        //        "MaxWireCAmt"          ,
        //        "TotalWireDCnt"           ,
        //        "MinWireDAmt"          ,
        //        "AvgWireDAmt"          ,
        //        "TotalCashCAmt"           ,
        //        "TotalCashCCnt"           ,
        //        "MinCashCAmt"          ,
        //        "AvgCashCAmt"          ,
        //        "MaxCashCAmt"          ,
        //        "AvgCashDAmt"          ,
        //        "TotalCashDAmt"           ,
        //        "TotalCashDCnt"           ,
        //        "MinCashDAmt"          ,
        //        "MaxCashDAmt"          ,
        //        "TotalCheckDCnt"          ,
        //        "AvgCheckDAmt"          ,
        //        "MaxCheckDAmt"          ,
        //        "TotalCheckDAmt"          ,
        //        "MinCheckDAmt"          ,
        //        "MaxClearingcheckCAmt"    ,
        //        "MinClearingcheckCAmt"    ,
        //        "AvgClearingcheckCAmt"    ,
        //        "TotalClearingcheckCAmt"   ,
        //        "TotalClearingcheckCCnt"   ,
        //        "MaxClearingcheckDAmt"    ,
        //        "AvgClearingcheckDAmt"    ,
        //        "TotalClearingcheckDAmt"   ,
        //        "TotalClearingcheckDCnt"   ,
        //        "MinClearingcheckDAmt",
        //        "IndustryCode"
        //    };



        //    List<string> skipList = null;//_config.GetSection($"{controllerName}:skipList").Get<List<string>>();
        //    Dictionary<string, DisplayNameAndFormat> displayNameAndFormat = null;
        //    Dictionary<string, List<dynamic>> dropdown = null;
        //    if (obj.IsInsliaze)
        //    {
        //        skipList = typeof(ArtAmlAnalysisView).GetProperties().Where(x => !temp.Contains(x.Name)).Select(x => x.Name).ToList();
        //        displayNameAndFormat = _config.GetSection($"{controllerName}:displayAndFormat").Get<Dictionary<string, DisplayNameAndFormat>>();
        //        dropdown = new Dictionary<string, List<dynamic>>{
        //        { "IndustryCode".ToLower(), fcfcore.ArtAmlAnalysisViews.Select(x=>x.IndustryCode).Where(x=> !string.IsNullOrEmpty(x)).Distinct().ToDynamicList()},
        //        };
        //    }


        //    //    new Dictionary<string, DisplayNameAndFormat>
        //    //{
        //    //    {"MoneyLaunderingRiskScore", new DisplayNameAndFormat{ DisplayName = "Money Laundering Risk Score" , Format="{0:n2}" } }
        //    //};




        //    var Data = _data.CallData<ArtAmlAnalysisView>(obj, columnsToDropDownd: dropdown, propertiesToSkip: skipList, DisplayNames: displayNameAndFormat);

        //    var data = new
        //    {
        //        data = Data.Data.ToArray(),
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //        selectable = true,
        //        toolbar = new List<dynamic>
        //        {
        //              new
        //            {
        //                text = "close Alerts"
        //                , id = "closeAlerts"
        //            },
        //            new
        //            {
        //                text = "route Alerts"
        //                , id = "routeAlerts"
        //            },
        //            new
        //            {
        //                text = "Close All Customers"
        //                , id = "CloseAll"
        //            },

        //        }
        //    };
        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        //        {
        //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

        //        }),

        //    };
        //}

        public async Task<IActionResult> Close([FromBody] CloseRequest closeRequest)
        {
            if (closeRequest == null)
                return BadRequest("You Should Send a Close request Body");
            //this action might take time so we used signalr
            (bool isSucceed, IEnumerable<string>? ColseFailedEntities) res = await _amlSrv.CloseAllAlertsAsync(closeRequest, User.Identity.Name, "CLP");
            await _amlHub.Clients.Client(AmlAnalysisHub.Connections[User.Identity.Name]).SendAsync("CloseResult", res);
            return Ok();
        }
        //[HttpPost]
        //public IActionResult ApplyRules(List<ApplyRulesModel> rules)
        //{
        //    try
        //    {
        //        foreach (var rule in rules)
        //        {
        //            if (String.IsNullOrEmpty(rule.AENs))
        //                continue;

        //            var AlertedEntityNumber = rule.AENs.Split(",");
        //            var PartitionedAENs = AlertedEntityNumber.Partition<string>(900);
        //            List<ArtAmlAnalysisView> EntitiesInTheTable = new();
        //            foreach (var part in PartitionedAENs)
        //            {
        //                var temp = fcfcore.ArtAmlAnalysisViews.Where(x => part.Contains(x.PartyNumber)).ToList();
        //                EntitiesInTheTable.AddRange(temp);
        //            }

        //            var AlertedENs = EntitiesInTheTable.Select(x => x.PartyNumber).ToArray();
        //            if (rule.Action == "Route")
        //            {
        //                var str = rule.RouteUser.Split("--");
        //                var queue = str[0];
        //                var user = str[1];
        //                _iaml.Route(null, AlertedENs, queue,
        //                    $"{rule.RuleId}--RTQ--FAAR-Apply",
        //                    user, $"Routed From AmlAnalysis Auto Rule :{rule.RuleId}", User.Identity.Name);
        //            }
        //            else if (rule.Action == "Close")
        //            {
        //                _iaml.Close(AlertedENs
        //                    , $"{rule.RuleId}--CLA", User.Identity.Name, "CLA"
        //                    , $"Closed By AmlAnalysis Auto-Rules :{rule.RuleId}");

        //            }

        //        }

        //        return RedirectToAction("Rules");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500);
        //        throw;
        //    }


        //}


        //public IActionResult GetAllEntities()
        //{
        //    var Alertedentitiesnumber = fcfkc.FskAlertedEntities.Where(x => x.AlertsCnt > 0).Select(x => x.AlertedEntityNumber);
        //    var TotalEntities = fcfkc.FskAlertedEntities.Count();

        //    var alerts = fcfkc.FskAlerts.Count(x => Alertedentitiesnumber.Contains(x.AlertedEntityNumber) && x.AlertStatusCode == "ACT");

        //    return Ok(new
        //    {
        //        AlertedentitiesNumbers = Alertedentitiesnumber,
        //        TotalEntities = TotalEntities,
        //        AlertedEntities = Alertedentitiesnumber.Count(),
        //        Alerts = alerts
        //    });
        //}


        //[AllowAnonymous]
        //public IActionResult ExecuteBatchRules()
        //{
        //    try
        //    {

        //        var rules = fcfcore.FscRuleBaseds.Where(r => r.Deleted == 0 && !string.IsNullOrEmpty(r.OutputReadable)).ToList().OrderByDescending(r => r.CreatedDate);
        //        StringBuilder sb = new StringBuilder("");
        //        foreach (var rule in rules)
        //        {
        //            string query = ExtractQuery(rule);
        //            var Entities = fcfcore.ArtAmlAnalysisViews.FromSqlRaw(query);
        //            var count = Entities.Count();
        //            if (rule.Action == "Route")
        //            {
        //                Entities.Select(x => x.PartyNumber).ToList()
        //                    .Partition<string>(900).ToList()
        //                    .ForEach(x =>
        //                            _iaml.Route(null, x.ToArray(), "",
        //                            $"{rule.RuleId}--RTQ--FAAR-Apply",
        //                            "", $"Routed From AmlAnalysis Auto Rule :{rule.RuleId}", "ART-SRV"));
        //                sb.AppendLine($"Rule number : {rule.RuleId} Routed {count} Entities");
        //            }
        //            else if (rule.Action == "Close")
        //            {
        //                Entities.Select(x => x.PartyNumber).ToList()
        //                    .Partition<string>(900).ToList()
        //                    .ForEach(x =>
        //                                 _iaml.Close(x.ToArray()
        //                                , $"{rule.RuleId}--CLA", "ART-SRV", "CLA"
        //                                , $"Closed By AmlAnalysis Auto-Rules :{rule.RuleId}"));

        //                sb.AppendLine($"Rule number : {rule.RuleId} Closed {count} Entities");
        //                fcfcore.RemoveRange(Entities);
        //                fcfcore.SaveChanges();
        //            }
        //        }
        //        return Ok($"Jobs Done for {DateTime.UtcNow} => [{sb.ToString()}]");
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError("ERROR:" + ex.Message + "---\n" + ex.InnerException);

        //        return BadRequest(ex.Message);

        //        throw;
        //    }

        //}
        public class ApplyRulesModel
        {
            public int RuleId { get; set; }
            public string AENs { get; set; }
            public string Action { get; set; }
            public string RouteUser { get; set; }
        }

        //i made it public  for unit test --Ehab



        public async Task<IActionResult> Route([FromBody] RouteRequest routeRequest)
        {
            if (routeRequest == null)
                return BadRequest("You Should Send a Route request Body");


            (bool isSucceed, IEnumerable<string>? RouteFailedEntities) res = await _amlSrv.RouteAllAlertsAsync(routeRequest, User.Identity.Name);
            await _amlHub.Clients.Client(AmlAnalysisHub.Connections[User.Identity.Name]).SendAsync("RouteResult", res);
            return Ok();
        }

        public ContentResult GetQueues()
        {
            var result = fcfcore.ArtSasQueues.Select(Q => Q.Queuecode);
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
        public ContentResult GetQueuesUsers([FromBody] string Queue)
        {
            if (string.IsNullOrEmpty(Queue))
            {
                var result = fcfcore.ArtSasUserQueues.Select(U => U.Userid).Distinct();
                return Content(JsonConvert.SerializeObject(result), "application/json");
            }
            else
            {
                var result = fcfcore.ArtSasUserQueues.Where(Q => Q.Queuecode == Queue).Select(U => U.Userid);
                return Content(JsonConvert.SerializeObject(result), "application/json");
            }
        }
        [HttpPost("[controller]/[action]")]
        public ContentResult GetRulesData([FromBody] KendoRequest req)
        {
            var rule = new ArtAmlAnalysisRule();
            var skiplist = new List<string>()
            {
                nameof(rule.Active),
                nameof(rule.Sql),
                nameof(rule.Deleted),
            };

            var dropdown = new Dictionary<string, List<dynamic>>()
            {
                { nameof(rule.Action).ToLower() , Enum.GetNames(typeof(AmlAnalysisAction)).ToDynamicList()  }
            };
            var rules = art.ArtAmlAnalysisRules.Where(r => r.Active && !r.Deleted);

            var Data = rules.CallData<ArtAmlAnalysisRule>(req, columnsToDropDownd: dropdown, propertiesToSkip: skiplist);

            //var result = fcfcore.FscRuleBaseds.Where(r => r.Deleted == 0 && !string.IsNullOrEmpty(r.OutputReadable)).ToList().OrderByDescending(r => r.CreatedDate);
            return Content(JsonConvert.SerializeObject(
                new
                {
                    data = Data.Data,
                    columns = Data.Columns,
                    total = Data.Total,
                    containsActions = false,
                    selectable = true,
                    toolbar = new List<dynamic>
                {
                    new
                    {
                        text = "Test Rules"
                        , id = "testRules"
                    },
                    new
                    {
                        text = "Create A rule",
                        id = "crtrule"
                    }
                    }

                }), "application/json");

        }

        [HttpPost]
        public IActionResult RulesData(string query, string tableName)
        {
            try
            {
                var count = fcfcore.FscRuleBaseds.Count();
                int maxid = 0;
                if (count != 0)
                {
                    maxid = fcfcore.FscRuleBaseds.Select(r => r.RuleId).Max() ?? 0;
                }
                var queries = new List<FscRuleBased>();

                int counter = maxid + 2;
                int parent = maxid + 1;
                var date = DateTime.Now;
                var querysplited = query.Split(",");
                foreach (var item in querysplited)
                {
                    var strs = item.Split(" ");
                    string rel;
                    string col;
                    string op;
                    string val;

                    var q = new FscRuleBased();
                    if (item.Equals(querysplited.First()))
                    {
                        var readable = query.Replace(",", "");
                        col = strs[0];
                        op = strs[1];
                        val = strs[2];
                        q.RuleId = parent;
                        q.ParentId = null;
                        q.RelationName = null;
                        q.OutputReadable = readable;
                    }
                    else
                    {
                        rel = strs[0];
                        col = strs[1];
                        op = strs[2];
                        val = strs[3];
                        q.RuleId = counter;
                        q.ParentId = parent;
                        q.RelationName = rel;
                    }
                    q.OperatorName = op;
                    q.ColumnName = col;
                    q.TableName = tableName;
                    q.CreatedDate = date;
                    q.Deleted = 0;
                    q.Active = 1;
                    q.UserId = User.Identity.Name;
                    q.RuleValue = val;
                    queries.Add(q);
                    counter++;

                }
                fcfcore.AddRange(queries);
                fcfcore.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        [HttpPost("[controller]/[action]")]
        public IActionResult AddRule([FromBody] AddRuleDto ruledto)
        {
            if (ruledto == null)
                return BadRequest("you should send a rule to add");
            var rule = new ArtAmlAnalysisRule
            {
                Action = ruledto.Action.ToString(),
                ReadableOutPut = ruledto.ReadableOutPut,
                Sql = ruledto.Sql,
                TableName = ruledto.TableName,
                RouteToUser = ruledto.RouteToUser
            };
            try
            {
                art.ArtAmlAnalysisRules.Add(rule);
                art.SaveChanges();
                return Ok($"Rule with id: {rule.Id} Was added");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message + ":" + e.InnerException?.Message);
                return BadRequest("something went wrong");
            }

        }



        [HttpGet]
        public ContentResult GetRuleData(int id)
        {
            var rule = fcfcore.FscRuleBaseds.Find(id);
            return Content(JsonConvert.SerializeObject(rule), "application/json");
        }

        public ContentResult ActiveDeActive(int rule_id)
        {
            var found = fcfcore.FscRuleBaseds.Find(rule_id);
            if (found.Active == 0)
            {
                found.Active = 1;
            }
            else { found.Active = 0; }

            fcfcore.SaveChanges();
            return Content(JsonConvert.SerializeObject(found), "application/json");
        }


        [AllowAnonymous]
        public IActionResult getrulez()
        {
            var data = typeof(AML_ANALYSISController).Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.Namespace == "DataGear_RV_Ver_1._7.Controllers")
                .Select(x => x.GetCustomAttribute<AuthorizeAttribute>()?.Roles)
                .Where(x => x is not null)
                .Select(x => new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = x
                });



            return Content(JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None

            }), "application/json");
        }



        [HttpPost]
        public void EditRule(int? id, int action, string user)
        {
            if (id == null)
            {
                return;
            }
            var rule = fcfcore.FscRuleBaseds.Find(id);
            if (rule is null)
            {
                return;
            }
            rule.Action = action == (int)RuleAction.Close ? "Close" : "Route";
            rule.RouteToUser = user;
            fcfcore.SaveChanges();
            return;
        }
        [HttpPost]
        public void DeletRole(int? id)
        {
            if (id == null)
            {
                return;
            }
            var rule = fcfcore.FscRuleBaseds.Find(id);
            if (rule is null)
            {
                return;
            }
            rule.Deleted = 1;
            fcfcore.SaveChanges();
            return;
        }
        [HttpPost("[controller]/[action]")]
        public IActionResult TestRules([FromBody] List<int> rules)
        {
            if (rules is null || rules.Count() == 0)
                return BadRequest("There no rules selected");
            var Rules = art.ArtAmlAnalysisRules.Where(r => rules.Contains(r.Id)).ToList();

            var result = Rules.Select(x =>
            {
                var aens = fcfcore.ArtAmlAnalysisViews.FromSqlRaw($"Select * From {x.TableName} Where {x.Sql}").Select(x => x.PartyNumber).ToList();
                var pair = new Dictionary<string, dynamic>
                {
                    {"Id" , x.Id },
                    {"AlertedEntities" , aens.Count() },
                    {"Alerts" , fcfkc.FskAlerts.Where(a => aens.Contains(a.AlertedEntityNumber) && a.AlertStatusCode.ToUpper() == "ACT").Count()},
                    {"text1" , "dsfdfsdsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss"},
                    {"text2" , "dsfdfsdsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss"},
                };
                return pair;
            });
            return Ok(result);
        }


        [HttpPost("[controller]/[action]")]
        public IActionResult Apply([FromBody] List<int> rules)
        {
            if (rules is null || rules.Count() == 0)
                return BadRequest("There no rules selected");
            try
            {
                var Rules = art.ArtAmlAnalysisRules.Where(r => rules.Contains(r.Id)).ToList();
                var closeRules = Rules.Where(x => x.Action == AmlAnalysisAction.Close.ToString());
                var routeRules = Rules.Where(x => x.Action == AmlAnalysisAction.Route.ToString());
                foreach (var rule in closeRules)
                {
                    var aens = fcfcore.ArtAmlAnalysisViews.FromSqlRaw($"Select * From {rule.TableName} Where {rule.Sql}").Select(x => x.PartyNumber).ToArray();
                    _iaml.Close(aens
                                , $"{rule.Id}--CLA", User.Identity.Name, "CLA"
                                , $"Closed By AmlAnalysis Auto-Rules :{rule.Id}");
                }

                foreach (var rule in routeRules)
                {
                    var aens = fcfcore.ArtAmlAnalysisViews.FromSqlRaw($"Select * From {rule.TableName} Where {rule.Sql}").Select(x => x.PartyNumber).ToArray();
                    _iaml.Route(null, aens, rule.RouteToUser.Split("--")[0],
                               $"{rule.Id}--RTQ--FAAR-Apply",
                               rule.RouteToUser.Split("--")[1], $"Routed From AmlAnalysis Auto Rule :{rule.Id}", User.Identity.Name);
                }

                return Ok("The Rules Have Been Applied");
            }
            catch (Exception e)
            {
                logger.LogCritical(e.Message + " " + e.InnerException.Message);
                return BadRequest("something went wrong");
            }

        }


        [HttpGet]
        public IActionResult GetAlertsCount(int?[] rules)
        {
            var Rules = fcfcore.FscRuleBaseds.Where(r => rules.Contains(r.RuleId));
            List<Dictionary<string, dynamic>> EnitiesAlertsPairs = new();
            foreach (var rule in Rules)
            {

                Dictionary<string, dynamic> pair = new();
                var query = ExtractQuery(rule);

                var AENs = fcfcore.ArtAmlAnalysisViews.FromSqlRaw(query).Select(r => r.PartyNumber).ToList();
                var PartitionedAENs = AENs.Partition<string>(900);
                if (AENs is null)
                {
                    pair.Add("RuleId", rule.RuleId);
                    pair.Add("AlertedEntities", 0);
                    pair.Add("Alerts", 0);
                    pair.Add("AENs", AENs);
                    pair.Add("Action", rule.Action);
                    pair.Add("RouteUser", rule.RouteToUser);
                    EnitiesAlertsPairs.Add(pair);
                    continue;
                }
                int count = 0;
                foreach (var List in PartitionedAENs)
                {
                    count += fcfkc.FskAlerts.Where(a => List.Contains(a.AlertedEntityNumber) && a.AlertStatusCode.ToUpper() == "ACT").Count();
                }
                //var AlertsCount = fcfkc.FskAlerts.Where(a => temp.Any(x=>x.Contains(a.AlertedEntityNumber)) && a.AlertStatusCode.ToUpper() == "ACT").Count();
                pair.Add("RuleId", rule.RuleId);
                pair.Add("AlertedEntities", AENs.Count());
                pair.Add("Alerts", count);
                pair.Add("AENs", AENs);
                pair.Add("Action", rule.Action);
                pair.Add("RouteUser", rule.RouteToUser);


                EnitiesAlertsPairs.Add(pair);


            }
            return Ok(EnitiesAlertsPairs);

        }
        private static string ExtractQuery(FscRuleBased rule)
        {

            // Table info 
            //PARTY_NUMBER
            string table = rule.TableName == "ART_AML_ANALYSIS_VIEW" ? "\"ART_AML_ANALYSIS_VIEW_Daily\"" : rule.TableName;
            string query = $"select * from {rule.TableName} where ";
            string[] readableOutputFullCondition = rule.OutputReadable.Split(" AND ");
            for (int i = 0; i < readableOutputFullCondition.Length; i++)
            {
                var condition = MakeCondition(readableOutputFullCondition[i]);

                string AND = i != readableOutputFullCondition.Length - 1 ? "AND" : " ";
                string StringQueryCondition = $"{condition} {AND} ";
                query += StringQueryCondition;
            }
            return query;
        }

        private static string MakeCondition(string condition)
        {
            string[] stringColumns = { "SEGMENT", "SEGMENT_SORTED", "PARTY_NAME", "MONTH_KEY", "PARTY_NUMBER", "PARTY_TYPE_DESC", "INDUSTRY_CODE", "INDUSTRY_DESC", "OCCUPATION_CODE", "OCCUPATION_DESC" };
            var spllitedCon = condition.Split(" ");
            string ConditionCN = spllitedCon[0];
            string ConditionOP = spllitedCon[1];

            var value = spllitedCon.Skip(2);
            var validvalue = String.Join(" ", value);
            validvalue = validvalue.Trim();
            string ConditionVAL = stringColumns.Contains(ConditionCN) ? $"'{validvalue}'" : validvalue;
            string lowwercolumn = stringColumns.Contains(ConditionCN) ? $"LOWER({ConditionCN})" : ConditionCN;

            string returnCondition = $" {lowwercolumn} {MapOperator(ConditionOP.ToLower(), ConditionVAL)} ";
            return returnCondition;
        }

        private static string MapOperator(string conditionOP, string value)
        {
            switch (conditionOP)
            {
                case "equal":
                    {
                        if (value.ToLower().Contains("null"))
                            return $"IS NULL";
                        return $"= {value}";
                        break;
                    }
                case "not equal":
                    {
                        if (value.ToLower().Contains("null"))
                            return $"IS NOT NULL";
                        return $"<> {value}";
                        break;
                    }
                case "not_equal":
                    {
                        if (value.ToLower().Contains("null"))
                            return $"IS NOT NULL";
                        return $"<> {value}";
                        break;
                    }
                case "less or equal":
                    {
                        return $"<= {value}";
                        break;
                    }
                case "less":
                    {
                        return $"< {value}";
                        break;
                    }

                case "greater or equal":
                    {
                        return $">= {value}";
                        break;
                    }
                case "contains":
                    {
                        string result = value.Substring(1, value.Length - 2);
                        return $"LIKE '%{result}%'";
                        break;
                    }
                case "not_contains":
                    {
                        string result = value.Substring(1, value.Length - 2);
                        return $"NOT LIKE '%{result}%'";
                        break;
                    }
                case "ends_with":
                    {
                        string result = value.Substring(1, value.Length - 2);
                        return $"LIKE '%{result}'";
                        break;
                    }
                case "begins_with":
                    {
                        string result = value.Substring(1, value.Length - 2);
                        return $"LIKE '{result}%'";
                        break;
                    }
                case "not_begins_with":
                    {
                        string result = value.Substring(1, value.Length - 2);
                        return $"NOT LIKE '{result}%'";
                        break;
                    }
                case "not_ends_with":
                    {
                        string result = value.Substring(1, value.Length - 2);
                        return $"NOT LIKE '%{result}'";
                        break;
                    }
                default:
                    return "";
                    break;
            }
        }


        public IActionResult bluider()
        {
            return View();
        }

    }
}
