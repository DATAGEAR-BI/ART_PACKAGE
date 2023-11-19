using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtEcmFtiFullCycle
    {
        public string EcmReference { get; set; } = null!;
        public DateTime CaseCreationDate { get; set; }
        public string? BranchName { get; set; }
        public string? CustomerName { get; set; }
        public string? Product { get; set; }
        public string? ProductType { get; set; }
        public string? Name { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? CaseStatus { get; set; }
        public string? LastActionTakenBy { get; set; }
        public string? FtiReference { get; set; }
        public string? EventName { get; set; }
        public string? EventStatus { get; set; }
        public DateTime? EventCreationDate { get; set; }
        public string? MasterAssignedTo { get; set; }
        public string? EventSteps { get; set; }
        public string? StepStatus { get; set; }
        public DateTime? StartdTime { get; set; }
        public DateTime? LstModTime { get; set; }
        public string? LstModUser { get; set; }
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
