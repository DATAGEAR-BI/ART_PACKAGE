using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.Segmentation;
using Data.Services;
using Data.Services.Grid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ART_PACKAGE.Controllers.SEG
{
    public class AllSegmentsOutliersNewController : BaseReportController<IGridConstructor<IBaseRepo<SegmentationContext, ArtAllSegmentsOutliersTb>, SegmentationContext, ArtAllSegmentsOutliersTb>, IBaseRepo<SegmentationContext, ArtAllSegmentsOutliersTb>, SegmentationContext, ArtAllSegmentsOutliersTb>
    {
        private readonly IBaseRepo<SegmentationContext, ArtAllSegsFeatrsStatcsTb> _segsFeatrsStatcsRepo;
        private readonly IBaseRepo<SegmentationContext, ArtSegoutvsalloutTb> _segoutvsalloutRepo;
        private readonly IBaseRepo<SegmentationContext, ArtSegoutvsallcustTb> _segoutvsallcustRepo;
        public AllSegmentsOutliersNewController(IGridConstructor<IBaseRepo<SegmentationContext, ArtAllSegmentsOutliersTb>, SegmentationContext, ArtAllSegmentsOutliersTb> gridConstructor, IBaseRepo<SegmentationContext, ArtAllSegsFeatrsStatcsTb> segsFeatrsStatcsRepo, IBaseRepo<SegmentationContext, ArtSegoutvsallcustTb> segoutvsallcustRepo, IBaseRepo<SegmentationContext, ArtSegoutvsalloutTb> segoutvsalloutRepo, UserManager<AppUser> um) : base(gridConstructor, um)
        {
            _segsFeatrsStatcsRepo = segsFeatrsStatcsRepo;
            _segoutvsallcustRepo = segoutvsallcustRepo;
            _segoutvsalloutRepo = segoutvsalloutRepo;
        }


        public async Task<IActionResult> GetDataByParams([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] GridRequest request)
        {
            bool hasParams = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            baseCondition = hasParams
                ? (x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString())
                : (System.Linq.Expressions.Expression<Func<ArtAllSegmentsOutliersTb, bool>>?)(x => false);

            return await GetData(request);
        }
        [HttpPost("[controller]/[action]/{gridId}")]
        public async Task<IActionResult> ExportByParams([FromBody] ExportRequest req, [FromRoute] string gridId, [FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromQuery] string? reportGUID)
        {
            bool hasParams = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
            baseCondition = hasParams
                ? (x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString())
                : (System.Linq.Expressions.Expression<Func<ArtAllSegmentsOutliersTb, bool>>?)(x => false);

            return await ExportToCsv(req, gridId, reportGUID: reportGUID);
        }




        [HttpGet("[controller]/[action]")]
        public IActionResult GetSegmentOutliersChartData([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment)
        {
            ArtSegoutvsalloutTb? segmentOutliers = _segoutvsalloutRepo.GetFirstWithCondition(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());

            List<Dictionary<string, object>> data = new();
            if (segmentOutliers != null)
            {
                if (segmentOutliers.NumberOfOutliers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                        { "NumberOfOutliers" , segmentOutliers.NumberOfOutliers },
                        { "Cat","Number Of Segment Outliers"}
                     });
                }
                if (segmentOutliers.TotalNumberOfOutliers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                          { "NumberOfOutliers" , segmentOutliers.TotalNumberOfOutliers },
                          { "Cat","Number Of Segment Customers"}
                        }
                     );
                }
            }

            return Ok(data);
        }


        [HttpGet("[controller]/[action]")]
        public IActionResult GetSegentCustomersChartData([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment)
        {
            ArtSegoutvsallcustTb? segmentOutliers = _segoutvsallcustRepo.GetFirstWithCondition(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString());

            List<Dictionary<string, object>> data = new();
            if (segmentOutliers != null)
            {
                if (segmentOutliers.NumberOfOutliers != null)
                {
                    data.Add(
                        new Dictionary<string, object>{
                        { "NumberOfOutliers" , segmentOutliers.NumberOfOutliers },
                        { "Cat","Number Of Segment Outliers"}
                     });
                }
                if (segmentOutliers.NumberOfCustomers != null)
                {
                    data.Add(
                       new Dictionary<string, object>{
                          { "NumberOfOutliers" , segmentOutliers.NumberOfCustomers },
                          { "Cat","Number Of Segment Customers"}
                       }
                    );
                }
            }
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetMonthKies()
        {
            IEnumerable<object?> keys = _segsFeatrsStatcsRepo.GetDistinctValuesOf(s => s.MonthKey);
            return Ok(keys);
        }
        [HttpGet("[controller]/[action]/{monthkey}")]
        public IActionResult SegTypesPerKey(int? monthkey)
        {
            IEnumerable<object?> types = _segsFeatrsStatcsRepo.GetDistinctValuesOf(s => s.PartyTypeDesc, s => s.MonthKey == monthkey.ToString());
            return Ok(types);
        }
        [HttpGet("[controller]/[action]/{monthkey}/{Type}")]
        public IActionResult Segment(int? monthkey, string Type)
        {
            IEnumerable<object?> segs = _segsFeatrsStatcsRepo.GetDistinctValuesOf(s => s.SegmentSorted, s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type);
            return Ok(segs);
        }





        //public async Task<IActionResult> ExportPdf([FromQuery] int? MonthKey, [FromQuery] string PartyTypeDesc, [FromQuery] int? Segment, [FromBody] KendoRequest req)
        //{
        //    //var DisplayNames = ReportsConfig.CONFIG[nameof(AllSegmentsOutliersNewController).ToLower()].DisplayNames;
        //    //var ColumnsToSkip = ReportsConfig.CONFIG[nameof(AllSegmentsOutliersNewController).ToLower()].SkipList;

        //    bool returnData = MonthKey is not null && PartyTypeDesc is not null && Segment is not null;
        //    if (!returnData)
        //    {
        //        return File(new byte[] { }, "application/pdf");
        //    }

        //    IQueryable<ArtAllSegmentsOutliersTb> data = _context.ArtAllSegmentsOutliersTbs.Where(x => x.MonthKey == MonthKey.ToString() && x.PartyTypeDesc == PartyTypeDesc && x.SegmentSorted == Segment.ToString()); ;
        //    data = data.CallData(req).Data;
        //    ViewData["title"] = $"Segment Number {Segment} Of Type {PartyTypeDesc} For Month Key {MonthKey}";
        //    ViewData["desc"] = " ";
        //    byte[] pdfBytes = await _pdfService.ExportToPdf(data.ToList(), ViewData, ControllerContext, 5
        //                                            , User.Identity.Name/*, ColumnsToSkip: ColumnsToSkip, DisplayNamesAndFormat: DisplayNames*/);
        //    return File(pdfBytes, "application/pdf");
        //}

        public override IActionResult Index()
        {
            return View();
        }

    }
}
