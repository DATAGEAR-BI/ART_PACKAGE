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
            GridResult<ArtAmlAlertDetailView> datGridResult = _gridConstructor.Repo.GetGridData(req);
            IQueryable<ArtAmlAlertDetailView> data = datGridResult.data;
            int count = datGridResult.total;
            System.Reflection.PropertyInfo[] props = typeof(ArtAmlAlertDetailView).GetProperties();
            byte[] bytes = Document.Create(container =>
            {
                int round = 1;
                int batch = 30;
                while (count > 0)
                {
                    List<ArtAmlAlertDetailView> pageData = data.Skip((round - 1) * batch).Take(batch).ToList();
                    _ = container.Page(page =>
                    {

                        page.Size(PageSizes.B1);
                        page.Margin(1, Unit.Centimetre);

                        page.Content().Border(1)
                            .Table(table =>
                            {
                                IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                                {
                                    return container

                                        .BorderColor(Colors.Grey.Medium)
                                        .Background(backgroundColor)
                                        .PaddingVertical(5)
                                        .PaddingHorizontal(10)
                                        .AlignCenter()
                                        .AlignMiddle();
                                }
                                // Define columns
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    foreach (System.Reflection.PropertyInfo prop in props)
                                    {
                                        columns.RelativeColumn();
                                    }
                                });

                                // Add header row
                                uint row = 1, column = 1;
                                table.Header(header =>
                                {
                                    IContainer CellStyle(IContainer container)
                                    {
                                        return DefaultCellStyle(container, Colors.White).ShowOnce();
                                    }
                                    _ = header.Cell().Row(row).Column(column++).Element(CellStyle).Text("#").Bold();
                                    foreach (System.Reflection.PropertyInfo prop in props)
                                    {
                                        _ = header.Cell().Row(row).Column(column++).Element(CellStyle).Text(prop.Name).Bold();
                                    }
                                });
                                column = 1;
                                row++;
                                // Assume `dataItems` is your data source
                                for (int i = 0; i < pageData.Count(); i++)
                                {
                                    _ = i % 2 == 0 ? table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.White)).Text(row - 1) : table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.White)).Element(c => DefaultCellStyle(c, Colors.Grey.Lighten1)).Text(row - 1);
                                    foreach (System.Reflection.PropertyInfo prop in props)
                                    {
                                        _ = i % 2 == 0
                                            ? table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.White)).Text(prop.GetValue(pageData[i]))
                                            : table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.Grey.Lighten1)).Text(prop.GetValue(pageData[i]));
                                    }
                                    column = 1;
                                    row++;
                                }

                            });
                    });
                    round++;
                    count -= batch;
                }

            }).GeneratePdf();
            //ViewData["title"] = "Alert Details";
            //ViewData["desc"] = "Presents the alerts details";
            //byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.data, ViewData, ControllerContext, 5
            //                                        , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(bytes, "application/pdf");
        }


    }
}
