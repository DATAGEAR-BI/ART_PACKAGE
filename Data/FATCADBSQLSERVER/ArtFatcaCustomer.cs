using System;
using System.Collections.Generic;

namespace Data.FATCADBSQLSERVER
{
    public partial class ArtFatcaCustomer
    {
        public string CaseId { get; set; } = null!;
        public string? CaseStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CustKey { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? BranchName { get; set; }
        public string? CustClsFlag { get; set; }
        public string? MainNationality { get; set; }
        public string? SignW8 { get; set; }
        public string? SignW9 { get; set; }
        public DateTime? W9SignDate { get; set; }
        public DateTime? W8SignDate { get; set; }
    }
}
