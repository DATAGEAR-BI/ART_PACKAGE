namespace Data.Data.ECM
{
    public partial class ArtAlertedEntity
    {
        public string CaseId { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? Name { get; set; }
        public string? PepInd { get; set; }
        public string? LastComment { get; set; }
        public string? LastCommentSubject { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int? NumberOfComment { get; set; }
        public int? NumberOfAttachments { get; set; }
    }
}
