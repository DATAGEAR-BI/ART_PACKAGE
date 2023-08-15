using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtEcmFtiFullCycle
    {
        public string EcmReference { get; set; } =null!;
        public DateTime CaseCreationDate { get; set; } 
        public string BranchId { get; set; } =null!;
        public string? CustomerName { get; set; }
        public string Product { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double? Amount { get; set; } 
        public string? Currency { get; set; } 
        public string? PrimaryOwner { get; set; } 
        public string? CaseStatus { get; set; } = null!;
        public string? LastActionTokenBy { get; set; } 
        public string? FtiReference { get; set; } 
        public string? EventName { get; set; } 
        public string EventStatus { get; set; } = null!;
        public DateTime EventCreationDate { get; set; }
        public string? MasterAssignedTo { get; set; }
        public string EventSteps { get; set; } = null!;
        public string StepStatus { get; set; } = null!;

    }
}
