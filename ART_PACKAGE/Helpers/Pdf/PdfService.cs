
using ART_PACKAGE.Helpers.CustomReport;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Rotativa.AspNetCore;
using System.ComponentModel;
using System.Linq.Dynamic.Core;

namespace ART_PACKAGE.Helpers.Pdf
{
    public class PdfService : IPdfService
    {
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
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
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

                        object val = nullableType != null && nullableType.IsNumericType() ? 0m : propType.IsNumericType() ? 0 : "-";
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
            dynamic props = TypeDescriptor.GetProperties(dobj);
            foreach (PropertyDescriptor propertyDescriptor in props)
            {
                if (dictionary.Keys.Count == propertyNames.Count())
                {
                    break;
                }
                if (propertyNames.Contains(propertyDescriptor.Name))
                {
                    object obj = propertyDescriptor.GetValue(dobj);
                    dictionary.Add(propertyDescriptor.Name, obj);
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
    }
}
