namespace Data.Audit.DGMGMT_AUD
{
    public partial class AccountAud
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public short? Revtype { get; set; }
        public string? AuthenticationDomain { get; set; }
        public string? Status { get; set; }
        public int? UserId { get; set; }
        public string? DataUpdate { get; set; }
    }
}
