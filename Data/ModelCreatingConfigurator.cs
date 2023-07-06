using Data.DGECM;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ModelCreatingConfigurator
    {
        public static void SqlServerOnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public static void DGECMSqlServerOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_100_CI_AI");
            modelBuilder.Entity<RefTableVal>(entity =>
            {
                entity.HasKey(e => new { e.RefTableName, e.ValCd })
                    .HasName("Ref_Table_Val_Pk");

                entity.ToTable("Ref_Table_Val", "DGCmgmt");

                entity.Property(e => e.RefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Ref_Table_Name");

                entity.Property(e => e.ValCd)
                    .HasMaxLength(32)
                    .HasColumnName("Val_Cd");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Active_Flg")
                    .IsFixedLength();

                entity.Property(e => e.Deleted).HasColumnName("DELETED");

                entity.Property(e => e.DisplayOrdrNo)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Display_Ordr_No");

                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .HasColumnName("Parent_Ref_Table_Name");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(32)
                    .HasColumnName("Parent_Val_Cd");

                entity.Property(e => e.ValDesc)
                    .HasMaxLength(4000)
                    .HasColumnName("Val_Desc");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => new { d.ParentRefTableName, d.ParentValCd })
                    .HasConstraintName("REF_TABLE_VAL_FK1");
            });
        }


        public static void DGECMOracleOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DGCMGMT");

            modelBuilder.Entity<RefTableVal>(entity =>
            {
                entity.HasKey(e => new { e.RefTableName, e.ValCd })
                    .HasName("REF_TABLE_VAL_PK");

                entity.ToTable("REF_TABLE_VAL");

                entity.HasIndex(e => new { e.ParentRefTableName, e.ParentValCd }, "REF_TABLE_VAL_FK1");

                entity.Property(e => e.RefTableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("REF_TABLE_NAME");

                entity.Property(e => e.ValCd)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("VAL_CD");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLG")
                    .IsFixedLength();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DELETED")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.DisplayOrdrNo)
                    .HasPrecision(6)
                    .HasColumnName("DISPLAY_ORDR_NO");



                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_REF_TABLE_NAME");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_VAL_CD");

                entity.Property(e => e.ValDesc)
                    .IsUnicode(false)
                    .HasColumnName("VAL_DESC");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => new { d.ParentRefTableName, d.ParentValCd })
                    .HasConstraintName("REF_TABLE_VAL_FK1");
            });
            modelBuilder.Entity<CaseLive>(entity =>
            {
                entity.HasKey(e => e.CaseRk)
                    .HasName("CASE_PK");

                entity.ToTable("CASE_LIVE");

                entity.HasIndex(e => e.CaseLinkSk, "CASE_IDX1");

                entity.HasIndex(e => new { e.SrcSysCd, e.CaseId }, "CASE_UX1")
                    .IsUnique();

                entity.Property(e => e.CaseRk)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.Amenddate)
                    .HasPrecision(6)
                    .HasColumnName("AMENDDATE");

                entity.Property(e => e.Anybicfieldbic)
                    .IsUnicode(false)
                    .HasColumnName("ANYBICFIELDBIC");

                entity.Property(e => e.Applicantid)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTID");

                entity.Property(e => e.Applicantname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTNAME");

                entity.Property(e => e.Applicantref)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTREF");

                entity.Property(e => e.Applicationdate)
                    .HasPrecision(6)
                    .HasColumnName("APPLICATIONDATE");

                entity.Property(e => e.Behalfofbranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BEHALFOFBRANCH");

                entity.Property(e => e.Beneficiaryaccountnum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYACCOUNTNUM");

                entity.Property(e => e.Beneficiarybirthyear)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYBIRTHYEAR");

                entity.Property(e => e.Beneficiarycountry)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYCOUNTRY");

                entity.Property(e => e.Beneficiaryidentity)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYIDENTITY");

                entity.Property(e => e.Beneficiarynationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYNATIONALITY");

                entity.Property(e => e.Birthplace)
                    .IsUnicode(false)
                    .HasColumnName("BIRTHPLACE");

                entity.Property(e => e.CaseCtgryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CTGRY_CD");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DESC");

                entity.Property(e => e.CaseDisposCd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DISPOS_CD");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseLinkSk)
                    .HasPrecision(10)
                    .HasColumnName("CASE_LINK_SK");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STAT_CD");

                entity.Property(e => e.CaseSubCtgryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_SUB_CTGRY_CD");

                entity.Property(e => e.CaseTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE_CD");

                entity.Property(e => e.CloseDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.Col1)
                    .IsUnicode(false)
                    .HasColumnName("COL1");

                entity.Property(e => e.Col2)
                    .IsUnicode(false)
                    .HasColumnName("COL2");

                entity.Property(e => e.Col3)
                    .IsUnicode(false)
                    .HasColumnName("COL3");

                entity.Property(e => e.Col4)
                    .IsUnicode(false)
                    .HasColumnName("COL4");

                entity.Property(e => e.Col5)
                    .IsUnicode(false)
                    .HasColumnName("COL5");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.Creditoragentbankbic)
                    .IsUnicode(false)
                    .HasColumnName("CREDITORAGENTBANKBIC");

                entity.Property(e => e.CustFullName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CUST_FULL_NAME");

                entity.Property(e => e.CustomerActivityCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ACTIVITY_COUNTRY");

                entity.Property(e => e.CustomerCreatedBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_CREATED_BRANCH");

                entity.Property(e => e.CustomerCreatedUser)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_CREATED_USER");

                entity.Property(e => e.CustomerResidency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_RESIDENCY");

                entity.Property(e => e.Debtoragentbankbic)
                    .IsUnicode(false)
                    .HasColumnName("DEBTORAGENTBANKBIC");

                entity.Property(e => e.DeleteFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DELETE_FLAG")
                    .IsFixedLength();

                entity.Property(e => e.Documentreference)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTREFERENCE");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.Eventname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EVENTNAME");

                entity.Property(e => e.Eventref)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EVENTREF");

                entity.Property(e => e.Expirydate)
                    .HasPrecision(6)
                    .HasColumnName("EXPIRYDATE");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HITS_COUNT");

                entity.Property(e => e.Inputname)
                    .IsUnicode(false)
                    .HasColumnName("INPUTNAME");

                entity.Property(e => e.Intermediarycode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("INTERMEDIARYCODE");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INVESTR_USER_ID");

                entity.Property(e => e.Issuedate)
                    .HasPrecision(6)
                    .HasColumnName("ISSUEDATE");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Masterref)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MASTERREF");

                entity.Property(e => e.Maxsensitivityrank)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("MAXSENSITIVITYRANK");

                entity.Property(e => e.Nationality)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY");

                entity.Property(e => e.OpenDate)
                    .HasPrecision(6)
                    .HasColumnName("OPEN_DATE");

                entity.Property(e => e.Othnationality)
                    .IsUnicode(false)
                    .HasColumnName("OTHNATIONALITY");

                entity.Property(e => e.Partytypedesc)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARTYTYPEDESC");

                entity.Property(e => e.Paydestinationcountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PAYDESTINATIONCOUNTRY");

                entity.Property(e => e.Payorigincountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PAYORIGINCOUNTRY");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER");

                entity.Property(e => e.PriorityCd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY_CD");

                entity.Property(e => e.Product)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Producttype)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTTYPE");

                entity.Property(e => e.Receiverbankbic)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVERBANKBIC");

                entity.Property(e => e.Receiverbic)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVERBIC");

                entity.Property(e => e.Receiverctry)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVERCTRY");

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.ReguRptRqdFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REGU_RPT_RQD_FLAG")
                    .IsFixedLength();

                entity.Property(e => e.Remitteraccountnum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERACCOUNTNUM");

                entity.Property(e => e.Remitterbirthyear)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERBIRTHYEAR");

                entity.Property(e => e.Remittercountry)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERCOUNTRY");

                entity.Property(e => e.Remitteridentity)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERIDENTITY");

                entity.Property(e => e.Remitternationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERNATIONALITY");

                entity.Property(e => e.ReopenDate)
                    .HasPrecision(6)
                    .HasColumnName("REOPEN_DATE");

                entity.Property(e => e.Searchcountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SEARCHCOUNTRY");

                entity.Property(e => e.Searchunit)
                    .HasMaxLength(1000)
                    .HasColumnName("SEARCHUNIT");

                entity.Property(e => e.Searchuser)
                    .HasMaxLength(1000)
                    .HasColumnName("SEARCHUSER");

                entity.Property(e => e.Senderbankbic)
                    .IsUnicode(false)
                    .HasColumnName("SENDERBANKBIC");

                entity.Property(e => e.Senderbic)
                    .IsUnicode(false)
                    .HasColumnName("SENDERBIC");

                entity.Property(e => e.Senderctry)
                    .IsUnicode(false)
                    .HasColumnName("SENDERCTRY");

                entity.Property(e => e.Senderreceiveragentcode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SENDERRECEIVERAGENTCODE");

                entity.Property(e => e.SrcSysCd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SRC_SYS_CD");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT_REFERENCE");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionBenificiary)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_BENIFICIARY");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_DIRECTION");

                entity.Property(e => e.TransactionRemitter)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_REMITTER");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.UiDefFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UI_DEF_FILE_NAME");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.ValidFromDate)
                    .HasPrecision(6)
                    .HasColumnName("VALID_FROM_DATE");

                entity.Property(e => e.ValidToDate)
                    .HasPrecision(6)
                    .HasColumnName("VALID_TO_DATE");

                entity.Property(e => e.VerNo)
                    .HasPrecision(10)
                    .HasColumnName("VER_NO");

                entity.Property(e => e.Waspending)
                    .IsUnicode(false)
                    .HasColumnName("WASPENDING");

                entity.Property(e => e.WlCategory)
                    .IsUnicode(false)
                    .HasColumnName("WL_CATEGORY");

                entity.Property(e => e.XIdentity)
                    .IsUnicode(false)
                    .HasColumnName("X_IDENTITY");
            });

            modelBuilder.HasSequence("CASE_RK_SEQ");

            modelBuilder.HasSequence("CUST_RK_SEQ");

            modelBuilder.HasSequence("EVENT_RK_SEQ");

            modelBuilder.HasSequence("OCCS_RK_SEQ");

            modelBuilder.HasSequence("USER_AUTH_DOMAIN_SEQUENCE");
        }
        public static void OracleOnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
