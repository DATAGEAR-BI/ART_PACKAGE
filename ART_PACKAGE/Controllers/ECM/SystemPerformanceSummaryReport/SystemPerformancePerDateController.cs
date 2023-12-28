using ART_PACKAGE.Helpers.Chart;
using Data.Data.ECM;
using Data.Services.QueryBuilder;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var result = data.GroupBy(x => new { x.YEAR, x.MONTH }).Select(x => new { Date = $"{15}-{x.Key.MONTH.Trim()}-{x.Key.YEAR}", CASES = x.Sum(x => x.NUMBER_OF_CASES) }).ToList();
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}
