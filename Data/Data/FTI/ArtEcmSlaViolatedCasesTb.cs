using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtEcmSlaViolatedCasesTb
    {
        public int CaseRk { get; set; }
        public string? BranchName { get; set; }
        public string? RelatedCaseId { get; set; }
        public string? CustomerName { get; set; }
        public string? CaseId { get; set; }
        public string? CustomerCIF { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public string? Product { get; set; }
        public string? EventName { get; set; }
        public string? CaseType { get; set; }
        public string? ProductType { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? MasterReference { get; set; }
        public string? RequestStatus { get; set; }
        public string? CustomerClassification { get; set; }
        public string? LastActionBy { get; set; }
        public string? FormattedTime { get; set; }
        public DateTime? LastActionDate { get; set; }
        public string? ProdCd { get; set; }
        public string? DisplayName { get; set; }
        public int? MlsToEscalation1 { get; set; }
        public int? TotalTime { get; set; }

    }
}
