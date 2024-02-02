using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Csv
{
    public interface ICsvExport
    {


        public bool ExportData<TContext, TModel>(ExportRequest exportRequest, int total, string folderPath, string fileName, int fileNumber, string userName, Expression<Func<TModel, bool>> baseCondition = null)
               where TContext : DbContext
               where TModel : class;

        public event Action<int, int> OnProgressChanged;

        public Task<IEnumerable<DataFile>> ExportForSchedulaedTask<TModel>(DbContext db, string parameterJson) where TModel : class;
    }
}
