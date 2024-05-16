using ART_PACKAGE.Extentions.StringExtentions;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class CustomReportClassMapper : ClassMap<CustomReportRecord>
    {
        private readonly List<string> _includedColumns;
        public CustomReportClassMapper(List<string> includedColumns)
        {
            _includedColumns = includedColumns;
            DictionaryConverter converter = new(_includedColumns);
            _ = Map(m => m.Data).Name("").TypeConverter(converter);
        }
    }

    public class DictionaryConverter : ITypeConverter
    {
        private readonly List<string> _includedColumns;
        private static int _rowNumber = 0;
        private bool firstRecord = true;
        public DictionaryConverter(List<string> includedColumns)
        {
            _includedColumns = includedColumns;
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            // Implementation depends on how you want to handle the conversion,
            // This is just a placeholder to show where the logic would go.
            throw new NotImplementedException();
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {

            if (firstRecord)
            {
                foreach (string header in _includedColumns)
                {
                    var headerFormatted = header.MapToHeaderName();
                    row.WriteField(headerFormatted);
                }
                row.Context.Writer.NextRecord();
                firstRecord = false;
            }

            _rowNumber++;
            Dictionary<string, object> val = (Dictionary<string, object>)value;
            IEnumerable<object> vals = _includedColumns.Select(x => val[x]);
            foreach (object v in vals)
            {
                row.WriteField(v);
            }
            return "";
        }
    }
}