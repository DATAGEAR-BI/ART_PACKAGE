namespace ART_PACKAGE.Helpers.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string body);
    }
}
