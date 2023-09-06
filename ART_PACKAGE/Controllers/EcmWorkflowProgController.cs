using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using CsvHelper;
using Data.Data.FTI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Linq.Dynamic.Core;
using System.Text;

namespace ART_PACKAGE.Controllers
{

    //[Authorize(Policy = "Licensed" , Roles = "EcmWorkflowProg")]


    public class EcmWorkflowProgController : Controller
    {
        private readonly FTIContext fti;
        private readonly IPdfService _pdfSrv;

        public EcmWorkflowProgController(IPdfService pdfSrv, FTIContext fti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
        }

        [HttpGet("[controller]/[action]/{EcmRefrence}")]
        public IActionResult GetEcmComments(string EcmRefrence)
        {
            var comments = fti.ArtTiEcmWorkflowProgReportOlds.Where(x => x.EcmReference == EcmRefrence && (x.Note != null || x.Comments != null)).Select(x => new { ecmReference = x.EcmReference, comments = x.Comments, note = x.Note, noteCreationTime = x.NoteCreationTime });
            return Ok(comments);

        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiEcmWorkflowProgReport> data = fti.ArtTiEcmWorkflowProgReports.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {

                DisplayNames = ReportsConfig.CONFIG[nameof(EcmWorkflowProgController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"EcmReference".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmReference).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"FtiReference".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.FtiReference).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"CutomerName".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.CutomerName).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Product".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.Product).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"ProductType".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ProductType).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"BranchId".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.BranchId).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EcmEvent".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmEvent).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"TransactionCurrency".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"PrimaryOwner".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"CaseStatCd".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"UpdateUserId".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EcmRejectionReason".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EcmRejectionReason).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventName".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventName).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"AssignedTo".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AssignedTo).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"StepStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.StepStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventSteps".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.EventSteps).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"AssignmentType".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AssignmentType).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Lstmoduser".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.Lstmoduser).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"WarningOverridden".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.WarningOverridden).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"InputSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.InputSlaStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"AuthorizeSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.AuthorizeSlaStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"ReviewSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ReviewSlaStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"ExternalReviewSlaStatus".ToLower(), fti.ArtTiEcmWorkflowProgReports.Select(x=>x.ExternalReviewSlaStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(EcmWorkflowProgController).ToLower()].SkipList;

            }

            KendoDataDesc<ArtTiEcmWorkflowProgReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                // selectable = true,
                toolbar = new List<dynamic>
                {


                },
                reportname = "EcmWorkflowProg"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(EcmWorkflowProgController).ToLower()].DisplayNames;

            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(EcmWorkflowProgController).ToLower()].SkipList;

            List<ArtTiEcmWorkflowProgReport> data = fti.ArtTiEcmWorkflowProgReports.CallData(req).Data.ToList();
            ViewData["title"] = "ECM Workflow Progression Report";
            ViewData["desc"] = "";
            byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }



        public IActionResult Export([FromBody] ExportDto<decimal> para)
        {
            IQueryable<ArtTiEcmWorkflowProgReport> data = fti.ArtTiEcmWorkflowProgReports.AsQueryable().CallData(para.Req).Data;
            var res = data.AsEnumerable().OrderBy(x => x.EcmReference).GroupBy(x => new { x.EcmReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
            IEnumerable<ExportDto> after = res.Select(x =>
            {
                IQueryable<ArtTiEcmWorkflowProgReportOld>? ListOfMatchingEcm = fti.ArtTiEcmWorkflowProgReportOlds.Where(o => o.EcmReference == x.Key.EcmReference && x.Key.CaseStatCd == o.CaseStatCd && x.Key.EventSteps == o.EventSteps && x.Key.StepStatus == o.StepStatus);
                return new ExportDto
                {
                    Record = x.FirstOrDefault(),
                    Comments = ListOfMatchingEcm?.Select(e => e.Comments).ToList(),
                    Note = ListOfMatchingEcm?.Select(e => e.Note).ToList(),
                    NoteCreationTime = ListOfMatchingEcm?.Select(e => e.NoteCreationTime).ToList()
                };

            });
            MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, CultureInfo.CurrentCulture))
            {


                sw.Write("");
                System.Reflection.PropertyInfo[] props = typeof(ArtTiEcmWorkflowProgReport).GetProperties();

                foreach (System.Reflection.PropertyInfo item in props)
                {
                    cw.WriteField(item.Name);
                }
                cw.WriteField("Comments");
                cw.WriteField("Note");
                cw.WriteField("NoteCreationTime");

                cw.NextRecord();
                foreach (ExportDto? elm in after)
                {
                    foreach (System.Reflection.PropertyInfo prop in props)
                    {
                        cw.WriteField(prop.GetValue(elm.Record));
                    }

                    cw.NextRecord();
                    for (int i = 0; i < elm.Comments.Count; i++)
                    {
                        foreach (System.Reflection.PropertyInfo prop in props)
                        {
                            cw.WriteField("");
                        }
                        cw.WriteField(elm.Comments[i]);
                        cw.WriteField(elm.Note[i]);
                        cw.WriteField(elm.NoteCreationTime[i]);
                        cw.NextRecord();
                    }
                }
            }

            return File(stream.ToArray(), "text/csv");
        }


        public class ExportDto
        {
            public ArtTiEcmWorkflowProgReport Record { get; set; }
            public List<string> Comments { get; set; }
            public List<string> Note { get; set; }
            public List<DateTime?> NoteCreationTime { get; set; }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
