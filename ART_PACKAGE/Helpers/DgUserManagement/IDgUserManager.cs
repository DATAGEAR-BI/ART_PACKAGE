namespace ART_PACKAGE.Helpers.DgUserManagement
{
    public interface IDgUserManager
    {
        public Task<DgResponse?> Authnticate(string uid, string password);
    }
}
