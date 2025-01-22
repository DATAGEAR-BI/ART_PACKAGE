using Data.Services;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
        public string ExportGridToCsv(ExportRequest exportRequest, string user, string gridId, string reportGUID, Expression<Func<TModel, bool>>? baseCondition = null);
        public Task<byte[]> ExportGridToPdf(ExportRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, Expression<Func<TModel, bool>>? baseCondition = null);

        public Task<byte[]> ExportGridToPdf(ExportPDFRequest exportRequest, string user, ActionContext actionContext, ViewDataDictionary ViewData, string reportId, Expression<Func<TModel, bool>>? baseCondition = null);
        public Task<string> ExportGridToPDFUsingIText(ExportPDFRequest exportRequest, string user, string gridId, string reportGUID, Expression<Func<TModel, bool>>? baseCondition = null);
        public Task<string> ExportGridToPDFUsingIText(ExportPDFRequest exportRequest, string user, int gridId, string reportGUID, Expression<Func<TModel, bool>>? baseCondition = null);

    }
}