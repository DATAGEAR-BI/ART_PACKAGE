namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskEntityEvent
    {
        public decimal EventId { get; set; }
        public decimal? CaseId { get; set; }
        public string EventTypeCode { get; set; } = null!;
        public string? EventDescription { get; set; }
        public string EntityNumber { get; set; } = null!;
        public string EntityLevelCode { get; set; } = null!;
        public string CreateUserId { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
