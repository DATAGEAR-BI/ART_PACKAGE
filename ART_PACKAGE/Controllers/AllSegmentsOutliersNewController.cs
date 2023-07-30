using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Services.Pdf;
using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers
{
    public class AllSegmentsOutliersNewController : Controller
    {
        private readonly AuthContext _context;
        private readonly IPdfService _pdfService;

        public AllSegmentsOutliersNewController(AuthContext _context, IPdfService pdfService)
        {
            this._context = _context;
            this._pdfService = pdfService;
        }



        public IActionResult GetData([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] KendoRequest request)
        {
            IQueryable<ArtAllSegmentsOutliersTb> data = _context.ArtAllSegmentsOutliersTbs.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                //DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
                //DropDownColumn = new Dictionary<string, List<dynamic>>
                //{
                //    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                //    {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                //    {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
                //    {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown().ToDynamicList() },
                //    {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                //    {"CreatedBy".ToLower(),dbfcfkc.FskCases.Where(x => x.CreateUserId != null).Select(x => x.CreateUserId).Distinct().OrderBy(t => t).ToDynamicList() },
                //    {"Owner".ToLower(),dbfcfkc.FskEntityQueues.Where(x => x.OwnerUserid != null).Select(x => x.OwnerUserid).Distinct().OrderBy(t => t).ToDynamicList() },
                //    {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown().ToDynamicList() }

                //};
                //ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;

            }
            var returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            var chartsData = new ArrayList();
            if (returnData)
            {
                data = data.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());
                chartsData.Add(Chart1Data(MonthKey, PartyTypeDesc, Segment));
                chartsData.Add(Chart2Data(MonthKey, PartyTypeDesc, Segment));
            }
            var Data = data.CallData<ArtAllSegmentsOutliersTb>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = returnData ? Data.Data : Enumerable.Empty<ArtAllSegmentsOutliersTb>(),
                columns = Data.Columns,
                total = returnData ? Data.Total : 0,
                containsActions = false,
                toolbar = new List<dynamic>
                {

                },
                chartdata = chartsData
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }



        private ChartData<Dictionary<string, object>> Chart1Data(int? MonthKey, string PartyTypeDesc, int? Segment)
        {
            var segData = _context.ArtSegoutvsalloutTbs.FirstOrDefault(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());
            var data = new List<Dictionary<string, object>>();
            if (segData != null)
            {
                if (segData.NumberOfOutliers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                        { "NumberOfOutliers" , segData.NumberOfOutliers },
                        { "Cat","Number Of Segment Outliers"}
                     });
                }
                if (segData.TotalNumberOfOutliers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                          { "NumberOfOutliers" , segData.TotalNumberOfOutliers },
                          { "Cat","Number Of Segment Customers"}
                        }
                     );
                }
            }
            var chrtdata = new ChartData<Dictionary<string, object>>
            {
                ChartId = "ch1",
                Data = data,
                Title = "Outlier Per Segment",
                Cat = "Cat",
                Val = "NumberOfOutliers"
            };
            return chrtdata;
        }
        private ChartData<Dictionary<string, object>> Chart2Data(int? MonthKey, string PartyTypeDesc, int? Segment)
        {
            var segData = _context.ArtSegoutvsallcustTbs.FirstOrDefault(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());
            var data = new List<Dictionary<string, object>>();
            if (segData != null)
            {
                if (segData.NumberOfOutliers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                        { "NumberOfOutliers" , segData.NumberOfOutliers },
                        { "Cat","Number Of Segment Outliers"}
                     });
                }
                if (segData.NumberOfCustomers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                          { "NumberOfOutliers" , segData.NumberOfCustomers },
                          { "Cat","Number Of Segment Customers"}
                        }
                     );
                }
            }
            var chrtdata = new ChartData<Dictionary<string, object>>
            {
                ChartId = "ch2",
                Data = data,
                Title = "Outliers Vs Customers Per Segment",
                Cat = "Cat",
                Val = "NumberOfOutliers"
            };
            return chrtdata;
        }

        [HttpGet]
        public ContentResult GetMonthKies()
        {
            var keys = _context.ArtAllSegsFeatrsStatcsTbs.Select(s => s.MonthKey).Distinct();
            return Content(JsonConvert.SerializeObject(keys), "application/json");
        }
        [HttpGet("[controller]/[action]/{monthkey}")]
        public ContentResult SegTypesPerKey(int? monthkey)
        {
            var types = _context.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString()).Select(s => s.PartyTypeDesc).Distinct();
            return Content(JsonConvert.SerializeObject(types), "application/json");
        }
        [HttpGet("[controller]/[action]/{monthkey}/{Type}")]
        public ContentResult Segment(int? monthkey, string Type)
        {
            var segs = _context.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type).Select(s => s.SegmentSorted).Distinct();

            return Content(JsonConvert.SerializeObject(segs), "application/json");
        }




        public async Task<IActionResult> Export([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] ExportDto<string> exportDto)
        {
            var returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            if (!returnData)
                return File(new byte[] { }, "text/csv");
            var data = _context.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString()); ;
            if (exportDto.All)
            {

                var bytes = await data.ExportToCSV<ArtAllSegmentsOutliersTb, GenericCsvClassMapper<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController>>(exportDto.Req);
                return File(bytes, "text/csv");

            }
            else
            {
                var bytes = await data.Where(x => exportDto.SelectedIdz.Contains(x.PartyNumber)).ExportToCSV<ArtAllSegmentsOutliersTb, GenericCsvClassMapper<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController>>(all: false);
                return File(bytes, "text/csv");
            }

        }
        public async Task<IActionResult> ExportPdf([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] KendoRequest req)
        {
            //var DisplayNames = ReportsConfig.CONFIG[nameof(AllSegmentsOutliersNewController).ToLower()].DisplayNames;
            //var ColumnsToSkip = ReportsConfig.CONFIG[nameof(AllSegmentsOutliersNewController).ToLower()].SkipList;

            var returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            if (!returnData)
                return File(new byte[] { }, "application/pdf");
            var data = _context.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString()); ;
            data = data.CallData<ArtAllSegmentsOutliersTb>(req).Data;
            ViewData["title"] = $"Segment Number {Segment} Of Type {PartyTypeDesc} For Month Key {MonthKey}";
            ViewData["desc"] = " ";
            var pdfBytes = await _pdfService.ExportToPdf(data.ToList(), ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name/*, ColumnsToSkip: ColumnsToSkip, DisplayNamesAndFormat: DisplayNames*/);
            return File(pdfBytes, "application/pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
