using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FCFKC
{
    public partial class FskLov
    {
        public string LovTypeName { get; set; } = null!;
        public string LovTypeCode { get; set; } = null!;
        public string LovLanguageDesc { get; set; } = null!;
        public string? LovTypeDesc { get; set; }
        public int? LovSortPositionNumber { get; set; }
        public string ActiveFlg { get; set; } = null!;
    }
}
