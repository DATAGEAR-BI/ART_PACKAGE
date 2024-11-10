using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Data.Services.CustomReport.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Services.CustomReport;

public class ReportCategoryRepo : BaseRepo<CustomReportsContext,ReportCategory > , IReportCategoryRepo
{
    private readonly ILogger<IReportCategoryRepo> _logger;
    public ReportCategoryRepo(CustomReportsContext context, ILogger<IReportCategoryRepo> logger) : base(context)
    {
        _logger = logger;
    }

    public Task<bool> AddCategory(AddCategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }
}