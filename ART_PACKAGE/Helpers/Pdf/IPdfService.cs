using ART_PACKAGE.Helpers.CustomReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ART_PACKAGE.Helpers.Pdf
{
    public interface IPdfService
    {
        public Task<byte[]> ExportToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName
            , List<string> ColumnsToSkip = null
            , Dictionary<string, DisplayNameAndFormat> DisplayNamesAndFormat = null);
        public Task<byte[]> ExportCustomReportToPdf(IEnumerable<dynamic> data, ViewDataDictionary ViewData
            , ActionContext ControllerContext
            , int ColumnsPerPage
            , string UserName
            , List<string> DataColumns);
        public Task<byte[]> ExportGroupedToPdf<T>(IEnumerable<T> data, ViewDataDictionary ViewData
           , ActionContext ControllerContext, string UserName, List<GridGroup>? GroupColumns, List<string> ColumnsToSkip = null
           , Dictionary<string, DisplayNameAndFormat> DisplayNamesAndFormat = null);
    }
}
