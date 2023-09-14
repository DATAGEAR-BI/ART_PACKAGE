using ART_PACKAGE.Helpers.CustomReport;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {
        public Task Export<TModel, TController>(DbContext _db, string userName, ExportDto<object> obj) where TModel : class;
        public Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true);
        public Task ExportSelectedCsv<T, T1, T2>(IQueryable<T> data, Func<T, bool> crt, string userName, ExportDto<T2> obj = null, bool all = true);

    }
}
