using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{
    public interface IGridConstructor<TRepo, TContext, TModel> where TContext : DbContext
        where TModel : class where TRepo : IBaseRepo<TContext, TModel>
    {
        public TRepo Repo { get; }

        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User);
        public GridResult<TModel> GetGridData(GridRequest request, Expression<Func<TModel, bool>> baseCondition, IEnumerable<Expression<Func<TModel, object>>>? includes = null);
        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, Expression<Func<TModel, bool>>? baseCondition = null);

    }
}