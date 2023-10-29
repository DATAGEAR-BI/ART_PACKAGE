namespace ART_PACKAGE.Helpers.Mail
{
    public class Message
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = to.ToList();
            Subject = subject;
            Content = content;
        }
    }
}
