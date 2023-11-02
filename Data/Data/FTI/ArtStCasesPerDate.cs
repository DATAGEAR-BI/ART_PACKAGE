using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtStCasesPerDate
    {
        public int? Year { get; set; }
        public string Month { get; set; } = null!;
        public int? Day { get; set; }
        public int? NUMBER_OF_CASES { get; set; }
    }
}
