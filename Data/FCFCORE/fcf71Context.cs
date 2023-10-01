using Microsoft.EntityFrameworkCore;

namespace Data.FCFCORE
{
    public partial class fcf71Context : DbContext
    {
        public fcf71Context()
        {
        }

        public fcf71Context(DbContextOptions<fcf71Context> options)
            : base(options)
        {
        }
        public virtual DbSet<FscPartyDim> FscPartyDims { get; set; } = null!;
        public virtual DbSet<FscBranchDim> FscBranchDims { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CI_AI");

            modelBuilder.Entity<FscPartyDim>(entity =>
            {
                entity.HasKey(e => e.PartyKey)
                    .HasName("XPKFSC_PARTY_DIM");

                entity.ToTable("FSC_PARTY_DIM", "FCFCORE");

                entity.HasIndex(e => e.ChangeBeginDate, "CHABEGDATEPARTY_DIM");

                entity.HasIndex(e => e.ChangeCurrentInd, "CHANGE_CURRENT_IND_INDX");

                entity.HasIndex(e => e.PartyStatusDesc, "PARSTATUDESCPARTY_DIM");

                entity.HasIndex(e => e.ScreeningDate, "SCREENINGDATEPARTY_DIM");

                entity.HasIndex(e => e.PartyNumber, "party_num_index");

                entity.Property(e => e.PartyKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("party_key");

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("annual_income_amount");

                entity.Property(e => e.BenOwnExemptInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ben_own_exempt_ind")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_begin_date");

                entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("change_current_ind")
                    .IsFixedLength();

                entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_end_date")
                    .HasDefaultValueSql("('5999-01-01T00:00:00')");

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("check_casher_ind")
                    .IsFixedLength();

                entity.Property(e => e.CitizenshipCountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("citizenship_country_code")
                    .IsFixedLength();

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("citizenship_country_name");

                entity.Property(e => e.CurrencyExchangeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("currency_exchange_ind")
                    .IsFixedLength();

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("customer_since_date");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("doing_business_as_name");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .HasColumnName("email_address");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind")
                    .IsFixedLength();

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("employee_number");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("employer_name");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("employer_phone_number");

                entity.Property(e => e.EntitySegmentId)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("entity_segment_id");

                entity.Property(e => e.Errordesc)
                    .HasMaxLength(4000)
                    .HasColumnName("errordesc");

                entity.Property(e => e.ExternalPartyInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("external_party_ind")
                    .IsFixedLength();

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("foreign_consulate_embassy_ind")
                    .IsFixedLength();

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("industry_code")
                    .IsFixedLength();

                entity.Property(e => e.IndustryCodeRr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("industry_code_rr");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("industry_desc");

                entity.Property(e => e.InternetGamblingInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("internet_gambling_ind")
                    .IsFixedLength();

                entity.Property(e => e.IssuesBearerSharesInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("issues_bearer_shares_ind")
                    .IsFixedLength();

                entity.Property(e => e.LastCashTransRptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_cash_trans_rpt_date");

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_contact_date");

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_risk_assessment_date");

                entity.Property(e => e.LastSuspActvRptDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_susp_actv_rpt_date");

                entity.Property(e => e.LegalEntityType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("legal_entity_type");

                entity.Property(e => e.LstUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lst_update_date");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("mailing_address_1");

                entity.Property(e => e.MailingAddress2)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("mailing_address_2");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("mailing_city_name");

                entity.Property(e => e.MailingCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mailing_country_code")
                    .IsFixedLength();

                entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mailing_country_name");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mailing_postal_code")
                    .IsFixedLength();

                entity.Property(e => e.MailingStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mailing_state_code")
                    .IsFixedLength();

                entity.Property(e => e.MailingStateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("mailing_state_name");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("marital_status_desc");

                entity.Property(e => e.MatchCodeIndividual)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("match_code_individual");

                entity.Property(e => e.MatchCodeMailingAddrLines)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_addr_lines");

                entity.Property(e => e.MatchCodeMailingAddress)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_address");

                entity.Property(e => e.MatchCodeMailingCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_city");

                entity.Property(e => e.MatchCodeMailingCountry)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_country");

                entity.Property(e => e.MatchCodeMailingState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_mailing_state");

                entity.Property(e => e.MatchCodeOrganization)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("match_code_organization");

                entity.Property(e => e.MatchCodeStreetAddrLines)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_addr_lines");

                entity.Property(e => e.MatchCodeStreetAddress)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_address");

                entity.Property(e => e.MatchCodeStreetCity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_city");

                entity.Property(e => e.MatchCodeStreetCountry)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_country");

                entity.Property(e => e.MatchCodeStreetState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("match_code_street_state");

                entity.Property(e => e.MoneyOrdersInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("money_orders_ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyTransmitterInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("money_transmitter_ind")
                    .IsFixedLength();

                entity.Property(e => e.MsbInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("msb_ind")
                    .IsFixedLength();

                entity.Property(e => e.NegativeNewsInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("negative_news_ind")
                    .IsFixedLength();

                entity.Property(e => e.NetWorthAmount)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("net_worth_amount");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("non_profit_org_ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("occupation_desc");

                entity.Property(e => e.OrgCountryOfBusinessCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("org_country_of_business_code")
                    .IsFixedLength();

                entity.Property(e => e.OrgCountryOfBusinessName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("org_country_of_business_name");

                entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("party_date_of_birth");

                entity.Property(e => e.PartyFirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_first_name");

                entity.Property(e => e.PartyIdCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("party_id_country_code")
                    .IsFixedLength();

                entity.Property(e => e.PartyIdStateCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_id_state_code");

                entity.Property(e => e.PartyIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("party_identification_id");

                entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_identification_type_desc");

                entity.Property(e => e.PartyLastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_last_name");

                entity.Property(e => e.PartyMiddleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_middle_name");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("party_name");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("party_number");

                entity.Property(e => e.PartyStatusDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_status_desc");

                entity.Property(e => e.PartyTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("party_tax_id");

                entity.Property(e => e.PartyTaxIdTypeCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("party_tax_id_type_code")
                    .IsFixedLength();

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("party_type_desc");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_2");

                entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone_number_3");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("politically_exposed_person_ind")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.PrepaidCardsInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("prepaid_cards_ind")
                    .IsFixedLength();

                entity.Property(e => e.PurgeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("purge_date");

                entity.Property(e => e.ResidenceCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("residence_country_code")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("residence_country_name");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.RiskClassification)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("risk_classification");

                entity.Property(e => e.ScreeningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SCREENING_DATE");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("street_address_2");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("street_city_name");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_country_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("street_country_name");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("street_postal_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_state_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("street_state_name");

                entity.Property(e => e.SuspActvRptCount)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("susp_actv_rpt_count");

                entity.Property(e => e.TravelersChequesInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("travelers_cheques_ind")
                    .IsFixedLength();

                entity.Property(e => e.TrustAccountInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("trust_account_ind")
                    .IsFixedLength();

                entity.Property(e => e.UltimateParentName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ultimate_parent_name");
            });


            modelBuilder.HasSequence("party_key").StartsAt(3);
            modelBuilder.Entity<FscBranchDim>(entity =>
            {
                entity.HasKey(e => e.BranchKey)
                    .HasName("XPKFSC_BRANCH_DIM");

                entity.ToTable("FSC_BRANCH_DIM", "FCFCORE");

                entity.Property(e => e.BranchKey)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("branch_key");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .HasColumnName("branch_name");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("branch_number");

                entity.Property(e => e.BranchTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("branch_type_desc");

                entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_begin_date");

                entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("change_current_ind")
                    .IsFixedLength();

                entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_end_date")
                    .HasDefaultValueSql("('5999-01-01T00:00:00')");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .HasColumnName("street_address_1");

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(35)
                    .HasColumnName("street_address_2");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .HasColumnName("street_city_name");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_country_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .HasColumnName("street_country_name");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("street_postal_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("street_state_code")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateName)
                    .HasMaxLength(35)
                    .HasColumnName("street_state_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
