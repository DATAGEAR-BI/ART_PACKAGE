using System.Linq.Expressions;
using System.Security.Claims;
using Data.Services.CustomReport;

namespace ART_PACKAGE.Helpers.Grid
{
    public class CustomReportGridConstructor : IGridConstructor<ICustomReportRepo,AuthContext,object>
    {
        public ICustomReportRepo Repo { get; }
        public GridIntializationConfiguration IntializeGrid(string controller, ClaimsPrincipal User)
        {
            throw new NotImplementedException();
        }

        public GridResult<object> GetGridData(GridRequest request, Expression<Func<object, bool>> baseCondition, IEnumerable<Expression<Func<object, object>>>? includes = null)
        {
            throw new NotImplementedException();
        }

        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, Expression<Func<object, bool>>? baseCondition = null)
        {
            throw new NotImplementedException();
        }
    }
}