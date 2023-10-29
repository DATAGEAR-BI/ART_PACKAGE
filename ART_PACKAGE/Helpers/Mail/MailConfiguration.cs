namespace ART_PACKAGE.Helpers.Mail
{
    public class MailConfiguration
    {
        public const string OptionName = "EmailConfiguration";
        public string From { get; set; } = null!;
        public string SmtpServer { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Port { get; set; }

    }
}
