using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Data.ECM
{
    public partial class ArtEcmCasesBirthdateView
    {
        public string CaseId { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreateDate { get; set; }
        public string IsDateAvailable { get; set; }
        public string BranchName { get; set; }
        public string BranchNumber { get; set; }
        public string CustomerDateOfBirth { get; set; }
    }
}
