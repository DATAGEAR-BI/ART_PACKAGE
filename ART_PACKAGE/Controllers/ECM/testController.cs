using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Data.Data.ECM;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML
{
    //////[Authorize(Roles = "AlertDetails")]
    public class TestController : BaseReportController<IGridConstructor<IBaseRepo<TestController, ArtAlertedEntity>, EcmContext, ArtAlertedEntity>, IBaseRepo<EcmContext, ArtAlertedEntity>, EcmContext, ArtAlertedEntity>
    {
        public TestController(IGridConstructor<IBaseRepo<EcmContext, ArtAlertedEntity>, EcmContext, ArtAlertedEntity> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }



        //public async Task<IActionResult> Export([FromBody] ExportDto<long?> req)
        //{
        //    IQueryable<ArtAlertedEntity> data = dbfcfkc.ArtAlertedEntitys.AsQueryable();
        //    IEnumerable<Task> tasks;
        //    int i = 1;
        //    if (req.All)
        //    {
        //        tasks = data.ExportToCSVE<ArtAlertedEntity, GenericCsvClassMapper<ArtAlertedEntity, testController>>(req.Req);


        //    }
        //    else
        //    {


        //        // Modify the LINQ expression to use Any and Contains
        //        tasks = data
        //            .Where(x => req.SelectedIdz.Contains(x.AlertId))
        //            .ExportToCSVE<ArtAlertedEntity, GenericCsvClassMapper<ArtAlertedEntity, testController>>(req.Req);
        //    }

        //    foreach (Task<byte[]> item in tasks.Cast<Task<byte[]>>())
        //    {
        //        try
        //        {
        //            byte[] bytes = await item;
        //            string FileName = nameof(testController).Replace("Controller", "") + "_" + i + "_" + DateTime.UtcNow.ToString("dd-MM-yyyy:h-mm") + ".csv";
        //            await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
        //                        .SendAsync("csvRecevied", bytes, FileName);
        //            i++;
        //        }
        //        catch (Exception ex)
        //        {
        //            await _exportHub.Clients.Clients(connections.GetConnections(User.Identity.Name))
        //                        .SendAsync("csvErrorRecevied", i);

        //        }

        //    }
        //    return new EmptyResult();
        //}
        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(GridController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GridController).ToLower()].SkipList;
        //    List<ArtAlertedEntity> data = dbfcfkc.ArtAlertedEntitys.CallData(req).Data.ToList();
        //    ViewData["title"] = "Alert Details";
        //    ViewData["desc"] = "Presents the alerts details";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}


        public override IActionResult Index()
        {
            return View();
        }


    }
}
