namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class CsvClassMapFactory
    {
        private readonly List<string>? _inculdedColumns;

        public CsvClassMapFactory(List<string>? inculdedColumns = null)
        {
            _inculdedColumns = inculdedColumns;
        }

        public BaseClassMap<TModel> CreateInstance<TModel>()
        {
            Type modelType = typeof(TModel);
            switch (modelType)
            {
                default:
                    return new GenericCsvClassMapper<TModel>(_inculdedColumns);
            }
        }
    }
}