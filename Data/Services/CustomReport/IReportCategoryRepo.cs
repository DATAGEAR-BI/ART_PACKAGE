using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Data.Services.CustomReport.DTOs;

namespace Data.Services.CustomReport;

public interface IReportCategoryRepo : IBaseRepo<CustomReportsContext,ReportCategory>
{


    public Task<bool> AddCategory(AddCategoryDto reportDto );
}