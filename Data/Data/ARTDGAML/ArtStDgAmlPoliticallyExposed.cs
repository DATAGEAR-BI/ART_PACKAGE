using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public partial class ArtStDgAmlPoliticallyExposed
    {
        public string? Customer_Name { get; set; }
        public string Customer_Number { get; set; } = null!;
        public string? Address { get; set; }

        public DateTime? Date_of_Birth { get; set; }

        public string? Politically_exposed { get; set; }
        public string? Citizenship { get; set; }
        public string? Identification_Document { get; set; }
        public string? Identification_Number { get; set; }
        public DateTime? Identification_Issue_Date { get; set; }
        public DateTime? Identification_Expiry_Date { get; set; }
        public string? Employer_Name { get; set; }
        public string? Occupation { get; set; }
        public string? Telephone { get; set; }
        public DateTime? Dealing_with_the_bank_since_date { get; set; }
        public string? Related_Accounts { get; set; }
    }
}
