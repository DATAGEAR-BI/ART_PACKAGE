using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Queries.GetGridDataRequest
{
    public class GetGridDataRequest<TContext, TModel> : IRequest<GridResult<TModel>>
         where TContext : DbContext
        where TModel : class
    {
        public GridRequest? Request { get; init; }
    }
}
