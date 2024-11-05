using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public partial class ArtStDgAmlSuspectedTransactionsDetail
    {
        public Decimal ALARM_ID { get; set; }
        public string ACCOUNT_NUMBER { get; set; } = null!;
        public string? TRANSACTION_REFERENCE { get; set; }

        public string? TRANSACTION_TYPE { get; set; }

        public int TRANSACTION_DATE { get; set; }
        public Decimal BASE_AMOUNT_EGP { get; set; }
        public Decimal EQUIVALENT_AMOUNT { get; set; }
        public string? EQUIVALENT_CURRENCY { get; set; }

    }
}
