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
    public class ListOfDeletedUsersController : Controller
    {
        private readonly ArtAuditContext context;
        private readonly IPdfService _pdfSrv;
        private readonly IDropDownService _dropSrv;
        public ListOfDeletedUsersController(ArtAuditContext context, IPdfService pdfSrv, IDropDownService dropSrv)
        {
            this.context = context;
            _pdfSrv = pdfSrv;
            _dropSrv = dropSrv;
        }

        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ListOfDeletedUser> data = context.ListOfDeletedUsers.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(ListOfDeletedUsersController).ToLower()].DisplayNames;

                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {nameof(ListOfDeletedUser.UserName)  .ToLower()  , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },
                    {nameof(ListOfDeletedUser.UserType)  .ToLower()  , _dropSrv.GetUserTypeDropDown().ToDynamicList() },
                    {nameof(ListOfDeletedUser.CreatedBy) .ToLower()  , _dropSrv.GetUserAudNameDropDown().ToDynamicList() },

                };
            }
            ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfDeletedUsersController).ToLower()].SkipList;

            KendoDataDesc<ListOfDeletedUser> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
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

        public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        {
            Microsoft.EntityFrameworkCore.DbSet<ListOfDeletedUser> data = context.ListOfDeletedUsers;
            byte[] bytes = await data.ExportToCSV<ListOfDeletedUser, GenericCsvClassMapper<ListOfDeletedUser, ListOfDeletedUsersController>>(para.Req);
            return File(bytes, "text/csv");
        }


        public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        {
            Dictionary<string, DisplayNameAndFormat> DisplayNames = ReportsConfig.CONFIG[nameof(ListOfDeletedUsersController).ToLower()].DisplayNames;
            List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(ListOfDeletedUsersController).ToLower()].SkipList;
            List<ListOfDeletedUser> data = context.ListOfDeletedUsers.CallData(req).Data.ToList();
            ViewData["title"] = "List Of Deleted Users";
            ViewData["desc"] = "This Report presents all deleted users with the related informaton as below";
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
