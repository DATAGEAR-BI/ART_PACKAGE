using MediatR;

namespace ART_PACKAGE.Queries.IntializeGridRequest
{
    public class IntializeGridRequest : IRequest<GridIntializationConfiguration>
    {
        public string Controller { get; init; } = null!;
    }
}
