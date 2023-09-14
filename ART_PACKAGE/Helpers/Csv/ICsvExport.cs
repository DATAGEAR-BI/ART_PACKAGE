using ART_PACKAGE.Helpers.CustomReport;

namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {
        public Task Export(string controller, string userName, ExportDto<object> obj);
        public Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true);
        public Task ExportSelectedCsv<T, T1, T2>(IQueryable<T> data, Func<T, bool> crt, string userName, ExportDto<T2> obj = null, bool all = true);

    }
}
