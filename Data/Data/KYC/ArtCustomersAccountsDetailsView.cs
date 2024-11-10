using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public class ArtCustomersAccountsDetailsView
    {
        public string Cid { get; set; } = null!;
        public string? AccountNumber { get; set; } //
        public string? AccountName { get; set; }  //
        public string? AccountStatus { get; set; }  //
        public DateTime? DateAccountOpened { get; set; } //
        public string? Branch { get; set; }  //
        public string? IdentificationNumber { get; set; }
        public string? IdentificationDocumentName { get; set; }  //
        public DateTime? CustIdentExpDate { get; set; }
        public string? CustomerType { get; set; }  //
        public string? Title { get; set; }    //
        public string? PhoneNumber { get; set; }
        public string? KraPin { get; set; }
        public string? ForeignTaxIdentificationNumber { get; set; }
        public string? Nationality { get; set; }
        public string? Industry { get; set; }  //
        public string? Sector { get; set; }  //
        public string? Residence { get; set; }
        public string? RiskStatusOrRiskClassification { get; set; }
        public string? NatureOfBusiness { get; set; }
        public string? PepFlag { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime? DateOfBirthOrIncorporation { get; set; }
        public string? DirectorIdentificationNumber { get; set; }
        public string? DirectorName { get; set; }  //
        public string? DirectorNationality { get; set; }
        public string? DirectorPhoneNumber { get; set; }
        public string? DirectorPin { get; set; }
        public string? DirectorOccupation { get; set; }
        public DateTime? DirectorDateOfBirth { get; set; }
        public string? SignatoryIdentificationNumber { get; set; }
        public string? SignatoryName { get; set; }  //
        public string? SignatoryNationality { get; set; }
        public string? SignatoryPhoneNumber { get; set; }
        public string? SignatoryPin { get; set; }
        public string? SignatoryOccupation { get; set; }
        public DateTime? SignatoryDateOfBirth { get; set; }
        public string? UboId { get; set; }
        public string? UboName { get; set; }

    }
}
