using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.ECM
{
    public class AlertedEntitiesController : BaseReportController<IGridConstructor<IBaseRepo<EcmContext, ArtAlertedEntity>, EcmContext, ArtAlertedEntity>, IBaseRepo<EcmContext, ArtAlertedEntity>, EcmContext, ArtAlertedEntity>
    {
        public AlertedEntitiesController(IGridConstructor<IBaseRepo<EcmContext, ArtAlertedEntity>, EcmContext, ArtAlertedEntity> gridConstructor) : base(gridConstructor)
        {
        }

        //public IActionResult GetData([FromBody] KendoRequest request)
        //{
        //    IQueryable<ArtAlertedEntity> data = context.ArtAlertedEntities.AsQueryable();

        //    Dictionary<string, GridColumnConfiguration> DisplayNames = null;
        //    Dictionary<string, List<dynamic>> DropDownColumn = null;
        //    List<string> ColumnsToSkip = null;

        //    if (request.IsIntialize)
        //    {
        //        DisplayNames = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].DisplayNames;

        //        DropDownColumn = new Dictionary<string, List<dynamic>>
        //        {

        //        };
        //        ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].SkipList;
        //    }

        //    KendoDataDesc<ArtAlertedEntity> Data = data.CallData(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);

        //    var result = new
        //    {
        //        data = Data.Data,
        //        columns = Data.Columns,
        //        total = Data.Total,
        //        containsActions = false,
        //    };

        //    return new ContentResult
        //    {
        //        ContentType = "application/json",
        //        Content = JsonConvert.SerializeObject(result)
        //    };
        //}

        //public async Task<IActionResult> Export([FromBody] ExportDto<decimal> para)
        //{
        //    Microsoft.EntityFrameworkCore.DbSet<ArtAlertedEntity> data = context.ArtAlertedEntities;
        //    await _csvSrv.ExportAllCsv<ArtAlertedEntity, AlertedEntitiesController, decimal>(data, User.Identity.Name, para);
        //    return new EmptyResult();
        //}


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertedEntitiesController).ToLower()].SkipList;
        //    List<ArtAlertedEntity> data = context.ArtAlertedEntities.CallData(req).Data.ToList();
        //    ViewData["title"] = "Alerted Entities Report";
        //    ViewData["desc"] = "This report presents all sanction cases with the related information on case level as below";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.AsQueryable(), para.req, ViewData,ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}

        public override IActionResult Index()
        {
            return View();
        }
    }
}
