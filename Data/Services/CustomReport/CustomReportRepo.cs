using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Services.CustomReport;

public class CustomReportRepo : BaseRepo<AuthContext,ArtSavedCustomReport> , ICustomReportRepo
{
    private readonly ILogger<ICustomReportRepo> _logger;
    public CustomReportRepo(AuthContext context, ILogger<ICustomReportRepo> logger) : base(context)
    {
        _logger = logger;
    }


    public async Task<bool> ShareReport(ShareReportDto shareRequest , AppUser currentUser , IEnumerable<AppUser> shareToUsers)
    {

        try
        {
            ArtSavedCustomReport? report = _context.ArtSavedCustomReports.Include(x => x.UserReports).FirstOrDefault(x => x.Id == shareRequest.ReportId);
            if (report is null)
            {
                _logger.LogCritical("Failed To share {ReportId} To ({Users}) Due To: {ex}",shareRequest.ReportId,string.Join(",",shareRequest.Recievers),"Report Not Found");
                return false;
            }
            foreach (AppUser user in shareToUsers)
            {
                UserReport? rep = user.UserReports.FirstOrDefault(x => x.ReportId == report.Id);
                if (rep is not null)
                    rep.ShareMessage = shareRequest.ShareMessage;
                else
                {
                    user.UserReports.Add(new UserReport()
                    {
                        ReportId = report.Id,
                        ShareMessage = shareRequest.ShareMessage,
                        SharedFromId = currentUser.Id,
                        UserId = user.Id
                    });
                }
            }

            report.IsShared = true;
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogCritical("Failed To share {ReportId} To ({Users}) Due To: {ex}",shareRequest.ReportId,string.Join(",",shareRequest.Recievers),e.Message);
            return false;
        }
        
    }

    public async Task<bool> UnShareReport(UnShareDto unShareRequest, AppUser cuAppUser, IEnumerable<AppUser> unshareFromUsers)
    {
        try
        {
            ArtSavedCustomReport? report = _context.ArtSavedCustomReports.Include(x => x.UserReports).FirstOrDefault(x => x.Id == unShareRequest.ReportId);
            var unshareFromUsersIds = unshareFromUsers.Select(x => x.Id).Where(x=>x != cuAppUser.Id);
           
            var usersToremain = report.UserReports.Where(x=>!unshareFromUsersIds.Contains(x.UserId));
            report.UserReports = usersToremain.ToList();
            if (!report.UserReports.Any(x => x.UserId != x.SharedFromId))
                report.IsShared = false;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogCritical("Failed To share {ReportId} To ({Users}) Due To: {ex}",unShareRequest.ReportId,string.Join(",",unShareRequest.Holders),e.Message);
            return false;
        }
        
    }

    public async Task<IEnumerable<AppUser>> GetReportUsers(int reportId)
    {
        try
        {
            ArtSavedCustomReport? report = await _context.ArtSavedCustomReports.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == reportId);
            return report.Users;
        }
        catch (Exception e)
        {
            _logger.LogCritical("Failed To get report Users due to : {ex}",e.Message);
            return null;
        }
      
    }
}