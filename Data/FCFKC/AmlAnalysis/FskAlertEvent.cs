namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskAlertEvent
    {
        public decimal EventId { get; set; }
        public decimal AlertId { get; set; }
        public string EventTypeCode { get; set; } = null!;
        public string? EventDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;

        public virtual FskAlert Alert { get; set; } = null!;
    }
}
