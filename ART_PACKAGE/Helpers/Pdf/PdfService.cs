
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
using System.Diagnostics;
using iText.Layout.Borders;
using iText.Kernel.Colors;
using ART_PACKAGE.Hubs;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
using ART_PACKAGE.Extentions.PDF;

namespace ART_PACKAGE.Helpers.Pdf
{
    public class PdfService : IPdfService
    {        
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ProcessesHandler _processesHandler;
        private readonly ILogger<PdfService> _logger;
        private readonly object _locker = new();
        public event Action<int, int> OnProgressChanged;
        public event Action<int, int> OnLastProgressChanged;
        private readonly IWebHostEnvironment _env;

        public PdfService(IServiceScopeFactory serviceScopeFactory, ProcessesHandler processesHandler,ILogger<PdfService> logger, IWebHostEnvironment env)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _processesHandler = processesHandler;
            _logger = logger;
            OnProgressChanged = (rd, fn) => _logger.LogInformation("file ({fn}) is being exported : {p}", fn, rd);
            OnLastProgressChanged = (rd, fn) => _logger.LogInformation("file is being exported : ({fn}) /  {p} ", fn, rd);
            _env = env;



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

        public async Task<bool> ITextPdf<TRepo, TContext, TModel>(ExportRequest req, int fileNumber, string folderPath, string fileName,string reportGUID, string tenantId, Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>
        {

            var filters = req.DataReq.Filter;

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                ITenantService tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
                tenantService.ManiualSetCurrentTenant(tenantId);


                //data prep
                TRepo Repo = scope.ServiceProvider.GetRequiredService<TRepo>();
                GridResult<TModel> dataRes = Repo.GetGridData(req.DataReq, baseCondition: baseCondition, defaultSort: defaultSort);
                IQueryable<TModel>? data = dataRes.data;
                int total = dataRes.total;

                // Ensure the folder path exists
                if (!Directory.Exists(folderPath))
                    _ = Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"{fileNumber}.{fileName}");
                bool isLandscape = true;

                try
                {
                    Stopwatch bdstopwatch = new Stopwatch();//
                    bdstopwatch.Start();
                    Stopwatch adstopwatch = new Stopwatch();
                    adstopwatch.Start();
                    using (var writer = new PdfWriter(filePath))
                    using (var pdf = new PdfDocument(writer))
                    {
                        var pageSize = isLandscape ? PageSize.A4.Rotate() : PageSize.A4;
                        var document = new Document(pdf, pageSize);
                        // Define document margins
                        float documentTopMargin = 32f;    // Points
                        float documentBottomMargin = 32f; // Points
                        float documentLeftMargin = 32f;   // Points
                        float documentRightMargin = 32f;  // Points
                        document.SetMargins(documentTopMargin, documentRightMargin, documentBottomMargin, documentLeftMargin);

                        // Get the properties of the TModel class for headers and data extraction
                        var modelType = typeof(TModel);
                        var properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        var columnHeaders = properties.Select(p => p.Name).ToArray();

                        // Partition settings
                        int partitionSize = 6; // Number of columns per page
                        int totalColumns = columnHeaders.Length;
                        int totalPagesForColumns = (int)Math.Ceiling((double)totalColumns / partitionSize);

                        int recordsPerPage = 20; // Set the number of records per page, this can be dynamic as needed
                        int rowCount = 0;
                        int index = 0;
                        int dataCount = data.Count();
                        bool newPageRequired = false;
                        int totalrec = totalPagesForColumns * dataCount;
                        int pdfRec = 0;
                        var pageHeight = pdf.GetDefaultPageSize().GetHeight();
                        float headerHeight = 20f; // Set a fixed height for the header row
                        float availableHeight = pageSize.GetHeight() - documentTopMargin - documentBottomMargin - headerHeight - 75 - (2 * recordsPerPage);

                        float rowHeight = availableHeight / recordsPerPage;
                        float calculatedFontSize = CalculateFontSize(rowHeight, lines: 2);

                        List<Table> tableList = new List<Table>();
                        var allElements = new List<IBlockElement>();
                        

                        // Define the paths to the images in wwwroot
                        string wwwrootPath = _env.WebRootPath;
                        string imagePath1 = Path.Combine(wwwrootPath, "imgs", "LOGO.png");
                        string imagePath2 = Path.Combine(wwwrootPath, "imgs", "bank_logo.png");

                        float logoMaxWidth = pdf.GetDefaultPageSize().GetWidth() * 0.1f;

                        document.AddLogos(imagePath1 ,imagePath2, logoMaxWidth);

                        document.AddTitle<TModel>();

                        document.AddDescription<TModel>();

                        document.AddFilters<TModel>(filters);

                        foreach (var item in data)
                        {
                            if (rowCount % recordsPerPage == 0)
                            {
                                foreach (var tabl in tableList)
                                {
                                    allElements.Add(tabl);
                                    //allElements.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                                    /*document.Add(tabl);
                                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Add a new page when a new partition starts
                                    */
                                }
                                tableList = new();
                                for (int i = 0; i < totalPagesForColumns - 1; i++)
                                {
                                    Table table = new Table(UnitValue.CreatePercentArray(partitionSize));
                                    table.SetWidth(UnitValue.CreatePercentValue(100));
                                    for (int h = (tableList.Count()) * partitionSize; h < ((tableList.Count() + 1) * partitionSize); h++)
                                    {
                                        table.AddHeaderCell(new Cell().Add(new Paragraph(columnHeaders[h]).SetFontSize(calculatedFontSize)).SetHeight(headerHeight).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBorder(Border.NO_BORDER)
                                        .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                        .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                                    }
                                    tableList.Add(table);

                                }
                                Table lastTable = new Table(UnitValue.CreatePercentArray(totalColumns % partitionSize == 0 ? partitionSize : totalColumns % partitionSize));
                                lastTable.SetWidth(UnitValue.CreatePercentValue(100));
                                for (int h = (tableList.Count()) * partitionSize; h < totalColumns; h++)
                                {
                                    lastTable.AddHeaderCell(new Cell()
                                        .Add(new Paragraph(columnHeaders[h]).SetFontSize(calculatedFontSize))
                                        .SetHeight(headerHeight)
                                        .SetTextAlignment(TextAlignment.CENTER)
                                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                                        .SetBorder(Border.NO_BORDER)
                                        .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                        .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                                }
                                tableList.Add(lastTable);
                            }
                            int columnNumber = 1;
                            int tableIndex = 0;
                            foreach (var property in properties)
                            {
                                var value = property.GetValue(item)?.ToString();

                                tableList[tableIndex].AddCell(new Cell().Add(new Paragraph(value ?? "").SetFontSize(calculatedFontSize)
                                        .SetTextAlignment(TextAlignment.CENTER)
                                        .SetMultipliedLeading(1f))
                                    //.SetHeight(rowHeight)
                                    .SetMinHeight(rowHeight) // Use SetMinHeight instead of SetHeight to allow wrapping.
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                    .SetFontSize(calculatedFontSize)
                                    .SetBackgroundColor((rowCount % recordsPerPage) % 2 == 0 ? new DeviceRgb(244, 244, 244) : ColorConstants.WHITE)
                                    .SetBorder(Border.NO_BORDER)
                                    .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                    .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));

                                if (columnNumber != 1 && columnNumber % partitionSize == 0)
                                {
                                    tableIndex++;
                                    pdfRec++;
                                    if (totalrec > 100 && (pdfRec % 100 == 0 || pdfRec == totalrec))
                                    {
                                        int recordsDone = pdfRec + 1;
                                        lock (_locker)
                                        {
                                            OnProgressChanged(recordsDone, fileNumber);
                                        }
                                    }
                                }
                                columnNumber++;
                            }


                            index++; // Increment the index for each item

                            // Log progress or handle process cancellation
                            /* if (dataCount > 100 && (index % 100 == 0 || index == dataCount))
                             {
                                 int recordsDone = index + 1;
                                 lock (_locker)
                                 {
                                     OnProgressChanged(recordsDone, fileNumber);
                                 }
                             }*/
                            rowCount++;
                            // If all records are added, break out of the loop
                            if (rowCount >= dataCount)
                                break;
                        }
                        bdstopwatch.Stop();

                        // Get the elapsed time as a TimeSpan
                        TimeSpan bdelapsedTime = bdstopwatch.Elapsed;

                        Console.WriteLine($@"until before close document takes {bdelapsedTime}");
                        int elementDone = 0;
                        int totalElements= allElements.Count();
                        foreach (var elem in allElements)
                        {
                            
                            document.Add(elem);
                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                            OnLastProgressChanged(elementDone, totalElements);
                            elementDone++;
                        }
                        // Close the document once done
                        document.Close();
                        adstopwatch.Stop();

                        // Get the elapsed time as a TimeSpan
                        TimeSpan adelapsedTime = adstopwatch.Elapsed;
                        Console.WriteLine($@"until after close document takes {adelapsedTime}");
                        OnLastProgressChanged(elementDone, totalElements);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }

                return true;
            }

               float CalculateFontSize(float cellHeight, int lines)
            {
                // Assuming a basic factor for line spacing and padding/margin inside the cell
                float lineSpacingFactor = 1.2f; // A factor to include space between lines
                float paddingFactor = 1.0f; // A factor for padding/margin within the cell

                // Calculate the approximate font size that fits the number of lines
                float calculatedFontSize = (cellHeight / (lines * lineSpacingFactor)) - paddingFactor;

                return Math.Max(calculatedFontSize, 6); // Set a minimum font size limit (e.g., 6pt)
            }
        }


    }
    class testttttt
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
    }
}
