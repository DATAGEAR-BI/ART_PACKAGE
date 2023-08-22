using ART_PACKAGE.Areas.Identity.Data;
using Data.Data;

namespace ART_PACKAGE.Helpers.Logging
{
    public class LoggedUser
    {
        public enum Status
        {
            Success,
            Fail
        }
        private readonly AuthContext _context;
        public LoggedUser(AuthContext context)
        {
            _context = context;
        }
        public void UpdateLoggedUser(string userName, Status status)
        {
            ArtLoggedUser? artLoggedUser = _context.ArtLoggedUsers.Where(x => x.UserName == userName).FirstOrDefault();
            if (artLoggedUser != null)
            {
                artLoggedUser.LoginStatus = status.ToString();
                artLoggedUser.LoginDate = DateTime.Now;
                _context.Entry(artLoggedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _ = _context.SaveChanges();
                return;
            }
            artLoggedUser = new ArtLoggedUser
            {
                LoginStatus = status.ToString(),
                LoginDate = DateTime.Now
            };
            _ = _context.ArtLoggedUsers.Add(artLoggedUser);
            _ = _context.SaveChanges();
        }
        public void AddLoggedUserAudit(string userName, string status)
        {
            ArtLoggedUserAudit _audit = new()
            {
                UserName = userName,
                LoginStatus = status.ToString(),
                LoginDate = DateTime.Now
            };
            _ = _context.ArtLoggedUserAudits.Add(_audit);
            _ = _context.SaveChanges();
        }
    }
}
