namespace Data.Data.ARTAUDIT
{
    public partial class ArtAuditUserAccessLog
    {
        public int? UserNumber { get; set; }
        public string? UserName { get; set; }
        public string? Department { get; set; }
        public string? ReportName { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
