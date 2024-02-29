using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.ECM;
using Data.DGECM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers.ECM
{
    //[Authorize(Roles = "CasesBirthdate")]
    public class CasesBirthdateController : Controller
    {
        private readonly EcmContext context;
        private readonly DGECMContext db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        private readonly ICsvExport _csvSrv;

        public CasesBirthdateController(EcmContext _context, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IPdfService pdfSrv, DGECMContext db, IDropDownService dropSrv, ICsvExport csvSrv)
        {
            _env = env;
            _pdfSrv = pdfSrv;
            context = _context;
            this.db = db;
            _dropSrv = dropSrv;
            _csvSrv = csvSrv;
        }




        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtEcmCasesBirthdateView> data = context.ArtEcmCasesBirthdateViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(CasesBirthdateController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesBirthdateController).ToLower()].SkipList;

            KendoDataDesc<ArtEcmCasesBirthdateView> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }



        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(CasesBirthdateController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesBirthdateController).ToLower()].SkipList;
            List<ArtEcmCasesBirthdateView> data = context.ArtEcmCasesBirthdateViews.CallData(req).Data.ToList();
            ViewData["title"] = "Cases BirthDate Report";
            ViewData["desc"] = "The related customer's date or year of birth as below";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
