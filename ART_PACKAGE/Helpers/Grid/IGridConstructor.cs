using Data.Services;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Grid
{
    public interface IGridConstructor<TContext, TModel> where TContext : DbContext
        where TModel : class
    {
        public IBaseRepo<TContext, TModel> Repo { get; }

        public GridIntializationConfiguration IntializeGrid(string controller, bool containsActions = false, bool selectable = false, List<GridButton>? toolbar = null, List<GridButton>? action = null);


        public string ExportGridToCsv(GridRequest gridRequest);

    }
}