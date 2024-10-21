using System.Net.Mail;
using System.Net;

namespace ART_PACKAGE.Helpers.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public async Task SendEmailAsync(string subject, string body)
        {
            try
            {
                MailMessage mailMessage = new()
                {
                    From = new MailAddress(_emailSettings.Username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(_emailSettings.To);

                using (SmtpClient smtpClient = new(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                    smtpClient.Timeout = 99999999; // Adjust timeout value (in milliseconds) as needed

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
