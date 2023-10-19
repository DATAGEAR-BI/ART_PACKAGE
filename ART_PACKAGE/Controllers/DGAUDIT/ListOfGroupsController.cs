using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.Audit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Controllers.DGAUDIT
{

    public class ListOfGroupsController : Controller
    {
        private readonly ArtAuditContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService dropDownService;
        private readonly ICsvExport _csvSrv;

        public ListOfGroupsController(ArtAuditContext context, IPdfService pdfSrv, IDropDownService dropDownService, ICsvExport csvSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            this.dropDownService = dropDownService;
            _csvSrv = csvSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfGroup> data = context.ListOfGroups.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    { "GroupName".ToLower(),dropDownService.GetGroupNameDropDown().ToDynamicList() },
                    { "GroupType".ToLower(),dropDownService.GetGroupTypeDropDown().ToDynamicList() },
                    { "CreatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },
                    { "LastUpdatedBy".ToLower(),dropDownService.GetUserAudNameDropDown().ToDynamicList() },

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].SkipList;

            KendoDataDesc<ListOfGroup> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        //public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<ListOfGroup> data = context.ListOfGroups;
        //    await _csvSrv.ExportAllCsv<ListOfGroup, ListOfGroupsController, decimal>(data, User.Identity.Name, para);
        //    return new EmptyResult();
        //}


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfGroupsController).ToLower()].SkipList;
            List<ListOfGroup> data = context.ListOfGroups.CallData(req).Data.ToList();
            ViewData["title"] = "List Of Groups Report";
            ViewData["desc"] = "This Report presents all groups with the related information as below";
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
