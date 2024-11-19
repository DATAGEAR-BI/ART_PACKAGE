using System.Linq.Expressions;
using ART_PACKAGE.Helpers.CustomReport;
using Data.Services;
using Data.Services.Grid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.Pdf
{
    public interface IPdfService
    {
        public event Action<int, int> OnProgressChanged;
        public event Action<int, int> OnLastProgressChanged;

        public Task<byte[]> ExportToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName
            , List<string> ColumnsToSkip = null
            , Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null);
        public Task<byte[]> ExportToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName,
            string reportId
            , List<string> ColumnsToSkip = null
            , Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null);
        public Task<byte[]> ExportToPdf<T>(IQueryable<T> data, KendoRequest obj, ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName
            , List<string> ColumnsToSkip = null
            , Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null);
        public Task<byte[]> ExportCustomReportToPdf(IEnumerable<dynamic> data, ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName
            , List<string> DataColumns);
        public Task<byte[]> ExportGroupedToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData
            , ActionContext ControllerContext, string UserName, List<GridGroup>? GroupColumns, List<string> ColumnsToSkip = null
            , Dictionary<string, GridColumnConfiguration> DisplayNamesAndFormat = null);

        public Task<bool> ITextPdf<TRepo, TContext, TModel>(ExportPDFRequest req, int fileNumber, string folderPath, string fileName,string reportGUID,string tenantId,Expression<Func<TModel, bool>> baseCondition = null, SortOption? defaultSort = null)    where TContext : DbContext
            where TModel : class
            where TRepo : IBaseRepo<TContext, TModel>;
    }
}