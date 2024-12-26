
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
//using iText.Kernel.Events;
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
using System.Linq;
using static iTextSharp.text.pdf.AcroFields;
using iText.Kernel.Font;
using iTextSharp.text.pdf;
using ART_PACKAGE.Extentions.StringExtentions;
using ART_PACKAGE.Areas.Identity.Data;
using System.Data.Odbc;
using Data.Services.CustomReport;
using ART_PACKAGE.Helpers.CSVMAppers;
using iText.Html2pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using PdfReader = iText.Kernel.Pdf.PdfReader;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using iText.Layout.Font;
using iText.Layout.Splitting;


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
        private readonly ICompositeViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IWebHostEnvironment _env;
  


        public PdfService(IServiceScopeFactory serviceScopeFactory, ProcessesHandler processesHandler, ILogger<PdfService> logger, ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider, IWebHostEnvironment env)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _processesHandler = processesHandler;
            _logger = logger;
            OnProgressChanged = (rd, fn) => _logger.LogInformation("file ({fn}) is being exported : {p}", fn, rd);
            OnLastProgressChanged = (rd, fn) => _logger.LogInformation("file is being exported : ({fn}) /  {p} ", fn, rd);
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
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
        // Method to render Razor view to HTML string
        public async Task<string> RenderViewToStringAsync(ActionContext ControllerContext,string viewName, object model, ViewDataDictionary controllerViewData = null)
        {
            // Simulated ActionContext
            HttpContext httpContext = ControllerContext.HttpContext;
            var actionContext = new ActionContext(httpContext, new Microsoft.AspNetCore.Routing.RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

            // Find the view
            var viewEngineResult = _viewEngine.FindView(actionContext, viewName, isMainPage: false);
            if (!viewEngineResult.Success)
            {
                throw new FileNotFoundException($"View '{viewName}' not found.");
            }

            using var sw = new StringWriter();
            var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            // Merge ViewData from the controller
            if (controllerViewData != null)
            {
                foreach (var key in controllerViewData.Keys)
                {
                    viewData[key] = controllerViewData[key];
                }
            }

            var tempData = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
            var viewContext = new ViewContext(
                actionContext,
                viewEngineResult.View,
                viewData,
                tempData,
                sw,
                new HtmlHelperOptions()
            );

            await viewEngineResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }

       /* public void ConvertHtmlToPdf(string htmlContent)
        {
            var converter = new HtmlToPdf();
            var doc = converter.RenderHtmlAsPdf(htmlContent);
            doc.SaveAs("mmmmmmmmmmmmmmmmmmmmmmmmm");
            
            
        }*/
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
            
            var s = await RenderViewToStringAsync(ControllerContext, "GenericReportAsPdf", dataColumnsParts,ViewData);
            /*string filePath = Path.Combine(_env.WebRootPath,"htpdf.pdf");
            using (var writer = new iText.Kernel.Pdf.PdfWriter(filePath))
            using (var pd = new iText.Kernel.Pdf.PdfDocument(writer))
            {
                var pageSize = PageSize.A4.Rotate();
                var document = new Document(pd, pageSize);

                var htmlElements = HtmlConverter.ConvertToElements(s);

                foreach (IElement element in htmlElements)
                {
                    var div = (Div)element;
                    // Resize the content to fit the cell
                    div.SetWidth(UnitValue.CreatePercentValue(100)); // Fit to cell width
                    div.SetFontSize(8); // Reduce font size to fit

                    document.Add(div);
                    // htmlCell.Add((IBlockElement)element);
                }
                document.Close();
            }*/


            using (var memoryStream = new MemoryStream()) // Create a MemoryStream
            {
                // Initialize PDF writer to write to the MemoryStream
                using (var writer = new PdfWriter(memoryStream))
                using (var pdfDocument = new PdfDocument(writer))
                {
                    var pageSize = PageSize.A4.Rotate();
                    var document = new Document(pdfDocument, pageSize);

                    // Convert HTML to iText elements
                    var htmlElements = HtmlConverter.ConvertToElements(s);

                    foreach (IElement element in htmlElements)
                    {
                        var div = (Div)element;
                        // Resize the content to fit the page
                        div.SetWidth(UnitValue.CreatePercentValue(100));
                        div.SetFontSize(8); // Adjust font size if needed

                        document.Add(div);
                    }

                    document.Close(); // Finalize the document
                }

                return memoryStream.ToArray(); // Return PDF as byte array

            }
            //ConvertHtmlToPdf(s);


            /*ViewAsPdf pdf = new("GenericReportAsPdf", dataColumnsParts)
            {
                ViewData = ViewData,
                //CustomSwitches = footer,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };



          

            return await pdf.BuildFile(ControllerContext);*/

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
       
        public async Task<bool> ITextPdf<TRepo, TContext, TModel>(ExportPDFRequest req, int fileNumber, string folderPath, string fileName, string reportGUID, string tenantId, Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>
        {

            var filters = req.DataReq.Filter;

            using (var scope = _serviceScopeFactory.CreateScope())
            {




                //data prep
                TRepo Repo = scope.ServiceProvider.GetRequiredService<TRepo>();
                GridResult<TModel> dataRes = Repo.GetGridData(req.DataReq, baseCondition: baseCondition, defaultSort: defaultSort);
                IQueryable<TModel>? data = dataRes.data;
                int total = dataRes.total;
                var reportConfigs = ReportConfigResolver2.GetConfigs<TModel>();
                var displayNames = reportConfigs?.DisplayNames;
                // Ensure the folder path exists
                if (!Directory.Exists(folderPath))
                    _ = Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"{fileNumber}.{fileName}");
                bool isLandscape = req.PdfOptions.IsLandScape;

                try
                {
                    Stopwatch bdstopwatch = new Stopwatch();//
                    bdstopwatch.Start();
                    Stopwatch adstopwatch = new Stopwatch();
                    adstopwatch.Start();
                    using (var writer = new iText.Kernel.Pdf.PdfWriter(filePath))
                    using (var pdf = new iText.Kernel.Pdf.PdfDocument(writer))
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
                        var properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(S => req.IncludedColumns.Contains(S.Name)).OrderBy(x => x.Name == "ActionDetail").ThenBy(p => req.IncludedColumns.IndexOf(p.Name)).Select(s=>new { property=s,format= displayNames is null?"": displayNames.ContainsKey(s.Name) ? displayNames[s.Name].Format:"" });
                        string[] columnHeaders = displayNames is null ? req.IncludedColumns.Select(s => s.MapToHeaderName()).ToArray() : req.IncludedColumns.Select(s => (displayNames.ContainsKey(s)) ? !string.IsNullOrEmpty(displayNames[s].DisplayName) ? displayNames[s].DisplayName : s.MapToHeaderName() : s.MapToHeaderName()).ToArray();//properties.Select(p => p.Name).ToArray();

                        // Partition settings
                        int partitionSize = reportConfigs.MapperType!=null&&(reportConfigs.MapperType.Name==typeof(ArtCFTConfigMapper).Name|| reportConfigs.MapperType.Name == typeof(ArtCRPConfigMapper).Name)&&req.IncludedColumns.Count()>2 ? columnHeaders.Count()-1: columnHeaders.Count();//req.PdfOptions.NumberOfColumnsInPage; // Number of columns per page
                        int totalColumns = columnHeaders.Count();
                        int totalPagesForColumns = (int)Math.Ceiling((double)totalColumns / partitionSize);

                        int recordsPerPage = req.PdfOptions.NumberOfRowsInPage; // Set the number of records per page, this can be dynamic as needed
                        int rowCount = 0;
                        int index = 0;
                        int dataCount = data.Count();
                        bool newPageRequired = false;
                        int totalrec = totalPagesForColumns * dataCount;
                        int pdfRec = 0;
                        var pageHeight = pdf.GetDefaultPageSize().GetHeight();
                        float headerHeight = 20f; // Set a fixed height for the header row
                        float availableHeight = pageSize.GetHeight() - documentTopMargin - documentBottomMargin - headerHeight - 75 - (2 * recordsPerPage);
                        float availableWidth = pageSize.GetWidth() - documentLeftMargin - documentRightMargin - 75 - (2 * recordsPerPage);

                        float rowHeight = availableHeight / recordsPerPage;
                        float rowWidth = availableWidth / partitionSize;
                        float calculatedFontSize = CalculateFontSize(rowHeight, rowWidth);//CalculateFontSize(rowHeight, lines: 2);

                        List<Table> tableList = new List<Table>();
                        var allElements = new List<IBlockElement>();

                        int elementDone = 0;

                        // Define the paths to the images in wwwroot
                        string wwwrootPath = _env.WebRootPath;

                        string fontPath = Path.Combine(wwwrootPath, "fonts", "Tahoma.ttf");
                        iText.Kernel.Font.PdfFont defaultFont = PdfFontFactory.CreateFont(fontPath, "Identity-H");
                        // Set the default font for the entire document
                        document.SetFont(defaultFont);

                        // Use pdfCalligraph's TextShaper to handle bidirectional text
                        FontSet fontSet = new FontSet();
                        fontSet.AddFont(fontPath);

                        document.SetFontProvider(new FontProvider(fontSet));



                        var arabicLanguageProcessor = new ArabicLigaturizer(0, 1);

                        string imagePath1 = Path.Combine(wwwrootPath, "imgs", "LOGO.png");
                        string imagePath2 = Path.Combine(wwwrootPath, "imgs", "bank_logo.png");

                        string watermarkPath = Path.Combine(wwwrootPath, "imgs", "watermark.png");

                        float logoMaxWidth = pdf.GetDefaultPageSize().GetWidth() * 0.1f;

                        document.AddLogos(imagePath1, imagePath2, logoMaxWidth);

                        document.AddTitle<TModel>();

                        document.AddDescription<TModel>();
                        document.AddQueryBuilderFilters(req.DataReq.QueryBuilderFilters);
                       
                        document.AddFilters(filters,displayNames);

                        document.AddWatermark(watermarkPath);
                        document.SetBaseDirection(BaseDirection.RIGHT_TO_LEFT);
                        document.SetTextAlignment(TextAlignment.CENTER);


                        if (!req.PdfOptions.UsingPartitionApproach)
                        {

                            float[] columnWidths = new float[columnHeaders.Count()];
                            for (int i = 0; i < columnHeaders.Count(); i++)
                            {
                                columnWidths[i] = 1; // Equal distribution
                            }
                            Table table = new Table(UnitValue.CreatePercentArray(columnHeaders.Count()));
                            table.SetWidth(UnitValue.CreatePercentValue(100));

                            table.SetMaxWidth(UnitValue.CreatePercentValue(100));
                            foreach (var header in columnHeaders)
                            {
                                table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFontSize(calculatedFontSize).SetTextAlignment(TextAlignment.CENTER)).SetHeight(headerHeight).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBorder(Border.NO_BORDER)
                                .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                            }
                            foreach (var row in data)
                            {
                                if (!_processesHandler.isProcessCanceld(reportGUID))
                                {
                                    foreach (var prop in properties)
                                    {
                                        var value = prop.property.GetValue(row)?.ToString();

                                        table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(value ?? "")).SetFontSize(calculatedFontSize)
                                                .SetTextAlignment(TextAlignment.CENTER).SetFont(defaultFont)
                                                .SetMultipliedLeading(1f))
                                            //.SetHeight(rowHeight)
                                            .SetMinHeight(rowHeight) // Use SetMinHeight instead of SetHeight to allow wrapping.
                                            .SetMaxWidth(rowWidth)
                                            .SetTextAlignment(TextAlignment.CENTER)
                                            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                            .SetFontSize(calculatedFontSize)
                                            .SetBackgroundColor((rowCount % recordsPerPage) % 2 == 0 ? new DeviceRgb(244, 244, 244) : ColorConstants.WHITE)
                                            .SetBorder(Border.NO_BORDER)
                                            .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                            .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                                    }
                                    pdfRec++;
                                    if (totalrec > 100 && (pdfRec % 100 == 0 || pdfRec == totalrec))
                                    {
                                        int recordsDone = pdfRec + 1;
                                        lock (_locker)
                                        {
                                            OnProgressChanged(recordsDone, fileNumber);
                                        }
                                    }
                                    /*else
                                    {
                                        int recordsDone = pdfRec + 1;
                                        lock (_locker)
                                        {
                                            OnProgressChanged(recordsDone, fileNumber);
                                        }
                                    }*/
                                }
                            }
                            lock (_locker)
                            {
                                OnProgressChanged(pdfRec + 1, fileNumber);
                                OnLastProgressChanged(0, fileNumber);

                            }
                            document.Add(table);
                            /*lock (_locker)
                            {
                                OnLastProgressChanged(1, 1);

                            }*/
                        }
                        else
                        {

                            foreach (var item in data)
                            {
                                if (!_processesHandler.isProcessCanceld(reportGUID))
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
                                        float[] widths = Enumerable.Repeat(1f, partitionSize).ToArray();
                                        float[] lastPageWidths = Enumerable.Repeat(1f, totalColumns % partitionSize == 0 ? partitionSize : totalColumns % partitionSize).ToArray();

                                        for (int i = 0; i < totalPagesForColumns - 1; i++)
                                        {

                                            //Table table = new Table(UnitValue.CreatePercentArray(partitionSize));
                                            Table table = new Table(UnitValue.CreatePercentArray(widths));
                                            table.SetWidth(UnitValue.CreatePercentValue(100));
                                            table.SetBaseDirection(BaseDirection.RIGHT_TO_LEFT);
                                            table.SetTextAlignment(TextAlignment.CENTER);
                                             
                                            //table.SetMaxWidth(UnitValue.CreatePercentValue(100));
                                            for (int h = (tableList.Count()) * partitionSize; h < ((tableList.Count() + 1) * partitionSize); h++)
                                            {
                                                table.AddHeaderCell(new Cell().Add(new Paragraph(columnHeaders[h]).SetFontSize(calculatedFontSize)).SetHeight(headerHeight).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBorder(Border.NO_BORDER)
                                                .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                                .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                                            }
                                            tableList.Add(table);

                                        }
                                        Table lastTable = new Table(UnitValue.CreatePercentArray(lastPageWidths));
                                        lastTable.SetWidth(UnitValue.CreatePercentValue(100));
                                        lastTable.SetBaseDirection(BaseDirection.RIGHT_TO_LEFT);
                                        lastTable.SetTextAlignment(TextAlignment.CENTER);
                                        //lastTable.SetMaxWidth(UnitValue.CreatePercentValue(100));
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
                                        var value = property.property.GetValue(item)?.ToString();
                                        if (!string.IsNullOrEmpty(property.format) && property.format == "html")
                                        {



                                            var style = "<style>\r\n                * { font-size: 8px; } /* Enforce font size globally */\r\n               \r\n                td, th { border: 1px solid black; padding: 2px; text-align: center; }\r\n            </style>";

                                            var htmlElements = HtmlConverter.ConvertToElements(style + value);
                                            Cell htmlCell = new Cell();
                                            htmlCell.SetMinHeight(rowHeight) // Use SetMinHeight instead of SetHeight to allow wrapping.
                                          .SetMaxWidth(rowWidth)
                                          .SetTextAlignment(TextAlignment.CENTER)
                                          .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                          //.SetFontSize(calculatedFontSize)
                                          .SetBackgroundColor((rowCount % recordsPerPage) % 2 == 0 ? new DeviceRgb(244, 244, 244) : ColorConstants.WHITE)
                                          .SetBorder(Border.NO_BORDER)
                                          .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                          .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1));

                                            foreach (IElement element in htmlElements)
                                            {
                                                var div = (Div)element;
                                                // Resize the content to fit the cell
                                                div.SetWidth(UnitValue.CreatePercentValue(100)); // Fit to cell width
                                                div.SetFontSize(8); // Reduce font size to fit

                                                htmlCell.Add(div);
                                                // htmlCell.Add((IBlockElement)element);
                                            }
                                            htmlCell.SetHeight(UnitValue.CreatePercentValue(100));
                                            tableList[tableIndex].AddCell(htmlCell);
                                            //.SetHeight(rowHeight)

                                        }
                                        else
                                        {
                                            Div d = new Div();
                                            var cell = new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(value ?? ""))
                                                .SetFont(defaultFont).SetFontSize(calculatedFontSize)
                                                .SetBaseDirection(BaseDirection.RIGHT_TO_LEFT)
                                              .SetTextAlignment(TextAlignment.CENTER)

                                              .SetMultipliedLeading(1f))
                                          //.SetHeight(rowHeight)
                                          .SetMinHeight(rowHeight) // Use SetMinHeight instead of SetHeight to allow wrapping.
                                          .SetMaxWidth(rowWidth / partitionSize)
                                          .SetWidth(rowWidth / partitionSize)
                                          .SetTextAlignment(TextAlignment.CENTER)
                                          .SetVerticalAlignment(VerticalAlignment.TOP)
                                          .SetFontSize(calculatedFontSize)
                                           .SetBaseDirection(BaseDirection.RIGHT_TO_LEFT)
                                          .SetBackgroundColor((rowCount % recordsPerPage) % 2 == 0 ? new DeviceRgb(244, 244, 244) : ColorConstants.WHITE)
                                          .SetBorder(Border.NO_BORDER)
                                          .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                          .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1));
                                            d.SetBaseDirection(BaseDirection.DEFAULT_BIDI);
                                            
                                            tableList[tableIndex].AddCell(cell);
                                        }


                                        if (columnNumber != 1 && columnNumber % partitionSize == 0)
                                        {
                                            tableIndex++;
                                            pdfRec++;
                                            if (totalrec <= 100)
                                            {
                                                int recordsDone = pdfRec ;
                                                lock (_locker)
                                                {
                                                    OnProgressChanged(recordsDone, fileNumber);
                                                }
                                            }

                                            if (totalrec > 100 && (pdfRec % 100 == 0 || pdfRec == totalrec))
                                            {
                                                int recordsDone = pdfRec ;
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
                                    {
                                        foreach (var tabl in tableList)
                                        {
                                            allElements.Add(tabl);
                                            //allElements.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                                            /*document.Add(tabl);
                                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Add a new page when a new partition starts
                                            */
                                        }
                                        break;

                                    }
                                }
                            }
                            bdstopwatch.Stop();

                            // Get the elapsed time as a TimeSpan
                            TimeSpan bdelapsedTime = bdstopwatch.Elapsed;

                            Console.WriteLine($@"until before close document takes {bdelapsedTime}");
                            int totalElements = allElements.Count();
                            foreach (var elem in allElements)
                            {
                                if (!_processesHandler.isProcessCanceld(reportGUID))
                                {
                                    document.Add(elem);
                                    if (elementDone < totalElements - 1)
                                        document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

                                    lock (_locker)
                                    {
                                        OnProgressChanged(elementDone, fileNumber*(-1));
                                        //OnLastProgressChanged(elementDone, fileNumber);

                                    }
                                    elementDone++;
                                }
                            }


                        }

                        // Close the document once done
                        document.Close();
                        adstopwatch.Stop();
                        lock (_locker)
                        {
                            OnProgressChanged(elementDone == 0 ? 1 : elementDone, fileNumber * (-1));
                           // OnLastProgressChanged(elementDone == 0 ? 1 : elementDone, fileNumber);

                        }
                        // Get the elapsed time as a TimeSpan
                        TimeSpan adelapsedTime = adstopwatch.Elapsed;
                        Console.WriteLine($@"until after close document takes {adelapsedTime}");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }

                return true;
            }



        }
        
        private float CalculateFontSize(float cellHeight, int lines)
        {
            // Assuming a basic factor for line spacing and padding/margin inside the cell
            float lineSpacingFactor = 1.2f; // A factor to include space between lines
            float paddingFactor = 1.0f; // A factor for padding/margin within the cell

            // Calculate the approximate font size that fits the number of lines
            float calculatedFontSize = (cellHeight / (lines * lineSpacingFactor)) - paddingFactor;

            return Math.Max(calculatedFontSize, 6); // Set a minimum font size limit (e.g., 6pt)
        }
        private float CalculateFontSize(float cellHeight, float cellWidth, int maxCharsOnLine = 20, int lines = 2, float lineSpacingFactor = 1f, float characterSpacingFactor = 1.0f)
        {
            // Calculate font size based on height
            float fontSizeBasedOnHeight = (cellHeight / (lines * lineSpacingFactor)) - 1.0f; // 1.0f is a padding factor

            // Calculate font size based on width
            float fontSizeBasedOnWidth = (cellWidth / (maxCharsOnLine * characterSpacingFactor)) * 2.65f;

            // Return the smaller of the two, ensuring a minimum font size
            //return Math.Min(fontSizeBasedOnHeight, fontSizeBasedOnWidth);
            return Math.Max(Math.Min(fontSizeBasedOnHeight, fontSizeBasedOnWidth), 1.4f);
        }
        private float CalculateFontSize(float cellWidth, int charactersPerLine = 70, float characterSpacingFactor = 1.0f)
        {
            // Calculate font size based on the number of characters that should fit in a single line
            float fontSizeBasedOnWidth = cellWidth / (charactersPerLine * characterSpacingFactor);

            // Return the calculated font size, ensuring a minimum value
            return Math.Max(fontSizeBasedOnWidth, 6); // Set a minimum font size of 6
        }

        public async Task<bool> ITextPdf(ExportPDFRequest req, int fileNumber, string folderPath, string fileName, string reportGUID, int reportId)
        {

            var filters = req.DataReq.Filter;

            using (var scope = _serviceScopeFactory.CreateScope())
            {



                //data prep
                ICustomReportRepo Repo = scope.ServiceProvider.GetRequiredService<ICustomReportRepo>();

                //GridResult<TModel> dataRes = Repo.GetGridData(req.DataReq);
                var factory =scope.ServiceProvider.GetRequiredService<DBFactory>();
                ArtSavedCustomReport report = Repo.GetReport(reportId);
                DbContext? schemaContext = factory.GetDbInstance(report.Schema.ToString());
                var connection = schemaContext.Database.GetDbConnection();
                GridResult<Dictionary<string, object>> dataRes = Repo.GetGridData(schemaContext, report, req.DataReq);

                IQueryable<CustomReportRecord> data = dataRes.data.Select(x => new CustomReportRecord() { Data = x });

                int total = dataRes.total;

                // Ensure the folder path exists
                if (!Directory.Exists(folderPath))
                    _ = Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"{fileNumber}.{fileName}");
                bool isLandscape = req.PdfOptions.IsLandScape;

                try
                {
                    Stopwatch bdstopwatch = new Stopwatch();//
                    bdstopwatch.Start();
                    Stopwatch adstopwatch = new Stopwatch();
                    adstopwatch.Start();
                    using (var writer = new iText.Kernel.Pdf.PdfWriter(filePath))
                    using (var pdf = new iText.Kernel.Pdf.PdfDocument(writer))
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
                        /*var modelType = typeof(TModel);
                        var properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(S => req.IncludedColumns.Contains(S.Name)).OrderBy(p => req.IncludedColumns.IndexOf(p.Name));*/
                        string[] columnHeaders = req.IncludedColumns.Select(s => s.MapToHeaderName()).ToArray();

                        // Partition settings
                        int partitionSize = columnHeaders.Count();//req.PdfOptions.NumberOfColumnsInPage; // Number of columns per page
                        int totalColumns = columnHeaders.Count();
                        int totalPagesForColumns = (int)Math.Ceiling((double)totalColumns / partitionSize);

                        int recordsPerPage = req.PdfOptions.NumberOfRowsInPage; // Set the number of records per page, this can be dynamic as needed
                        int rowCount = 0;
                        int index = 0;
                        int dataCount = data.Count();
                        bool newPageRequired = false;
                        int totalrec = totalPagesForColumns * dataCount;
                        int pdfRec = 0;
                        var pageHeight = pdf.GetDefaultPageSize().GetHeight();
                        float headerHeight = 20f; // Set a fixed height for the header row
                        float availableHeight = pageSize.GetHeight() - documentTopMargin - documentBottomMargin - headerHeight - 75 - (2 * recordsPerPage);
                        float availableWidth = pageSize.GetWidth() - documentLeftMargin - documentRightMargin - 75 - (2 * recordsPerPage);

                        float rowHeight = availableHeight / recordsPerPage;
                        float rowWidth = availableWidth / partitionSize;
                        float calculatedFontSize = CalculateFontSize(rowHeight, rowWidth);//CalculateFontSize(rowHeight, lines: 2);

                        List<Table> tableList = new List<Table>();
                        var allElements = new List<IBlockElement>();

                        int elementDone = 0;

                        // Define the paths to the images in wwwroot
                        string wwwrootPath = _env.WebRootPath;

                        string fontPath = Path.Combine(wwwrootPath, "fonts", "ARIAL.TTF");
                        iText.Kernel.Font.PdfFont defaultFont = PdfFontFactory.CreateFont(fontPath, "Identity-H");
                        // Set the default font for the entire document
                        document.SetFont(defaultFont);

                        var arabicLanguageProcessor = new ArabicLigaturizer();

                        string imagePath1 = Path.Combine(wwwrootPath, "imgs", "LOGO.png");
                        string imagePath2 = Path.Combine(wwwrootPath, "imgs", "bank_logo.png");

                        string watermarkPath = Path.Combine(wwwrootPath, "imgs", "watermark.png");

                        float logoMaxWidth = pdf.GetDefaultPageSize().GetWidth() * 0.1f;

                        document.AddLogos(imagePath1, imagePath2, logoMaxWidth);

                        document.AddTitle(report.Name);

                        document.AddDescription(report.Description);
                        document.AddQueryBuilderFilters(req.DataReq.QueryBuilderFilters);

                        document.AddFilters(filters);

                        document.AddWatermark(watermarkPath);

                        if (!req.PdfOptions.UsingPartitionApproach)
                        {

                            float[] columnWidths = new float[columnHeaders.Count()];
                            for (int i = 0; i < columnHeaders.Count(); i++)
                            {
                                columnWidths[i] = 1; // Equal distribution
                            }
                            Table table = new Table(UnitValue.CreatePercentArray(columnHeaders.Count()));
                            table.SetWidth(UnitValue.CreatePercentValue(100));

                            table.SetMaxWidth(UnitValue.CreatePercentValue(100));
                            foreach (var header in columnHeaders)
                            {
                                table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFontSize(calculatedFontSize).SetTextAlignment(TextAlignment.RIGHT)).SetHeight(headerHeight).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBorder(Border.NO_BORDER)
                                .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                            }
                            /*foreach (var row in data)
                            {

                                foreach (var prop in properties)
                                {
                                    var value = prop.GetValue(row)?.ToString();

                                    table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(value ?? "")).SetFontSize(calculatedFontSize)
                                            .SetTextAlignment(TextAlignment.CENTER).SetFont(defaultFont)
                                            .SetMultipliedLeading(1f))
                                        //.SetHeight(rowHeight)
                                        .SetMinHeight(rowHeight) // Use SetMinHeight instead of SetHeight to allow wrapping.
                                        .SetMaxWidth(rowWidth)
                                        .SetTextAlignment(TextAlignment.CENTER)
                                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                                        .SetFontSize(calculatedFontSize)
                                        .SetBackgroundColor((rowCount % recordsPerPage) % 2 == 0 ? new DeviceRgb(244, 244, 244) : ColorConstants.WHITE)
                                        .SetBorder(Border.NO_BORDER)
                                        .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                        .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                                }
                                pdfRec++;
                                if (totalrec > 100 && (pdfRec % 100 == 0 || pdfRec == totalrec))
                                {
                                    int recordsDone = pdfRec + 1;
                                    lock (_locker)
                                    {
                                        OnProgressChanged(recordsDone, fileNumber);
                                    }
                                }
                                *//*else
                                {
                                    int recordsDone = pdfRec + 1;
                                    lock (_locker)
                                    {
                                        OnProgressChanged(recordsDone, fileNumber);
                                    }
                                }*//*
                            }*/
                            lock (_locker)
                            {
                                OnProgressChanged(pdfRec + 1, fileNumber);
                                OnLastProgressChanged(0, fileNumber);

                            }
                            document.Add(table);
                            /*lock (_locker)
                            {
                                OnLastProgressChanged(1, 1);

                            }*/
                        }
                        else
                        {

                            foreach (var item in data)
                            {
                                if (rowCount % recordsPerPage == 0)
                                {

                                    foreach (var tabl in tableList)
                                    {
                                        allElements.Add(tabl);
                                        //allElements.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                                        //document.Add(tabl);
                                        //document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Add a new page when a new partition starts

                                    }
                                    tableList = new();
                                    float[] widths = Enumerable.Repeat(1f, partitionSize).ToArray();
                                    float[] lastPageWidths = Enumerable.Repeat(1f, totalColumns % partitionSize == 0 ? partitionSize : totalColumns % partitionSize).ToArray();

                                    for (int i = 0; i < totalPagesForColumns - 1; i++)
                                    {

                                        //Table table = new Table(UnitValue.CreatePercentArray(partitionSize));
                                        Table table = new Table(UnitValue.CreatePercentArray(widths));
                                        table.SetWidth(UnitValue.CreatePercentValue(100));
                                        //table.SetMaxWidth(UnitValue.CreatePercentValue(100));
                                        for (int h = (tableList.Count()) * partitionSize; h < ((tableList.Count() + 1) * partitionSize); h++)
                                        {
                                            table.AddHeaderCell(new Cell().Add(new Paragraph(columnHeaders[h]).SetFontSize(calculatedFontSize)).SetHeight(headerHeight).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBorder(Border.NO_BORDER)
                                            .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                                            .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                                        }
                                        tableList.Add(table);

                                    }
                                    Table lastTable = new Table(UnitValue.CreatePercentArray(lastPageWidths));
                                    lastTable.SetWidth(UnitValue.CreatePercentValue(100));
                                    //lastTable.SetMaxWidth(UnitValue.CreatePercentValue(100));
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
                                foreach (var property in req.IncludedColumns)
                                {
                                    var value = item.Data[property]?.ToString();

                                    tableList[tableIndex].AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(value ?? "")).SetFont(defaultFont).SetFontSize(calculatedFontSize)
                                            .SetTextAlignment(TextAlignment.CENTER)
                                            .SetMultipliedLeading(1f))
                                        //.SetHeight(rowHeight)
                                        .SetMinHeight(rowHeight) // Use SetMinHeight instead of SetHeight to allow wrapping.
                                        .SetMaxWidth(rowWidth)
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
                                if (dataCount > 100 && (index % 100 == 0 || index == dataCount))
                                {
                                    int recordsDone = index + 1;
                                    lock (_locker)
                                    {
                                        OnProgressChanged(recordsDone, fileNumber);
                                    }
                                }
                                rowCount++;

                                // If all records are added, break out of the loop
                                if (rowCount >= dataCount)
                                {
                                    foreach (var tabl in tableList)
                                    {
                                        allElements.Add(tabl);
                                        //allElements.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                                        //document.Add(tabl);
                                       // document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE)); // Add a new page when a new partition starts

                                    }
                                    //tableList.Clear();
                                    break;

                                }
                            }
                            bdstopwatch.Stop();

                            // Get the elapsed time as a TimeSpan
                            TimeSpan bdelapsedTime = bdstopwatch.Elapsed;

                            Console.WriteLine($@"until before close document takes {bdelapsedTime}");
                            int totalElements = allElements.Count();
                            foreach (var elem in allElements)
                            {

                                document.Add(elem);
                                if (elementDone < totalElements - 1)
                                    document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                                lock (_locker)
                                {
                                    OnLastProgressChanged(elementDone, fileNumber);

                                }
                                elementDone++;
                            }


                        }

                        // Close the document once done
                        document.Close();
                        adstopwatch.Stop();
                        lock (_locker)
                        {
                            OnLastProgressChanged(elementDone == 0 ? 1 : elementDone, fileNumber);

                        }
                        // Get the elapsed time as a TimeSpan
                        TimeSpan adelapsedTime = adstopwatch.Elapsed;
                        Console.WriteLine($@"until after close document takes {adelapsedTime}");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }

                return true;
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
