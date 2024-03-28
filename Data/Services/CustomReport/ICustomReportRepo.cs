using ART_PACKAGE.Areas.Identity.Data;
using Data.Services;
using Data.Services.CustomReport;

namespace DataGear_RV_Ver_1._7.Services.CustomReport
{

    public interface ICustomReportRepo : IBaseRepo<AuthContext, ArtSavedCustomReport>
    {
        public Task<bool> ShareReport(ShareReportDto shareRequest, AppUser currentUser, IEnumerable<AppUser> shareToUsers);

        public Task<bool> UnShareReport(UnShareDto unShareRequest, AppUser cuAppUser,
            IEnumerable<AppUser> unshareFromUsers);

        public Task<IEnumerable<AppUser>> GetReportUsers(int reportId);
    }
}