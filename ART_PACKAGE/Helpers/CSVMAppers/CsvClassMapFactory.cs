using CsvHelper.Configuration;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class CsvClassMapFactory
    {
        private readonly List<string>? _inculdedColumns;

        public CsvClassMapFactory(List<string>? inculdedColumns = null)
        {
            _inculdedColumns = inculdedColumns;
        }

        public ClassMap CreateInstance<TModel>()
        {
            Type modelType = typeof(TModel);
            Type dictType = typeof(CustomReportRecord);
            Type CFTConfig = typeof(ArtCFTConfigMapper);
            if (modelType == dictType)
                return new CustomReportClassMapper(_inculdedColumns);
            if (modelType == CFTConfig)
                return new ArtCFTConfigMapper(_inculdedColumns);

            return new GenericCsvClassMapper<TModel>(_inculdedColumns);
        }
    }
}