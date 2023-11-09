using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ART_PACKAGE.Helpers.Mail
{
    public class MailSender : IMailSender
    {

        private readonly ILogger<IMailSender> logger;
        private readonly MailConfiguration _emailConfig;
        public MailSender(IOptions<MailConfiguration> emailConfig, ILogger<IMailSender> logger)
        {
            _emailConfig = emailConfig.Value;
            this.logger = logger;
        }
        public bool SendEmail(Message message)
        {
            MimeMessage emailMessage = CreateEmailMessage(message);
            try
            {
                Send(emailMessage);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("mail didnt sent {error}", ex.Message);
                return false;
            }

        }




        private MimeMessage CreateEmailMessage(Message message)
        {
            MimeMessage emailMessage = new();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From, _emailConfig.From));
            emailMessage.To.AddRange(message.To.Select(x => new MailboxAddress(x, x)));
            emailMessage.Subject = message.Subject;
            BodyBuilder bodyBuilder = new() { TextBody = message.Content };


            foreach (DataFile attachment in message.Attachments)
            {
                _ = bodyBuilder.Attachments.Add(attachment.Name, attachment.Bytes, ContentType.Parse(attachment.MimeType));
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using SmtpClient client = new();
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                _ = client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);

                _ = client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
