using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtGoamlReportsSusbectParty
    {
        public int Id { get; set; }
        public string? Reportcode { get; set; }
        public string? Reportstatuscode { get; set; }
        public string? Entityreference { get; set; }
        public string? Fiurefnumber { get; set; }
        public string? Transactionnumber { get; set; }
        public DateTime? Submissiondate { get; set; }
        public DateTime? Reportcreateddate { get; set; }
        public DateTime? Reportcloseddate { get; set; }
        public string? Partynumber { get; set; }
        public string? Account { get; set; }
        public string? PartyId { get; set; }
        public string? PartyName { get; set; }
        public string? Branch { get; set; }
        public string Activity { get; set; } = null!;
    }
}
