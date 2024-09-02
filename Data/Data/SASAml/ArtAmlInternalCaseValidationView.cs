using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public partial class ArtAmlInternalCaseValidationView
    {


        public decimal? CaseId { get; set; } // Maps to NUMBER(22,12)
        public string? TransactionType { get; set; } // Maps to VARCHAR2(30)
        public string? EntityName { get; set; } // Maps to VARCHAR2(35)
        public string? EntityNumber { get; set; } // Maps to VARCHAR2(50)
        public string? BranchName { get; set; } // Maps to VARCHAR2(100)
        public string? BranchNumber { get; set; } // Maps to VARCHAR2(40)
        public string? Region { get; set; } // Maps to VARCHAR2(35)
        public string? CasePriority { get; set; } // Maps to VARCHAR2(100)
        public string? CaseStatus { get; set; } // Maps to VARCHAR2(100)
        public string? CaseCategory { get; set; } // Maps to VARCHAR2(100)
        public string? CaseSubCategory { get; set; } // Maps to VARCHAR2(100)
        public string? EntityLevel { get; set; } // Maps to VARCHAR2(100)
        public string? CreatedBy { get; set; } // Maps to VARCHAR2(60)
        public DateTime? CreateDate { get; set; } // Maps to DATE
        public string? Owner { get; set; } // Maps to VARCHAR2(60)
        public DateTime? ClosedDate { get; set; } // Maps to TIMESTAMP(6)
    }
}
