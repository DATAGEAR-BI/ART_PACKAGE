using ART_PACKAGE.Areas.Identity.Data;

namespace Data.Services.CustomReport;

public interface ICustomReportRepo : IBaseRepo<AuthContext,ArtSavedCustomReport>
{
    public Task<bool> ShareReport(ShareReportDto shareRequest , AppUser currentUser , IEnumerable<AppUser> shareToUsers);

    public Task<bool> UnShareReport(UnShareDto unShareRequest, AppUser cuAppUser,
        IEnumerable<AppUser> unshareFromUsers);

    public Task<IEnumerable<AppUser>> GetReportUsers(int reportId);

    public Task<bool> SaveReport(SaveReportDto reportDto , AppUser owner);
}