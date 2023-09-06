using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using CsvHelper;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Services.Pdf;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Data;
using ART_PACKAGE.Helpers.CSVMAppers;
using Data.TIZONE2;

namespace ART_PACKAGE.Controllers { 
    //[Authorize(Policy = "Licensed" , Roles ="EcmAuditTrial")]

    
    public class EcmAuditTrialController : Controller
    {

        private readonly AuthContext fti;
        private readonly TIZONE2Context ti;
        //private readonly ACTIVITI_FTI_DB.ModelContext ACTIVITI_FTI;
        //private readonly DGCMGMT_FTI_DB.ModelContext DGCMGMT_FTI;
        //private readonly DGECM_METADATA_FTI_DB.ModelContext DGECM_METADATA;
        private readonly IPdfService _pdfSrv;



        public EcmAuditTrialController(IPdfService pdfSrv, AuthContext fti, TIZONE2Context ti)
        {
            _pdfSrv = pdfSrv;
            this.fti = fti;
            this.ti = ti;
        }


        //public IActionResult GetComments()
        //{

        //    var cases = DGCMGMT_FTI.CaseLives.ToList();
        //    var comments = DGECM_METADATA.Comments.ToList();
        //    var result = cases.Join(comments, c => c.CaseRk, co => co.EntityRk, (c, co) => new { c.CaseId, co.Description });
        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}
        [HttpGet("[controller]/[action]/{FtiReference}")]
        public IActionResult GetEcmComments(/*string EcmRefrence*/ string FtiReference)
        {
            //var comments = fti.ArtTiEcmAuditReports.Where(x => x.EcmReference == EcmRefrence).Select(x => new { x.EcmReference, x.Comments, x.Note });
            var req = ti.Masters.Where(c => c.MasterRef == FtiReference)?.Join(ti.Notes, c => c.Key97, co => co.MasterKey, (c, co) => new { ftiref = c.MasterRef, Comment = co.NoteText }).Where(x => x.Comment != null);
            if (req is null)
                return NotFound("there is no notes");
            return Ok(req);

        }
        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiEcmAuditReport> data = fti.ArtTiEcmAuditReports.AsQueryable();
            //IQueryable<CaseLive> filter = DGCMGMT_FTI.CaseLives.AsQueryable();
            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(EcmAuditTrialController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
            {
                {"EcmReference".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.EcmReference != null).Select(x=>x.EcmReference).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"FtiReference".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.FtiReference != null).Select(x=>x.FtiReference).Distinct().Where(x=> x != null ).ToDynamicList() },
                //{"CutomerName".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.CutomerName != null).Select(x=>x.CutomerName).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Product".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.Product != null).Select(x=>x.Product).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"Producttype".ToLower(), fti.ArtTiEcmAuditReports.Where(x => x.Producttype != null).Select(x=>x.Producttype).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"BranchId".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.BranchId).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EcmEvent".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EcmEvent).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"TransactionCurrency".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.TransactionCurrency).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"PrimaryOwner".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.PrimaryOwner).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"CaseStatCd".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.CaseStatCd).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"UpdateUserId".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.UpdateUserId).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventName".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventName).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventStatus".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"MasterAssignedTo".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.MasterAssignedTo).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"StepStatus".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.StepStatus).Distinct().Where(x=> x != null ).ToDynamicList() },
                {"EventSteps".ToLower(), fti.ArtTiEcmAuditReports.Where(x=>x.BranchId != null).Select(x=>x.EventSteps).Distinct().Where(x=> x != null ).ToDynamicList() },
            };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(EcmAuditTrialController).ToLower()].SkipList;
            }

            var Data = data.CallData<ArtTiEcmAuditReport>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                },
                reportname = "EcmAuditTrial"
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            var DisplayNames  = ReportsConfig.CONFIG[nameof(EcmAuditTrialController).ToLower()].DisplayNames;

            var ColumnsToSkip  = ReportsConfig.CONFIG[nameof(EcmAuditTrialController).ToLower()].SkipList;

            var data = fti.ArtTiEcmAuditReports.CallData<ArtTiEcmAuditReport>(req).Data.ToList();
            ViewData["title"] = "ECM Audit Trial Report";
            ViewData["desc"] = "";
            var pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, this.ControllerContext, 5
                                                    , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(pdfBytes, "application/pdf");
        }



        public IActionResult Export([FromBody] ExportDto<decimal> para)
        {
            var data = fti.ArtTiEcmAuditReports.AsQueryable().CallData<ArtTiEcmAuditReport>(para.Req).Data;
            var res = data.AsEnumerable<ArtTiEcmAuditReport>().OrderBy(x=>x.EcmReference).GroupBy(x => new {  x.EcmReference,x.FtiReference, x.CaseStatCd, x.EventSteps, x.StepStatus });
            var after = res.Select(x =>
            {
                var ListOfMatchingEcm = ti.Masters.Where(c => c.MasterRef == x.Key.FtiReference)?.Join(ti.Notes, c => c.Key97, co => co.MasterKey, (c, co) => co.NoteText);
                return new ExportDto
                {
                    Record = x.FirstOrDefault(),
                    Note = ListOfMatchingEcm?.Select(e => e).ToList(),

                };

            });
            var stream = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.CurrentCulture))
            {


                sw.Write("");
                var props = typeof(ArtTiEcmAuditReport).GetProperties();

                foreach (var item in props)
                {
                    cw.WriteField(item.Name);
                }

                cw.WriteField("Note");


                cw.NextRecord();
                foreach (var elm in after)
                {
                    foreach (var prop in props)
                    {
                        cw.WriteField(prop.GetValue(elm.Record));
                    }

                    cw.NextRecord();
                    for (int i = 0; i < elm.Note.Count; i++)
                    {
                        foreach (var prop in props)
                        {
                            cw.WriteField("");
                        }

                        cw.WriteField(elm.Note[i]);

                        cw.NextRecord();
                    }
                    cw.NextRecord();
                }
            }

            return File(stream.ToArray(), "text/csv");
        }

        public class ExportDto
        {
            public ArtTiEcmAuditReport Record { get; set; }

            public List<string> Note { get; set; }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
