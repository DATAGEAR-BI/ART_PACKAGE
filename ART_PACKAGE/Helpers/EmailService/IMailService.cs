namespace ART_PACKAGE.Helpers.EmailService
{
    public interface IMailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
