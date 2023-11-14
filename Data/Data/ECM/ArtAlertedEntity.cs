namespace Data.Data.ECM
{
    public partial class ArtAlertedEntity
    {
        public string CaseId { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? PartName { get; set; }
        public string? PartNumber { get; set; }
        public string? PepInd { get; set; }
        public DateTime? EcmLastStatusDate { get; set; }
        public string? LastComment { get; set; }
        public string? LastCommentSubject { get; set; }

    }
}
