using ART_PACKAGE.Helpers.CustomReport;
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

        public bool ExportData<TContext, TModel>(GridRequest gridRequest, int total, string folderPath, string fileName, int fileNumber, string userName)
               where TContext : DbContext
               where TModel : class;

        public event Action<int, int> OnProgressChanged;

        public Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel, TController>(DbContext db, string parameterJson) where TModel : class;
    }
}
