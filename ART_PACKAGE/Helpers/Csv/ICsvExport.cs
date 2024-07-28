using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Services;
using Data.Services.Grid;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {


        public bool ExportData<TRepo, TContext, TModel>(ExportRequest exportRequest, string folderPath, string fileName, int fileNumber, Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>;
        public bool ExportData<TRepo, TContext, TModel>(ExportRequest exportRequest, string folderPath, string fileName, int fileNumber, string reportGUID, Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)
            where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>;
        public Task Export<TModel, TController, TColumn>(DbContext _db, string userName, ExportDto<object> obj, string idColumn) where TModel : class;
        public Task Export<TModel, TController>(DbContext _db, string userName, ExportDto<object> obj) where TModel : class;
        public bool ExportCustomData(ArtSavedCustomReport report, ExportRequest exportRequest, string folderPath, string fileName, int fileNumber);
        public bool ExportCustomData(ArtSavedCustomReport report, ExportRequest exportRequest, string folderPath, string fileName, int fileNumber, string reportGUID);

        public event Action<int, int> OnProgressChanged;
        public Task ExportAllCsv<T, T1, T2>(IQueryable<T> data, string userName, ExportDto<T2> obj = null, bool all = true);

        public Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel, TContext>(string parameterJson) where TModel : class where TContext : DbContext;

    }
}