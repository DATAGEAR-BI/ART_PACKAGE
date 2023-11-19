using Data.DGAML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public class CustomersWithExpiredDocumentU4
    {
        public string? CustomerNumber { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? NationalIDExpirationDate { get; set; }
        public DateTime? PassportExpirationDate { get; set; }
        public DateTime? BusinessLicenseExpirationDate { get; set; }
        public DateTime? WorkPermitExpirationDate { get; set; }


    }
}
