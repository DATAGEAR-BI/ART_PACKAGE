using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.FTI;
using Data.TIZONE2;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Linq.Dynamic.Core;
using Data.Services.Grid;

namespace ART_PACKAGE.Controllers.FTI
{
    ////////[Authorize(Policy = "Licensed" , Roles ="EcmAuditTrial")]


    public class EcmAuditTrialController : Controller
    {

        private readonly FTIContext fti;
        private readonly TIZONE2Context ti;
        //private readonly ACTIVITI_FTI_DB.ModelContext ACTIVITI_FTI;
        //private readonly DGCMGMT_FTI_DB.ModelContext DGCMGMT_FTI;
        //private readonly DGECM_METADATA_FTI_DB.ModelContext DGECM_METADATA;
        private readonly IPdfService _pdfSrv;



        public EcmAuditTrialController(IPdfService pdfSrv, FTIContext fti, TIZONE2Context ti)
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
            return req is null ? NotFound("there is no notes") : Ok(req);
        }
        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtTiEcmAuditReport> data = fti.ArtTiEcmAuditReports.AsQueryable();
            //IQueryable<CaseLive> filter = DGCMGMT_FTI.CaseLives.AsQueryable();
            Dictionary<string, GridColumnConfiguration> DisplayNames = null;
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

            KendoDataDesc<ArtTiEcmAuditReport> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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
            Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(EcmAuditTrialController).ToLower()].DisplayNames;

            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(EcmAuditTrialController).ToLower()].SkipList;

            List<ArtTiEcmAuditReport> data = fti.ArtTiEcmAuditReports.CallData(req).Data.ToList();
            ViewData["title"] = "ECM Audit Trial Report";
            ViewData["desc"] = "";
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

