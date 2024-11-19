using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtAmlUserPerformance
    {
        public decimal AlarmId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? AssignDate { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string UserName { get; set; } = null!;
        public string? Action { get; set; }
        public int? DurationsInSeconds { get; set; }
        public int? DurationsInMinutes { get; set; }
        public int? DurationsInHours { get; set; }
        public int? DurationsInDays { get; set; }
    }
}
