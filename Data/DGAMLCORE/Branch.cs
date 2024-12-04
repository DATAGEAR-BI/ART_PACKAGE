using System;
using System.Collections.Generic;

namespace Data.DGAMLCORE
{
    public partial class Branch
    {
        public int BranchKey { get; set; }
        public string? BranchTypeDesc { get; set; }
        public string? BranchNo { get; set; }
        public string? BranchName { get; set; }
        public string? Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public string? CityName { get; set; }
        public string? StateCd { get; set; }
        public string? StateName { get; set; }
        public string? PostCd { get; set; }
        public string? CntryCd { get; set; }
        public string? CntryName { get; set; }
        public DateTime? ChgBeginDate { get; set; }
        public DateTime? ChgEndDate { get; set; }
        public string? ChgCurrentInd { get; set; }
    }
}
