using ART_PACKAGE.Queries.GetGridDataRequest;
using ART_PACKAGE.Queries.IntializeGridRequest;
using Data.Data.SASAml;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ART_PACKAGE.Controllers
{
    public class GridController : Controller
    {

        private readonly IMediator _mediator;




        public GridController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }





        public async Task<IActionResult> GetData([FromBody] GridRequest request)
        {

            if (request.IsIntialize)
            {
                IntializeGridRequest intializeReq = new() { Controller = GetType().Name };
                GridIntializationConfiguration res = await _mediator.Send(intializeReq);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            else
            {
                GetGridDataRequest<SasAmlContext, ArtAmlAlertDetailView> getDataReq = new() { Request = request };
                GridResult<ArtAmlAlertDetailView> res = await _mediator.Send(getDataReq);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }



        }


        //public async Task<IActionResult> ExportPdf([FromBody] KendoRequest req)
        //{
        //    Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].DisplayNames;
        //    List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(AlertDetailsController).ToLower()].SkipList;
        //    List<ArtAmlAlertDetailView> data = dbfcfkc.ArtAmlAlertDetailViews.CallData(req).Data.ToList();
        //    ViewData["title"] = "Alert Details";
        //    ViewData["desc"] = "Presents the alerts details";
        //    byte[] pdfBytes = await _pdfSrv.ExportToPdf(data, ViewData, ControllerContext, 5
        //                                            , User.Identity.Name, ColumnsToSkip, DisplayNames);
        //    return File(pdfBytes, "application/pdf");
        //}


    }
}
