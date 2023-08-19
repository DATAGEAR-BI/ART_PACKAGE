using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ECM
{
    public partial class ArtHomeCasesDate
    {
        public decimal? Year { get; set; }
        public string Month { get; set; } = null!;
        public decimal? Day { get; set; }
        public decimal? NumberOfCases { get; set; }
    }
}
