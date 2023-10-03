using ART_PACKAGE.Extentions.QueryBuilderExtentions;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.Aml_Analysis;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Hubs;
using ART_PACKAGE.Models;
using Data.Data.AmlAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.AML_ANALYSIS
{

    public class AML_ANALYSISController : Controller
    {
        private readonly IConfiguration _config;
        private readonly List<string> Descs = new() { "FPO", "MLI", "MLS", "OTH" };
        private readonly ILogger<AML_ANALYSISController> logger;
        private readonly IAmlAnalysis _amlSrv;
        private readonly IHubContext<AmlAnalysisHub> _amlHub;
        private readonly AmlAnalysisContext _context;
        private readonly AmlAnalysisUpdateTableIndecator _updateInd;
        private readonly UsersConnectionIds connections;

        public AML_ANALYSISController(ILogger<AML_ANALYSISController> logger, IConfiguration config, IAmlAnalysis amlSrv, IHubContext<AmlAnalysisHub> amlHub, AmlAnalysisContext context, AmlAnalysisUpdateTableIndecator updateInd, UsersConnectionIds connections = null)
        {
            this.logger = logger;
            _config = config;
            _amlSrv = amlSrv;
            _amlHub = amlHub;
            _context = context;
            _updateInd = updateInd;
            this.connections = connections;
        }




        public ContentResult QueryBuilderData()
        {
            Microsoft.EntityFrameworkCore.Metadata.IEntityType? entityType = _context.Model.FindEntityType(typeof(ArtAmlAnalysisViewTb));


            IEnumerable<QueryBuilderFilter> data = entityType.GetProperties().Select(x =>
        {

            string type = x.PropertyInfo.PropertyType.GetQueryBuilderType();
            string name = x.GetColumnName();
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

        public ContentResult GetData([FromBody] KendoRequest obj)
        {
            //var entitis = fcfcore.ArtAmlAnalysisViews.Select(x => x.PartyNumber);
            //var alertscount = fcfkc.FskAlertedEntities.Where(x => entitis.Contains(x.AlertedEntityNumber)).Select(a => a.AlertsCnt);
            IQueryable<ArtAmlAnalysisViewTb> _data = _context.ArtAmlAnalysisViewTbs;

            string controllerName = GetType().Name.Replace("Controller", "");
            List<string> temp = new()
            {
                "PartyNumber",
                "SegmentSorted",
                "AlertsCount",
                "AlertsCnt",
                "ClosedAlertsCount",
                "TotalWireCAmt"         ,
                "MaxMls",
                "PartyName",
                "PartyTypeDesc",
                "OccupationDesc",
                "TotalWireDAmt"           ,
                "EmployeeInd"          ,
                "OwnerUserId"          ,
                "BranchName"          ,
                "IndustryDesc"          ,
                "TotalCreditAmount"          ,
                "TotalDebitAmount"          ,
                "TotalCreditCnt"         ,
                "TotalDebitCnt"           ,
                "TotalAmount"          ,
                "TotalCnt"          ,
                "AvgWireCAmt"          ,
                "MaxWireCAmt"          ,
                "TotalWireDCnt"           ,
                "MinWireDAmt"          ,
                "AvgWireDAmt"          ,
                "TotalCashCAmt"           ,
                "TotalCashCCnt"           ,
                "MinCashCAmt"          ,
                "AvgCashCAmt"          ,
                "MaxCashCAmt"          ,
                "AvgCashDAmt"          ,
                "TotalCashDAmt"           ,
                "TotalCashDCnt"           ,
                "MinCashDAmt"          ,
                "MaxCashDAmt"          ,
                "TotalCheckDCnt"          ,
                "AvgCheckDAmt"          ,
                "MaxCheckDAmt"          ,
                "TotalCheckDAmt"          ,
                "MinCheckDAmt"          ,
                "MaxClearingcheckCAmt"    ,
                "MinClearingcheckCAmt"    ,
                "AvgClearingcheckCAmt"    ,
                "TotalClearingcheckCAmt"   ,
                "TotalClearingcheckCCnt"   ,
                "MaxClearingcheckDAmt"    ,
                "AvgClearingcheckDAmt"    ,
                "TotalClearingcheckDAmt"   ,
                "TotalClearingcheckDCnt"   ,
                "MinClearingcheckDAmt",
                "IndustryCode"
            };



            List<string> skipList = null;//_config.GetSection($"{controllerName}:skipList").Get<List<string>>();
            Dictionary<string, DisplayNameAndFormat> displayNameAndFormat = null;
            Dictionary<string, List<dynamic>> dropdown = null;
            if (obj.IsIntialize)
            {
                skipList = typeof(ArtAmlAnalysisView).GetProperties().Where(x => !temp.Contains(x.Name)).Select(x => x.Name).ToList();
                displayNameAndFormat = _config.GetSection($"{controllerName}:displayAndFormat").Get<Dictionary<string, DisplayNameAndFormat>>();
                dropdown = new Dictionary<string, List<dynamic>>{
                    { "IndustryCode".ToLower(), _context.ArtAmlAnalysisViewTbs.Select(x=>x.IndustryCode).Where(x=> !string.IsNullOrEmpty(x)).Distinct().ToDynamicList()},
                    };
            }




            KendoDataDesc<ArtAmlAnalysisViewTb> Data = _data.CallData(obj, columnsToDropDownd: dropdown, propertiesToSkip: skipList, DisplayNames: displayNameAndFormat);

            var data = new
            {
                data = Data.Data.ToArray(),
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                selectable = true,
                toolbar = new List<dynamic>
                    {
                          new
                        {
                            text = "close Alerts"
                            , id = "closeAlerts"
                        },
                        new
                        {
                            text = "route Alerts"
                            , id = "routeAlerts"
                        },
                    }
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }

        public async Task<IActionResult> Close([FromBody] CloseRequest closeRequest)
        {
            if (closeRequest == null)
                return BadRequest("You Should Send a Close request Body");
            //this action might take time so we used signalr
            (bool isSucceed, IEnumerable<string>? ColseFailedEntities) = await _amlSrv.CloseAllAlertsAsync(closeRequest, User.Identity.Name, "CLP");
            var response = new { isSucceed, ColseFailedEntities };
            await _amlHub.Clients.Clients(connections.GetConnections(User.Identity.Name)).SendAsync("CloseResult", response);
            return Ok();
        }





        [AllowAnonymous]
        public IActionResult ExecuteBatchRules()
        {
            _updateInd.PerformInd = true;
            logger.LogInformation("Batch Rules will be excuted in the next 10 minutes");
            return Ok();
        }

        public async Task<IActionResult> Route([FromBody] RouteRequest routeRequest)
        {
            if (routeRequest == null)
                return BadRequest("You Should Send a Route request Body");


            (bool isSucceed, IEnumerable<string>? RouteFailedEntities) = await _amlSrv.RouteAllAlertsAsync(routeRequest, User.Identity.Name);
            var response = new { isSucceed, RouteFailedEntities };
            await _amlHub.Clients.Clients(connections.GetConnections(User.Identity.Name)).SendAsync("RouteResult", response);
            return Ok();
        }

        public ContentResult GetQueues()
        {
            List<string> result = new() { "TestQ", "TestQ1", "TestQ2" };
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
        public ContentResult GetQueuesUsers([FromBody] string Queue)
        {
            List<string> Qs = new() { "TestQ", "TestQ1", "TestQ2" };
            Dictionary<string, List<string>> usersDict = new()
            {
                { "TestQ" , new List<string> { "TestU1" , "TestU2" } },
                { "TestQ1" , new List<string> { "TestU3" , "TestU4" } },
                { "TestQ2" , new List<string> { "TestU5"  } },
            };
            if (string.IsNullOrEmpty(Queue))
            {
                IEnumerable<string> result = usersDict.Values.SelectMany(x => x);
                return Content(JsonConvert.SerializeObject(result), "application/json");
            }
            else
            {
                List<string> result = usersDict[Queue];
                return Content(JsonConvert.SerializeObject(result), "application/json");
            }
        }
        [HttpPost("[controller]/[action]")]
        public ContentResult GetRulesData([FromBody] KendoRequest req)
        {

            List<string> skiplist = new()
            {
                nameof(ArtAmlAnalysisRule.Active),
                nameof(ArtAmlAnalysisRule.Sql),
                nameof(ArtAmlAnalysisRule.Deleted),
            };

            Dictionary<string, List<dynamic>> dropdown = new()
            {
                { nameof(ArtAmlAnalysisRule.Action).ToLower() , Enum.GetNames(typeof(AmlAnalysisAction)).ToDynamicList()  }
            };
            IQueryable<ArtAmlAnalysisRule> rules = _context.ArtAmlAnalysisRules.Where(r => r.Active && !r.Deleted);

            KendoDataDesc<ArtAmlAnalysisRule> Data = rules.CallData(req, columnsToDropDownd: dropdown, propertiesToSkip: skiplist);

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
                    , new
                    {
                        text = "Edit/Delete",
                        id = "performAction"
                    }
                    }

                }), "application/json");

        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> EditRule([FromBody] EditRuleDto ruledto)
        {
            ArtAmlAnalysisRule? rule = await _context.ArtAmlAnalysisRules.FindAsync(ruledto.Id);
            if (rule == null)
                return NotFound();

            rule.Action = ruledto.Action.ToString();

            rule.RouteToUser = ruledto.Action == AmlAnalysisAction.Route ? ruledto.RouteToUser : null;


            rule.Active = ruledto.Active;

            _ = await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("[controller]/[action]/{id}")]
        public async Task<IActionResult> DeleteRule(int? id)
        {
            if (id is null)
                return BadRequest(new Error("argumentError", "You must Provide an id"));

            ArtAmlAnalysisRule? rule = await _context.ArtAmlAnalysisRules.FindAsync(id);
            if (rule is null)
                return NotFound();
            rule.Deleted = true;
            _ = await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult AddRule([FromBody] AddRuleDto ruledto)
        {
            if (ruledto == null)
                return BadRequest("you should send a rule to add");
            ArtAmlAnalysisRule rule = new()
            {
                Action = ruledto.Action.ToString(),
                ReadableOutPut = ruledto.ReadableOutPut,
                Sql = ruledto.Sql,
                TableName = ruledto.TableName,
                RouteToUser = ruledto.RouteToUser
            };
            try
            {
                _ = _context.ArtAmlAnalysisRules.Add(rule);
                _ = _context.SaveChanges();
                return Ok($"Rule with id: {rule.Id} Was added");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message + ":" + e.InnerException?.Message);
                return BadRequest("something went wrong");
            }

        }

        [HttpGet("[controller]/[action]/{id}")]
        public async Task<IActionResult> GetRuleById(int? id)
        {
            if (id is null)
                return BadRequest(new Error("argumentError", "You must Provide an id"));

            ArtAmlAnalysisRule? rule = await _context.ArtAmlAnalysisRules.FindAsync(id);

            return rule is null ? NotFound() : Ok(rule);
        }



        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> TestRules([FromBody] List<int> rules)
        {
            if (rules is null || rules.Count() == 0)
                return BadRequest("There no rules selected");
            IEnumerable<TestRulesResult> result = await _amlSrv.TestRules(rules);
            return Ok(result);
        }


        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Apply([FromBody] List<int> rules)
        {
            if (rules is null || rules.Count() == 0)
                return BadRequest("There no rules selected");
            (bool isAllSucceed, IEnumerable<int> FailedRules) = await _amlSrv.ApplyRules(rules);

            return isAllSucceed
                ? Ok("all rules has been apllied")
                : BadRequest($"this rules : {string.Join(",", FailedRules)} made some issues please contact with support");

        }
        public IActionResult Builder()
        {
            return View();
        }

    }
}
