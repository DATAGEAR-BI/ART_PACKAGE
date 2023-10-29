namespace ART_PACKAGE.Helpers.Mail
{
    public interface IMailSender
    {
        bool SendEmail(Message message);
    }
}
