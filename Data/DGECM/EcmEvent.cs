namespace Data.DGECM
{
    public partial class EcmEvent
    {
        public int EventRk { get; set; }
        public string BusinessObjectName { get; set; } = null!;
        public int BusinessObjectRk { get; set; }
        public string EventTypeCd { get; set; } = null!;
        public string? EventDesc { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? LinkedObjectName { get; set; }
        public int? LinkedObjectRk { get; set; }
    }
}
