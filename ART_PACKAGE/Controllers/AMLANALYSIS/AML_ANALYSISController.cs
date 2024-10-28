using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.AmlAnalysis;
using Data.Services.AmlAnalysis;
using Data.Services.Grid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.AMLANALYSIS
{
    public class AML_ANALYSISController : BaseReportController<IGridConstructor<IAmlAnalysisRepo, AmlAnalysisContext, ArtAmlAnalysisViewTb>, IAmlAnalysisRepo, AmlAnalysisContext, ArtAmlAnalysisViewTb>
    {
        // GET
        public override IActionResult Index()
        {
            return View();
        }

        public AML_ANALYSISController(IGridConstructor<IAmlAnalysisRepo, AmlAnalysisContext, ArtAmlAnalysisViewTb> gridConstructor) : base(gridConstructor)
        {
        }

        [HttpPut]
        public async Task<IActionResult> CloseAlerts([FromBody] CloseRequest closeRequest)
        {
            try
            {
                (bool isSucceed, IEnumerable<string> ColseFailedEntities) = await _gridConstructor.Repo.CloseAllAlertsAsync(closeRequest, (await GetUser()).Email, "CLP");
                if (!isSucceed)
                    return BadRequest();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public async Task<IActionResult> RouteAlerts([FromBody] RouteRequest routeRequest)
        {
            try
            {
                (bool isSucceed, IEnumerable<string>? RouteFailedEntities) = await _gridConstructor.Repo.RouteAllAlertsAsync(routeRequest, (await GetUser()).Email);
                if (!isSucceed)
                    return BadRequest();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult GetQueues()
        {
            try
            {
                IEnumerable<SelectItem> res = _gridConstructor.Repo.GetQueues();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        [HttpGet("[controller]/[action]/{queue?}")]
        public IActionResult GetQeueUsers(string? queue = "all")
        {
            try
            {
                IEnumerable<SelectItem> res = _gridConstructor.Repo.GetUsers(queue);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}