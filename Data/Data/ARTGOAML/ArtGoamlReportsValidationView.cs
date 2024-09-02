using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTGOAML
{
    public partial class ArtGoamlReportsValidationView
    {
        public decimal? Id { get; set; } // Maps to NUMBER(22,10)
        public string? ReportCode { get; set; } // Maps to VARCHAR2(1020)
        public string? ReportIndicator { get; set; } // Maps to VARCHAR2(1020)
        public string? CrimeProduct { get; set; } // Maps to VARCHAR2(4000)
        public string? EmployeeInd { get; set; } // Maps to VARCHAR2(26)
        public string? Account { get; set; } // Maps to VARCHAR2(1020)
        public string? AccountType { get; set; } // Maps to VARCHAR2(4000)
        public string? ReportStatusCode { get; set; } // Maps to VARCHAR2(1020)
        public string? TransactionNumber { get; set; } // Maps to VARCHAR2(1020)
        public DateTime? ReportDate { get; set; } // Maps to TIMESTAMP(9)
        public DateTime? ReportCreatedDate { get; set; } // Maps to TIMESTAMP(9)
        public DateTime? ReportClosedDate { get; set; } // Maps to TIMESTAMP(9)
        public DateTime? SubmissionDate { get; set; } // Maps to TIMESTAMP(9)
        public string? EntityReference { get; set; } // Maps to VARCHAR2(1020)
        public string? FiuRefNumber { get; set; } // Maps to VARCHAR2(1020)
        public string? PartyName { get; set; } // Maps to VARCHAR2(3068)
        public string? PartyNumber { get; set; } // Maps to VARCHAR2(1020)
        public string? Branch { get; set; } // Maps to VARCHAR2(1020)
        public string? Region { get; set; } // Maps to VARCHAR2(35)
        public string? Activity { get; set; } // Maps to VARCHAR2(12)




    }
}
