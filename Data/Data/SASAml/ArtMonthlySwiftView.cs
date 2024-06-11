using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public partial class ArtMonthlySwiftView
    {

        [Key]
        [StringLength(41)]
        public string Month { get; set; }

        [StringLength(35)]
        public string BankName { get; set; }

        [StringLength(35)]
        public string Country { get; set; }

        public decimal? NumberOfTransactions { get; set; }
    }
}
