namespace Data.Audit.DGMGMT_AUD
{
    public partial class UserDgAud
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public short? Revtype { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? UserType { get; set; }
        public string? DataUpdate { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? LastUpdatedDate { get; set; }
        public string? LastLoginDate { get; set; }
        public int? CounterLock { get; set; }
        public bool? Active { get; set; }
        public bool? Enable { get; set; }
        public string? LastFailedLogin { get; set; }
    }
}
