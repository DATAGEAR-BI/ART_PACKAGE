using System;
using System.Collections.Generic;

namespace Data.DGAMLAC
{
    public partial class AcLkpTable
    {
        public string LkpName { get; set; } = null!;
        public string LkpValCd { get; set; } = null!;
        public string? LkpValDesc { get; set; }
        public string? LkpNameParent { get; set; }
        public decimal? DisplayOrdrNo { get; set; }
        public string? ActiveFlg { get; set; }
        public string? Deleted { get; set; }
        public string LkpLangDesc { get; set; } = null!;
        public string? LkpValCdParent { get; set; }
        public string? LkpLangDescParent { get; set; }
    }
}
