using ART_PACKAGE.Helpers.Grid;
using ART_PACKAGE.Helpers.Pdf;
using CsvHelper;
using CsvHelper.Configuration;
using Data.Data.SASAml;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
using System.Text;

namespace ART_PACKAGE.Controllers
{
    public class GridController : Controller
    {

        private readonly IGridConstructor<SasAmlContext, ArtAmlCustomersDetailsView> _gridConstructor;
        private readonly IPdfService _pdfSrv;

        public GridController(IGridConstructor<SasAmlContext, ArtAmlCustomersDetailsView> gridConstructor, IPdfService pdfSrv)
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

                GridResult<ArtAmlCustomersDetailsView> res = _gridConstructor.Repo.GetGridData(request, new SortOption { field = nameof(ArtAmlCustomersDetailsView.CustomerNumber), dir = "asc" });
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
            GridResult<ArtAmlCustomersDetailsView> datGridResult = _gridConstructor.Repo.GetGridData(req);
            IQueryable<ArtAmlCustomersDetailsView> data = datGridResult.data;
            int count = datGridResult.total;
            System.Reflection.PropertyInfo[] props = typeof(ArtAmlAlertDetailView).GetProperties();
            byte[] bytes = Document.Create(container =>
            {
                static IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                {
                    return container

                        .BorderColor(Colors.Grey.Medium)
                        .Background(backgroundColor)
                        .PaddingVertical(5)
                        .PaddingHorizontal(10)
                        .AlignCenter()
                        .AlignMiddle();
                }

                static IContainer CellStyle(IContainer container)
                {
                    return DefaultCellStyle(container, Colors.White).ShowOnce();
                }
                _ = container.Page(page =>
                      {

                          page.Size(PageSizes.B1);
                          page.Margin(1, Unit.Centimetre);

                          page.Content().Border(1)
                          .Table(table =>
                          {


                              uint row = 1, column = 1;
                              // Define columns
                              table.ColumnsDefinition(columns =>
                              {

                                  foreach (System.Reflection.PropertyInfo prop in props)
                                  {
                                      columns.RelativeColumn();
                                  }
                              });
                              table.Header(header =>
                              {

                                  foreach (System.Reflection.PropertyInfo prop in props)
                                  {
                                      _ = header.Cell().Row(row).Column(column++).Element(e => DefaultCellStyle(e, Colors.Cyan.Accent1)).Text(prop.Name).Bold();
                                  }
                              });
                              column = 1;
                              row++;
                              // Assume `dataItems` is your data source
                              //var dataWithIndex = data.Select((x, i) => new { x, i });

                              foreach (ArtAmlCustomersDetailsView di in data)
                              {
                                  foreach (System.Reflection.PropertyInfo prop in props)
                                  {
                                      _ = row % 2 == 0
                                          ? table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.White)).Text(prop.GetValue(di))
                                          : table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.Grey.Lighten1)).Text(prop.GetValue(di));
                                  }
                                  column = 1;

                                  row++;



                              }

                          });
                          page.Footer().AlignCenter().Text(x =>
                            {
                                _ = x.Span("Page: ");
                                _ = x.CurrentPageNumber();
                            });
                      });







                //int round = 1;
                //int batch = 30;
                //while (count > 0)
                //{
                //    IQueryable<ArtAmlAlertDetailView> pageData = data.Skip((round - 1) * batch).Take(batch);
                //    _ = container.Page(page =>
                //    {

                //        page.Size(PageSizes.B1);
                //        page.Margin(1, Unit.Centimetre);

                //        page.Content().Border(1)
                //            .Table(table =>
                //            {
                //                IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                //                {
                //                    return container

                //                        .BorderColor(Colors.Grey.Medium)
                //                        .Background(backgroundColor)
                //                        .PaddingVertical(5)
                //                        .PaddingHorizontal(10)
                //                        .AlignCenter()
                //                        .AlignMiddle();
                //                }
                //                // Define columns
                //                table.ColumnsDefinition(columns =>
                //                {

                //                    foreach (System.Reflection.PropertyInfo prop in props)
                //                    {
                //                        columns.RelativeColumn();
                //                    }
                //                });

                //                // Add header row
                //                uint row = 1, column = 1;
                //                table.Header(header =>
                //                {

                //                    IContainer CellStyle(IContainer container)
                //                    {
                //                        return DefaultCellStyle(container, Colors.White).ShowOnce();
                //                    }
                //                    foreach (System.Reflection.PropertyInfo prop in props)
                //                    {
                //                        _ = header.Cell().Row(row).Column(column++).Element(CellStyle).Text(prop.Name).Bold();
                //                    }
                //                });

                //                column = 1;
                //                row++;
                //                // Assume `dataItems` is your data source
                //                foreach (ArtAmlAlertDetailView? item in pageData)
                //                {
                //                    foreach (System.Reflection.PropertyInfo prop in props)
                //                    {
                //                        _ = row % 2 == 0
                //                            ? table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.White)).Text(prop.GetValue(item))
                //                            : table.Cell().Row(row).Column(column++).Element(c => DefaultCellStyle(c, Colors.Grey.Lighten1)).Text(prop.GetValue(item));
                //                    }
                //                    column = 1;
                //                    row++;
                //                }

                //            });

                //        page.Footer().AlignCenter().Text(x =>
                //        {
                //            x.Span("Page: ");
                //            x.CurrentPageNumber();
                //        });
                //    });
                //    round++;
                //    count -= batch;
                //}

            }).GeneratePdf();
            //ViewData["title"] = "Alert Details";
            //ViewData["desc"] = "Presents the alerts details";
            //byte[] pdfBytes = await _pdfSrv.ExportToPdf(data.data, ViewData, ControllerContext, 5
            //                                        , User.Identity.Name, ColumnsToSkip, DisplayNames);
            return File(bytes, "application/pdf");
        }


        public async Task<IActionResult> TestExportWithHangfire([FromBody] GridRequest req)
        {
            _ = BackgroundJob.Enqueue(() => ExportCsv(req));
            return Ok();
        }


        private void ExportCsv(GridRequest req)
        {
            var data = _gridConstructor.Repo.GetGridData(req);

            CsvConfiguration config = new(CultureInfo.CurrentCulture)
            {
                IgnoreReferences = true,
            };
            using MemoryStream stream = new();
            using (StreamWriter sw = new(stream, new UTF8Encoding(true)))
            using (CsvWriter cw = new(sw, config))
            {

                cw.WriteHeader<ArtAmlCustomersDetailsView>();
                cw.NextRecord();
                cw.WriteRecords(data.data);
            }

            var bytes = stream.ToArray();
        }

    }
}
