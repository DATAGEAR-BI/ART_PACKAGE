using ART_PACKAGE.Helpers.CustomReportHelpers;

namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {
        public Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true);
        public Task ExportSelectedCsv<T, T1, T2>(IQueryable<T> data, Func<T, bool> crt, string userName, ExportDto<T2> obj = null, bool all = true);

    }
}
