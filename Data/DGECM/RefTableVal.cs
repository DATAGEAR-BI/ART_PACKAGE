using System;
using System.Collections.Generic;

namespace Data.DGECM
{
    public partial class RefTableVal
    {
        public RefTableVal()
        {
            InverseParent = new HashSet<RefTableVal>();
        }

        public string RefTableName { get; set; } = null!;
        public string ValCd { get; set; } = null!;
        public string ValDesc { get; set; } = null!;
        public string? ParentRefTableName { get; set; }
        public string? ParentValCd { get; set; }
        public decimal DisplayOrdrNo { get; set; }
        public string ActiveFlg { get; set; } = null!;
        public byte Deleted { get; set; }
        public string ModuleName { get; set; }
        public virtual RefTableVal? Parent { get; set; }
        public virtual ICollection<RefTableVal> InverseParent { get; set; }
    }
}
