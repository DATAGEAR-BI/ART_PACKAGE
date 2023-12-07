using Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ART_PACKAGE.Helpers.Grid
{
    public interface IGridConstructor<TContext, TModel> where TContext : DbContext
        where TModel : class
    {
        public IBaseRepo<TContext, TModel> Repo { get; }

        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User);

        public string ExportGridToCsv(GridRequest gridRequest, string user, string gridId);

    }
}