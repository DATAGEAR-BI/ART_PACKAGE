using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DGCMGMT
{
    public partial class ArtHomeCasesStatus
    {
        public int YEAR { get; set; }
        public string CaseStatus { get; set; }
        public decimal? NumberOfCases { get; set; }
    }
}
