using ART_PACKAGE.Helpers.Grid;
using Data.Data.AmlAnalysis;
using Data.Services.AmlAnalysis;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("[controller]/[action]")]
        public IActionResult TestRules([FromQuery] int[] rules)
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
