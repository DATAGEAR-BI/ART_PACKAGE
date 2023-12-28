using ART_PACKAGE.Helpers.Chart;
using Data.Data.ECM;
using Data.Services.QueryBuilder;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM.SystemPerformanceSummaryReport
{
    public class SystemPerformancePerDateController : BaseChartController<EcmContext, ArtSystemPerfPerDate>
    {
        public SystemPerformancePerDateController(IChartConstructor<ArtSystemPerfPerDate, EcmContext> chartConstructor) : base(chartConstructor)
        {
        }

        public override async Task<IActionResult> GetData([FromBody] List<BuilderFilter> filters)
        {
            IEnumerable<ArtSystemPerfPerDate> data = _chartConstructor.GetChartData(filters);
            var result = data.GroupBy(x => new { x.YEAR, x.MONTH }).Select(x => new { Date = DateTime.ParseExact($"{15}-{x.Key.MONTH.Trim()}-{x.Key.YEAR}", "d-MMM-yyyy", null), CASES = x.Sum(x => x.NUMBER_OF_CASES) });
            return Ok(result);
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}
