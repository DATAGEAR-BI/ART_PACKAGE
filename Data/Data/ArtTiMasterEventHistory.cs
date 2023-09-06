using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtTiMasterEventHistory
    {
        public string? EventRef { get; set; }
        public string? MasterRef { get; set; }
        public string? Product { get; set; }
        public string? Address1 { get; set; }
        public string? Status { get; set; }
        public decimal? Outstamt { get; set; }
        public string? Outstccy { get; set; }
        public decimal? OutstamtEgp { get; set; }
        public DateTime? ExpiryDat { get; set; }
        public DateTime? Bookoffdat { get; set; }
        public DateTime? DeactDate { get; set; }
        public DateTime? StartedFilter { get; set; }
        public string? Started { get; set; }
        public string? CrossRef { get; set; }
        public decimal? Amount { get; set; }
        public string? Ccy { get; set; }
        public decimal? AmountEgp { get; set; }
        public string? StatusEv { get; set; }
        public string? Shortname { get; set; }
        public string? Stepdescr { get; set; }
        public string? StepStatus { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
        public string? Gfcun { get; set; }
        public string? CusMnm { get; set; }
        public string? SwBank { get; set; }
        public string? SwCtr { get; set; }
        public string? SwLoc { get; set; }
        public string? SwBranch { get; set; }
        public string? Team { get; set; }
        public string? Extrainfo { get; set; }
        public string? Language { get; set; }
        public string? Isfinished { get; set; }
        public decimal Stepkey { get; set; }
    }
}
