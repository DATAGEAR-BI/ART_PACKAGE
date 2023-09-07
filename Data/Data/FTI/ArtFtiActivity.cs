using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtFtiActivity
    {
        public string? EcmReference { get; set; }
        public string? FtiReference { get; set; }
        public string? EventName { get; set; }
        public string? EventStatus { get; set; }
        public DateTime? EventCreationDate { get; set; }
        public string? MasterAssignedTo { get; set; }
        public string? EventSteps { get; set; }
        public string? StepStatus { get; set; }
        public string? Product { get; set; }
    }
}
