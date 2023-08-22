using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ECM
{
    public class ArtSystemPerfPerDate
    {
        public int? YEAR { get; set; }
        public string MONTH { get; set; } = null!;
        public int? DAY { get; set; }
        public int? NUMBER_OF_CASES { get; set; }
    }
}
