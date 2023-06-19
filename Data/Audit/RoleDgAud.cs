using System;
using System.Collections.Generic;

namespace Data.Audit
{
    public partial class RoleDgAud
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public short? Revtype { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Name { get; set; }
        public string? RoleType { get; set; }
        public string? Status { get; set; }
        public string? DataUpdate { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? LastUpdatedDate { get; set; }
    }
}
