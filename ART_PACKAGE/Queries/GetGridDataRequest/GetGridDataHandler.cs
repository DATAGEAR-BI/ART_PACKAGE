using Data.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Queries.GetGridDataRequest
{
    public class GetGridDataHandler<TContext, TModel> : IRequestHandler<GetGridDataRequest<TContext, TModel>, GridResult<TModel>>
        where TContext : DbContext
        where TModel : class
    {
        private readonly IBaseRepo<TContext, TModel> _repo;

        public GetGridDataHandler(IBaseRepo<TContext, TModel> repo)
        {
            _repo = repo;
        }

        public async Task<GridResult<TModel>> Handle(GetGridDataRequest<TContext, TModel> request, CancellationToken cancellationToken)
        {
            return _repo.GetGridData(request.Request);
        }
    }
}
