using Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{
    public interface IGridConstructor<TContext, TModel> where TContext : DbContext
        where TModel : class
    {
        protected IBaseRepo<TContext, TModel> Repo { get; }

        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User);
        public GridResult<TModel> GetGridData(GridRequest request, Expression<Func<TModel, bool>> baseCondition, IEnumerable<Expression<Func<TModel, object>>>? includes = null);

        public string ExportGridToCsv(GridRequest gridRequest, string user, string gridId);

    }
}