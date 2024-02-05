using System.Linq.Expressions;
using ART_PACKAGE.Areas.Identity.Data;
using Data.Services.Grid;

namespace Data.Services.CustomReport;

public class CustomReportRepo : BaseRepo<AuthContext,object> , ICustomReportRepo
{
    public CustomReportRepo(AuthContext context) : base(context)
    {
    }

    
}