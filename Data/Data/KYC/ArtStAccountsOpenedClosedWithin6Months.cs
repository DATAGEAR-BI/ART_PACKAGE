using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public class ArtStAccountsOpenedClosedWithin6Months
    {
        public string? ACCT_NO { get; set; }
        public string? ACCT_NAME { get; set; }
        public string? CUST_NO { get; set; }
        public string? IDENTIFICATION_NUMBER { get; set; }
        public string? ACCT_PRIM_BRANCH_NAME { get; set; }
        public DateTime? ACCT_OPEN_DATE { get; set; }
        public DateTime? ACCT_CLOSE_DATE { get; set; }
        public string ACCOUNT_STATUS { get; set; } = null!;
    }
}
