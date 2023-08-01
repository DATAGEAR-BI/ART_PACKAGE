using ART_PACKAGE.Helpers.CustomReportHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Services.Pdf
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
    }
}
