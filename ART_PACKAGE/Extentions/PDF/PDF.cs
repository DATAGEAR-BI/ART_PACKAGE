using iText.Layout;
using Data.Services.Grid;
using ART_PACKAGE.Extentions.CSV;
using ART_PACKAGE.Helpers.CSVMAppers;
using System.Reflection;
using System.Text.Json;
using KendoFilterExtention = ART_PACKAGE.Helpers.CustomReport;
using System.Text;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using iText.Layout.Properties;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using com.sun.org.apache.bcel.@internal.generic;
using Type = System.Type;
using Data.Setting;
using iText.IO.Image;
using iTextSharp.text.pdf;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using Data.Services.QueryBuilder;
using ART_PACKAGE.Extentions.StringExtentions;
using ART_PACKAGE.Extentions.Filters;

namespace ART_PACKAGE.Extentions.PDF
{
    public static class PDF
    {
        private static readonly Dictionary<string, string> StringOp = new()
        {
            { "eq"              , "{1} = '{0}'" },
            { "neq"             , "{1} <> '{0}'" },
            { "isnull"          , "{1} IS NULL" },
            { "isnotnull"       , "{1} IS NOT NULL" },
            { "isempty"         , $@"{{1}} = ''" },
            { "isnotempty"      , $@"{{1}} <> ''" },
            { "startswith"      , "{1} LIKE '{0}%'" },
            { "doesnotstartwith", "{1} NOT LIKE '{0}%'" },
            { "contains"        , "{1} LIKE '%{0}%'" },
            { "doesnotcontain"  , "{1} NOT LIKE '%{0}%'" },
            { "endswith"        , "{1} LIKE '%{0}'" },
            { "doesnotendwith"  , "{1} NOT LIKE '%{0}'" },
            { "isnullorempty"  , $@"{{1}} = '' or {{1}} IS NULL" },
            { "isnotnullorempty"  , $@"{{1}} != '' and {{1}} IS NOT NULL" },
        };
        private static readonly Dictionary<string, string> StringOpForC = new()
        {
            { "eq"              , "{0}==\"{1}\"" },
            { "neq"             , "{0}!=\"{1}\"" },
            { "isnull"          , "{0}== null" },
            { "isnotnull"       , "{0}!= null" },
            { "isempty"         , "{0}==\"\"" },
            { "isnotempty"      , "{0}!=\"\"" },
            { "startswith"      , "{0}.StartsWith(\"{1}\")" },
            { "doesnotstartwith", "!{0}.StartsWith(\"{1}\")" },
            { "contains"        , "{0}.Contains(\"{1}\")" },
            { "doesnotcontain"  , "!{0}.Contains(\"{1}\")" },
            { "endswith"        , "{0}.EndsWith(\"{1}\")" },
            { "doesnotendwith"  , "!{0}.EndsWith(\"{1}\")" },
            { "isnullorempty"  , "{0}== null || {0}==\"\"" },
            { "isnotnullorempty"  ,"{0}!= null && {0}!=\"\"" },
        };
        private static readonly Dictionary<string, string> NumberOp = new()
        {
            { "eq", "{1} = {0}" },
            { "neq", "{1} <> {0}" },
            { "isnull", "{1} IS NULL" },
            { "isnotnull", "{1} IS NOT NULL" },
            {"gte"  ,"{1} >= {0}"},
            {"gt"   ,"{1} > {0}"},
            {"lte"  ,"{1} <= {0}"},
            { "lt"  , "{1} < {0}" },
        };
        private static readonly Dictionary<string, string> NumberOpForC = new()
        {
            { "eq", "{0} == {1}" },
            { "neq", "{0} != {1}" },
            { "isnull", "{0} == null" },
            { "isnotnull", "{0} != null" },
            {"gte"  ,"{0} >= {1}"},
            {"gt"   ,"{0} > {1}"},
            {"lte"  ,"{0} <= {1}"},
            { "lt"  , "{0} < {1}" },
        };
        private static readonly Dictionary<string, string> DateOpForC = new()
        {
            { "eq", "{0} == \"{1}\"" },
            { "neq", "{0} != \"{1}\"" },
            { "isnull", "{0} == null" },
            { "isnotnull", "{0} != null" },
            {"gte"  , "{0} >= \"{1}\"" },
            {"gt"   , "{0} > \"{1}\"" },
            {"lte"  , "{0} <= \"{1}\"" },
            { "lt"  , "{0} < \"{1}\"" },
        };
        private static readonly Dictionary<string, string> readableOperators = new()
        {
            {"eq" , "Is Equal To" },
            {"neq" , "Is Not Equal To" },
            {"gt" , "Is Greater Than" },
            {"gte" , "Is Greater Than Or Equal" },
            {"lt" , "Is Less Than" },
            {"lte" , "Is Less Than Or Equal" },
            {"isnull" , "Is Null" },
            {"isnotnull" , "Is Not Null" },
            {"isempty" , "Is Empty" },
            {"isnotempty" , "Is Not Empty" },
            {"startswith" , "Starts With" },
            {"doesnotstartwith" , "Doesn't Start With" },
            {"contains" , "Contains" },
            {"doesnotcontain" , "Doesn't Contain" },
            {"endswith" , "Ends With" },
            {"doesnotendwith" , "Doesn't End With" },
            {"isnullorempty", "Has No Value" },
            {"isnotnullorempty","Has Value" }

        };



        /// <summary>
        /// Adds a watermark image to the first page of the document.
        /// </summary>
        /// <param name="document">The iText document to modify.</param>
        /// <param name="imagePath">The path to the watermark image.</param>
        /// <param name="opacity">The opacity of the watermark (0.0 to 1.0).</param>
        public static Document AddWatermark(this Document document, string imagePath, float opacity = 0.1f)
        {
            var pdfDoc = document.GetPdfDocument();
            if (pdfDoc.GetNumberOfPages() < 1)
            {
                throw new InvalidOperationException("The document has no pages.");
            }

            var page = pdfDoc.GetPage(1);
            var pageSize = page.GetPageSize();

            float pageWidth = pageSize.GetWidth();
            float pageHeight = pageSize.GetHeight();

            // Load the image
            var imageData = ImageDataFactory.Create(imagePath);
            var image = new Image(imageData);

            // Scale image to fill the entire page size
            image
                .SetOpacity(opacity)
                .ScaleAbsolute(pageWidth, pageHeight) // Set the image size to match the page size
                .SetFixedPosition(0, 0); // Position the image at the bottom-left corner of the page

            // Draw the watermark image
            var pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
            var canvas = new Canvas(pdfCanvas, pageSize);
            canvas.Add(image);

            return document;
        }

       public static Document AddQueryBuilderFilters(this Document document, List<BuilderFilter> filters)
        {

            if (filters == null) return document;
            List unorderedList = new List()
                        .SetSymbolIndent(12)           // Indent for symbols
                        .SetListSymbol("\u2022")       // Bullet point symbol
                        .SetMarginLeft(20).SetFontSize(16);
            unorderedList.Add(new ListItem("Global Filters"));
            document.Add(unorderedList);
            var arabicLanguageProcessor = new ArabicLigaturizer();


            Table table = new Table(UnitValue.CreatePercentArray(3));
            table.SetWidth(UnitValue.CreatePercentValue(70));
            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddHeaderCell(new Cell().Add(new Paragraph("Column")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Operator")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Value")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            foreach (var filter in filters)
            {
                
                    table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(filter.Field.ToString() ?? ""))
                              .SetTextAlignment(TextAlignment.CENTER)));
                table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(filter.Operator.ToString() ?? ""))
                              .SetTextAlignment(TextAlignment.CENTER)));
                table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(filter.Value.ToString() ?? ""))
                              .SetTextAlignment(TextAlignment.CENTER)));


            }
            document.Add(table);
            return document;
        }
        public static Document AddFilters<TModel>(this Document document,Filter filters) {

            if (filters== null) return document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
            

            List unorderedList = new List()
                        .SetSymbolIndent(12)           // Indent for symbols
                        .SetListSymbol("\u2022")       // Bullet point symbol
                        .SetMarginLeft(20).SetFontSize(16);
            unorderedList.Add(new ListItem("Table Filters"));
            document.Add(unorderedList);
            var arabicLanguageProcessor = new ArabicLigaturizer();


            Table table = new Table(UnitValue.CreatePercentArray(3));
            table.SetWidth(UnitValue.CreatePercentValue(70));
            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddHeaderCell(new Cell().Add(new Paragraph("Column")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Operator")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Value")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            foreach (var filter in filters.GetFilterTextForCsv<TModel>())
            {
                foreach (var filterGrediant in filter)
                {
                    table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(filterGrediant.ToString() ?? ""))
                              .SetTextAlignment(TextAlignment.CENTER)));

                }
            }
            document.Add(table);
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            return document;

        }
        public static Document AddFilters(this Document document, Filter filters, Dictionary<string, GridColumnConfiguration>? displayNames=null)
        {

            if (filters == null) return document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));


            List unorderedList = new List()
                        .SetSymbolIndent(12)           // Indent for symbols
                        .SetListSymbol("\u2022")       // Bullet point symbol
                        .SetMarginLeft(20).SetFontSize(16);
            unorderedList.Add(new ListItem("Table Filters"));
            document.Add(unorderedList);
            var arabicLanguageProcessor = new ArabicLigaturizer();


            Table table = new Table(UnitValue.CreatePercentArray(3));
            table.SetWidth(UnitValue.CreatePercentValue(70));
            table.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            table.AddHeaderCell(new Cell().Add(new Paragraph("Column")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Operator")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Value")).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY));
            foreach (var filter in filters.ToList(displayNames))
            {
                foreach (var filterGrediant in filter)
                {
                    table.AddCell(new Cell().Add(new Paragraph(arabicLanguageProcessor.Process(filterGrediant.ToString() ?? ""))
                              .SetTextAlignment(TextAlignment.CENTER)));

                }
            }
            document.Add(table);
            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            return document;

        }
        private static string GetFiltersString<T>(this Filter Filters)
        {
            if (Filters == null || Filters.filters.Count == 0)
            {
                return string.Empty;
            }

            string? logic = Filters.logic;

            if (logic is null)
            {
                return string.Empty;
            }
            StringBuilder _sb = new();
            foreach (object? item in Filters.filters)
            {
                string t = JsonSerializer.Serialize(item);
                ///JsonElement t = JsonSerializer.Serialize(item);
                KendoFilterExtention.FilterData i = t.ToObject<KendoFilterExtention.FilterData>();

                /*JsonElement t = (JsonElement)item;
                KendoFilterExtention.FilterData i = t.ToObject<KendoFilterExtention.FilterData>();*/
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    _ = _sb.Append(GetFiltersString<T>(filter));

                }
                else
                {
                    Type propType = typeof(T).GetProperty(i.field).PropertyType;
                    string query = "";
                    Type? underlyingType = Nullable.GetUnderlyingType(propType);
                    if (underlyingType != null)
                    {

                        query = $"para.{i.field}.HasValue && ";
                        if (underlyingType.Name == nameof(String))
                        {




                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(StringOpForC[i.@operator], $"para.{i.field}");

                            }
                            else
                            {
                                string value = ((JsonElement)i.value).ToObject<string>();
                                query += string.Format(StringOpForC[i.@operator], $"para.{i.field}.Value", value);

                            }
                        }
                        else if (underlyingType.Name == nameof(DateTime))
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(DateOpForC[i.@operator], $"para.{i.field}");

                            }
                            else
                            {
                                DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                                value = value.ToLocalTime();
                                query += string.Format(DateOpForC[i.@operator], $"para.{i.field}.Value.Date", value.Date.ToLocalTime().ToString());

                            }
                        }
                        else if (underlyingType.IsEnum)
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(StringOpForC[i.@operator], $"para.{i.field}");

                            }
                            else
                            {
                                MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);

                                query += string.Format(StringOpForC[i.@operator], $"para.{i.field}.Value", value.ToString());

                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                query = string.Format(NumberOpForC[i.@operator], $"para.{i.field}");


                            }
                            else
                            {
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);
                                query += string.Format(NumberOpForC[i.@operator], $"para.{i.field}.Value", value);

                            }
                        }
                        _ = _sb.Append(query);
                    }
                    else
                    {
                        if (propType.Name == nameof(String))
                        {
                            string value = ((JsonElement)i.value).ToObject<string>();
                            query += string.Format(StringOpForC[i.@operator], $"para.{i.field}", value);
                        }
                        else if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            value = value.ToLocalTime();
                            query += string.Format(DateOpForC[i.@operator], $"para.{i.field}.Date", value.Date.ToString());
                        }
                        else if (propType.IsEnum)
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);

                            query += string.Format(StringOpForC[i.@operator], $"para.{i.field}", value.ToString());
                        }
                        else
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);

                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);
                            query += string.Format(NumberOpForC[i.@operator], $"para.{i.field}", value);
                        }
                        _ = _sb.Append(query);
                    }



                }
                if (Filters.filters.IndexOf((Filter)item) != Filters.filters.Count - 1)
                {
                    string l = logic == "and" ? "&&" : "||";
                    _ = _sb.Append($" {l} ");
                }

            }

            return "(" + _sb.ToString() + ")";
        }
        public static T ToObject<T>(this string json)
        {

            //string json = element.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }
        public static List<List<object>> GetFilterTextForCsv<TModel>(this Filter Filters)
        {
            Dictionary<string, GridColumnConfiguration> displayNames = new();
            displayNames = ReportConfigService.GetConfigs<TModel>() is not null ? ReportConfigService.GetConfigs<TModel>().DisplayNames : null;
            List<List<object>> returnList = new();
            if (Filters is null)
            {
                return returnList;
            }

            string? logic = Filters.logic;

            if (logic is null)
            {
                return returnList;
            }


            foreach (object? item in Filters.filters)
            {
                string t = JsonSerializer.Serialize(item);
                ///JsonElement t = JsonSerializer.Serialize(item);
                KendoFilterExtention.FilterData i = t.ToObject<KendoFilterExtention.FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    returnList.AddRange(GetFilterTextForCsv<TModel>(filter));

                }
                else
                {

                    Type propType = typeof(TModel).GetProperty(i.field).PropertyType;
                    Type? underlyingType = Nullable.GetUnderlyingType(propType);
                    if (underlyingType != null)
                    {

                        if (underlyingType.Name == nameof(String))
                        {




                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator],"" };
                                returnList.Add(v);

                            }
                            else
                            {
                                string value = ((JsonElement)i.value).ToObject<string>();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);

                            }
                        }
                        else if (underlyingType.Name == nameof(DateTime))
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                                value = value.ToLocalTime();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else if (underlyingType.IsEnum)
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);

                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(FilterExtensions.ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                /*MethodInfo? vmethod = typeof(PDF)
                ?.GetMethod(nameof(FilterExtensions.ToObjectJE))
                ?.MakeGenericMethod(underlyingType);
                                var vv = vmethod?.Invoke(null, new object[] { (JsonElement)i.value });
                                var vvv = ConvertToNullableType(vv, underlyingType);*/

                               
                                    object? deserializedValue = Gmethod.Invoke(null, new object[] { (JsonElement)i.value });

                                    object? value = ConvertToNullableType(deserializedValue, underlyingType);
                                    List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                    returnList.Add(v);
                               
                                
                             
                             
                            }
                        }
                    }
                    else
                    {
                        if (propType.Name == nameof(String))
                        {
                            string value = ((JsonElement)i.value).ToObject<string>();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            value = value.ToLocalTime();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.IsEnum)
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);

                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(FilterExtensions.ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? deserializedValue = Gmethod.Invoke(null, new object[] { (JsonElement)i.value });

                            object? value = ConvertToNullableType(deserializedValue, propType);
                            //object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                    }

                    ///////////////
                  /*  List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], i.value };
                    returnList.Add(v);*/
                }


            }


            return returnList;




        }
        public static List<List<object>> GetFilterTextForCsv(this Filter Filters)
        {/*
            Dictionary<string, GridColumnConfiguration> displayNames = new();
            displayNames = ReportConfigService.GetConfigs<TModel>() is not null ? ReportConfigService.GetConfigs<TModel>().DisplayNames : null;
            List<List<object>> returnList = new();
            if (Filters is null)
            {
                return returnList;
            }

            string? logic = Filters.logic;

            if (logic is null)
            {
                return returnList;
            }


            foreach (object? item in Filters.filters)
            {
                string t = JsonSerializer.Serialize(item);
                ///JsonElement t = JsonSerializer.Serialize(item);
                KendoFilterExtention.FilterData i = t.ToObject<KendoFilterExtention.FilterData>();
                if (i.field == null)
                {
                    Filter filter = t.ToObject<Filter>();
                    returnList.AddRange(GetFilterTextForCsv(filter));

                }
                else
                {

                    Type propType = typeof(TModel).GetProperty(i.field).PropertyType;
                    Type? underlyingType = Nullable.GetUnderlyingType(propType);
                    if (underlyingType != null)
                    {

                        if (underlyingType.Name == nameof(String))
                        {




                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                string value = ((JsonElement)i.value).ToObject<string>();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);

                            }
                        }
                        else if (underlyingType.Name == nameof(DateTime))
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                                value = value.ToLocalTime();
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else if (underlyingType.IsEnum)
                        {

                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);
                            }
                            else
                            {
                                MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                                MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                                object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), underlyingType);

                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);
                            }
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(FilterExtensions.ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);


                            if (i.@operator.ToLower().Contains("null".ToLower()))
                            {
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], "" };
                                returnList.Add(v);

                            }
                            else
                            {
                                *//*MethodInfo? vmethod = typeof(PDF)
                ?.GetMethod(nameof(FilterExtensions.ToObjectJE))
                ?.MakeGenericMethod(underlyingType);
                                var vv = vmethod?.Invoke(null, new object[] { (JsonElement)i.value });
                                var vvv = ConvertToNullableType(vv, underlyingType);*//*


                                object? deserializedValue = Gmethod.Invoke(null, new object[] { (JsonElement)i.value });

                                object? value = ConvertToNullableType(deserializedValue, underlyingType);
                                List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                                returnList.Add(v);




                            }
                        }
                    }
                    else
                    {
                        if (propType.Name == nameof(String))
                        {
                            string value = ((JsonElement)i.value).ToObject<string>();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.Name == nameof(DateTime))
                        {
                            DateTime value = ((JsonElement)i.value).ToObject<DateTime>();
                            value = value.ToLocalTime();
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else if (propType.IsEnum)
                        {
                            MethodInfo? method = typeof(SW).GetMethod(nameof(ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(propType);
                            object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);

                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                        else
                        {
                            MethodInfo? method = typeof(FilterExtensions).GetMethod(nameof(FilterExtensions.ToObject), BindingFlags.Static | BindingFlags.Public);
                            MethodInfo Gmethod = method.MakeGenericMethod(underlyingType);
                            object? deserializedValue = Gmethod.Invoke(null, new object[] { (JsonElement)i.value });

                            object? value = ConvertToNullableType(deserializedValue, propType);
                            //object? value = Convert.ChangeType(Gmethod.Invoke(null, new object[] { i.value }), propType);
                            List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], value };
                            returnList.Add(v);
                        }
                    }

                    ///////////////
                    *//*  List<object> v = new() { displayNames is not null && displayNames.ContainsKey(i.field) ? displayNames[i.field].DisplayName : i.field.MapToHeaderName(), readableOperators[i.@operator], i.value };
                      returnList.Add(v);*//*
                }


            }

*/
            return new();//returnList;




        }
        /* public static T ToObjectJE<T>(this JsonElement element)
         {
             string json = element.GetRawText();

             return JsonSerializer.Deserialize<T>(json);
         }*/

        private static object ConvertToNullableType(object value, Type targetType)
        {
            if (value == null || Convert.IsDBNull(value))
            {
                return null;
            }

            Type nonNullableType = Nullable.GetUnderlyingType(targetType) ?? targetType;
            return Convert.ChangeType(value, nonNullableType);
        }


        public static Document AddTitle<TModel>(this Document document,string? reportTitle=null)
        {
            if (reportTitle==null)
            {
                reportTitle = ReportConfigService.GetConfigs<TModel>() is not null ? ReportConfigService.GetConfigs<TModel>().ReportTitle : "";
            }
       
            Paragraph title = new Paragraph(string.IsNullOrEmpty( reportTitle)?"No Title": reportTitle)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20)
                ;

            document.Add(title);
            return document;
        }
        public static Document AddTitle(this Document document, string reportTitle)
        {
            

            Paragraph title = new Paragraph(string.IsNullOrEmpty(reportTitle) ? "No Title" : reportTitle)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20)
                ;

            document.Add(title);
            return document;
        }

        public static Document AddDescription<TModel>(this Document document, string? reportDescription = null)
        {
            if (reportDescription == null)
            {
                reportDescription = ReportConfigService.GetConfigs<TModel>() is not null ? ReportConfigService.GetConfigs<TModel>().ReportDescription : "";
            }

            
              
            // Add a description
            Paragraph description = new Paragraph(string.IsNullOrEmpty(reportDescription)? "": reportDescription)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(12);
            document.Add(description);
            return document;
        }
        public static Document AddDescription(this Document document, string? reportDescription )
        {
           
            // Add a description
            Paragraph description = new Paragraph(string.IsNullOrEmpty(reportDescription) ? "" : reportDescription)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(12);
            document.Add(description);
            return document;
        }
        public static Document AddLogos(this Document document, string imagePath1, string imagePath2,float maxWidth)
        {


            // Load the images
            Image img1 = new Image(ImageDataFactory.Create(imagePath1));
            Image img2 = new Image(ImageDataFactory.Create(imagePath2));

            // Manually calculate the scale for each image based on its aspect ratio
            float img1Width = img1.GetImageWidth();
            float img1Height = img1.GetImageHeight();
            float img2Width = img2.GetImageWidth();
            float img2Height = img2.GetImageHeight();

            // Set the image width to 40% of the page width and scale the height proportionally
            float img1ScaledWidth = maxWidth;
            float img1ScaledHeight = (img1Height / img1Width) * img1ScaledWidth;

            float img2ScaledWidth = maxWidth;
            float img2ScaledHeight = (img2Height / img2Width) * img2ScaledWidth;

            img1.SetWidth(img1ScaledWidth);
            img1.SetHeight(img1ScaledHeight);

            img2.SetWidth(img2ScaledWidth);
            img2.SetHeight(img2ScaledHeight);

            // Create a table with 2 equal-width columns for the 2 images
            Table imageTable = new Table(2)  // 2 columns for 2 images
                .UseAllAvailableWidth()        // Use all available width
                .SetWidth(UnitValue.CreatePercentValue(100)) // Fill 100% of the page width
                .SetHorizontalAlignment(HorizontalAlignment.CENTER); // Center table horizontally

            // Add the first image (centered)
            imageTable.AddCell(new Cell()
                .Add(img1.SetHorizontalAlignment(HorizontalAlignment.LEFT))
                .SetTextAlignment(TextAlignment.CENTER)  // Center the first image
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)

                .SetBorder(Border.NO_BORDER)
                .SetWidth(UnitValue.CreatePercentValue(50)));  // Set width for this cell (50%)

            // Add the second image (right-aligned)
            imageTable.AddCell(new Cell()
                .Add(img2.SetHorizontalAlignment(HorizontalAlignment.RIGHT))
                .SetTextAlignment(TextAlignment.RIGHT)  // Align the second image to the right
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetBorder(Border.NO_BORDER)
                .SetWidth(UnitValue.CreatePercentValue(50))
                );  // Set width for the second cell (50%)

            // Add the table to the document
            document.Add(imageTable);


            return document;
        }
        /*public static Table AddHeaders<TModel>(this Table table,List<string> headers = null)
        {
            if (headers is not null)
            {
                foreach (var header in headers)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFontSize(calculatedFontSize)).SetHeight(headerHeight).SetTextAlignment(TextAlignment.CENTER).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetBorder(Border.NO_BORDER)
                    .SetBorderTop(new SolidBorder(new DeviceRgb(222, 225, 230), 1))
                    .SetBorderBottom(new SolidBorder(new DeviceRgb(222, 225, 230), 1)));
                }
            }
        }*/
    }
}
