namespace Data.Data.ECM
{
    public partial class ArtClearDetect
    {
        public int RequestUid { get; set; }
        public DateTime? RequestDate { get; set; }
        public string SearchMatch { get; set; } = null!;
        public string? SourceType { get; set; }
        public string? CaseId { get; set; }
    }
}
