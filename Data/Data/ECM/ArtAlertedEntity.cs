namespace Data.Data.ECM
{
    public partial class ArtAlertedEntity
    {
        public string CaseId { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? Name { get; set; }
        public string? PepInd { get; set; }
    }
}
