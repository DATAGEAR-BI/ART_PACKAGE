using System;
using System.Collections.Generic;

namespace Data.DGAMLAdmin
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Enabled { get; set; }
        public DateTime? LastPasswordResetDate { get; set; }
    }
}
