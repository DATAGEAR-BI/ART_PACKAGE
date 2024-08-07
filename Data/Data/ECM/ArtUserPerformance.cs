﻿namespace Data.Data.ECM
{
    public class ArtUserPerformance
    {
        public string CaseId { get; set; } = null!;
        public string? CaseTypeCd { get; set; }
        public string? CaseDesc { get; set; }

        public string? CaseStatus { get; set; }
        public string? Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public string? LockedBy { get; set; }
        public DateTime? AsssignedTime { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string? ActionUser { get; set; }
        public string? Action { get; set; }
        public int? DurationsInSeconds { get; set; }
        public int? DurationsInMinutes { get; set; }
        public int? DurationsInHours { get; set; }
        public int? DurationsInDays { get; set; }


        public decimal CaseRk { get; set; }
        public DateTime? ValidFromDate { get; set; }

        public string? CreateUserId { get; set; }


    }
}
