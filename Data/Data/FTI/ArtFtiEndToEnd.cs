using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtFtiEndToEnd
    {
        public string EcmReference { get; set; } = null!;
        public DateTime CaseCreationDate { get; set; }
        public string? BranchName { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerClassification { get; set; }
        public string? Product { get; set; }
        public string? ProductType { get; set; }
        public string? EventName { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? FtiReference { get; set; }
        public string? EventStatus { get; set; }
        public DateTime? EventCreationDate { get; set; }
        public string? MasterAssignedTo { get; set; }
        public string? EventSteps { get; set; }
        public string? StepStatus { get; set; }
        public DateTime? StartedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public string? TimeDifference { get; set; }
        public string? LastModUser { get; set; }
        public string? FirstLineParty { get; set; }
        public string? TradeInstructions { get; set; }
        public string? FirstLineInstructions { get; set; }
        public string? CaseComments { get; set; }
        public string? ParentCaseId { get; set; }
        public string? EcmEventStep { get; set; }
        public string? EcmEventCreatedBy { get; set; }
        public DateTime? EcmEventCreatedDate { get; set; }
        public string? Assignee { get; set; }
        public string? AssignedBy { get; set; }
        public DateTime? AssignedTime { get; set; }
        public string? UnAssignee { get; set; }
        public string? UnAssignedBy { get; set; }
        public DateTime? UnAssignedTime { get; set; }
        

    }
}
