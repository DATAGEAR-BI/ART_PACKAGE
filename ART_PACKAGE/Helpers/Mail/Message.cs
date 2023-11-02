namespace ART_PACKAGE.Helpers.Mail
{
    public class Message
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public List<DataFile> Attachments { get; set; }
        public Message(IEnumerable<string> to, string subject, string content, List<DataFile> attachments)
        {
            To = to.ToList();
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
