using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlCasesTransactionsDetailPopUpWindow
    {
        public string CaseId { get; set; } = null!;
        public string? EventType { get; set; }
        public string? EventDescription { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
