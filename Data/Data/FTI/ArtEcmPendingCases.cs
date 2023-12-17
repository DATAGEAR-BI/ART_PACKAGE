using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtEcmPendingCases
    {
        public int CaseRk { get; set; }
        public string? BranchName { get; set; }
        public string? ParentCaseId { get; set; }
        public string? CustomerName { get; set; }
        public string? SubCaseId { get; set; }
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
        public string? ParentActionBy { get; set; }
        public DateTime? ParentLastActionDate { get; set; }
        public DateTime? SubLastActionDate { get; set; }
        public DateTime? LastActionTakenDate { get; set; }
        public string? TimeDifference { get; set; }
    }
}
