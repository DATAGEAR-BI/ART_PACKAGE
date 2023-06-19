using System;
using System.Collections.Generic;

namespace Data.Audit
{
    public partial class UserDg
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string Name { get; set; } = null!;
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string Status { get; set; } = null!;
        public string UserType { get; set; } = null!;
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
