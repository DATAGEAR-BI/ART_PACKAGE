﻿using System;
using System.Collections.Generic;

namespace Data.Audit.DGMGMT
{
    public partial class RoleDg
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string Name { get; set; } = null!;
        public string RoleType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? DataUpdate { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? LastUpdatedDate { get; set; }
    }
}
