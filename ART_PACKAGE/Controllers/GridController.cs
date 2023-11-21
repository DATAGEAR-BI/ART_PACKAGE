using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Pdf;
using Data.Data.SASAml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ART_PACKAGE.Controllers
{
    public class GridController : Controller
    {

        private readonly IGridConstructor<SasAmlContext, ArtAmlAlertDetailView> _gridConstructor;
        private readonly IPdfService _pdfSrv;
        public GridController(IGridConstructor<SasAmlContext, ArtAmlAlertDetailView> gridConstructor, IPdfService pdfSrv)
        {

            _gridConstructor = gridConstructor;
            _pdfSrv = pdfSrv;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetData([FromBody] GridRequest request)
        {

            if (request.IsIntialize)
            {

                GridIntializationConfiguration res = _gridConstructor.IntializeGrid(GetType().Name, selectable: true, toolbar: new List<GridButton> { new GridButton { action = "test", text = "TEST" } });
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }
            else
            {

                GridResult<ArtAmlAlertDetailView> res = _gridConstructor.Repo.GetGridData(request);
                return new ContentResult
                {
                    ContentType = "application/json",
                    Content = JsonConvert.SerializeObject(res)
                };
            }



        }


        public async Task<IActionResult> ExportPdf([FromBody] GridRequest req)
        {
            //Dictionary<string, GridColumnConfiguration> DisplayNames = ReportsConfig.CONFIG[nameof(GridController).ToLower()].DisplayNames;
            //List<string> ColumnsToSkip = ReportsConfig.CONFIG[nameof(GridController).ToLower()].SkipList;
            IQueryable<ArtAmlAlertDetailView> data = _gridConstructor.Repo.GetGridData(req).data;
            System.Reflection.PropertyInfo[] props = typeof(ArtAmlAlertDetailView).GetProperties();
            byte[] bytes = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.B1);
                    page.Margin(1, Unit.Centimetre);

                    page.Content()
                        .Table(table =>
                        {
                            // Define columns
                            table.ColumnsDefinition(columns =>
                            {

                                foreach (System.Reflection.PropertyInfo prop in props)
                                {
                                    columns.RelativeColumn();
                                }
                            });

                            // Add header row
                            uint row = 1, column = 1;
                            table.Header(header =>
                            {
                                foreach (System.Reflection.PropertyInfo prop in props)
                                {
                                    header.Cell().Row(row).Column(column++).Text(prop.Name).DirectionAuto().Bold();
                                }
                            });
                            column = 1;
                            row++;
                            // Assume `dataItems` is your data source
                            foreach (ArtAmlAlertDetailView item in data)
                            {
                                foreach (System.Reflection.PropertyInfo prop in props)
                                {
                                    table.Cell().Row(row).Column(column++).Text(prop.GetValue(item));
                                }
                                column = 1;
                                row++;
                            }

                        });
                });
            }).GeneratePdf();
            //ViewData["title"] = "Alert Details";
            //ViewData["desc"] = "Presents the alerts details";
            //byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.data, ViewData, ControllerContext, 5
            //                                        , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(bytes, "application/pdf");
        }


    }
}
