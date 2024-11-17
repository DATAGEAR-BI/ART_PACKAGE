
using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using System.ComponentModel;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using ART_PACKAGE.Helpers.Handlers;
using Data.Services;
using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Path = System.IO.Path;


namespace ART_PACKAGE.Helpers.Pdf
{
    public class PdfService : IPdfService
    {        
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ProcessesHandler _processesHandler;
        private readonly ILogger<PdfService> _logger;
        private readonly object _locker = new();
        public event Action<int, int> OnProgressChanged;
        public PdfService(IServiceScopeFactory serviceScopeFactory, ProcessesHandler processesHandler,ILogger<PdfService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _processesHandler = processesHandler;
            _logger = logger;



        }
        public async Task<byte[]> ExportCustomReportToPdf(IEnumerable<dynamic> data, ViewDataDictionary ViewData, ActionContext ControllerContext, int ColumnsPerPage, string UserName, List<string> DataColumns)
        {
            ViewData["user"] = UserName;
            List<IEnumerable<Dictionary<string, object>>> dataColumnsParts = new();
            List<List<string>> props = PartitionProPertiesOf(DataColumns, ColumnsPerPage);

            foreach (List<string> group in props)
            {
                dataColumnsParts.Add(GetDataPArtitionedByColumnsForCustom(data, group));
            }
            //string footer = "--footer-center \"Printed on: " + DateTime.UtcNow.ToString("dd/MM/yyyyy hh:mm:ss") + "  Page: [page]/[toPage]" + "  Printed By : " + UserName + "\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
            _ = new ViewAsPdf("ReportPdfCover")
            {
                ViewData = ViewData,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
            ViewAsPdf pdf = new("GenericReportAsPdf", dataColumnsParts)
            {
                ViewData = ViewData,
                //CustomSwitches = footer,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Size.B0
            };


            return await pdf.BuildFile(ControllerContext);




            //var outputStream = new MemoryStream();
            //var document = new Document();
            //var writer = new PdfCopy(document, outputStream);
            //var coverReader = new PdfReader(await coverPdf.BuildFile(ControllerContext));
            //var bodyReader = new PdfReader(await pdf.BuildFile(ControllerContext));
            //document.Open();
            ////var tasks = new List<Task<PdfReader>>();
            ////pdfs.ToList().ForEach(x =>
            ////{
            ////    var t = Task.Run(async () =>
            ////    {
            ////        return new PdfReader(await x.BuildFile(ControllerContext));
            ////    });
            ////    tasks.Add(t);
            ////});
            ////var memoryStreams = await Task.WhenAll(tasks);

            ////var first = memoryStreams.Min(x=>x.NumberOfPages);
            //writer.AddPage(writer.GetImportedPage(coverReader, 1));
            //for (int i = 1; i <= bodyReader.NumberOfPages; i++)
            //{
            //    writer.AddPage(writer.GetImportedPage(bodyReader, i));

            //}

            //document.Close();

            //return outputStream.ToArray();
        }

        public async Task<byte[]> ExportToPdf<T>(IEnumerable<T> data
            , ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName
            , List<string> ColumnsToSkip = null
            , Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {
            ViewData["user"] = UserName;
            List<IEnumerable<Dictionary<string, object>>> dataColumnsParts = new();
            List<List<string>> props = PartitionProPertiesOf<T>(ColumnsToSkip, ColumnsPerPage);
            foreach (List<string> group in props)
            {
                dataColumnsParts.Add(GetDataPArtitionedByColumns(data, group, DisplayNamesAndFormat));
            }
            //string footer = "--footer-center \"Printed on: " + DateTime.UtcNow.ToString("dd/MM/yyyyy hh:mm:ss") + "  Page: [page]/[toPage]" + "  Printed By : " + UserName + "\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
            _ = new ViewAsPdf("ReportPdfCover")
            {
                ViewData = ViewData,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
            //IEnumerable<ViewAsPdf> pdfs = dataColumnsParts.Select(x => new ViewAsPdf("GenericReportAsPdf", x)
            //{
            //    ViewData = ViewData,
            //    CustomSwitches = footer,
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            //});


            ViewAsPdf pdf = new("GenericReportAsPdf", dataColumnsParts)
            {
                ViewData = ViewData,
                //CustomSwitches = footer,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };





            return await pdf.BuildFile(ControllerContext);

            //var outputStream = new MemoryStream();
            //var document = new Document();
            //var writer = new PdfCopy(document, outputStream);
            ////var coverReader = new PdfReader(await coverPdf.BuildFile(ControllerContext));
            ////var bodyReader = new PdfReader();
            //document.Open();
            ////var tasks = new List<Task<PdfReader>>();
            ////pdfs.ToList().ForEach(x =>
            ////{
            ////    var t = Task.Run(async () =>
            ////    {
            ////        return new PdfReader(await x.BuildFile(ControllerContext));
            ////    });
            ////    tasks.Add(t);
            ////});
            ////var memoryStreams = await Task.WhenAll(tasks);

            ////var first = memoryStreams.Min(x=>x.NumberOfPages);
            //writer.AddPage(writer.GetImportedPage(coverReader, 1));
            //for (int i = 1; i <= bodyReader.NumberOfPages; i++)
            //{
            //    writer.AddPage(writer.GetImportedPage(bodyReader, i));

            //}
            ////for (int i = 1; i <= first; i++)
            ////{
            ////    foreach (var reader in memoryStreams)
            ////    {
            ////        writer.AddPage(writer.GetImportedPage(reader, i));

            ////    }

            ////}

            //document.Close();

            //return outputStream.ToArray();

        }

        public async Task<byte[]> ExportToPdf<T>(IQueryable<T> data, KendoRequest obj
          , ViewDataDictionary ViewData
          , ActionContext ControllerContext
          , int ColumnsPerPage
          , string UserName
          , List<string> ColumnsToSkip = null
          , Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {

            KendoDataDesc<T> calldata = data.CallData(obj);
            data = calldata.Data;
            decimal total = calldata.Total;
            ReportConfig config = ReportConfigResolver2.GetConfigs<T>();
            ColumnsToSkip = ColumnsToSkip == null ? config != null ? config.SkipList : ColumnsToSkip : ColumnsToSkip;


            ViewData["user"] = UserName;
            List<IEnumerable<Dictionary<string, object>>> dataColumnsParts = new();
            List<List<string>> props = PartitionProPertiesOf<T>(ColumnsToSkip, ColumnsPerPage);
            foreach (List<string> group in props)
            {
                dataColumnsParts.Add(GetDataPArtitionedByColumns(data, group, DisplayNamesAndFormat));
            }
            //string footer = "--footer-center \"Printed on: " + DateTime.UtcNow.ToString("dd/MM/yyyyy hh:mm:ss") + "  Page: [page]/[toPage]" + "  Printed By : " + UserName + "\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
            _ = new ViewAsPdf("ReportPdfCover")
            {
                ViewData = ViewData,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };


            ViewAsPdf pdf = new("GenericReportAsPdf", dataColumnsParts)
            {
                ViewData = ViewData,
                //CustomSwitches = footer,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };





            return await pdf.BuildFile(ControllerContext);


        }


        public async Task<byte[]> ExportGroupedToPdf<T>(IEnumerable<T> data,
                ViewDataDictionary ViewData, ActionContext ControllerContext,
                string UserName, List<GridGroup>? GroupColumns, List<string> ColumnsToSkip = null,
                Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {
            IEnumerable<GroupedData> grouped = data.AsQueryable()
               .GroupBy($"new ({string.Join(",", GroupColumns.Select(x => x.field))})", "it")
               .Select("new(it.Key As Key ,it as Items)")
               .ToDynamicList().Select(x => (GroupedData)DynamicGroupToDict<T>(x, GroupColumns, ColumnsToSkip, DisplayNamesAndFormat));
            string footer = "--footer-center \"Printed on: " + DateTime.UtcNow.ToString("dd/MM/yyyyy hh:mm:ss") + "  Page: [page]/[toPage]" + "  Printed By : " + UserName + "\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
            ViewAsPdf pdf = new("GenericGroupedReportAsPdf", grouped)
            {
                CustomSwitches = footer,
                ViewData = ViewData,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
            return await pdf.BuildFile(ControllerContext);
        }


        private IEnumerable<Dictionary<string, object>> GetDataPArtitionedByColumnsForCustom(IEnumerable<dynamic> list,
         IEnumerable<string> propertyNames,
         Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {
            List<Dictionary<string, object>> res = new();
            list.ToList().ForEach(x =>
            {
                res.Add(dynamicToDict(x, propertyNames));
            });
            return res;
        }
        private GroupedData DynamicGroupToDict<T>(dynamic dobj, List<GridGroup>? GroupColumns, List<string> ColumnsToSkip = null,
          Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {
            //Dictionary<string, List<Dictionary<string, object>>> res = new Dictionary<string, List<Dictionary<string, object>>>();
            List<string> key = new();
            dynamic keyProps = TypeDescriptor.GetProperties(dobj.Key);
            Dictionary<string, object> keyValue = new();

            foreach (PropertyDescriptor prop in keyProps)
            {

                key.Add(prop.Name);
                string column = DisplayNamesAndFormat is not null
                           && DisplayNamesAndFormat.ContainsKey(prop.Name) ? DisplayNamesAndFormat[prop.Name].DisplayName : prop.Name;

                keyValue.Add(column, prop.GetValue(dobj.Key));


            }

            IEnumerable<GridAggregate>? aggs = GroupColumns.All(x => x.aggregates == null) ? null : GroupColumns.SelectMany(x => x.aggregates);

            System.Reflection.PropertyInfo[] props = typeof(T).GetProperties();
            List<Dictionary<string, object>> items = new();
            List<(string Column, bool HasAggreGate, string AggregateType)> Columns = new();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if (!ColumnsToSkip.Contains(prop.Name))
                {
                    string column = DisplayNamesAndFormat is not null
                      && DisplayNamesAndFormat.ContainsKey(prop.Name) ? DisplayNamesAndFormat[prop.Name].DisplayName : prop.Name;

                    GridAggregate? propAggs = aggs != null && aggs.Count() != 0 ? aggs.FirstOrDefault(x => x.field == prop.Name) : null;
                    bool hasAggs = propAggs != null;
                    string aggType = hasAggs ? propAggs.aggregate : "";
                    Columns.Add((column, hasAggs, aggType));
                }

            }
            foreach (T item in dobj.Items)
            {
                Dictionary<string, object> itemDict = new();

                foreach (System.Reflection.PropertyInfo prop in props)
                {
                    if (!ColumnsToSkip.Contains(prop.Name))
                    {
                        string column = DisplayNamesAndFormat is not null
                        && DisplayNamesAndFormat.ContainsKey(prop.Name) ? DisplayNamesAndFormat[prop.Name].DisplayName : prop.Name;
                        Type propType = prop.PropertyType;

                        Type? nullableType = Nullable.GetUnderlyingType(propType);

                        object val = nullableType != null && GridHelprs.IsNumericType(nullableType) ? 0m : GridHelprs.IsNumericType(propType) ? 0 : "-";
                        itemDict.Add(column, prop.GetValue(item) ?? val);
                    }

                }
                items.Add(itemDict);
            }

            return new GroupedData { Key = keyValue, Items = items, Columns = Columns };
        }
        private Dictionary<string, object> dynamicToDict(dynamic dobj, IEnumerable<string> propertyNames)
        {
            Dictionary<string, object> dictionary = new();
            //dynamic props = TypeDescriptor.GetProperties(dobj.Data);
            foreach (string propertyDescriptor in dobj.Data.Keys)
            {
                if (dictionary.Keys.Count == propertyNames.Count())
                {
                    break;
                }
                if (propertyNames.Contains(propertyDescriptor))
                {
                    object obj = dobj.Data[propertyDescriptor];
                    dictionary.Add(propertyDescriptor, obj);
                }

            }
            return dictionary;

        }

        private IEnumerable<Dictionary<string, object>> GetDataPArtitionedByColumns<T>(IEnumerable<T> list,
           IEnumerable<string> propertyNames,
           Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {

            return list.Select(x =>
            {

                Dictionary<string, object> elmDict = propertyNames.ToDictionary(p => DisplayNamesAndFormat is not null && DisplayNamesAndFormat.Keys.Contains(p) ? DisplayNamesAndFormat[p].DisplayName : p
                , p => x.GetType().GetProperty(p).GetValue(x, null) ?? "-");
                return elmDict;
            });
        }
        private List<List<string>> PartitionProPertiesOf(List<string> Columns, int ColumnsPerPage)
        {


            List<List<string>> props =

                                                      Columns.Select((value, index) => new { Value = value, Index = index })
                                                       .GroupBy(x => x.Index / ColumnsPerPage)
                                                       .Select(group => group.Select(x => x.Value).ToList())
                                                       .ToList();
            return props;
        }
        private List<List<string>> PartitionProPertiesOf<T>(List<string> ColumnsToSkip, int ColumnsPerPage)
        {

            ColumnsToSkip ??= new List<string>();
            List<List<string>> props = typeof(T).GetProperties()
                                                       .Where(x => !ColumnsToSkip.Contains(x.Name))
                                                       .Select((value, index) => new { Value = value.Name, Index = index })
                                                       .GroupBy(x => x.Index / ColumnsPerPage)
                                                       .Select(group => group.Select(x => x.Value).ToList())
                                                       .ToList();
            return props;
        }

        public async Task<byte[]> ExportToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData, ActionContext ControllerContext, int ColumnsPerPage, string UserName, string reportId, List<string> ColumnsToSkip = null, Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {
            ViewData["user"] = UserName;
            ViewData["reportId"] = reportId;
            List<IEnumerable<Dictionary<string, object>>> dataColumnsParts = new();
            List<List<string>> props = PartitionProPertiesOf<T>(ColumnsToSkip, ColumnsPerPage);
            foreach (List<string> group in props)
            {
                dataColumnsParts.Add(GetDataPArtitionedByColumns(data, group, DisplayNamesAndFormat));
            }
            //string footer = "--footer-center \"Printed on: " + DateTime.UtcNow.ToString("dd/MM/yyyyy hh:mm:ss") + "  Page: [page]/[toPage]" + "  Printed By : " + UserName + "\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
            _ = new ViewAsPdf("ReportPdfCover")
            {
                ViewData = ViewData,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
            //IEnumerable<ViewAsPdf> pdfs = dataColumnsParts.Select(x => new ViewAsPdf("GenericReportAsPdf", x)
            //{
            //    ViewData = ViewData,
            //    CustomSwitches = footer,
            //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            //});


            ViewAsPdf pdf = new("GenericReportAsPdf", dataColumnsParts)
            {
                ViewData = ViewData,
                //CustomSwitches = footer,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };





            return await pdf.BuildFile(ControllerContext);

            //var outputStream = new MemoryStream();
            //var document = new Document();
            //var writer = new PdfCopy(document, outputStream);
            ////var coverReader = new PdfReader(await coverPdf.BuildFile(ControllerContext));
            ////var bodyReader = new PdfReader();
            //document.Open();
            ////var tasks = new List<Task<PdfReader>>();
            ////pdfs.ToList().ForEach(x =>
            ////{
            ////    var t = Task.Run(async () =>
            ////    {
            ////        return new PdfReader(await x.BuildFile(ControllerContext));
            ////    });
            ////    tasks.Add(t);
            ////});
            ////var memoryStreams = await Task.WhenAll(tasks);

            ////var first = memoryStreams.Min(x=>x.NumberOfPages);
            //writer.AddPage(writer.GetImportedPage(coverReader, 1));
            //for (int i = 1; i <= bodyReader.NumberOfPages; i++)
            //{
            //    writer.AddPage(writer.GetImportedPage(bodyReader, i));

            //}
            ////for (int i = 1; i <= first; i++)
            ////{
            ////    foreach (var reader in memoryStreams)
            ////    {
            ////        writer.AddPage(writer.GetImportedPage(reader, i));

            ////    }

            ////}

            //document.Close();

            //return outputStream.ToArray();

        }

        public async Task<byte[]> ExportToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData, ActionContext ControllerContext, int ColumnsPerPage, string UserName, string reportId, List<string> inculdedColumns, List<string> ColumnsToSkip = null, Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null)
        {
            ViewData["user"] = UserName;
            ViewData["reportId"] = reportId;
            List<IEnumerable<Dictionary<string, object>>> dataColumnsParts = new();
            List<List<string>> props = PartitionProPertiesOf(inculdedColumns, ColumnsPerPage);
            foreach (List<string> group in props)
            {
                dataColumnsParts.Add(GetDataPArtitionedByColumns(data, group, DisplayNamesAndFormat));
            }
           _ = new ViewAsPdf("ReportPdfCover")
            {
                ViewData = ViewData,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
      

            ViewAsPdf pdf = new("GenericReportAsPdf", dataColumnsParts)
            {
                ViewData = ViewData,
                //CustomSwitches = footer,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };





            return await pdf.BuildFile(ControllerContext);

         

        }

        public async Task<bool> ITextPdf<TRepo, TContext, TModel>(ExportRequest req, int fileNumber, string folderPath, string fileName,string reportGUID,Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>
        {
            //data prep
            TRepo Repo = _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<TRepo>();
            GridResult<TModel> dataRes = Repo.GetGridData(req.DataReq, baseCondition: baseCondition, defaultSort: defaultSort);
            IQueryable<TModel>? data = dataRes.data;
            int total = dataRes.total;
            List<testttttt> s = new();
            for (int i = 0; i < 1000; i++)
            {
                s.Add(new() { id = i, name = "name" + i, phone = "0101088667" + i });
            }
            //file prep
            if (!Directory.Exists(folderPath))
                _ = Directory.CreateDirectory(folderPath);
            

            string filePath = Path.Combine(folderPath, $"{fileNumber}.{fileName}");
            
            //string pdfPath = "exported_data.pdf";
            bool isLandscape = true; 
            // Create a PDF document
            
                  

                try
            {
                // Create a PDF writer
                using (var writer = new PdfWriter(filePath))
                {
                using (var pdf = new PdfDocument(writer))
                {
                    var pageSize = isLandscape ? PageSize.A4.Rotate() : PageSize.A4;
                    var document = new Document(pdf, pageSize);

                        // Add an image on the first page
                        /*var imagePath = "path_to_image.jpg";
                        var image = new iText.Layout.Element.Image(ImageDataFactory.Create(imagePath))
                            .SetFixedPosition(50, pageSize.GetHeight() - 150, 200)
                            .SetAutoScale(true);
                        document.Add(image);#1#
                        */
                        // Get model properties for dynamic table headers
                        // var modelType = typeof(TModel);
                         var modelType = typeof(testttttt);

                        var properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var columnHeaders = properties.Select(p => p.Name).ToArray();

                    // Define table layout
                    var table = new Table(UnitValue.CreatePercentArray(columnHeaders.Length)); // Dynamic number of columns
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Add headers
                    foreach (var header in columnHeaders)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(header)));
                    }

                    // Adjust font size dynamically
                    float fontSize = 8f; // Start with a smaller font size
                    if (columnHeaders.Length > 20)
                    {
                        fontSize = 8f; // Adjust font size if necessary
                    }
                    else
                    {
                        fontSize = 12f; // Default font size
                    }

                    // Add footer with page numbers
                    pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new PDFPageEventHandler());

                    // Retrieve data from IQueryable and add it to the table
                    int rowCount = 0;
                    if (!data.Any())
                        OnProgressChanged(0, fileNumber);
                    int index = 0;
                    int dataCount = data.Count();
                    float progress = 0;
                    foreach (var item in s)
                    {
                        if (_processesHandler.isProcessCanceld(reportGUID))
                        {
                            if (!Directory.Exists(folderPath))
                                _ = Directory.CreateDirectory(folderPath);
                            try
                            {
                                _logger.LogInformation("Pdf Process Cancled");
                                document.Add(table);
                                // Close the document
                                document.Close();
                                return true;
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError("some thing wrong happend while saving the file : {err}", ex.Message);
                                return false;
                            }
                        }




                        if (rowCount % 50 == 0 && rowCount > 0) // Example for page break
                        {
                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                            table = new Table(UnitValue.CreatePercentArray(columnHeaders.Length)); // Recreate table to continue on new page
                            table.SetWidth(UnitValue.CreatePercentValue(100));

                            // Re-add headers
                            foreach (var header in columnHeaders)
                            {
                                table.AddHeaderCell(new Cell().Add(new Paragraph(header)));
                            }
                        }

                        // Add data cells
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(item)?.ToString();
                            table.AddCell(new Cell().Add(new Paragraph(value).SetFontSize(fontSize)));
                        }
                        rowCount++;

                        index++; // Increment the index for each item
                        if (dataCount > 100)
                        {
                            if (index % 100 == 0 || index == dataCount) // Also check progress at the last item
                            {
                                //progress = (float)(index / (float)total * 100);
                                int recordsDone = index + 1;
                                lock (_locker)
                                {
                                    OnProgressChanged(recordsDone, fileNumber);
                                }
                            }
                        }
                        else
                        {
                            int recordsDone = index + 1;
                            lock (_locker)
                            {
                                //OnProgressChanged(recordsDone, fileNumber);
                            }
                        }

                    }

                    document.Add(table);

                    // Close the document
                    document.Close();
                }
                }
            }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                return true;
        }


    }
    class testttttt
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}
