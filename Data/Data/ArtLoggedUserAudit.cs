namespace ART_PACKAGE.Helpers.Logging
{
    public class ArtLoggedUserAudit
    {
        public int ID { get; set; } 
        public string? UserName { get; set; }
        public DateTime? LoginDate { get; set; }
        public string? LoginStatus { get; set; }
    }
}
