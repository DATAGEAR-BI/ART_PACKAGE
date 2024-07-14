using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.AmlAnalysis;
using Data.Services.AmlAnalysis;
using Data.Services.Grid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ArtAmlAnalysisRule = Data.Data.AmlAnalysis.ArtAmlAnalysisRule;

namespace ART_PACKAGE.Controllers.AML_ANALYSIS
{
    public class AutoRulesController
        : BaseReportController<
            IGridConstructor<IAutoRulesRepo, AmlAnalysisContext, ArtAmlAnalysisRule>,
            IAutoRulesRepo,
            AmlAnalysisContext,
            ArtAmlAnalysisRule
        >
    {
        public AutoRulesController(
            IGridConstructor<
                IAutoRulesRepo,
                AmlAnalysisContext,
                ArtAmlAnalysisRule
            > gridConstructor,
            UserManager<AppUser> um
        )
            : base(gridConstructor, um) { }

        // GET
        public override IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public override async Task<IActionResult> GetData([FromBody] GridRequest request)
        {

            if (request.IsIntialize)
            {

                GridIntializationConfiguration res = _gridConstructor.IntializeGrid((typeof(ArtAmlAnalysisRule).Name + "Config").ToLower(), User);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            else
            {
                baseCondition=(x=>x.Deleted==false);
                GridResult<ArtAmlAnalysisRule> res = _gridConstructor.GetGridData(request, baseCondition, includes);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
                };
            }
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult GetQueryBuilderParams()
        {
            return Ok(_gridConstructor.Repo.GetQueryBuilderFields());
        }
        
        [HttpPost("[controller]/[action]")]
        public IActionResult AddRule([FromBody] AddRuleRequest req)
        {
            try
            {
                _gridConstructor.Repo.AddRule(req);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("[controller]/[action]/{id}")]
        public IActionResult Activate([FromRoute] int id, [FromQuery] bool active)
        {
            try
            {
                _ = _gridConstructor.Repo.ActivateRule(id, active);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("[controller]/[action]/{id}")]
        public IActionResult DeleteRule([FromRoute] int id)
        {
            try
            {
                _gridConstructor.Repo.DeleteRule(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult TestRules([FromBody] int[] rules)
        {
            try
            {
                IEnumerable<TestRulesResult> res = _gridConstructor.Repo.TestRules(rules);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Apply([FromBody] List<int> rules)
        {
            if (rules is null || rules.Count() == 0)
                return BadRequest("There no rules selected");
            (bool isAllSucceed, IEnumerable<int> FailedRules) =
                await _gridConstructor.Repo.ApplyRules(rules);

            return isAllSucceed
                ? Ok("all rules has been apllied")
                : BadRequest(
                    $"this rules : {string.Join(",", FailedRules)} made some issues please contact with support"
                );
        }
    }
}