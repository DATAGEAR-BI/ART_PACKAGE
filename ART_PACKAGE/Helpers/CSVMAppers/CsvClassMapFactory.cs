using CsvHelper.Configuration;
using Data.Data.CRP;
using Data.Data.ECM;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class CsvClassMapFactory
    {
        private readonly List<string>? _inculdedColumns;



        public CsvClassMapFactory(List<string>? inculdedColumns = null)
        {
            _inculdedColumns = inculdedColumns;

        }

        public ClassMap CreateInstance<TModel>(ReportConfigService reportsConfigResolver)
        {
            Type modelType = typeof(TModel);
            Type dictType = typeof(CustomReportRecord);
            Type CFTConfig = typeof(ArtCFTConfig);
            Type CRPConfig = typeof(ArtCrpConfig);
            if (modelType == dictType)
                return new CustomReportClassMapper(_inculdedColumns);
            if (modelType == CFTConfig)
                return new ArtCFTConfigMapper(_inculdedColumns);
            if (modelType == CRPConfig)
                return new ArtCRPConfigMapper(_inculdedColumns);

            return new GenericCsvClassMapper<TModel>(reportsConfigResolver, _inculdedColumns);
        }
    }
}