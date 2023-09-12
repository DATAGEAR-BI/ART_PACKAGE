namespace ART_PACKAGE.DBModel
{
    public partial class AcAlarmEvent
    {
        public decimal EventId { get; set; }
        public decimal AlarmId { get; set; }
        public string EventTypeCd { get; set; } = null!;
        public string? EventDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
    }
}
