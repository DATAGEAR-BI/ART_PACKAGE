using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FscBranchDim> FscBranchDims { get; set; } = null!;
        public virtual DbSet<FscPartyDim> FscPartyDims { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                _ = optionsBuilder.UseOracle("User Id=FCFCORE;Password=FCFCORE1;Data Source=192.168.1.96:1521/aml71;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.HasDefaultSchema("FCFCORE");

            _ = modelBuilder.Entity<FscBranchDim>(entity =>
            {
                _ = entity.HasKey(e => e.BranchKey)
                    .HasName("XPKFSC_BRANCH_DIM");

                _ = entity.ToTable("FSC_BRANCH_DIM");

                _ = entity.HasIndex(e => e.BranchName, "XIE2FSC_BRANCH_DIM");

                _ = entity.HasIndex(e => e.BranchNumber, "XIE3FSC_BRANCH_DIM");

                _ = entity.Property(e => e.BranchKey)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("BRANCH_KEY");

                _ = entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                _ = entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                _ = entity.Property(e => e.BranchTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_TYPE_DESC");

                _ = entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_BEGIN_DATE");

                _ = entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHANGE_CURRENT_IND")
                    .IsFixedLength();

                _ = entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_END_DATE")
                    .HasDefaultValueSql("to_date('59990101','YYYYMMDD')\n		");

                _ = entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                _ = entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_2");

                _ = entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_CITY_NAME");

                _ = entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_CODE")
                    .IsFixedLength();

                _ = entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_NAME");

                _ = entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STREET_POSTAL_CODE")
                    .IsFixedLength();

                _ = entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_CODE")
                    .IsFixedLength();

                _ = entity.Property(e => e.StreetStateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_NAME");
            });

            _ = modelBuilder.Entity<FscPartyDim>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToTable("FSC_PARTY_DIM");

                _ = entity.Property(e => e.AddressComments)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_COMMENTS");

                _ = entity.Property(e => e.AddressTown)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_TOWN");

                _ = entity.Property(e => e.AddressType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS_TYPE");

                _ = entity.Property(e => e.Alias)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ALIAS");

                _ = entity.Property(e => e.AnnualIncomeAmount)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                _ = entity.Property(e => e.BenOwnExemptInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("BEN_OWN_EXEMPT_IND");

                _ = entity.Property(e => e.BirthPlace)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("BIRTH_PLACE");

                _ = entity.Property(e => e.BusinessClosed)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_CLOSED");

                _ = entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_BEGIN_DATE");

                _ = entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CHANGE_CURRENT_IND");

                _ = entity.Property(e => e.ChangeDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_DATE");

                _ = entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_END_DATE");

                _ = entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CHECK_CASHER_IND");

                _ = entity.Property(e => e.CitizenshipCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_CODE");

                _ = entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                _ = entity.Property(e => e.Comments)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                _ = entity.Property(e => e.CurrencyExchangeInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY_EXCHANGE_IND");

                _ = entity.Property(e => e.CustomerBusinessSegment)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_BUSINESS_SEGMENT");

                _ = entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CUSTOMER_SINCE_DATE");

                _ = entity.Property(e => e.DateBusinessClosed)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("DATE_BUSINESS_CLOSED");

                _ = entity.Property(e => e.DateDeceased)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("DATE_DECEASED");

                _ = entity.Property(e => e.Deceased)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("DECEASED");

                _ = entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                _ = entity.Property(e => e.EmailAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                _ = entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND");

                _ = entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NUMBER");

                _ = entity.Property(e => e.EmployerAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_ADDRESS");

                _ = entity.Property(e => e.EmployerAddressType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_ADDRESS_TYPE");

                _ = entity.Property(e => e.EmployerCity)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_CITY");

                _ = entity.Property(e => e.EmployerComments)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_COMMENTS");

                _ = entity.Property(e => e.EmployerCommunicationType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_COMMUNICATION_TYPE");

                _ = entity.Property(e => e.EmployerContactType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_CONTACT_TYPE");

                _ = entity.Property(e => e.EmployerCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_COUNTRY_CODE");

                _ = entity.Property(e => e.EmployerCountryPrefix)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_COUNTRY_PREFIX");

                _ = entity.Property(e => e.EmployerName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_NAME");

                _ = entity.Property(e => e.EmployerNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_NUMBER");

                _ = entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                _ = entity.Property(e => e.EmployerState)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_STATE");

                _ = entity.Property(e => e.EmployerTown)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_TOWN");

                _ = entity.Property(e => e.EmployerZip)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_ZIP");

                _ = entity.Property(e => e.EmpoyerExtension)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPOYER_EXTENSION");

                _ = entity.Property(e => e.EntitySegmentId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ENTITY_SEGMENT_ID");

                _ = entity.Property(e => e.Errordesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ERRORDESC");

                _ = entity.Property(e => e.ExternalPartyInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EXTERNAL_PARTY_IND");

                _ = entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("FOREIGN_CONSULATE_EMBASSY_IND");

                _ = entity.Property(e => e.Gender)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                _ = entity.Property(e => e.HoldMail)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("HOLD_MAIL");

                _ = entity.Property(e => e.IdNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");

                _ = entity.Property(e => e.IdentComments)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_COMMENTS");

                _ = entity.Property(e => e.IdentExpiryDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_EXPIRY_DATE");

                _ = entity.Property(e => e.IdentIssueCountry)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_ISSUE_COUNTRY");

                _ = entity.Property(e => e.IdentIssueDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_ISSUE_DATE");

                _ = entity.Property(e => e.IdentIssuedBy)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_ISSUED_BY");

                _ = entity.Property(e => e.IncorporationDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_DATE");

                _ = entity.Property(e => e.IncorporationLegalForm)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_LEGAL_FORM");

                _ = entity.Property(e => e.IncorporationNumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("INCORPORATION_NUMBER");

                _ = entity.Property(e => e.IncorporationState)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_STATE");

                _ = entity.Property(e => e.IndustryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE");

                _ = entity.Property(e => e.IndustryCodeRr)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE_RR");

                _ = entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                _ = entity.Property(e => e.InternetGamblingInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INTERNET_GAMBLING_IND");

                _ = entity.Property(e => e.IssuesBearerSharesInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ISSUES_BEARER_SHARES_IND");

                _ = entity.Property(e => e.LastCashTransRptDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LAST_CASH_TRANS_RPT_DATE");

                _ = entity.Property(e => e.LastContactDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_CONTACT_DATE");

                _ = entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                _ = entity.Property(e => e.LastSuspActvRptDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LAST_SUSP_ACTV_RPT_DATE");

                _ = entity.Property(e => e.LegalEntityCode)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LEGAL_ENTITY_CODE");

                _ = entity.Property(e => e.LegalEntityDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_ENTITY_DESC");

                _ = entity.Property(e => e.LegalEntityType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_ENTITY_TYPE");

                _ = entity.Property(e => e.LstUpdateDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LST_UPDATE_DATE");

                _ = entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                _ = entity.Property(e => e.MailingAddress2)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_2");

                _ = entity.Property(e => e.MailingCityName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                _ = entity.Property(e => e.MailingCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_COUNTRY_CODE");

                _ = entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_COUNTRY_NAME");

                _ = entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_POSTAL_CODE");

                _ = entity.Property(e => e.MailingStateCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_STATE_CODE");

                _ = entity.Property(e => e.MailingStateName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_STATE_NAME");

                _ = entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS_DESC");

                _ = entity.Property(e => e.MatchCodeIndividual)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_INDIVIDUAL");

                _ = entity.Property(e => e.MatchCodeMailingAddrLines)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_ADDR_LINES");

                _ = entity.Property(e => e.MatchCodeMailingAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_ADDRESS");

                _ = entity.Property(e => e.MatchCodeMailingCity)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_CITY");

                _ = entity.Property(e => e.MatchCodeMailingCountry)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_COUNTRY");

                _ = entity.Property(e => e.MatchCodeMailingState)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_STATE");

                _ = entity.Property(e => e.MatchCodeOrganization)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_ORGANIZATION");

                _ = entity.Property(e => e.MatchCodeStreetAddrLines)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_ADDR_LINES");

                _ = entity.Property(e => e.MatchCodeStreetAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_ADDRESS");

                _ = entity.Property(e => e.MatchCodeStreetCity)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_CITY");

                _ = entity.Property(e => e.MatchCodeStreetCountry)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_COUNTRY");

                _ = entity.Property(e => e.MatchCodeStreetState)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_STATE");

                _ = entity.Property(e => e.MoneyOrdersInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MONEY_ORDERS_IND");

                _ = entity.Property(e => e.MoneyTransmitterInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MONEY_TRANSMITTER_IND");

                _ = entity.Property(e => e.MothersName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MOTHERS_NAME");

                _ = entity.Property(e => e.MsbInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MSB_IND");

                _ = entity.Property(e => e.Nationality2)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY2");

                _ = entity.Property(e => e.Nationality3)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY3");

                _ = entity.Property(e => e.NegativeNewsInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NEGATIVE_NEWS_IND");

                _ = entity.Property(e => e.NetWorthAmount)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NET_WORTH_AMOUNT");

                _ = entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORG_IND");

                _ = entity.Property(e => e.OccupationCode)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("OCCUPATION_CODE");

                _ = entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                _ = entity.Property(e => e.OrgCountryOfBusinessCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ORG_COUNTRY_OF_BUSINESS_CODE");

                _ = entity.Property(e => e.OrgCountryOfBusinessName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ORG_COUNTRY_OF_BUSINESS_NAME");

                _ = entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("PARTY_DATE_OF_BIRTH");

                _ = entity.Property(e => e.PartyFirstName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_FIRST_NAME");

                _ = entity.Property(e => e.PartyIdCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_ID_COUNTRY_CODE");

                _ = entity.Property(e => e.PartyIdStateCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_ID_STATE_CODE");

                _ = entity.Property(e => e.PartyIdentificationId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARTY_IDENTIFICATION_ID");

                _ = entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_TYPE_DESC");

                _ = entity.Property(e => e.PartyKey)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARTY_KEY");

                _ = entity.Property(e => e.PartyLastName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_LAST_NAME");

                _ = entity.Property(e => e.PartyMiddleName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_MIDDLE_NAME");

                _ = entity.Property(e => e.PartyName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                _ = entity.Property(e => e.PartyNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                _ = entity.Property(e => e.PartyStatusDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_STATUS_DESC");

                _ = entity.Property(e => e.PartyTaxId)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TAX_ID");

                _ = entity.Property(e => e.PartyTaxIdTypeCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TAX_ID_TYPE_CODE");

                _ = entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                _ = entity.Property(e => e.PassportCountry)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PASSPORT_COUNTRY");

                _ = entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_1");

                _ = entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_2");

                _ = entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_3");

                _ = entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND");

                _ = entity.Property(e => e.PrepaidCardsInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PREPAID_CARDS_IND");

                _ = entity.Property(e => e.PurgeDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PURGE_DATE");

                _ = entity.Property(e => e.ResidenceCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_CODE");

                _ = entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                _ = entity.Property(e => e.Result)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RESULT");

                _ = entity.Property(e => e.RiskAssessment)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RISK_ASSESSMENT");

                _ = entity.Property(e => e.RiskClassification)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RISK_CLASSIFICATION");

                _ = entity.Property(e => e.ScreeningDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("SCREENING_DATE");

                _ = entity.Property(e => e.SegmentId)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_ID");

                _ = entity.Property(e => e.SourceOfWealth)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_OF_WEALTH");

                _ = entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                _ = entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_2");

                _ = entity.Property(e => e.StreetCityName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STREET_CITY_NAME");

                _ = entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_CODE");

                _ = entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_NAME");

                _ = entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_POSTAL_CODE");

                _ = entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_CODE");

                _ = entity.Property(e => e.StreetStateName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_NAME");

                _ = entity.Property(e => e.SuspActvRptCount)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("SUSP_ACTV_RPT_COUNT");

                _ = entity.Property(e => e.Title)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                _ = entity.Property(e => e.TphComments)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TPH_COMMENTS");

                _ = entity.Property(e => e.TphCommunicationType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TPH_COMMUNICATION_TYPE");

                _ = entity.Property(e => e.TphContactType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TPH_CONTACT_TYPE");

                _ = entity.Property(e => e.TphCountryPrefix)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TPH_COUNTRY_PREFIX");

                _ = entity.Property(e => e.TphExtension)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TPH_EXTENSION");

                _ = entity.Property(e => e.TravelersChequesInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TRAVELERS_CHEQUES_IND");

                _ = entity.Property(e => e.TrustAccountInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TRUST_ACCOUNT_IND");

                _ = entity.Property(e => e.UltimateParentName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ULTIMATE_PARENT_NAME");

                _ = entity.Property(e => e.Url)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
