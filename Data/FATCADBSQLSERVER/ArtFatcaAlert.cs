﻿using System;
using System.Collections.Generic;

namespace Data.FATCADBSQLSERVER
{
    public partial class ArtFatcaAlert
    {
        public string? CaseId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? BranchName { get; set; }
        public string IncidentId { get; set; } = null!;
        public string? Type { get; set; }
        public string? Description { get; set; }
    }
}
