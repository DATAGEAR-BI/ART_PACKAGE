using Data.Data;
using Data.DGCMGMT;
using Data.DGECM;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            modelBuilder.Entity<CaseLive>(entity =>
            {
                entity.HasKey(e => e.CaseRk)
                    .HasName("Case_Pk");

                entity.ToTable("Case_Live", "DGCmgmt");

                entity.HasIndex(e => e.CaseDesc, "IX_Case_Desc");

                entity.HasIndex(e => e.CaseStatCd, "IX_Case_Live_Case_Stat_Cd");

                entity.HasIndex(e => e.CaseStatCd, "IX_Case_Stat_Cd");

                entity.HasIndex(e => e.ValidFromDate, "IX_Valid_From_Date");

                entity.HasIndex(e => e.ValidToDate, "IX_Valid_To_Date");

                entity.Property(e => e.CaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Case_Rk");

                entity.Property(e => e.Amenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("AMENDDATE");

                entity.Property(e => e.AnyBicFieldBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("anyBicFieldBic");

                entity.Property(e => e.ApplicantId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("applicantId");

                entity.Property(e => e.ApplicantName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("applicantName");

                entity.Property(e => e.ApplicantRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("applicantRef");

                entity.Property(e => e.ApplicationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("applicationDate");

                entity.Property(e => e.BehalfOfBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("behalfOfBranch");

                entity.Property(e => e.BeneficiaryAccountNum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryAccountNum");

                entity.Property(e => e.BeneficiaryBirthYear)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryBirthYear");

                entity.Property(e => e.BeneficiaryCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryCountry");

                entity.Property(e => e.BeneficiaryIdentity)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryIdentity");

                entity.Property(e => e.BeneficiaryNationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("beneficiaryNationality");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("birthPlace");

                entity.Property(e => e.CaseCtgryCd)
                    .HasMaxLength(32)
                    .HasColumnName("Case_Ctgry_Cd");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Desc");

                entity.Property(e => e.CaseDisposCd)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Dispos_Cd");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("Case_Id");

                entity.Property(e => e.CaseLinkSk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Case_Link_Sk");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .HasColumnName("Case_Stat_Cd");

                entity.Property(e => e.CaseSubCtgryCd)
                    .HasMaxLength(32)
                    .HasColumnName("Case_Sub_Ctgry_Cd");

                entity.Property(e => e.CaseTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("Case_Type_Cd");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Close_Date");

                entity.Property(e => e.Col1)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col2)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col3)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col4)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Col5)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.CreditorAgentBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("creditorAgentBankBic");

                entity.Property(e => e.CustFullName)
                    .HasMaxLength(200)
                    .HasColumnName("Cust_Full_Name");

                entity.Property(e => e.CustomerActivityCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_activity_country");

                entity.Property(e => e.CustomerCreatedBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_created_branch");

                entity.Property(e => e.CustomerCreatedUser)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_created_user");

                entity.Property(e => e.CustomerResidency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("customer_residency");

                entity.Property(e => e.DebtorAgentBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("debtorAgentBankBic");

                entity.Property(e => e.DeleteFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Delete_Flag")
                    .IsFixedLength();

                entity.Property(e => e.DocumentReference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EventName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("eventName");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("eventRef");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("hits_count");

                entity.Property(e => e.InputName)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("inputName");

                entity.Property(e => e.IntermediaryCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("intermediaryCode");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Investr_User_Id");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("issueDate");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("masterRef");

                entity.Property(e => e.MaxSensitivityRank).HasColumnName("maxSensitivityRank");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("nationality");

                entity.Property(e => e.OpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Open_Date");

                entity.Property(e => e.OthNationality)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("partyTypeDesc");

                entity.Property(e => e.PayDestinationCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("payDestinationCountry");

                entity.Property(e => e.PayOriginCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("payOriginCountry");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("primary_owner");

                entity.Property(e => e.PriorityCd)
                    .HasMaxLength(32)
                    .HasColumnName("Priority_Cd");

                entity.Property(e => e.Product)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("product");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("productType");

                entity.Property(e => e.ReceiverBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("receiverBankBic");

                entity.Property(e => e.ReceiverBic)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("receiverBic");

                entity.Property(e => e.ReceiverCtry)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("receiverCtry");

                entity.Property(e => e.Reference)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReguRptRqdFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Regu_Rpt_Rqd_Flag")
                    .IsFixedLength();

                entity.Property(e => e.RemitterAccountNum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remitterAccountNum");

                entity.Property(e => e.RemitterBirthYear)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("remitterBirthYear");

                entity.Property(e => e.RemitterCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("remitterCountry");

                entity.Property(e => e.RemitterIdentity)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("remitterIdentity");

                entity.Property(e => e.RemitterNationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("remitterNationality");

                entity.Property(e => e.ReopenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REOpen_Date");

                entity.Property(e => e.SearchCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("searchCountry");

                entity.Property(e => e.SearchUnit)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("searchUnit");

                entity.Property(e => e.SearchUser)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("searchUser");

                entity.Property(e => e.SenderBankBic)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("senderBankBic");

                entity.Property(e => e.SenderBic)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("senderBic");

                entity.Property(e => e.SenderCtry)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("senderCtry");

                entity.Property(e => e.SenderReceiverAgentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senderReceiverAgentCode");

                entity.Property(e => e.SrcSysCd)
                    .HasMaxLength(32)
                    .HasColumnName("Src_Sys_Cd");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("swift_reference");

                entity.Property(e => e.TransactionAmount).HasColumnName("transaction_amount");

                entity.Property(e => e.TransactionBenificiary)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_benificiary");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_currency");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_direction");

                entity.Property(e => e.TransactionRemitter)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_remitter");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("transaction_type");

                entity.Property(e => e.UiDefFileName)
                    .HasMaxLength(100)
                    .HasColumnName("UI_Def_File_Name");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Update_User_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.ValidFromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid_From_Date");

                entity.Property(e => e.ValidToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Valid_To_Date");

                entity.Property(e => e.VerNo)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Ver_No");

                entity.Property(e => e.WasPending)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("wasPending");

                entity.Property(e => e.WlCategory)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("WL_CATEGORY");

                entity.Property(e => e.XIdentity)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("X_IDENTITY");
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
