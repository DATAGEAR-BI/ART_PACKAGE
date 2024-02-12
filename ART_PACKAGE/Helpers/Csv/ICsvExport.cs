using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {


        public bool ExportData<TRepo, TContext, TModel>(ExportRequest exportRequest, string folderPath, string fileName, int fileNumber, Expression<Func<TModel, bool>> baseCondition = null)
               where TContext : DbContext
               where TModel : class
               where TRepo : IBaseRepo<TContext, TModel>;

        public bool ExportCustomData(ArtSavedCustomReport report, ExportRequest exportRequest, string folderPath, string fileName, int fileNumber);

        public event Action<int, int> OnProgressChanged;

        public Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel, TContext>(string parameterJson) where TModel : class where TContext : DbContext;
    }
}
