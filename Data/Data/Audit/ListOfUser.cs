namespace Data.Data.Audit
{
    public class ListOfUser
    {
        public string UserName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string UserType { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastFailedLogin { get; set; }
        public int? CounterLock { get; set; }
        public bool? Active { get; set; }
        public bool? Enable { get; set; }
    }
}
