using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.Segmentation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.SEG
{
    public class AllSegmentsOutliersNewController : Controller
    {
        private readonly SegmentationContext _context;
        private readonly IPdfService _pdfService;

        public AllSegmentsOutliersNewController(SegmentationContext _context, IPdfService pdfService)
        {
            this._context = _context;
            _pdfService = pdfService;
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
            bool returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            ArrayList chartsData = new();
            if (returnData)
            {
                data = data.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());
                _ = chartsData.Add(Chart1Data(MonthKey, PartyTypeDesc, Segment));
                _ = chartsData.Add(Chart2Data(MonthKey, PartyTypeDesc, Segment));
            }
            KendoDataDesc<ArtAllSegmentsOutliersTb> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            ArtSegoutvsalloutTb? segData = _context.ArtSegoutvsalloutTbs.FirstOrDefault(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());
            List<Dictionary<string, object>> data = new();
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
            ChartData<Dictionary<string, object>> chrtdata = new()
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
            ArtSegoutvsallcustTb? segData = _context.ArtSegoutvsallcustTbs.FirstOrDefault(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());
            List<Dictionary<string, object>> data = new();
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
            ChartData<Dictionary<string, object>> chrtdata = new()
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
            IQueryable<string?> keys = _context.ArtAllSegsFeatrsStatcsTbs.Select(s => s.MonthKey).Distinct();
            return Content(JsonConvert.SerializeObject(keys), "application/json");
        }
        [HttpGet("[controller]/[action]/{monthkey}")]
        public ContentResult SegTypesPerKey(int? monthkey)
        {
            IQueryable<string?> types = _context.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString()).Select(s => s.PartyTypeDesc).Distinct();
            return Content(JsonConvert.SerializeObject(types), "application/json");
        }
        [HttpGet("[controller]/[action]/{monthkey}/{Type}")]
        public ContentResult Segment(int? monthkey, string Type)
        {
            IQueryable<string?> segs = _context.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type).Select(s => s.SegmentSorted).Distinct();

            return Content(JsonConvert.SerializeObject(segs), "application/json");
        }




        public async Task<IActionResult> Export([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] ExportDto<string> exportDto)
        {
            bool returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            if (!returnData)
            {
                return File(new byte[] { }, "text/csv");
            }

            IQueryable<ArtAllSegmentsOutliersTb> data = _context.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString()); ;
            if (exportDto.All)
            {

                byte[] bytes = await data.ExportToCSV<ArtAllSegmentsOutliersTb, GenericCsvClassMapper<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController>>(exportDto.Req);
                return File(bytes, "text/csv");

            }
            else
            {
                byte[] bytes = await data.Where(x => exportDto.SelectedIdz.Contains(x.PartyNumber)).ExportToCSV<ArtAllSegmentsOutliersTb, GenericCsvClassMapper<ArtAllSegmentsOutliersTb, AllSegmentsOutliersNewController>>(all: false);
                return File(bytes, "text/csv");
            }

        }
        public async Task<IActionResult> ExportPdf([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] KendoRequest req)
        {
            //var DisplayNames = ReportsConfig.CONFIG[nameof(AllSegmentsOutliersNewController).ToLower()].DisplayNames;
            //var ColumnsToSkip = ReportsConfig.CONFIG[nameof(AllSegmentsOutliersNewController).ToLower()].SkipList;

            bool returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            if (!returnData)
            {
                return File(new byte[] { }, "application/pdf");
            }

            IQueryable<ArtAllSegmentsOutliersTb> data = _context.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString()); ;
            data = data.CallData(req).Data;
            ViewData["title"] = $"Segment Number {Segment} Of Type {PartyTypeDesc} For Month Key {MonthKey}";
            ViewData["desc"] = " ";
            byte[] pdfBytes = await _pdfService.ExportToPdf(data.ToList(), ViewData, ControllerContext, 5
                                                    , User.Identity.Name/*, ColumnsToSkip: ColumnsToSkip, DisplayNamesAndFormat: DisplayNames*/);
            return File(pdfBytes, "application/pdf");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
