using ART_PACKAGE.Helpers.CustomReport;
using Data.Data.ExportSchedular;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {

        public Task ExportMissed(string reqId, string UserName, List<int> missedFiles);
        public Task Export<TModel, TController, TColumn>(DbContext _db, string userName, ExportDto<object> obj, string idColumn) where TModel : class;
        public Task Export<TModel, TController>(DbContext _db, string userName, ExportDto<object> obj) where TModel : class;
        public Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true);
        public Task ExportSelectedCsv<T, T1, T2>(IQueryable<T> data, string propName, string userName, ExportDto<T2> obj = null, bool all = true);
        public void ClearExportFolder(string reqId);


        public Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel, TController>(DbContext db, IEnumerable<TaskParameters> parameters) where TModel : class;
    }
}
