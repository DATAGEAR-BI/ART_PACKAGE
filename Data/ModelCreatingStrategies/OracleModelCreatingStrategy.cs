using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Data.AmlAnalysis;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Data.Data.FATCA;
using Data.DGECM;
using Data.FCF71;
using Data.FCFCORE;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.TIZONE2;
using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{

    public class OracleModelCreatingStrategy : IBaseModelCreatingStrategy
    {


        public void OnModelCreating(ModelBuilder modelBuilder)
        {




            //Aduit
            modelBuilder.Entity<ArtGroupsAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GROUPS_AUDIT_VIEW", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.MemberUsers).HasColumnName("member_users");

                entity.Property(e => e.RoleNames).HasColumnName("role_names");

                entity.Property(e => e.SubGroupNames).HasColumnName("sub_group_names");
            });
            modelBuilder.Entity<ArtRolesAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ROLES_AUDIT_VIEW", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupNames).HasColumnName("group_names");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.MemberUsers).HasColumnName("member_users");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });
            modelBuilder.Entity<ArtUsersAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_USERS_AUDIT_VIEW", "ART_DB");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.DomainAccounts).HasColumnName("domain_accounts");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.GroupNames).HasColumnName("group_names");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleNames).HasColumnName("role_names");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");
            });
            modelBuilder.Entity<LastLoginPerDayView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LAST_LOGIN_PER_DAY_VIEW", "ART_DB");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_TYPE");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Logindatetime)
                .HasColumnType("datetime")
                .HasColumnName("LOGINDATETIME");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });
            modelBuilder.Entity<ListGroupsRolesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_GROUPS_ROLES_SUMMARY", "ART_DB");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });
            modelBuilder.Entity<ListGroupsSubGroupsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_GROUPS_SUB_GROUPS_SUMMARY", "ART_DB");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.SubGroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUB_GROUP_NAME");
            });
            modelBuilder.Entity<ListOfDeletedUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_DELTED_USERS", "ART_DB");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });
            modelBuilder.Entity<ListOfGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_GROUPS", "ART_DB");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_name");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("group_type");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");
            });
            modelBuilder.Entity<ListOfRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_ROLES", "ART_DB");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_type");
            });
            modelBuilder.Entity<ListOfUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS", "ART_DB");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CounterLock).HasColumnName("counter_lock");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("display_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enable).HasColumnName("enable");

                entity.Property(e => e.LastFailedLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("last_failed_login");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_updated_by");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_updated_date");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });
            modelBuilder.Entity<ListOfUsersAndGroupsRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_AND_GROUPS_ROLES", "ART_DB");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.RoleOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });
            modelBuilder.Entity<ListOfUsersGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_GROUPS", "ART_DB");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });
            modelBuilder.Entity<ListOfUsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_ROLES", "ART_DB");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_ROLE");
            });




        }

        public void OnSegmentionModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART");

            modelBuilder.Entity<ArtAlertsPerSegmentTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALERTS_PER_SEGMENT_TB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfAlerts)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_ALERTS");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_DESCRIPTION");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<ArtAllSegmentCustCountTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGMENT_CUST_COUNT_TB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_DESCRIPTION");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<ArtAllSegmentsOutliersTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGMENTS_OUTLIERS_TB");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.Feature)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("FEATURE");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                entity.Property(e => e.UpperOutlierLimit)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UPPER_OUTLIER_LIMIT");
            });

            modelBuilder.Entity<ArtAllSegsFeatrsStatcsTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGS_FEATRS_STATCS_TB");

                entity.Property(e => e.AvgCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_C_AMT");

                entity.Property(e => e.AvgCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_D_AMT");

                entity.Property(e => e.AvgCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_D_AMT");

                entity.Property(e => e.AvgFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_FEES_D_AMT");

                entity.Property(e => e.AvgInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.AvgInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.AvgMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_C_AMT");

                entity.Property(e => e.AvgTotalAmt)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("AVG_TOTAL_AMT");

                entity.Property(e => e.AvgTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_CT_AMT");

                entity.Property(e => e.AvgTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_DT_AMT");

                entity.Property(e => e.AvgWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_C_AMT");

                entity.Property(e => e.AvgWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_D_AMT");

                entity.Property(e => e.AvgWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MaxCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_C_AMT");

                entity.Property(e => e.MaxCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_D_AMT");

                entity.Property(e => e.MaxCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_D_AMT");

                entity.Property(e => e.MaxFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_FEES_D_AMT");

                entity.Property(e => e.MaxInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MaxInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MaxMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_C_AMT");

                entity.Property(e => e.MaxTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_AMT");

                entity.Property(e => e.MaxTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_CT_AMT");

                entity.Property(e => e.MaxTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_DT_AMT");

                entity.Property(e => e.MaxWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_C_AMT");

                entity.Property(e => e.MaxWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_D_AMT");

                entity.Property(e => e.MaxWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MinCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_C_AMT");

                entity.Property(e => e.MinCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_D_AMT");

                entity.Property(e => e.MinCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_D_AMT");

                entity.Property(e => e.MinFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_FEES_D_AMT");

                entity.Property(e => e.MinInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MinInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MinMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_C_AMT");

                entity.Property(e => e.MinTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_AMT");

                entity.Property(e => e.MinTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_CT_AMT");

                entity.Property(e => e.MinTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_DT_AMT");

                entity.Property(e => e.MinWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_C_AMT");

                entity.Property(e => e.MinWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_D_AMT");

                entity.Property(e => e.MinWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentDescription)
                    .HasColumnName("SEGMENT_DESCRIPTION");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_AMT");

                entity.Property(e => e.TotalCashCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_CNT");

                entity.Property(e => e.TotalCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_AMT");

                entity.Property(e => e.TotalCashDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_CNT");

                entity.Property(e => e.TotalCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_AMT");

                entity.Property(e => e.TotalCheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_CNT");

                entity.Property(e => e.TotalCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CNT");

                entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalCtCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CT_CNT");

                entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");

                entity.Property(e => e.TotalDebitCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_CNT");

                entity.Property(e => e.TotalFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_FEES_D_AMT");

                entity.Property(e => e.TotalFeesDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_FEES_D_CNT");

                entity.Property(e => e.TotalInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.TotalInternaltransferCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                entity.Property(e => e.TotalInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.TotalInternaltransferDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                entity.Property(e => e.TotalMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_AMT");

                entity.Property(e => e.TotalMiscCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_CNT");

                entity.Property(e => e.TotalWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_AMT");

                entity.Property(e => e.TotalWireCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_CNT");

                entity.Property(e => e.TotalWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_AMT");

                entity.Property(e => e.TotalWireDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_CNT");

                entity.Property(e => e.TotalWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WITHDRAWAL_D_AMT");

                entity.Property(e => e.TotalWithdrawalDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WITHDRAWAL_D_CNT");
            });

            modelBuilder.Entity<ArtAllSegsOutliersLimitTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_ALL_SEGS_OUTLIERS_LIMIT_TB");

                entity.Property(e => e.Feature)
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasColumnName("FEATURE");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                entity.Property(e => e.UpperOutlierLimit)
                    .HasColumnType("NUMBER")
                    .HasColumnName("UPPER_OUTLIER_LIMIT");
            });

            modelBuilder.Entity<ArtChangedSegmentTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_CHANGED_SEGMENT_TB");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.LastSegmentId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LAST_SEGMENT_ID");

                entity.Property(e => e.MonthKey)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                entity.Property(e => e.PartyNumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.RiskClassification)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.SegmentSorted)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<ArtCustsPerTypeTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_CUSTS_PER_TYPE_TB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<ArtIndustrySegmentTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_INDUSTRY_SEGMENT_TB");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");
            });

            modelBuilder.Entity<ArtMebSegmentsV3Tb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_MEB_SEGMENTS_V3_TB");

                entity.Property(e => e.AlertsCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.AvgCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_C_AMT");

                entity.Property(e => e.AvgCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_D_AMT");

                entity.Property(e => e.AvgCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_D_AMT");

                entity.Property(e => e.AvgFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_FEES_D_AMT");

                entity.Property(e => e.AvgInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.AvgInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.AvgMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_C_AMT");

                entity.Property(e => e.AvgTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_AMT");

                entity.Property(e => e.AvgTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_CT_AMT");

                entity.Property(e => e.AvgTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TOTAL_DT_AMT");

                entity.Property(e => e.AvgWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_C_AMT");

                entity.Property(e => e.AvgWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_D_AMT");

                entity.Property(e => e.AvgWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WITHDRAWAL_D_AMT");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.MaxCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_C_AMT");

                entity.Property(e => e.MaxCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_D_AMT");

                entity.Property(e => e.MaxCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_D_AMT");

                entity.Property(e => e.MaxFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_FEES_D_AMT");

                entity.Property(e => e.MaxInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MaxInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MaxMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_C_AMT");

                entity.Property(e => e.MaxMls)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MLS");

                entity.Property(e => e.MaxTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_AMT");

                entity.Property(e => e.MaxTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_CT_AMT");

                entity.Property(e => e.MaxTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TOTAL_DT_AMT");

                entity.Property(e => e.MaxWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_C_AMT");

                entity.Property(e => e.MaxWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_D_AMT");

                entity.Property(e => e.MaxWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MinCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_C_AMT");

                entity.Property(e => e.MinCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_D_AMT");

                entity.Property(e => e.MinCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_D_AMT");

                entity.Property(e => e.MinFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_FEES_D_AMT");

                entity.Property(e => e.MinInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MinInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MinMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_C_AMT");

                entity.Property(e => e.MinTotalAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_AMT");

                entity.Property(e => e.MinTotalCtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_CT_AMT");

                entity.Property(e => e.MinTotalDtAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TOTAL_DT_AMT");

                entity.Property(e => e.MinWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_C_AMT");

                entity.Property(e => e.MinWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_D_AMT");

                entity.Property(e => e.MinWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WITHDRAWAL_D_AMT");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                entity.Property(e => e.PartyNumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.RiskClassification)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_AMT");

                entity.Property(e => e.TotalCashCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_CNT");

                entity.Property(e => e.TotalCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_AMT");

                entity.Property(e => e.TotalCashDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_CNT");

                entity.Property(e => e.TotalCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_AMT");

                entity.Property(e => e.TotalCheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_CNT");

                entity.Property(e => e.TotalCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CNT");

                entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalCtCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CT_CNT");

                entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");

                entity.Property(e => e.TotalDebitCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_CNT");

                entity.Property(e => e.TotalFeesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_FEES_D_AMT");

                entity.Property(e => e.TotalFeesDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_FEES_D_CNT");

                entity.Property(e => e.TotalInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.TotalInternaltransferCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                entity.Property(e => e.TotalInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.TotalInternaltransferDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                entity.Property(e => e.TotalMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_AMT");

                entity.Property(e => e.TotalMiscCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_CNT");

                entity.Property(e => e.TotalWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_AMT");

                entity.Property(e => e.TotalWireCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_CNT");

                entity.Property(e => e.TotalWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_AMT");

                entity.Property(e => e.TotalWireDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_CNT");

                entity.Property(e => e.TotalWithdrawalDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WITHDRAWAL_D_AMT");

                entity.Property(e => e.TotalWithdrawalDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WITHDRAWAL_D_CNT");
            });

            modelBuilder.Entity<ArtSegoutvsallcustTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_SEGOUTVSALLCUST_TB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfCustomers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_CUSTOMERS");

                entity.Property(e => e.NumberOfOutliers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_OUTLIERS");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<ArtSegoutvsalloutTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_SEGOUTVSALLOUT_TB");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfOutliers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_OUTLIERS");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.SegmentSorted)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT_SORTED");

                entity.Property(e => e.TotalNumberOfOutliers)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_NUMBER_OF_OUTLIERS");
            });

        }
        public void OnARTGOAMLModelCreating(ModelBuilder modelBuilder)
        {
            //GOAML
            modelBuilder.Entity<ArtGoamlReportsDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GOAML_REPORTS_DETAILS", "ART");

                entity.Property(e => e.Action)
                    .HasColumnName("ACTION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Currencycodelocal)
                    .HasMaxLength(255)
                    .HasColumnName("CURRENCYCODELOCAL")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Entityreference)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITYREFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Fiurefnumber)
                    .HasMaxLength(255)
                    .HasColumnName("FIUREFNUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Isvalid).HasColumnName("ISVALID");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("LOCATION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .HasColumnName("PRIORITY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reason)
                    .HasMaxLength(4000)
                    .HasColumnName("REASON")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Rentitybranch)
                    .HasMaxLength(255)
                    .HasColumnName("RENTITYBRANCH")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Rentityid).HasColumnName("RENTITYID");

                entity.Property(e => e.Reportcloseddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.Reportcode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcreatedby)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCREATEDBY")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcreateddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.Reportingpersontype)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTINGPERSONTYPE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportrisksignificance)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTRISKSIGNIFICANCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportstatuscode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTSTATUSCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportuserlockid)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTUSERLOCKID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportxml)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTXML")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Submissioncode)
                    .HasMaxLength(255)
                    .HasColumnName("SUBMISSIONCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Submissiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .HasColumnName("VERSION")
                    .UseCollation("Arabic_100_CI_AI");
            });

            modelBuilder.Entity<ArtGoamlReportsIndicator>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GOAML_REPORTS_INDICATORS", "ART");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("DESCRIPTION")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Indicator)
                    .HasMaxLength(255)
                    .HasColumnName("INDICATOR")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.ReportId).HasColumnName("REPORT_ID");
            });

            modelBuilder.Entity<ArtGoamlReportsSusbectParty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GOAML_REPORTS_SUSBECT_PARTIES", "ART");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .HasColumnName("ACCOUNT")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Activity)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .HasColumnName("BRANCH")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Entityreference)
                    .HasMaxLength(255)
                    .HasColumnName("ENTITYREFERENCE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Fiurefnumber)
                    .HasMaxLength(255)
                    .HasColumnName("FIUREFNUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PartyId)
                    .HasMaxLength(255)
                    .HasColumnName("PARTY_ID")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(765)
                    .HasColumnName("PARTY_NAME")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Partynumber)
                    .HasMaxLength(255)
                    .HasColumnName("PARTYNUMBER")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcloseddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.Reportcode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Reportcreateddate)
                    .HasColumnType("datetime")
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.Reportstatuscode)
                    .HasMaxLength(255)
                    .HasColumnName("REPORTSTATUSCODE")
                    .UseCollation("Arabic_100_CI_AI");

                entity.Property(e => e.Submissiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Transactionnumber)
                    .HasMaxLength(255)
                    .HasColumnName("TRANSACTIONNUMBER")
                    .UseCollation("Arabic_100_CI_AI");
            });
        }

        public void OnARTDGAMLModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnEcmModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART");
            //ECM
            modelBuilder.Entity<ArtHomeCasesDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_DATE");

                entity.Property(e => e.Day)
                    .HasColumnType("int")
                    .HasColumnName("DAY");

                entity.Property(e => e.Month)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("MONTH");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");

                entity.Property(e => e.Year)
                    .HasColumnType("int")
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<ArtHomeCasesStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_STATUS");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");
            });

            modelBuilder.Entity<ArtHomeCasesType>(entity =>
            {

                entity.HasNoKey();

                entity.ToView("ART_HOME_CASES_TYPES");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.NumberOfCases)
                    .HasColumnType("int")
                    .HasColumnName("NUMBER_OF_CASES");
            });

            modelBuilder.Entity<ArtSystemPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SYSTEM_PERFORMANCE");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DESC");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CreateUserId)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");
                entity.Property(e => e.CaseRk)
                    .IsUnicode(false)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CaseType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.ClientName)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.ValidFromDate)
                    .HasPrecision(6)
                    .HasColumnName("VALID_FROM_DATE");

                entity.Property(e => e.DurationsInDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.EcmLastStatusDate)
                    .HasPrecision(6)
                    .HasColumnName("ECM_LAST_STATUS_DATE");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HITS_COUNT");

                entity.Property(e => e.IdentityNum)
                    .IsUnicode(false)
                    .HasColumnName("IDENTITY_NUM");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INVESTR_USER_ID");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Priority)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY");



                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT_REFERENCE");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_DIRECTION");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.LastComment)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("LAST_COMMENT");
                entity.Property(e => e.LastCommentSubject)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("LAST_COMMENT_SUBJECT");
                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_DATE");
                entity.Property(e => e.CreatedBy)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("CREATED_BY");
                entity.Property(e => e.NumberOfComment)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_COMMENTS");
                entity.Property(e => e.NumberOfAttachments)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_ATTACHMENTS");
            });

            modelBuilder.Entity<ArtAlertedEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ALERTED_ENTITY");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Name)
                    .HasColumnType("CLOB")
                    .HasColumnName("NAME");

                entity.Property(e => e.PepInd)
                    .HasColumnType("CLOB")
                    .HasColumnName("PEP_IND");
                entity.Property(e => e.LastComment)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("LAST_COMMENT");
                entity.Property(e => e.LastCommentSubject)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("LAST_COMMENT_SUBJECT");
                entity.Property(e => e.UpdatedDate)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_DATE");
                entity.Property(e => e.CreatedBy)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("CREATED_BY");
                entity.Property(e => e.NumberOfComment)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_COMMENTS");
                entity.Property(e => e.NumberOfAttachments)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_ATTACHMENTS");
            });

            modelBuilder.Entity<ArtUserPerformance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_USER_PERFORMANCE", "ART");

                entity.Property(e => e.Action)
                    .HasMaxLength(256)
                    .HasColumnName("ACTION");

                entity.Property(e => e.ActionUser)
                    .HasMaxLength(60)
                    .HasColumnName("ACTION_USER");

                entity.Property(e => e.AsssignedTime)

                    .HasColumnName("ASSSIGNED_TIME");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .HasColumnName("CASE_DESC");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseRk)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(4000)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("CASE_TYPE_CD");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.DurationsInDays).HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours).HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes).HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds).HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Priority)
                    .HasMaxLength(4000)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.ReleasedDate)
                    .HasColumnName("RELEASED_DATE");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.ValidFromDate)

                    .HasColumnName("VALID_FROM_DATE");
            });

            modelBuilder.Entity<ArtSystemPerformanceNcba>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_SYSTEM_PERFORMANCE_NCBA");

                entity.Property(e => e.CaseDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DESC");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseTtpe)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_TTPE");

                entity.Property(e => e.ClientName)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CLIENT_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DurationsInDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_DAYS");

                entity.Property(e => e.DurationsInHours)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_HOURS");

                entity.Property(e => e.DurationsInMinutes)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_MINUTES");

                entity.Property(e => e.DurationsInSeconds)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATIONS_IN_SECONDS");

                entity.Property(e => e.EcmLastStatusDate)
                    .HasPrecision(6)
                    .HasColumnName("ECM_LAST_STATUS_DATE");

                entity.Property(e => e.HitsCount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HITS_COUNT");

                entity.Property(e => e.IdentityNum)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("IDENTITY_NUM");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.Priority)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.SwiftReference)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT_REFERENCE");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.TransactionDirection)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_DIRECTION");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_TYPE");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");
            });
        }

        public void OnSasAmlModelCreating(ModelBuilder modelBuilder)
        {
            //AML
            modelBuilder.Entity<ArtHomeAlertsPerDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_ALERTS_PER_DATE".ToUpper(), "ART");

                entity.Property(e => e.Month).HasMaxLength(4000);

                entity.Property(e => e.NumberOfAlerts).HasColumnName("Number_Of_ALerts".ToUpper());
                entity.Property(e => e.Day)
                   .HasColumnName("DAY");

                entity.Property(e => e.Month)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("MONTH");

                entity.Property(e => e.NumberOfAlerts)
                    .HasColumnName("NUMBER_OF_ALERTS");
                entity.Property(e => e.Year)
                    .HasColumnName("YEAR");
            });

            modelBuilder.Entity<ArtHomeAlertsPerStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_ALERTS_PER_STATUS".ToUpper(), "ART");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(100)
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertsCount).HasColumnName("Alerts_Count".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_Number_Of_Accounts".ToUpper(), "ART");

                entity.Property(e => e.NumberOfAccounts).HasColumnName("Number_Of_Accounts".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_HOME_NUMBER_OF_CUSTOMERS".ToUpper(), "ART");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("Number_Of_Customers".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfHighRiskCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_NUMBER_OF_High_Risk_CUSTS".ToUpper(), "ART");

                entity.Property(e => e.NumberOfHighRiskCustomers).HasColumnName("Number_Of_High_Risk_Customers".ToUpper());
            });

            modelBuilder.Entity<ArtHomeNumberOfPepCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_NUMBER_OF_PEP_CUSTOMERS".ToUpper(), "ART");

                entity.Property(e => e.NumberOfPepCustomers).HasColumnName("Number_Of_PEP_Customers".ToUpper());
            });

            modelBuilder.Entity<ArtAmlTriageView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_TRIAGE_VIEW");

                entity.Property(e => e.AgeOldestAlert)
                    .HasPrecision(4)
                    .HasColumnName("AGE_OLDEST_ALERT");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("NUMBER(15,3)")
                    .HasColumnName("AGGREGATE_AMT");

                entity.Property(e => e.AlertedEntityLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_LEVEL");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.AlertsCnt)
                    .HasPrecision(4)
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.RiskScore)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_SCORE");
            });
            modelBuilder.Entity<ArtAmlAlertDetailView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_ALERT_DETAIL_VIEW");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTUAL_VALUES_TEXT");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_DESCRIPTION");

                entity.Property(e => e.AlertId)
                    .HasPrecision(12)
                    .HasColumnName("ALERT_ID");

                entity.Property(e => e.AlertStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_STATUS");

                entity.Property(e => e.AlertSubCat)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_SUB_CAT");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_TYPE_CD");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.InvestigationDays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INVESTIGATION_DAYS");

                entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasPrecision(3)
                    .HasColumnName("MONEY_LAUNDERING_RISK_SCORE");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND");

                entity.Property(e => e.ReportCloseRsn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_CLOSE_RSN");

                entity.Property(e => e.RunDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_DATE");

                entity.Property(e => e.ScenarioId)
                    .HasPrecision(12)
                    .HasColumnName("SCENARIO_ID");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_NAME");
            });
            modelBuilder.Entity<ArtAmlCustomersDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_CUSTOMERS_DETAILS_VIEW");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLG")
                    .IsFixedLength();

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasPrecision(10)
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CITY_NAME");

                entity.Property(e => e.CustomerDateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("CUSTOMER_DATE_OF_BIRTH");

                entity.Property(e => e.CustomerIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_IDENTIFICATION_ID");

                entity.Property(e => e.CustomerIdentificationType)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_IDENTIFICATION_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NUMBER");

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CUSTOMER_SINCE_DATE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.CustomerTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TAX_ID");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NUMBER");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_NAME");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                entity.Property(e => e.GovernorateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GOVERNORATE_NAME");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.IsEmployee)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IS_EMPLOYEE")
                    .IsFixedLength();

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_COUNTRY_NAME");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_POSTAL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS_DESC");

                entity.Property(e => e.NetWorthAmount)
                    .HasPrecision(10)
                    .HasColumnName("NET_WORTH_AMOUNT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORG_IND")
                    .IsFixedLength();

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_2");

                entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_3");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_NAME");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STREET_POSTAL_CODE")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ArtAmlCaseDetailsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_CASE_DETAILS_VIEW");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CaseCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CATEGORY");

                entity.Property(e => e.CaseId)
                    .HasPrecision(12)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CasePriority)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_PRIORITY");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseSubCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_SUB_CATEGORY");

                entity.Property(e => e.ClosedDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSED_DATE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.EntityLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_LEVEL");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.EntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NUMBER");

                entity.Property(e => e.Owner)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER");
            });
            modelBuilder.Entity<ArtAmlHighRiskCustView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_HIGH_RISK_CUST_VIEW");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("PARTY_DATE_OF_BIRTH");

                entity.Property(e => e.PartyIdentificationId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_ID");

                entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_TYPE_DESC")
                    .IsFixedLength();

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTaxId)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TAX_ID");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND");

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.RiskClassification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_CITY_NAME");
            });
            modelBuilder.Entity<ArtRiskAssessmentView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_RISK_ASSESSMENT_VIEW");

                entity.Property(e => e.AssessmentCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_CATEGORY_CD");

                entity.Property(e => e.AssessmentSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_SUBCATEGORY_CD");

                entity.Property(e => e.AssessmentTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_TYPE_CD");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.OwnerUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USER_LONG_ID");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.ProposedRiskClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROPOSED_RISK_CLASS");

                entity.Property(e => e.RiskAssessmentDuration)
                    .HasPrecision(3)
                    .HasColumnName("RISK_ASSESSMENT_DURATION");

                entity.Property(e => e.RiskAssessmentId)
                    .HasPrecision(12)
                    .HasColumnName("RISK_ASSESSMENT_ID");

                entity.Property(e => e.RiskClass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS");

                entity.Property(e => e.RiskStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RISK_STATUS");

                entity.Property(e => e.VersionNumber)
                    .HasPrecision(10)
                    .HasColumnName("VERSION_NUMBER");
            });


        }

        public void OnAuditModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtGroupsAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_GROUPS_AUDIT_VIEW");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(9)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasPrecision(9)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.MemberUsers)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_USERS");

                entity.Property(e => e.RoleNames)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAMES");

                entity.Property(e => e.SubGroupNames)
                    .IsUnicode(false)
                    .HasColumnName("SUB_GROUP_NAMES");
            });

            modelBuilder.Entity<ArtRolesAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ROLES_AUDIT_VIEW");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(9)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.GroupNames)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAMES");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasPrecision(9)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.MemberUsers)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_USERS");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<ArtUsersAuditView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_USERS_AUDIT_VIEW");

                entity.Property(e => e.Action)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasPrecision(9)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.DomainAccounts)
                    .IsUnicode(false)
                    .HasColumnName("DOMAIN_ACCOUNTS");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enable)
                    .HasPrecision(1)
                    .HasColumnName("ENABLE");

                entity.Property(e => e.GroupNames)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAMES");

                entity.Property(e => e.LastFailedLogin)
                    .HasPrecision(9)
                    .HasColumnName("LAST_FAILED_LOGIN");

                entity.Property(e => e.LastLoginDate)
                    .HasPrecision(9)
                    .HasColumnName("LAST_LOGIN_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasPrecision(9)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.RoleNames)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAMES");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<LastLoginPerDayView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LAST_LOGIN_PER_DAY_VIEW");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_TYPE");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Logindatetime)
                    .HasPrecision(6)
                    .HasColumnName("LOGINDATETIME");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<ListGroupsRolesSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_GROUPS_ROLES_SUMMARY");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<ListGroupsSubGroupsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_GROUPS_SUB_GROUPS_SUMMARY");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.SubGroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUB_GROUP_NAME");
            });

            modelBuilder.Entity<ListOfDeletedUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_DELTED_USERS");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_FAILED_LOGIN");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_LOGIN_DATE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");
            });

            modelBuilder.Entity<ListOfGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_GROUPS");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_TYPE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");
            });

            modelBuilder.Entity<ListOfRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_ROLES");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_TYPE");
            });

            modelBuilder.Entity<ListOfUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS");

                entity.Property(e => e.Active)
                    .HasPrecision(1)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CounterLock)
                    .HasPrecision(10)
                    .HasColumnName("COUNTER_LOCK");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enable)
                    .HasPrecision(1)
                    .HasColumnName("ENABLE");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_FAILED_LOGIN");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_LOGIN_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");
            });

            modelBuilder.Entity<ListOfUsersAndGroupsRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_AND_GROUPS_ROLES");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.RoleOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<ListOfUsersGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_GROUPS");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.MemberOfGroup)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMBER_OF_GROUP");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<ListOfUsersRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LIST_OF_USERS_ROLES");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_ROLE");
            });
        }

        public void OnAmlAnalysisModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART");

            modelBuilder.Entity<ArtAlertsStatusCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_ALERTS_STATUS_CUSTOMER");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.ClosedAlertsCount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLOSED_ALERTS_COUNT");
            });

            modelBuilder.Entity<ArtAmlAnalysisView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AML_ANALYSIS_VIEW");

                entity.Property(e => e.AlertsCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.AlertsCount)
                    .HasPrecision(6)
                    .HasColumnName("ALERTS_COUNT");

                entity.Property(e => e.AvgBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_BUYSECURITY_C_AMT");

                entity.Property(e => e.AvgCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_C_AMT");

                entity.Property(e => e.AvgCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_D_AMT");

                entity.Property(e => e.AvgCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_D_AMT");

                entity.Property(e => e.AvgClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.AvgClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.AvgDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_DERIVATIVES_C_AMT");

                entity.Property(e => e.AvgDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_DERIVATIVES_D_AMT");

                entity.Property(e => e.AvgInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INHOUSECHECK_C_AMT");

                entity.Property(e => e.AvgInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INHOUSECHECK_D_AMT");

                entity.Property(e => e.AvgInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.AvgInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.AvgLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.AvgLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.AvgLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LCCOLLECTION_C_AMT");

                entity.Property(e => e.AvgLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LCCOLLECTION_D_AMT");

                entity.Property(e => e.AvgLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOAN_C_AMT");

                entity.Property(e => e.AvgLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOAN_D_AMT");

                entity.Property(e => e.AvgLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.AvgLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOANTOP_UP_C_AMT");

                entity.Property(e => e.AvgMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_C_AMT");

                entity.Property(e => e.AvgMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_D_AMT");

                entity.Property(e => e.AvgMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.AvgMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.AvgOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.AvgPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.AvgReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.AvgReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.AvgSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SALARYCREDIT_C_AMT");

                entity.Property(e => e.AvgSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SALARYDEBIT_D_AMT");

                entity.Property(e => e.AvgSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SECURITIES_C_AMT");

                entity.Property(e => e.AvgSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SECURITIES_D_AMT");

                entity.Property(e => e.AvgSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SELLSECURITY_D_AMT");

                entity.Property(e => e.AvgTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TDREDEMPTION_C_AMT");

                entity.Property(e => e.AvgTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TDREDEMPTION_D_AMT");

                entity.Property(e => e.AvgTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.AvgTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.AvgTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TTISSUANCE_D_AMT");

                entity.Property(e => e.AvgWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_C_AMT");

                entity.Property(e => e.AvgWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_D_AMT");

                entity.Property(e => e.ClosedAlertsCount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLOSED_ALERTS_COUNT");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.MaxBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_BUYSECURITY_C_AMT");

                entity.Property(e => e.MaxCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_C_AMT");

                entity.Property(e => e.MaxCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_D_AMT");

                entity.Property(e => e.MaxCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_D_AMT");

                entity.Property(e => e.MaxClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.MaxClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.MaxDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_DERIVATIVES_C_AMT");

                entity.Property(e => e.MaxDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_DERIVATIVES_D_AMT");

                entity.Property(e => e.MaxInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INHOUSECHECK_C_AMT");

                entity.Property(e => e.MaxInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INHOUSECHECK_D_AMT");

                entity.Property(e => e.MaxInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MaxInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MaxLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.MaxLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.MaxLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LCCOLLECTION_C_AMT");

                entity.Property(e => e.MaxLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LCCOLLECTION_D_AMT");

                entity.Property(e => e.MaxLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOAN_C_AMT");

                entity.Property(e => e.MaxLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOAN_D_AMT");

                entity.Property(e => e.MaxLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.MaxLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOANTOP_UP_C_AMT");

                entity.Property(e => e.MaxMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_C_AMT");

                entity.Property(e => e.MaxMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_D_AMT");

                entity.Property(e => e.MaxMls)
                    .HasPrecision(6)
                    .HasColumnName("MAX_MLS");

                entity.Property(e => e.MaxMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.MaxMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.MaxOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.MaxPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.MaxReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.MaxReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.MaxSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SALARYCREDIT_C_AMT");

                entity.Property(e => e.MaxSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SALARYDEBIT_D_AMT");

                entity.Property(e => e.MaxSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SECURITIES_C_AMT");

                entity.Property(e => e.MaxSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SECURITIES_D_AMT");

                entity.Property(e => e.MaxSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SELLSECURITY_D_AMT");

                entity.Property(e => e.MaxTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TDREDEMPTION_C_AMT");

                entity.Property(e => e.MaxTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TDREDEMPTION_D_AMT");

                entity.Property(e => e.MaxTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.MaxTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.MaxTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TTISSUANCE_D_AMT");

                entity.Property(e => e.MaxWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_C_AMT");

                entity.Property(e => e.MaxWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_D_AMT");

                entity.Property(e => e.MinBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_BUYSECURITY_C_AMT");

                entity.Property(e => e.MinCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_C_AMT");

                entity.Property(e => e.MinCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_D_AMT");

                entity.Property(e => e.MinCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_D_AMT");

                entity.Property(e => e.MinClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.MinClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.MinDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_DERIVATIVES_C_AMT");

                entity.Property(e => e.MinDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_DERIVATIVES_D_AMT");

                entity.Property(e => e.MinInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INHOUSECHECK_C_AMT");

                entity.Property(e => e.MinInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INHOUSECHECK_D_AMT");

                entity.Property(e => e.MinInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MinInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MinLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.MinLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.MinLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LCCOLLECTION_C_AMT");

                entity.Property(e => e.MinLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LCCOLLECTION_D_AMT");

                entity.Property(e => e.MinLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOAN_C_AMT");

                entity.Property(e => e.MinLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOAN_D_AMT");

                entity.Property(e => e.MinLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.MinLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOANTOP_UP_C_AMT");

                entity.Property(e => e.MinMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_C_AMT");

                entity.Property(e => e.MinMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_D_AMT");

                entity.Property(e => e.MinMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.MinMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.MinOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.MinPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.MinReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.MinReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.MinSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SALARYCREDIT_C_AMT");

                entity.Property(e => e.MinSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SALARYDEBIT_D_AMT");

                entity.Property(e => e.MinSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SECURITIES_C_AMT");

                entity.Property(e => e.MinSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SECURITIES_D_AMT");

                entity.Property(e => e.MinSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SELLSECURITY_D_AMT");

                entity.Property(e => e.MinTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TDREDEMPTION_C_AMT");

                entity.Property(e => e.MinTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TDREDEMPTION_D_AMT");

                entity.Property(e => e.MinTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.MinTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.MinTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TTISSUANCE_D_AMT");

                entity.Property(e => e.MinWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_C_AMT");

                entity.Property(e => e.MinWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_D_AMT");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfLocations)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_LOCATIONS");

                entity.Property(e => e.OccupationCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_CODE");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.Prediction)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PREDICTION");

                entity.Property(e => e.RiskClassification)
                    .HasPrecision(1)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_BUYSECURITY_C_AMT");

                entity.Property(e => e.TotalBuysecurityCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_BUYSECURITY_C_CNT");

                entity.Property(e => e.TotalCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_AMT");

                entity.Property(e => e.TotalCashCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_CNT");

                entity.Property(e => e.TotalCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_AMT");

                entity.Property(e => e.TotalCashDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_CNT");

                entity.Property(e => e.TotalCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_AMT");

                entity.Property(e => e.TotalCheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_CNT");

                entity.Property(e => e.TotalClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.TotalClearingcheckCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_C_CNT");

                entity.Property(e => e.TotalClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.TotalClearingcheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_D_CNT");

                entity.Property(e => e.TotalCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CNT");

                entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalCreditCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_CNT");

                entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");

                entity.Property(e => e.TotalDebitCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_CNT");

                entity.Property(e => e.TotalDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_C_AMT");

                entity.Property(e => e.TotalDerivativesCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_C_CNT");

                entity.Property(e => e.TotalDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_D_AMT");

                entity.Property(e => e.TotalDerivativesDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_D_CNT");

                entity.Property(e => e.TotalInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_C_AMT");

                entity.Property(e => e.TotalInhousecheckCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_C_CNT");

                entity.Property(e => e.TotalInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_D_AMT");

                entity.Property(e => e.TotalInhousecheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_D_CNT");

                entity.Property(e => e.TotalInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.TotalInternaltransferCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                entity.Property(e => e.TotalInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.TotalInternaltransferDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                entity.Property(e => e.TotalLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.TotalLcBlClcnCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_CNT");

                entity.Property(e => e.TotalLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.TotalLcBlClcnDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_CNT");

                entity.Property(e => e.TotalLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_C_AMT");

                entity.Property(e => e.TotalLccollectionCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_C_CNT");

                entity.Property(e => e.TotalLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_D_AMT");

                entity.Property(e => e.TotalLccollectionDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_D_CNT");

                entity.Property(e => e.TotalLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_C_AMT");

                entity.Property(e => e.TotalLoanCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_C_CNT");

                entity.Property(e => e.TotalLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_D_AMT");

                entity.Property(e => e.TotalLoanDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_D_CNT");

                entity.Property(e => e.TotalLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.TotalLoandisbursementCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANDISBURSEMENT_C_CNT");

                entity.Property(e => e.TotalLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANTOP_UP_C_AMT");

                entity.Property(e => e.TotalLoantopUpCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANTOP_UP_C_CNT");

                entity.Property(e => e.TotalMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_AMT");

                entity.Property(e => e.TotalMiscCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_CNT");

                entity.Property(e => e.TotalMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_AMT");

                entity.Property(e => e.TotalMiscDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_CNT");

                entity.Property(e => e.TotalMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.TotalMngrschckissnceCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_C_CNT");

                entity.Property(e => e.TotalMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.TotalMngrschckissnceDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_D_CNT");

                entity.Property(e => e.TotalOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.TotalOutwrdchqrtrnDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_OUTWRDCHQRTRN_D_CNT");

                entity.Property(e => e.TotalPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.TotalPymntofinstllmntDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_PYMNTOFINSTLLMNT_D_CNT");

                entity.Property(e => e.TotalReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.TotalReturnchequeCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNCHEQUE_C_CNT");

                entity.Property(e => e.TotalReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.TotalReturnedwiresDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNEDWIRES_D_CNT");

                entity.Property(e => e.TotalSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYCREDIT_C_AMT");

                entity.Property(e => e.TotalSalarycreditCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYCREDIT_C_CNT");

                entity.Property(e => e.TotalSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYDEBIT_D_AMT");

                entity.Property(e => e.TotalSalarydebitDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYDEBIT_D_CNT");

                entity.Property(e => e.TotalSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_C_AMT");

                entity.Property(e => e.TotalSecuritiesCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_C_CNT");

                entity.Property(e => e.TotalSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_D_AMT");

                entity.Property(e => e.TotalSecuritiesDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_D_CNT");

                entity.Property(e => e.TotalSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SELLSECURITY_D_AMT");

                entity.Property(e => e.TotalSellsecurityDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SELLSECURITY_D_CNT");

                entity.Property(e => e.TotalTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_C_AMT");

                entity.Property(e => e.TotalTdredemptionCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_C_CNT");

                entity.Property(e => e.TotalTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_D_AMT");

                entity.Property(e => e.TotalTdredemptionDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_D_CNT");

                entity.Property(e => e.TotalTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.TotalTermdepositCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_C_CNT");

                entity.Property(e => e.TotalTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.TotalTermdepositDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_D_CNT");

                entity.Property(e => e.TotalTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TTISSUANCE_D_AMT");

                entity.Property(e => e.TotalTtissuanceDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TTISSUANCE_D_CNT");

                entity.Property(e => e.TotalWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_AMT");

                entity.Property(e => e.TotalWireCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_CNT");

                entity.Property(e => e.TotalWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_AMT");

                entity.Property(e => e.TotalWireDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_CNT");
                entity.Property(e => e.Segment)
                 .HasColumnType("NUMBER")
                 .HasColumnName("SEGMENT");

                entity.Property(e => e.SegmentSorted)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<ArtAmlAnalysisViewTb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ART_AML_ANALYSIS_VIEW_TB");

                entity.Property(e => e.AlertsCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.AlertsCount)
                    .HasPrecision(6)
                    .HasColumnName("ALERTS_COUNT");

                entity.Property(e => e.AvgBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_BUYSECURITY_C_AMT");

                entity.Property(e => e.AvgCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_C_AMT");

                entity.Property(e => e.AvgCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CASH_D_AMT");

                entity.Property(e => e.AvgCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CHECK_D_AMT");

                entity.Property(e => e.AvgClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.AvgClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.AvgDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_DERIVATIVES_C_AMT");

                entity.Property(e => e.AvgDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_DERIVATIVES_D_AMT");

                entity.Property(e => e.AvgInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INHOUSECHECK_C_AMT");

                entity.Property(e => e.AvgInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INHOUSECHECK_D_AMT");

                entity.Property(e => e.AvgInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.AvgInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.AvgLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.AvgLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.AvgLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LCCOLLECTION_C_AMT");

                entity.Property(e => e.AvgLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LCCOLLECTION_D_AMT");

                entity.Property(e => e.AvgLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOAN_C_AMT");

                entity.Property(e => e.AvgLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOAN_D_AMT");

                entity.Property(e => e.AvgLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.AvgLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_LOANTOP_UP_C_AMT");

                entity.Property(e => e.AvgMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_C_AMT");

                entity.Property(e => e.AvgMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MISC_D_AMT");

                entity.Property(e => e.AvgMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.AvgMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.AvgOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.AvgPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.AvgReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.AvgReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.AvgSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SALARYCREDIT_C_AMT");

                entity.Property(e => e.AvgSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SALARYDEBIT_D_AMT");

                entity.Property(e => e.AvgSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SECURITIES_C_AMT");

                entity.Property(e => e.AvgSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SECURITIES_D_AMT");

                entity.Property(e => e.AvgSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_SELLSECURITY_D_AMT");

                entity.Property(e => e.AvgTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TDREDEMPTION_C_AMT");

                entity.Property(e => e.AvgTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TDREDEMPTION_D_AMT");

                entity.Property(e => e.AvgTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.AvgTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.AvgTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_TTISSUANCE_D_AMT");

                entity.Property(e => e.AvgWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_C_AMT");

                entity.Property(e => e.AvgWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AVG_WIRE_D_AMT");

                entity.Property(e => e.ClosedAlertsCount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CLOSED_ALERTS_COUNT");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.MaxBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_BUYSECURITY_C_AMT");

                entity.Property(e => e.MaxCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_C_AMT");

                entity.Property(e => e.MaxCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CASH_D_AMT");

                entity.Property(e => e.MaxCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CHECK_D_AMT");

                entity.Property(e => e.MaxClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.MaxClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.MaxDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_DERIVATIVES_C_AMT");

                entity.Property(e => e.MaxDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_DERIVATIVES_D_AMT");

                entity.Property(e => e.MaxInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INHOUSECHECK_C_AMT");

                entity.Property(e => e.MaxInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INHOUSECHECK_D_AMT");

                entity.Property(e => e.MaxInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MaxInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MaxLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.MaxLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.MaxLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LCCOLLECTION_C_AMT");

                entity.Property(e => e.MaxLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LCCOLLECTION_D_AMT");

                entity.Property(e => e.MaxLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOAN_C_AMT");

                entity.Property(e => e.MaxLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOAN_D_AMT");

                entity.Property(e => e.MaxLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.MaxLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_LOANTOP_UP_C_AMT");

                entity.Property(e => e.MaxMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_C_AMT");

                entity.Property(e => e.MaxMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MISC_D_AMT");

                entity.Property(e => e.MaxMls)
                    .HasPrecision(6)
                    .HasColumnName("MAX_MLS");

                entity.Property(e => e.MaxMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.MaxMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.MaxOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.MaxPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.MaxReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.MaxReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.MaxSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SALARYCREDIT_C_AMT");

                entity.Property(e => e.MaxSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SALARYDEBIT_D_AMT");

                entity.Property(e => e.MaxSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SECURITIES_C_AMT");

                entity.Property(e => e.MaxSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SECURITIES_D_AMT");

                entity.Property(e => e.MaxSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_SELLSECURITY_D_AMT");

                entity.Property(e => e.MaxTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TDREDEMPTION_C_AMT");

                entity.Property(e => e.MaxTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TDREDEMPTION_D_AMT");

                entity.Property(e => e.MaxTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.MaxTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.MaxTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_TTISSUANCE_D_AMT");

                entity.Property(e => e.MaxWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_C_AMT");

                entity.Property(e => e.MaxWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAX_WIRE_D_AMT");

                entity.Property(e => e.MinBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_BUYSECURITY_C_AMT");

                entity.Property(e => e.MinCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_C_AMT");

                entity.Property(e => e.MinCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CASH_D_AMT");

                entity.Property(e => e.MinCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CHECK_D_AMT");

                entity.Property(e => e.MinClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.MinClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.MinDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_DERIVATIVES_C_AMT");

                entity.Property(e => e.MinDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_DERIVATIVES_D_AMT");

                entity.Property(e => e.MinInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INHOUSECHECK_C_AMT");

                entity.Property(e => e.MinInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INHOUSECHECK_D_AMT");

                entity.Property(e => e.MinInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.MinInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.MinLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.MinLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.MinLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LCCOLLECTION_C_AMT");

                entity.Property(e => e.MinLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LCCOLLECTION_D_AMT");

                entity.Property(e => e.MinLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOAN_C_AMT");

                entity.Property(e => e.MinLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOAN_D_AMT");

                entity.Property(e => e.MinLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.MinLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_LOANTOP_UP_C_AMT");

                entity.Property(e => e.MinMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_C_AMT");

                entity.Property(e => e.MinMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MISC_D_AMT");

                entity.Property(e => e.MinMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.MinMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.MinOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.MinPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.MinReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.MinReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.MinSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SALARYCREDIT_C_AMT");

                entity.Property(e => e.MinSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SALARYDEBIT_D_AMT");

                entity.Property(e => e.MinSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SECURITIES_C_AMT");

                entity.Property(e => e.MinSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SECURITIES_D_AMT");

                entity.Property(e => e.MinSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_SELLSECURITY_D_AMT");

                entity.Property(e => e.MinTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TDREDEMPTION_C_AMT");

                entity.Property(e => e.MinTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TDREDEMPTION_D_AMT");

                entity.Property(e => e.MinTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.MinTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.MinTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_TTISSUANCE_D_AMT");

                entity.Property(e => e.MinWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_C_AMT");

                entity.Property(e => e.MinWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MIN_WIRE_D_AMT");

                entity.Property(e => e.MonthKey)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_KEY");

                entity.Property(e => e.NumberOfLocations)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_LOCATIONS");

                entity.Property(e => e.OccupationCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_CODE");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                entity.Property(e => e.Prediction)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PREDICTION");

                entity.Property(e => e.RiskClassification)
                    .HasPrecision(1)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalBuysecurityCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_BUYSECURITY_C_AMT");

                entity.Property(e => e.TotalBuysecurityCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_BUYSECURITY_C_CNT");

                entity.Property(e => e.TotalCashCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_AMT");

                entity.Property(e => e.TotalCashCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_C_CNT");

                entity.Property(e => e.TotalCashDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_AMT");

                entity.Property(e => e.TotalCashDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CASH_D_CNT");

                entity.Property(e => e.TotalCheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_AMT");

                entity.Property(e => e.TotalCheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CHECK_D_CNT");

                entity.Property(e => e.TotalClearingcheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_C_AMT");

                entity.Property(e => e.TotalClearingcheckCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_C_CNT");

                entity.Property(e => e.TotalClearingcheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_D_AMT");

                entity.Property(e => e.TotalClearingcheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CLEARINGCHECK_D_CNT");

                entity.Property(e => e.TotalCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CNT");

                entity.Property(e => e.TotalCreditAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_AMOUNT");

                entity.Property(e => e.TotalCreditCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_CREDIT_CNT");

                entity.Property(e => e.TotalDebitAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_AMOUNT");

                entity.Property(e => e.TotalDebitCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DEBIT_CNT");

                entity.Property(e => e.TotalDerivativesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_C_AMT");

                entity.Property(e => e.TotalDerivativesCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_C_CNT");

                entity.Property(e => e.TotalDerivativesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_D_AMT");

                entity.Property(e => e.TotalDerivativesDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_DERIVATIVES_D_CNT");

                entity.Property(e => e.TotalInhousecheckCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_C_AMT");

                entity.Property(e => e.TotalInhousecheckCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_C_CNT");

                entity.Property(e => e.TotalInhousecheckDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_D_AMT");

                entity.Property(e => e.TotalInhousecheckDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INHOUSECHECK_D_CNT");

                entity.Property(e => e.TotalInternaltransferCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_AMT");

                entity.Property(e => e.TotalInternaltransferCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_C_CNT");

                entity.Property(e => e.TotalInternaltransferDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_AMT");

                entity.Property(e => e.TotalInternaltransferDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_INTERNALTRANSFER_D_CNT");

                entity.Property(e => e.TotalLcBlClcnCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_AMT");

                entity.Property(e => e.TotalLcBlClcnCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_C_CNT");

                entity.Property(e => e.TotalLcBlClcnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_AMT");

                entity.Property(e => e.TotalLcBlClcnDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LC_BL_CLCN_D_CNT");

                entity.Property(e => e.TotalLccollectionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_C_AMT");

                entity.Property(e => e.TotalLccollectionCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_C_CNT");

                entity.Property(e => e.TotalLccollectionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_D_AMT");

                entity.Property(e => e.TotalLccollectionDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LCCOLLECTION_D_CNT");

                entity.Property(e => e.TotalLoanCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_C_AMT");

                entity.Property(e => e.TotalLoanCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_C_CNT");

                entity.Property(e => e.TotalLoanDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_D_AMT");

                entity.Property(e => e.TotalLoanDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOAN_D_CNT");

                entity.Property(e => e.TotalLoandisbursementCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANDISBURSEMENT_C_AMT");

                entity.Property(e => e.TotalLoandisbursementCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANDISBURSEMENT_C_CNT");

                entity.Property(e => e.TotalLoantopUpCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANTOP_UP_C_AMT");

                entity.Property(e => e.TotalLoantopUpCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_LOANTOP_UP_C_CNT");

                entity.Property(e => e.TotalMiscCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_AMT");

                entity.Property(e => e.TotalMiscCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_C_CNT");

                entity.Property(e => e.TotalMiscDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_AMT");

                entity.Property(e => e.TotalMiscDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MISC_D_CNT");

                entity.Property(e => e.TotalMngrschckissnceCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_C_AMT");

                entity.Property(e => e.TotalMngrschckissnceCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_C_CNT");

                entity.Property(e => e.TotalMngrschckissnceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_D_AMT");

                entity.Property(e => e.TotalMngrschckissnceDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_MNGRSCHCKISSNCE_D_CNT");

                entity.Property(e => e.TotalOutwrdchqrtrnDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_OUTWRDCHQRTRN_D_AMT");

                entity.Property(e => e.TotalOutwrdchqrtrnDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_OUTWRDCHQRTRN_D_CNT");

                entity.Property(e => e.TotalPymntofinstllmntDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_PYMNTOFINSTLLMNT_D_AMT");

                entity.Property(e => e.TotalPymntofinstllmntDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_PYMNTOFINSTLLMNT_D_CNT");

                entity.Property(e => e.TotalReturnchequeCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNCHEQUE_C_AMT");

                entity.Property(e => e.TotalReturnchequeCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNCHEQUE_C_CNT");

                entity.Property(e => e.TotalReturnedwiresDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNEDWIRES_D_AMT");

                entity.Property(e => e.TotalReturnedwiresDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_RETURNEDWIRES_D_CNT");

                entity.Property(e => e.TotalSalarycreditCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYCREDIT_C_AMT");

                entity.Property(e => e.TotalSalarycreditCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYCREDIT_C_CNT");

                entity.Property(e => e.TotalSalarydebitDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYDEBIT_D_AMT");

                entity.Property(e => e.TotalSalarydebitDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SALARYDEBIT_D_CNT");

                entity.Property(e => e.TotalSecuritiesCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_C_AMT");

                entity.Property(e => e.TotalSecuritiesCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_C_CNT");

                entity.Property(e => e.TotalSecuritiesDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_D_AMT");

                entity.Property(e => e.TotalSecuritiesDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SECURITIES_D_CNT");

                entity.Property(e => e.TotalSellsecurityDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SELLSECURITY_D_AMT");

                entity.Property(e => e.TotalSellsecurityDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_SELLSECURITY_D_CNT");

                entity.Property(e => e.TotalTdredemptionCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_C_AMT");

                entity.Property(e => e.TotalTdredemptionCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_C_CNT");

                entity.Property(e => e.TotalTdredemptionDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_D_AMT");

                entity.Property(e => e.TotalTdredemptionDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TDREDEMPTION_D_CNT");

                entity.Property(e => e.TotalTermdepositCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_C_AMT");

                entity.Property(e => e.TotalTermdepositCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_C_CNT");

                entity.Property(e => e.TotalTermdepositDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_D_AMT");

                entity.Property(e => e.TotalTermdepositDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TERMDEPOSIT_D_CNT");

                entity.Property(e => e.TotalTtissuanceDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TTISSUANCE_D_AMT");

                entity.Property(e => e.TotalTtissuanceDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_TTISSUANCE_D_CNT");

                entity.Property(e => e.TotalWireCAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_AMT");

                entity.Property(e => e.TotalWireCCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_C_CNT");

                entity.Property(e => e.TotalWireDAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_AMT");

                entity.Property(e => e.TotalWireDCnt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_WIRE_D_CNT");
                entity.Property(e => e.Segment)
      .HasColumnType("NUMBER")
      .HasColumnName("SEGMENT");

                entity.Property(e => e.SegmentSorted)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEGMENT_SORTED");
            });

            modelBuilder.Entity<VaGroupInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_GROUP_INFO");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAYNAME");

                entity.Property(e => e.ExtidContext)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EXTID_CONTEXT");

                entity.Property(e => e.ExtidIdentifier)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("EXTID_IDENTIFIER");

                entity.Property(e => e.Grouptype)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GROUPTYPE");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });
            modelBuilder.Entity<VaPersonInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VA_PERSON_INFO");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAYNAME");

                entity.Property(e => e.ExtidContext)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EXTID_CONTEXT");

                entity.Property(e => e.ExtidId)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("EXTID_ID");

                entity.Property(e => e.ExtidIdentifier)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EXTID_IDENTIFIER");

                entity.Property(e => e.Id)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });
            modelBuilder.Entity<LstOfUsersAndGroupsRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("SAS_LIST_OF_USERS_AND_GROUPS_ROLES");//SAS_LST_USERS_AND_GROUPS_ROLES

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.GroupDisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_DISPLAY_NAME");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_NAME");

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("JOB_TITLE");

                entity.Property(e => e.RoleDisplayName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_DISPLAY_NAME");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.UserId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });
        }

        public void OnFcfkcAmlAnalysisModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FCFKC");

            modelBuilder.Entity<FskAlert>(entity =>
            {
                entity.HasKey(e => e.AlertId)
                    .HasName("PK_ALERT");

                entity.ToTable("FSK_ALERT");

                entity.HasIndex(e => e.AlertedEntityNumber, "ALRTD_ENT_NMBR_INDEX1");

                entity.HasIndex(e => e.ScenarioId, "IDX_ALERT_SCENARIO");

                entity.HasIndex(e => e.QueueCode, "XEIQFSK_ALERT");

                entity.HasIndex(e => e.PrimaryEntityKey, "XIE5FSK_ALERT");

                entity.HasIndex(e => e.PrimaryEntityName, "XIE6FSK_ALERT");

                entity.HasIndex(e => e.PrimaryEntityNumber, "XIE9FSK_ALERT");

                entity.Property(e => e.AlertId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("ALERT_ID");

                entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ACTUAL_VALUES_TEXT");

                entity.Property(e => e.AlertCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_CATEGORY_CD");

                entity.Property(e => e.AlertDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_DESCRIPTION");

                entity.Property(e => e.AlertStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_STATUS_CODE")
                    .IsFixedLength();

                entity.Property(e => e.AlertSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_SUBCATEGORY_CD");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_TYPE_CD");

                entity.Property(e => e.AlertedEntityKey)
                    .HasPrecision(12)
                    .HasColumnName("ALERTED_ENTITY_KEY");

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.EntitySegmentId)
                    .HasPrecision(12)
                    .HasColumnName("ENTITY_SEGMENT_ID");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGICAL_DELETE_IND")
                    .IsFixedLength();

                entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasPrecision(3)
                    .HasColumnName("MONEY_LAUNDERING_RISK_SCORE");

                entity.Property(e => e.PrimaryEntityKey)
                    .HasPrecision(12)
                    .HasColumnName("PRIMARY_ENTITY_KEY");

                entity.Property(e => e.PrimaryEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.PrimaryEntityName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_ENTITY_NAME");

                entity.Property(e => e.PrimaryEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_ENTITY_NUMBER");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("QUEUE_CODE");

                entity.Property(e => e.RunDate)
                    .HasColumnType("DATE")
                    .HasColumnName("RUN_DATE");

                entity.Property(e => e.ScenarioId)
                    .HasPrecision(12)
                    .HasColumnName("SCENARIO_ID");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_NAME");

                entity.Property(e => e.SuppressionEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("SUPPRESSION_END_DATE");

                entity.Property(e => e.TerrorFinancingRiskScore)
                    .HasPrecision(3)
                    .HasColumnName("TERROR_FINANCING_RISK_SCORE");

                entity.Property(e => e.VersionNumber)
                    .HasPrecision(10)
                    .HasColumnName("VERSION_NUMBER");
            });

            modelBuilder.Entity<FskAlertEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK_ALERT_EVENT");

                entity.ToTable("FSK_ALERT_EVENT");

                entity.HasIndex(e => e.AlertId, "IDX_ALERT_EVENT_ALERT");

                entity.HasIndex(e => new { e.CreateDate, e.EventTypeCode, e.AlertId }, "XIE1FSK_ALERT_EVENT");

                entity.Property(e => e.EventId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("EVENT_ID");

                entity.Property(e => e.AlertId)
                    .HasPrecision(12)
                    .HasColumnName("ALERT_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_DESCRIPTION");

                entity.Property(e => e.EventTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_TYPE_CODE")
                    .IsFixedLength();

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.FskAlertEvents)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_EVENT_ALERT");
            });

            modelBuilder.Entity<FskAlertedEntity>(entity =>
            {
                entity.HasKey(e => new { e.AlertedEntityLevelCode, e.AlertedEntityNumber })
                    .HasName("XPKFSK_ALERTED_ENTITY");

                entity.ToTable("FSK_ALERTED_ENTITY");

                entity.HasIndex(e => new { e.AlertedEntityNumber, e.AlertedEntityLevelCode }, "XAK1FSK_ALERTED_ENTITY")
                    .IsUnique();

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.AgeOldestAlert)
                    .HasPrecision(6)
                    .HasColumnName("AGE_OLDEST_ALERT");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("NUMBER(18,3)")
                    .HasColumnName("AGGREGATE_AMT");

                entity.Property(e => e.AlertedEntityName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NAME");

                entity.Property(e => e.AlertedEntitySegmentId)
                    .HasPrecision(18)
                    .HasColumnName("ALERTED_ENTITY_SEGMENT_ID");

                entity.Property(e => e.AlertsCnt)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ALERTS_CNT");

                entity.Property(e => e.CreatedTimestamp)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_TIMESTAMP");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.LockTimestamp)
                    .HasPrecision(6)
                    .HasColumnName("LOCK_TIMESTAMP");

                entity.Property(e => e.LockUserid)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("LOCK_USERID");

                entity.Property(e => e.LstupdateDate)
                    .HasPrecision(6)
                    .HasColumnName("LSTUPDATE_DATE");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("LSTUPDATE_USER_ID");

                entity.Property(e => e.MoneyLaunderingScore)
                    .HasPrecision(6)
                    .HasColumnName("MONEY_LAUNDERING_SCORE");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND")
                    .IsFixedLength();

                entity.Property(e => e.RiskScoreCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("RISK_SCORE_CODE");

                entity.Property(e => e.TransactionsCnt)
                    .HasPrecision(10)
                    .HasColumnName("TRANSACTIONS_CNT");
            });

            modelBuilder.Entity<FskComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("XPKFSK_COMMENT");

                entity.ToTable("FSK_COMMENT");

                entity.HasIndex(e => new { e.ObjectTypeCd, e.ObjectId }, "XIE1FSK_COMMENT");

                entity.Property(e => e.CommentId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("COMMENT_ID");

                entity.Property(e => e.CommentCategoryCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_CATEGORY_CD")
                    .IsFixedLength();

                entity.Property(e => e.CommentText)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_TEXT");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGICAL_DELETE_IND")
                    .IsFixedLength();

                entity.Property(e => e.LstupdateDate)
                    .HasPrecision(6)
                    .HasColumnName("LSTUPDATE_DATE");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LSTUPDATE_USER_ID");

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OBJECT_ID");

                entity.Property(e => e.ObjectTypeCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OBJECT_TYPE_CD")
                    .IsFixedLength();
            });

            modelBuilder.Entity<FskEntityEvent>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("XPKFSK_ENTITY_EVENT");

                entity.ToTable("FSK_ENTITY_EVENT");

                entity.HasIndex(e => e.CaseId, "XIE1FSK_ENTITY_EVENT");

                entity.Property(e => e.EventId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("EVENT_ID");

                entity.Property(e => e.CaseId)
                    .HasPrecision(12)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.EntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.EntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NUMBER");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_DESCRIPTION");

                entity.Property(e => e.EventTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_TYPE_CODE")
                    .IsFixedLength();
            });

            modelBuilder.Entity<FskEntityQueue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FSK_ENTITY_QUEUE");

                entity.HasIndex(e => new { e.AlertedEntityLevelCode, e.AlertedEntityNumber, e.QueueCode, e.OwnerUserid }, "XEIQFSK_ENTITY_QUEUE");

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("QUEUE_CODE");
            });
        }
        public void OnFcfkcSASAMLModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Fsk_EntityQueue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FSK_ENTITY_QUEUE");

                entity.HasIndex(e => new { e.AlertedEntityLevelCode, e.AlertedEntityNumber, e.QueueCode, e.OwnerUserid }, "XEIQFSK_ENTITY_QUEUE");

                entity.Property(e => e.AlertedEntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.AlertedEntityNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALERTED_ENTITY_NUMBER");

                entity.Property(e => e.OwnerUserid)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USERID");

                entity.Property(e => e.QueueCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("QUEUE_CODE");
            });
            modelBuilder.Entity<FskCase>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("XPKFSK_CASE");

                entity.ToTable("FSK_CASE");

                entity.Property(e => e.CaseId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.AggregateAmt)
                    .HasColumnType("NUMBER(15,3)")
                    .HasColumnName("AGGREGATE_AMT");

                entity.Property(e => e.CaseCategoryCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CATEGORY_CODE");

                entity.Property(e => e.CaseCloseReasonCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CASE_CLOSE_REASON_CODE");

                entity.Property(e => e.CaseDescription)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DESCRIPTION");

                entity.Property(e => e.CasePriorityCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_PRIORITY_CODE");

                entity.Property(e => e.CaseStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS_CODE");

                entity.Property(e => e.CaseSubCategoryCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_SUB_CATEGORY_CODE");

                entity.Property(e => e.CaseSummary)
                    .IsUnicode(false)
                    .HasColumnName("CASE_SUMMARY");

                entity.Property(e => e.CaseTypeCode)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE_CODE");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.FirstTransactionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("FIRST_TRANSACTION_DATE");

                entity.Property(e => e.LastTransactionDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_TRANSACTION_DATE");

                entity.Property(e => e.LeContactAgency)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("LE_CONTACT_AGENCY");

                entity.Property(e => e.LeContactDate)
                    .HasPrecision(6)
                    .HasColumnName("LE_CONTACT_DATE");

                entity.Property(e => e.LeContactName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("LE_CONTACT_NAME");

                entity.Property(e => e.LeContactPhone)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("LE_CONTACT_PHONE");

                entity.Property(e => e.LeContactPhoneExt)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("LE_CONTACT_PHONE_EXT");

                entity.Property(e => e.LeContactedInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LE_CONTACTED_IND")
                    .IsFixedLength();

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGICAL_DELETE_IND")
                    .IsFixedLength();

                entity.Property(e => e.LstupdateDate)
                    .HasPrecision(6)
                    .HasColumnName("LSTUPDATE_DATE");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LSTUPDATE_USER_ID");

                entity.Property(e => e.ModifiedInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MODIFIED_IND")
                    .IsFixedLength();

                entity.Property(e => e.OpenedInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OPENED_IND")
                    .IsFixedLength();

                entity.Property(e => e.OwnerUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USER_LONG_ID");

                entity.Property(e => e.VersionNumber)
                    .HasPrecision(10)
                    .HasColumnName("VERSION_NUMBER");
            });

            modelBuilder.Entity<FskLov>(entity =>
            {
                entity.HasKey(e => new { e.LovTypeName, e.LovTypeCode, e.LovLanguageDesc })
                    .HasName("PK_LOV");

                entity.ToTable("FSK_LOV");

                entity.Property(e => e.LovTypeName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("LOV_TYPE_NAME");

                entity.Property(e => e.LovTypeCode)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("LOV_TYPE_CODE");

                entity.Property(e => e.LovLanguageDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOV_LANGUAGE_DESC");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE_FLG")
                    .HasDefaultValueSql("'Y'  ")
                    .IsFixedLength();

                entity.Property(e => e.LovSortPositionNumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOV_SORT_POSITION_NUMBER");

                entity.Property(e => e.LovTypeDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOV_TYPE_DESC");
            });

            modelBuilder.Entity<FskRiskAssessment>(entity =>
            {
                entity.HasKey(e => e.RiskAssessmentId)
                    .HasName("PK_RISK_ASMNT");

                entity.ToTable("FSK_RISK_ASSESSMENT");

                entity.HasIndex(e => e.PartyKey, "XIE5FSK_RISK_ASMNT");

                entity.HasIndex(e => e.PartyNumber, "XIE9FSK_RISK_ASMNT");

                entity.Property(e => e.RiskAssessmentId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("RISK_ASSESSMENT_ID");

                entity.Property(e => e.AssessmentCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_CATEGORY_CD");

                entity.Property(e => e.AssessmentSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_SUBCATEGORY_CD");

                entity.Property(e => e.AssessmentTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ASSESSMENT_TYPE_CD");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGICAL_DELETE_IND")
                    .IsFixedLength();

                entity.Property(e => e.OwnerUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_USER_LONG_ID");

                entity.Property(e => e.PartyKey)
                    .HasPrecision(12)
                    .HasColumnName("PARTY_KEY");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.ProposedRiskClassification)
                    .HasPrecision(1)
                    .HasColumnName("PROPOSED_RISK_CLASSIFICATION");

                entity.Property(e => e.RiskAssessmentDuration)
                    .HasPrecision(3)
                    .HasColumnName("RISK_ASSESSMENT_DURATION");

                entity.Property(e => e.RiskAssessmentStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("RISK_ASSESSMENT_STATUS_CODE")
                    .IsFixedLength();

                entity.Property(e => e.RiskClassification)
                    .HasPrecision(1)
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.StartingMonthKey)
                    .HasPrecision(6)
                    .HasColumnName("STARTING_MONTH_KEY");

                entity.Property(e => e.VersionNumber)
                    .HasPrecision(10)
                    .HasColumnName("VERSION_NUMBER");
            });

            modelBuilder.Entity<FskScenario>(entity =>
            {
                entity.HasKey(e => e.ScenarioId)
                    .HasName("PK_SCENARIO");

                entity.ToTable("FSK_SCENARIO");

                entity.HasIndex(e => e.HeaderId, "IDX_SCENARIO_HEADER");

                entity.HasIndex(e => e.RoutingGroupId, "XIF2FSK_SCENARIO");

                entity.Property(e => e.ScenarioId)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("SCENARIO_ID");

                entity.Property(e => e.AlertCategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_CATEGORY_CD");

                entity.Property(e => e.AlertSubcategoryCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_SUBCATEGORY_CD");

                entity.Property(e => e.AlertTypeCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ALERT_TYPE_CD");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_USER_ID");

                entity.Property(e => e.CurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CURRENT_IND")
                    .IsFixedLength();

                entity.Property(e => e.DfltSuppressDurationCount)
                    .HasPrecision(8)
                    .HasColumnName("DFLT_SUPPRESS_DURATION_COUNT");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE")
                    .HasDefaultValueSql("to_date('59990101','YYYYMMDD')  ");

                entity.Property(e => e.EndUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("END_USER_ID");

                entity.Property(e => e.EntityLevelCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_LEVEL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.ExecutionProbabilityRate)
                    .HasColumnType("NUMBER(7,7)")
                    .HasColumnName("EXECUTION_PROBABILITY_RATE");

                entity.Property(e => e.HeaderId)
                    .HasPrecision(12)
                    .HasColumnName("HEADER_ID");

                entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOGICAL_DELETE_IND")
                    .IsFixedLength();

                entity.Property(e => e.LstupdateDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LSTUPDATE_DATE");

                entity.Property(e => e.LstupdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LSTUPDATE_USER_ID");

                entity.Property(e => e.MoneyLaunderingBayesWeight)
                    .HasColumnType("NUMBER(15,5)")
                    .HasColumnName("MONEY_LAUNDERING_BAYES_WEIGHT");

                entity.Property(e => e.OrderInHeader)
                    .HasPrecision(5)
                    .HasColumnName("ORDER_IN_HEADER");

                entity.Property(e => e.PrimaryEntityNumberVarName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_ENTITY_NUMBER_VAR_NAME");

                entity.Property(e => e.ProductTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE_CODE")
                    .IsFixedLength();

                entity.Property(e => e.RiskFactorInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RISK_FACTOR_IND")
                    .IsFixedLength();

                entity.Property(e => e.RootKey)
                    .HasPrecision(12)
                    .HasColumnName("ROOT_KEY");

                entity.Property(e => e.RoutingGroupId)
                    .HasPrecision(12)
                    .HasColumnName("ROUTING_GROUP_ID");

                entity.Property(e => e.RoutingUserLongId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("ROUTING_USER_LONG_ID");

                entity.Property(e => e.SaveTrigTransInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SAVE_TRIG_TRANS_IND")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioCategoryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_CATEGORY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioCodeLocationDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_CODE_LOCATION_DESC");

                entity.Property(e => e.ScenarioDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_DESCRIPTION");

                entity.Property(e => e.ScenarioDurationCount)
                    .HasPrecision(8)
                    .HasColumnName("SCENARIO_DURATION_COUNT");

                entity.Property(e => e.ScenarioName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_NAME");

                entity.Property(e => e.ScenarioRunFrequencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_RUN_FREQUENCY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioShortDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_SHORT_DESCRIPTION");

                entity.Property(e => e.ScenarioStatusCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_STATUS_CODE")
                    .IsFixedLength();

                entity.Property(e => e.ScenarioTypeCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCENARIO_TYPE_CODE")
                    .IsFixedLength();

                entity.Property(e => e.SkipIfNoTransCurrDayInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SKIP_IF_NO_TRANS_CURR_DAY_IND")
                    .IsFixedLength();

                entity.Property(e => e.TerrorFinancingBayesWeight)
                    .HasColumnType("NUMBER(15,5)")
                    .HasColumnName("TERROR_FINANCING_BAYES_WEIGHT");

                entity.Property(e => e.VersionNumber)
                    .HasPrecision(5)
                    .HasColumnName("VERSION_NUMBER");

                entity.Property(e => e.VsdDeploymentName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VSD_DEPLOYMENT_NAME");

                entity.Property(e => e.VsdWindowName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("VSD_WINDOW_NAME");
            });
        }

        public void OnFTIModelCreating(ModelBuilder modelBuilder)
        {
            //FTI
            modelBuilder.Entity<ArtTiAcpostingsAccReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ACPOSTINGS_ACC_REPORT");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_TYPE");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_NO")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM");

                entity.Property(e => e.DrCrFlg)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DR_CR_FLG")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.Mainbanking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MAINBANKING")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.PostAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT");

                entity.Property(e => e.PostAmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT_EGP");

                entity.Property(e => e.Shortname)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Spsk)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SPSK");

                entity.Property(e => e.Valuedate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUEDATE");
            });

            modelBuilder.Entity<ArtTiAcpostingsCustReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ACPOSTINGS_CUST_REPORT");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT_TYPE");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_NO")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DrCrFlg)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DR_CR_FLG")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.Mainbanking)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MAINBANKING")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.PostAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT");

                entity.Property(e => e.PostAmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("POST_AMOUNT_EGP");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME")
                    .IsFixedLength();

                entity.Property(e => e.Spsk)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SPSK");

                entity.Property(e => e.Valuedate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUEDATE");
            });

            modelBuilder.Entity<ArtTiActivityReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ACTIVITY_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Address12)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS12")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BaseStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BASE_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm12)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM12")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.EventStatus)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STATUS");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Gfcun12)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN12")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref12)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF12")
                    .IsFixedLength();

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("START_TIME")
                    .IsFixedLength();

                entity.Property(e => e.Started)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("STARTED");

                entity.Property(e => e.StartedFilter)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTED_FILTER");

                entity.Property(e => e.Stepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STEPDESCR");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBank12)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK12")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch12)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH12")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr12)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR12")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc12)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC12")
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("TEAM");

                entity.Property(e => e.Touched)
                    .HasColumnType("DATE")
                    .HasColumnName("TOUCHED");
            });

            modelBuilder.Entity<ArtTiAmortizationReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_Amortization_Report");

                entity.Property(e => e.AccPeriod)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ACC_PERIOD");

                entity.Property(e => e.AccrueAmt)
                    .HasPrecision(15)
                    .HasColumnName("ACCRUE_AMT");

                entity.Property(e => e.AccrueCcy)
                    .IsUnicode(false)
                    .HasColumnName("ACCRUE_CCY");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.C8ced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("C8CED")
                    .IsFixedLength();

                entity.Property(e => e.ChargeAmt)
                    .HasPrecision(15)
                    .HasColumnName("CHARGE_AMT");

                entity.Property(e => e.ChargeCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Chgpextraday)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("CHGPEXTRADAY");

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DailyAcc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DAILY_ACC");

                entity.Property(e => e.Descr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.EndDat)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DAT");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(43)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Firststart)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTSTART")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.PeriodChg)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PERIOD_CHG");

                entity.Property(e => e.Periodic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PERIODIC")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF");

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDat)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DAT");

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiChargesByCustReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_CHARGES_BY_CUST_REPORT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Hvbad1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("HVBAD1");

                entity.Property(e => e.Longname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LONGNAME");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.TotoalBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalClaimedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_CLAIMED_CHG_DUE");

                entity.Property(e => e.TotoalOutstandingChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_OUTSTANDING_CHG_DUE");

                entity.Property(e => e.TotoalPaidChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PAID_CHG_DUE");

                entity.Property(e => e.TotoalPeriodicBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PERIODIC_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalWaivedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_WAIVED_CHG_DUE");
            });

            modelBuilder.Entity<ArtTiChargesByMasterReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_CHARGES_BY_MASTER_REPORT");

                entity.Property(e => e.Hvbad1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("HVBAD1");

                entity.Property(e => e.Longname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LONGNAME");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.TotoalBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalClaimedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_CLAIMED_CHG_DUE");

                entity.Property(e => e.TotoalOutstandingChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_OUTSTANDING_CHG_DUE");

                entity.Property(e => e.TotoalPaidChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PAID_CHG_DUE");

                entity.Property(e => e.TotoalPeriodicBilledChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_PERIODIC_BILLED_CHG_DUE");

                entity.Property(e => e.TotoalWaivedChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTOAL_WAIVED_CHG_DUE");
            });

            modelBuilder.Entity<ArtTiChargesDetailsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_CHARGES_DETAILS_REPORT");

                entity.Property(e => e.Action)
                    .HasMaxLength(48)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.ChgCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHG_CCY")
                    .IsFixedLength();

                entity.Property(e => e.ChgDue)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHG_DUE");

                entity.Property(e => e.ChgDueEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHG_DUE_EGP");

                entity.Property(e => e.ChgbasAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHGBAS_AMT");

                entity.Property(e => e.ChgbasAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHGBAS_AMT_EGP");

                entity.Property(e => e.ChgbasCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHGBAS_CCY")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.EventRef)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Hvbad1)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("HVBAD1");

                entity.Property(e => e.Longname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("LONGNAME");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.ParticChg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTIC_CHG")
                    .IsFixedLength();

                entity.Property(e => e.Reduction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REDUCTION")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX1")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL1");

                entity.Property(e => e.SchAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT");

                entity.Property(e => e.SchAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT_EGP");

                entity.Property(e => e.SchCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCH_CCY")
                    .IsFixedLength();

                entity.Property(e => e.SchCcySei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SCH_CCY_SEI")
                    .IsFixedLength();

                entity.Property(e => e.SchCcySpt)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("SCH_CCY_SPT");

                entity.Property(e => e.SchRate)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("SCH_RATE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("START_TIME")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.TaxAmt)
                    .HasPrecision(15)
                    .HasColumnName("TAX_AMT");

                entity.Property(e => e.TaxCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TAX_CCY")
                    .IsFixedLength();

                entity.Property(e => e.TaxFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TAX_FOR")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiDiaryExceptionsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_DIARY_EXCEPTIONS_REPORT");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_CODE")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NoteText)
                    .IsUnicode(false)
                    .HasColumnName("NOTE_TEXT");

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.Sovaluecode)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUECODE");

                entity.Property(e => e.Sovaluedesc)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUEDESC");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEAM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiEcmTransactionsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ECM_TRANSACTIONS_REPORT");

                entity.Property(e => e.Applicantname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTNAME");

                entity.Property(e => e.Behalfofbranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BEHALFOFBRANCH");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STAT_CD");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Eventname)
                    .IsUnicode(false)
                    .HasColumnName("EVENTNAME");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER");

                entity.Property(e => e.Product)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Producttype)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTTYPE");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");
            });

            modelBuilder.Entity<ArtTiInterfaceDetailsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_INTERFACE_DETAILS_REPORT");

                entity.Property(e => e.Gz361d1f)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZ361D1F")
                    .IsFixedLength();

                entity.Property(e => e.Gz361mdt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361MDT");

                entity.Property(e => e.Gz361ncd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361NCD");

                entity.Property(e => e.Gz361rat)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361RAT");

                entity.Property(e => e.Gz361sdt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZ361SDT");

                entity.Property(e => e.Gzamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZAMT");

                entity.Property(e => e.GzamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZAMT_EGP");

                entity.Property(e => e.Gzbrnm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GZBRNM")
                    .IsFixedLength();

                entity.Property(e => e.Gzccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZCCY");

                entity.Property(e => e.Gzcus1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GZCUS1");

                entity.Property(e => e.Gzdlp)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZDLP")
                    .IsFixedLength();

                entity.Property(e => e.Gzg331ext)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331EXT");

                entity.Property(e => e.Gzg331pam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331PAM");

                entity.Property(e => e.Gzg331pccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG331PCCY");

                entity.Property(e => e.Gzg331pced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG331PCED");

                entity.Property(e => e.Gzg331psd1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZG331PSD1");

                entity.Property(e => e.Gzg331purd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331PURD");

                entity.Property(e => e.Gzg331sam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331SAM");

                entity.Property(e => e.Gzg331sccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG331SCCY");

                entity.Property(e => e.Gzg331sced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG331SCED");

                entity.Property(e => e.Gzg331sled)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG331SLED");

                entity.Property(e => e.Gzg361ced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG361CED")
                    .IsFixedLength();

                entity.Property(e => e.Gzg461ext)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461EXT");

                entity.Property(e => e.Gzg461pccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG461PCCY");

                entity.Property(e => e.Gzg461pced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG461PCED");

                entity.Property(e => e.Gzg461psd1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZG461PSD1");

                entity.Property(e => e.Gzg461sccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG461SCCY");

                entity.Property(e => e.Gzg461sced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG461SCED");

                entity.Property(e => e.Gzg461tpam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TPAM");

                entity.Property(e => e.Gzg461tprd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TPRD");

                entity.Property(e => e.Gzg461tsam)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TSAM");

                entity.Property(e => e.Gzg461tsld)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG461TSLD");

                entity.Property(e => e.Gzg891acc)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZG891ACC");

                entity.Property(e => e.Gzg891ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZG891CCY");

                entity.Property(e => e.Gzg891ced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZG891CED");

                entity.Property(e => e.Gzg891dte)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GZG891DTE");

                entity.Property(e => e.Gzh97nacc)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NACC");

                entity.Property(e => e.Gzh97nact)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NACT");

                entity.Property(e => e.Gzh97nactc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NACTC");

                entity.Property(e => e.Gzh97nanmd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NANMD");

                entity.Property(e => e.Gzh97nboacc)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NBOACC");

                entity.Property(e => e.Gzh97nca2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NCA2");

                entity.Property(e => e.Gzh97nced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NCED");

                entity.Property(e => e.Gzh97nctp1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NCTP1");

                entity.Property(e => e.Gzh97nean1)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NEAN1");

                entity.Property(e => e.Gzh97nean2)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NEAN2");

                entity.Property(e => e.Gzh97nnegp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNEGP");

                entity.Property(e => e.Gzh97nnr1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR1");

                entity.Property(e => e.Gzh97nnr2)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR2");

                entity.Property(e => e.Gzh97nnr3)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR3");

                entity.Property(e => e.Gzh97nnr4)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NNR4");

                entity.Property(e => e.Gzh97npc)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NPC");

                entity.Property(e => e.Gzh97nrecn)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NRECN");

                entity.Property(e => e.Gzh97nsrc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NSRC");

                entity.Property(e => e.Gzh97ntcd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NTCD");

                entity.Property(e => e.Gzh97nuc1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NUC1");

                entity.Property(e => e.Gzh97nuc2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("GZH97NUC2");

                entity.Property(e => e.Reference)
                    .HasMaxLength(27)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE");

                entity.Property(e => e.Tranid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("TRANID")
                    .IsFixedLength();

                entity.Property(e => e.Tretxt)
                    .HasMaxLength(132)
                    .IsUnicode(false)
                    .HasColumnName("TRETXT");

                entity.Property(e => e.Trfile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TRFILE")
                    .IsFixedLength();

                entity.Property(e => e.Trseq)
                    .HasPrecision(7)
                    .HasColumnName("TRSEQ");

                entity.Property(e => e.Trstat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRSTAT")
                    .IsFixedLength();

                entity.Property(e => e.Trtype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRTYPE")
                    .IsFixedLength();

                entity.Property(e => e.UserCodes)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("USER_CODES");

                entity.Property(e => e.UserOptions)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("USER_OPTIONS");

                entity.Property(e => e.ValueDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUE_DATE");
            });

            modelBuilder.Entity<ArtTiMasterEventHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_MASTER_EVENT_HISTORY");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.Bookoffdat)
                    .HasColumnType("DATE")
                    .HasColumnName("BOOKOFFDAT");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_CODE")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .IsUnicode(false)
                    .HasColumnName("CCY");

                entity.Property(e => e.CrossRef)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CROSS_REF")
                    .IsFixedLength();

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DeactDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEACT_DATE");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REF");

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Extrainfo)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("EXTRAINFO");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Isfinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFINISHED")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Started)
                    .HasMaxLength(19)
                    .IsUnicode(false)
                    .HasColumnName("STARTED");

                entity.Property(e => e.StartedFilter)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTED_FILTER");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.StatusEv)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_EV")
                    .IsFixedLength();

                entity.Property(e => e.StepStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STEP_STATUS");

                entity.Property(e => e.Stepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STEPDESCR");

                entity.Property(e => e.Stepkey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("STEPKEY");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Team)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEAM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiMastevehistProdFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_MASTEVEHIST_PROD_FILTER");

                entity.Property(e => e.Product)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiMastevehistStatusFilter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_MASTEVEHIST_STATUS_FILTER");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiOsActivityReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_ACTIVITY_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Product)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Team)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("TEAM")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiOsLiabilityReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_LIABILITY_REPORT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.LiabCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("LIAB_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Totliabamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTLIABAMT");

                entity.Property(e => e.TotliabamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTLIABAMT_EGP");
            });

            modelBuilder.Entity<ArtTiOsTransAwaitiApprlReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_AWAITI_APPRL_REPORT");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.Descr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.EventReference)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_REFERENCE");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isfinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFINISHED")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NpcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.NpcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.NpcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.PcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.PcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.PcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Started)
                    .HasPrecision(9)
                    .HasColumnName("STARTED");

                entity.Property(e => e.Status)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Touched)
                    .HasColumnType("DATE")
                    .HasColumnName("TOUCHED");

                entity.Property(e => e.Type)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiOsTransByGatewayReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_BY_GATEWAY_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccysei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYSEI")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Partptd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTPTD")
                    .IsFixedLength();

                entity.Property(e => e.Prodcode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PRODCODE")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RevNext)
                    .HasColumnType("DATE")
                    .HasColumnName("REV_NEXT");

                entity.Property(e => e.Revolving)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REVOLVING")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Sovalue1)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE1");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");
            });

            modelBuilder.Entity<ArtTiOsTransByNonpriReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_BY_NONPRI_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.Code79)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CODE79")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccysei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYSEI")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Partptd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTPTD")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RevNext)
                    .HasColumnType("DATE")
                    .HasColumnName("REV_NEXT");

                entity.Property(e => e.Revolving)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REVOLVING")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Sovalue1)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE1");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");
            });

            modelBuilder.Entity<ArtTiOsTransByPrincipalReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_OS_TRANS_BY_PRINCIPAL_REPORT");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.Code79)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CODE79")
                    .IsFixedLength();

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Descrip)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outccysei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYSEI")
                    .IsFixedLength();

                entity.Property(e => e.Outccyspt)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("OUTCCYSPT");

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Partptd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PARTPTD")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RevNext)
                    .HasColumnType("DATE")
                    .HasColumnName("REV_NEXT");

                entity.Property(e => e.Revolving)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REVOLVING")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.Sovalue1)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE1");

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");
            });

            modelBuilder.Entity<ArtTiPeriodicChrgsPayReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_PERIODIC_CHRGS_PAY_REPORT");

                entity.Property(e => e.AccrueAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT");

                entity.Property(e => e.AccrueAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT_EGP");

                entity.Property(e => e.AccrueCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ACCRUE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.ChargeAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT");

                entity.Property(e => e.ChargeAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT_EGP");

                entity.Property(e => e.ChargeCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.ChgCusMnm1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHG_CUS_MNM1")
                    .IsFixedLength();

                entity.Property(e => e.ChgGfcun1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("CHG_GFCUN1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwBank1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_BANK1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwBranch1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_BRANCH1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwCtr1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_CTR1")
                    .IsFixedLength();

                entity.Property(e => e.ChgSwLoc1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CHG_SW_LOC1")
                    .IsFixedLength();

                entity.Property(e => e.Chgpextraday)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("CHGPEXTRADAY");

                entity.Property(e => e.Ddate)
                    .HasColumnType("DATE")
                    .HasColumnName("DDATE");

                entity.Property(e => e.Descr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descr1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR1")
                    .IsFixedLength();

                entity.Property(e => e.EndDat)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DAT");

                entity.Property(e => e.Firststart)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTSTART")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NpcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.NpcpAddress11)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_ADDRESS11")
                    .IsFixedLength();

                entity.Property(e => e.NpcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.NpcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.NpcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Payrec)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("PAYREC");

                entity.Property(e => e.PcpAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.PcpCusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PCP_CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.PcpGfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCP_GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.PcpSwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.SchAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT");

                entity.Property(e => e.SchAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCH_AMT_EGP");

                entity.Property(e => e.SchCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SCH_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDat)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DAT");

                entity.Property(e => e.SuppAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUPP_ACC")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiPeriodicChrgsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_PERIODIC_CHRGS_REPORT");

                entity.Property(e => e.AccrueAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT");

                entity.Property(e => e.AccrueAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCRUE_AMT_EGP");

                entity.Property(e => e.AccrueCcy)
                    .IsUnicode(false)
                    .HasColumnName("ACCRUE_CCY");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.AdvArr)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ADV_ARR");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.ChargeAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT");

                entity.Property(e => e.ChargeAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARGE_AMT_EGP");

                entity.Property(e => e.ChargeCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Chgpextraday)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("CHGPEXTRADAY");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.DailyAcc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DAILY_ACC");

                entity.Property(e => e.Descr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.EndDat)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DAT");

                entity.Property(e => e.Firststart)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTSTART")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Outccyced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OUTCCYCED")
                    .IsFixedLength();

                entity.Property(e => e.Outstamt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT");

                entity.Property(e => e.OutstamtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTAMT_EGP");

                entity.Property(e => e.Outstccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("OUTSTCCY")
                    .IsFixedLength();

                entity.Property(e => e.Payrec)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAYREC")
                    .IsFixedLength();

                entity.Property(e => e.Periodic)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PERIODIC")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrref)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF");

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.StartDat)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DAT");

                entity.Property(e => e.SuppAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SUPP_ACC")
                    .IsFixedLength();

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiSystemTailoringReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_SYSTEM_TAILORING_REPORT");

                entity.Property(e => e.AccSrc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACC_SRC");

                entity.Property(e => e.ActualAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACTUAL_AMT");

                entity.Property(e => e.Amberdate)
                    .HasColumnType("DATE")
                    .HasColumnName("AMBERDATE");

                entity.Property(e => e.Amberdays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMBERDAYS");

                entity.Property(e => e.Amberrsecs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMBERRSECS");

                entity.Property(e => e.Ambertime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AMBERTIME");

                entity.Property(e => e.Amendchg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AMENDCHG")
                    .IsFixedLength();

                entity.Property(e => e.Amount43)
                    .HasPrecision(15)
                    .HasColumnName("AMOUNT43");

                entity.Property(e => e.AmtCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("AMT_CCY");

                entity.Property(e => e.AmtField)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AMT_FIELD");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(27)
                    .IsUnicode(false)
                    .HasColumnName("ATTACHMENT");

                entity.Property(e => e.Autoprint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AUTOPRINT");

                entity.Property(e => e.AvailType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AVAIL_TYPE");

                entity.Property(e => e.Bsparamsetdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BSPARAMSETDESCR")
                    .IsFixedLength();

                entity.Property(e => e.Bsparamsetid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("BSPARAMSETID")
                    .IsFixedLength();

                entity.Property(e => e.Btinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BTINITSTEPDESCR");

                entity.Property(e => e.Btinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BTINITSTEPID");

                entity.Property(e => e.Btrejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("BTREJSTEPDESCR");

                entity.Property(e => e.Btrejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BTREJSTEPID");

                entity.Property(e => e.Canamdbas)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CANAMDBAS")
                    .IsFixedLength();

                entity.Property(e => e.ChkLimit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHK_LIMIT");

                entity.Property(e => e.Contingent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CONTINGENT");

                entity.Property(e => e.Curren64)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CURREN64")
                    .IsFixedLength();

                entity.Property(e => e.Date71)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE71");

                entity.Property(e => e.DateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DATE_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Dateab63)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DATEAB63")
                    .IsFixedLength();

                entity.Property(e => e.Deadlinedate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEADLINEDATE");

                entity.Property(e => e.Deadlinedays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEADLINEDAYS");

                entity.Property(e => e.Deadlinersecs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEADLINERSECS");

                entity.Property(e => e.Deadlinetime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DEADLINETIME");

                entity.Property(e => e.Debitcredit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEBITCREDIT");

                entity.Property(e => e.Dombehaviour)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOMBEHAVIOUR");

                entity.Property(e => e.Domcode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DOMCODE");

                entity.Property(e => e.Domdefault)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOMDEFAULT");

                entity.Property(e => e.Domlinkcode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DOMLINKCODE");

                entity.Property(e => e.Domlinkname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DOMLINKNAME");

                entity.Property(e => e.Domname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DOMNAME");

                entity.Property(e => e.Domtype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOMTYPE");

                entity.Property(e => e.ErrorText)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ERROR_TEXT");

                entity.Property(e => e.Eventlongname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EVENTLONGNAME")
                    .IsFixedLength();

                entity.Property(e => e.Field2Src)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIELD2_SRC")
                    .IsFixedLength();

                entity.Property(e => e.Fromstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("FROMSTEPDESCR");

                entity.Property(e => e.Fromstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("FROMSTEPID");

                entity.Property(e => e.Gwinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GWINITSTEPDESCR");

                entity.Property(e => e.Gwinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GWINITSTEPID");

                entity.Property(e => e.Gwrejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GWREJSTEPDESCR");

                entity.Property(e => e.Gwrejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GWREJSTEPID");

                entity.Property(e => e.Intege18)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTEGE18");

                entity.Property(e => e.InternAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERN_ACC");

                entity.Property(e => e.Intinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("INTINITSTEPDESCR");

                entity.Property(e => e.Intinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("INTINITSTEPID");

                entity.Property(e => e.Inuse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INUSE");

                entity.Property(e => e.Liabamttyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIABAMTTYP");

                entity.Property(e => e.Liability)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LIABILITY");

                entity.Property(e => e.Mappingid)
                    .HasMaxLength(43)
                    .IsUnicode(false)
                    .HasColumnName("MAPPINGID");

                entity.Property(e => e.Mappingsubid)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("MAPPINGSUBID");

                entity.Property(e => e.Mappingtype)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("MAPPINGTYPE");

                entity.Property(e => e.Mapstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("MAPSTEPDESCR");

                entity.Property(e => e.Mapstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MAPSTEPID");

                entity.Property(e => e.Margin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MARGIN");

                entity.Property(e => e.Nextstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NEXTSTEPDESCR");

                entity.Property(e => e.Nextstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("NEXTSTEPID");

                entity.Property(e => e.Obsolete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OBSOLETE");

                entity.Property(e => e.Operat44)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OPERAT44")
                    .IsFixedLength();

                entity.Property(e => e.Optional)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OPTIONAL");

                entity.Property(e => e.Paramsetdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PARAMSETDESCR")
                    .IsFixedLength();

                entity.Property(e => e.Paramsetid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PARAMSETID")
                    .IsFixedLength();

                entity.Property(e => e.Postingtyp)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("POSTINGTYP");

                entity.Property(e => e.Prodlongname)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("PRODLONGNAME");

                entity.Property(e => e.Projection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PROJECTION");

                entity.Property(e => e.Reddate)
                    .HasColumnType("DATE")
                    .HasColumnName("REDDATE");

                entity.Property(e => e.Reddays)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REDDAYS");

                entity.Property(e => e.Redrsecs)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REDRSECS");

                entity.Property(e => e.Redtime)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REDTIME");

                entity.Property(e => e.Rejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("REJSTEPDESCR");

                entity.Property(e => e.Rejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("REJSTEPID");

                entity.Property(e => e.RelDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REL_DATE")
                    .IsFixedLength();

                entity.Property(e => e.Relati29)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RELATI29")
                    .IsFixedLength();

                entity.Property(e => e.Relevmapkey)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RELEVMAPKEY");

                entity.Property(e => e.RevPstngs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REV_PSTNGS");

                entity.Property(e => e.Seq97)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQ97");

                entity.Property(e => e.Sequence)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SEQUENCE");

                entity.Property(e => e.Severity)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SEVERITY");

                entity.Property(e => e.StepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STEP_TIME");

                entity.Property(e => e.Steptype)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("STEPTYPE");

                entity.Property(e => e.Swinitstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SWINITSTEPDESCR");

                entity.Property(e => e.Swinitstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SWINITSTEPID");

                entity.Property(e => e.Swrejstepdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SWREJSTEPDESCR");

                entity.Property(e => e.Swrejstepid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SWREJSTEPID");

                entity.Property(e => e.Teamcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEAMCODE");

                entity.Property(e => e.Teamdescr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("TEAMDESCR");

                entity.Property(e => e.Templatedescr)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TEMPLATEDESCR");

                entity.Property(e => e.Templateid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TEMPLATEID");

                entity.Property(e => e.Trancode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TRANCODE");

                entity.Property(e => e.TransAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_ACC");

                entity.Property(e => e.Trcrsdliab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRCRSDLIAB");

                entity.Property(e => e.Type24)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TYPE24")
                    .IsFixedLength();

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");

                entity.Property(e => e.Useevtfm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USEEVTFM");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });
            modelBuilder.Entity<ArtTiFinanInterAccrual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_FINAN_INTER_ACCRUALS");

                entity.Property(e => e.Actualrate)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("ACTUALRATE");

                entity.Property(e => e.Address1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS1")
                    .IsFixedLength();

                entity.Property(e => e.AmtOS)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMT_O_S");

                entity.Property(e => e.AmtOSEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMT_O_S_EGP");

                entity.Property(e => e.AmtOrPct)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AMT_OR_PCT")
                    .IsFixedLength();

                entity.Property(e => e.BalancAmt)
                    .HasPrecision(15)
                    .HasColumnName("BALANC_AMT");

                entity.Property(e => e.BaseRate2)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("BASE_RATE2");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.Calcdte)
                    .HasColumnType("DATE")
                    .HasColumnName("CALCDTE");

                entity.Property(e => e.CalcdtePd)
                    .HasColumnType("DATE")
                    .HasColumnName("CALCDTE_PD");

                entity.Property(e => e.Calcrate)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("CALCRATE");

                entity.Property(e => e.Calcrate1)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CALCRATE1");

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.CcySei)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_SEI")
                    .IsFixedLength();

                entity.Property(e => e.CcySpt)
                    .HasColumnType("NUMBER(28,20)")
                    .HasColumnName("CCY_SPT");

                entity.Property(e => e.Commitamt)
                    .HasPrecision(15)
                    .HasColumnName("COMMITAMT");

                entity.Property(e => e.CusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Cycleend)
                    .HasColumnType("DATE")
                    .HasColumnName("CYCLEEND");

                entity.Property(e => e.DealCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DEAL_CCY")
                    .IsFixedLength();

                entity.Property(e => e.DiffRate2)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("DIFF_RATE2");

                entity.Property(e => e.EarlyDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EARLY_DATE");

                entity.Property(e => e.Extraday)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EXTRADAY")
                    .IsFixedLength();

                entity.Property(e => e.Gfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("GFCUN")
                    .IsFixedLength();

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_CODE")
                    .IsFixedLength();

                entity.Property(e => e.GroupRate2)
                    .HasColumnType("NUMBER")
                    .HasColumnName("GROUP_RATE2");

                entity.Property(e => e.Idb)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDB")
                    .IsFixedLength();

                entity.Property(e => e.InterestRateType)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("INTEREST_RATE_TYPE");

                entity.Property(e => e.Interp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTERP")
                    .IsFixedLength();

                entity.Property(e => e.Interprate)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("INTERPRATE");

                entity.Property(e => e.IntpAmt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTP_AMT");

                entity.Property(e => e.IntpAmtEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTP_AMT_EGP");

                entity.Property(e => e.IntpCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("INTP_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Intperday)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTPERDAY");

                entity.Property(e => e.Intpernum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INTPERNUM");

                entity.Property(e => e.Intperunit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("INTPERUNIT")
                    .IsFixedLength();

                entity.Property(e => e.Inttypeid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INTTYPEID")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Maturity)
                    .HasColumnType("DATE")
                    .HasColumnName("MATURITY");

                entity.Property(e => e.PartpnRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PARTPN_REF")
                    .IsFixedLength();

                entity.Property(e => e.Pastduedte)
                    .HasColumnType("DATE")
                    .HasColumnName("PASTDUEDTE");

                entity.Property(e => e.Pedoramt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PEDORAMT")
                    .IsFixedLength();

                entity.Property(e => e.Prodcut)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRODCUT")
                    .IsFixedLength();

                entity.Property(e => e.Prodtypedesc)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRODTYPEDESC")
                    .IsFixedLength();

                entity.Property(e => e.Prodtypename)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PRODTYPENAME")
                    .IsFixedLength();

                entity.Property(e => e.Ptnshare)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PTNSHARE");

                entity.Property(e => e.RateType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RATE_TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Recamt)
                    .HasPrecision(15)
                    .HasColumnName("RECAMT");

                entity.Property(e => e.RecamtPd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECAMT_PD");

                entity.Property(e => e.RecamtPdEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RECAMT_PD_EGP");

                entity.Property(e => e.Recccy)
                    .IsUnicode(false)
                    .HasColumnName("RECCCY");

                entity.Property(e => e.RecccyPd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("RECCCY_PD")
                    .IsFixedLength();

                entity.Property(e => e.Schratetype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SCHRATETYPE")
                    .IsFixedLength();

                entity.Property(e => e.Sovalue)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasColumnName("SOVALUE");

                entity.Property(e => e.SplitTier)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SPLIT_TIER")
                    .IsFixedLength();

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.SwBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.SwBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.SwCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.SwLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.TierAmt)
                    .HasPrecision(15)
                    .HasColumnName("TIER_AMT");

                entity.Property(e => e.TierBase)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TIER_BASE")
                    .IsFixedLength();

                entity.Property(e => e.TierDiff)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIER_DIFF")
                    .IsFixedLength();

                entity.Property(e => e.TierNum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TIER_NUM");

                entity.Property(e => e.TierPnum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TIER_PNUM");

                entity.Property(e => e.TierPunit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TIER_PUNIT")
                    .IsFixedLength();

                entity.Property(e => e.TierSprd)
                    .HasColumnType("NUMBER(11,7)")
                    .HasColumnName("TIER_SPRD");
            });

            modelBuilder.Entity<ArtTiWatchlistOsCheckReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_WATCHLIST_OS_CHECK_REPORT");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_EGP");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.CcyCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CCY_CED")
                    .IsFixedLength();

                entity.Property(e => e.Descr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCR")
                    .IsFixedLength();

                entity.Property(e => e.Descri56)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("DESCRI56")
                    .IsFixedLength();

                entity.Property(e => e.Fullname)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isfinished)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISFINISHED")
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("LANGUAGE")
                    .IsFixedLength();

                entity.Property(e => e.Longna85)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("LONGNA85")
                    .IsFixedLength();

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.Npcpaddress1)
                    .IsUnicode(false)
                    .HasColumnName("NPCPADDRESS1");

                entity.Property(e => e.NpcpcusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPCPCUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Npcpgfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPCPGFCUN")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.NpcpswLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("NPCPSW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Pcpaddress1)
                    .IsUnicode(false)
                    .HasColumnName("PCPADDRESS1");

                entity.Property(e => e.PcpcusMnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PCPCUS_MNM")
                    .IsFixedLength();

                entity.Property(e => e.Pcpgfcun)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PCPGFCUN")
                    .IsFixedLength();

                entity.Property(e => e.PcpswBank)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_BANK")
                    .IsFixedLength();

                entity.Property(e => e.PcpswBranch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.PcpswCtr)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_CTR")
                    .IsFixedLength();

                entity.Property(e => e.PcpswLoc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PCPSW_LOC")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME");

                entity.Property(e => e.Started)
                    .HasPrecision(9)
                    .HasColumnName("STARTED");

                entity.Property(e => e.Status)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Touched)
                    .HasColumnType("DATE")
                    .HasColumnName("TOUCHED");

                entity.Property(e => e.Type)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TYPE")
                    .IsFixedLength();

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ArtTiAdvancePaymentUtilizationReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ADVANCE_PAYMENT_UTILIZATION_REPORT");

                entity.Property(e => e.AdvAmount)
                    .HasPrecision(15)
                    .HasColumnName("ADV_AMOUNT");

                entity.Property(e => e.AdvCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ADV_CURRENCY")
                    .IsFixedLength();

                entity.Property(e => e.AdvReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADV_REFERENCE")
                    .IsFixedLength();

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH")
                    .IsFixedLength();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATION_DATE");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DATE");

                entity.Property(e => e.NonPrincipalParty)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NON_PRINCIPAL_PARTY")
                    .IsFixedLength();

                entity.Property(e => e.OutstandingAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("OUTSTANDING_AMOUNT");

                entity.Property(e => e.PrincipalParty)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRINCIPAL_PARTY")
                    .IsFixedLength();

                entity.Property(e => e.UtilizationAmount)
                    .HasPrecision(15)
                    .HasColumnName("UTILIZATION_AMOUNT");

                entity.Property(e => e.UtilizationCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("UTILIZATION_CURRENCY")
                    .IsFixedLength();

                entity.Property(e => e.UtilizationTrn)
                    .IsUnicode(false)
                    .HasColumnName("UTILIZATION_TRN");
            });
            modelBuilder.Entity<ArtTiEcmWorkflowProgReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ECM_WORKFLOW_PROG_REPORT");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNED_TO")
                    .IsFixedLength();

                entity.Property(e => e.AssignmentType)
                    .HasMaxLength(62)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNMENT_TYPE");

                entity.Property(e => e.AuthorizeSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("AUTHORIZE_SLA_STATUS");

                entity.Property(e => e.AuthorizeStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AUTHORIZE_STEP_TIME");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STAT_CD");

                entity.Property(e => e.CutomerName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUTOMER_NAME");

                entity.Property(e => e.EcmCaseCreationDate)
                    .HasPrecision(6)
                    .HasColumnName("ECM_CASE_CREATION_DATE");

                entity.Property(e => e.EcmEvent)
                    .IsUnicode(false)
                    .HasColumnName("ECM_EVENT");

                entity.Property(e => e.EcmReference)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REFERENCE");

                entity.Property(e => e.EcmRejectionReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REJECTION_REASON");

                entity.Property(e => e.EcmRejectionType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REJECTION_TYPE");

                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EVENT_CREATION_DATE");

                entity.Property(e => e.EventName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_NAME")
                    .IsFixedLength();

                entity.Property(e => e.EventStatus)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STATUS");

                entity.Property(e => e.EventSteps)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STEPS");

                entity.Property(e => e.ExternalReviewSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("EXTERNAL_REVIEW_SLA_STATUS");

                entity.Property(e => e.ExternalReviewStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXTERNAL_REVIEW_STEP_TIME");

                entity.Property(e => e.FtiReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FTI_REFERENCE")
                    .IsFixedLength();

                entity.Property(e => e.InputMaxTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INPUT_MAX_TIME");

                entity.Property(e => e.InputSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("INPUT_SLA_STATUS");

                entity.Property(e => e.InputStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INPUT_STEP_TIME");

                entity.Property(e => e.Lstmodtime)
                    .HasPrecision(6)
                    .HasColumnName("LSTMODTIME");

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER");

                entity.Property(e => e.Product)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.ProductType)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE");

                entity.Property(e => e.RejectionReason)
                    .IsUnicode(false)
                    .HasColumnName("REJECTION_REASON");

                entity.Property(e => e.ReviewSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("REVIEW_SLA_STATUS");

                entity.Property(e => e.ReviewStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REVIEW_STEP_TIME");

                entity.Property(e => e.SlaDashboardAmber)
                    .HasPrecision(6)
                    .HasColumnName("SLA_DASHBOARD_AMBER");

                entity.Property(e => e.SlaDashboardRed)
                    .HasPrecision(6)
                    .HasColumnName("SLA_DASHBOARD_RED");

                entity.Property(e => e.SlaDeadline)
                    .HasPrecision(6)
                    .HasColumnName("SLA_DEADLINE");

                entity.Property(e => e.SlaRemainingTime)
                    .HasPrecision(15)
                    .HasColumnName("SLA_REMAINING_TIME");

                entity.Property(e => e.StepStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STEP_STATUS");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.WarningOverridden)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WARNING_OVERRIDDEN")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ArtTiFullJournalReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_FULL_JOURNAL_REPORT");

                entity.Property(e => e.Area)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("AREA");

                entity.Property(e => e.AreaCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AREA_CODE")
                    .IsFixedLength();

                entity.Property(e => e.DataAfter)
                    .IsUnicode(false)
                    .HasColumnName("DATA_AFTER");

                entity.Property(e => e.Databefore)
                    .IsUnicode(false)
                    .HasColumnName("DATABEFORE");

                entity.Property(e => e.Dataitem)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DATAITEM")
                    .IsFixedLength();

                entity.Property(e => e.Datetime)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETIME");

                entity.Property(e => e.Entrytimeutc)
                    .HasPrecision(6)
                    .HasColumnName("ENTRYTIMEUTC");

                entity.Property(e => e.Jkey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("JKEY");

                entity.Property(e => e.Mcaction)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MCACTION");

                entity.Property(e => e.Mcmtcetype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MCMTCETYPE");

                entity.Property(e => e.Mcnote)
                    .IsUnicode(false)
                    .HasColumnName("MCNOTE");

                entity.Property(e => e.Mcowner)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MCOWNER");

                entity.Property(e => e.Mcusername)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MCUSERNAME");

                entity.Property(e => e.MtceType)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("MTCE_TYPE");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ArtTiEcmWorkflowProgReportOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ECM_WORKFLOW_PROG_REPORT_OLD");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNED_TO")
                    .IsFixedLength();

                entity.Property(e => e.AssignmentType)
                    .HasMaxLength(62)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNMENT_TYPE");

                entity.Property(e => e.AuthorizeSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("AUTHORIZE_SLA_STATUS");

                entity.Property(e => e.AuthorizeStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AUTHORIZE_STEP_TIME");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STAT_CD");

                entity.Property(e => e.Comments)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CutomerName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUTOMER_NAME");

                entity.Property(e => e.EcmCaseCreationDate)
                    .HasPrecision(6)
                    .HasColumnName("ECM_CASE_CREATION_DATE");

                entity.Property(e => e.EcmEvent)
                    .IsUnicode(false)
                    .HasColumnName("ECM_EVENT");

                entity.Property(e => e.EcmReference)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REFERENCE");

                entity.Property(e => e.EcmRejectionReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REJECTION_REASON");

                entity.Property(e => e.EcmRejectionType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REJECTION_TYPE");

                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EVENT_CREATION_DATE");

                entity.Property(e => e.EventName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_NAME")
                    .IsFixedLength();

                entity.Property(e => e.EventStatus)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STATUS");

                entity.Property(e => e.EventSteps)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STEPS");

                entity.Property(e => e.ExternalReviewSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("EXTERNAL_REVIEW_SLA_STATUS");

                entity.Property(e => e.ExternalReviewStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXTERNAL_REVIEW_STEP_TIME");

                entity.Property(e => e.FtiReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FTI_REFERENCE")
                    .IsFixedLength();

                entity.Property(e => e.InputMaxTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INPUT_MAX_TIME");

                entity.Property(e => e.InputSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("INPUT_SLA_STATUS");

                entity.Property(e => e.InputStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INPUT_STEP_TIME");

                entity.Property(e => e.Lstmodtime)
                    .HasPrecision(6)
                    .HasColumnName("LSTMODTIME");

                entity.Property(e => e.Lstmoduser)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LSTMODUSER")
                    .IsFixedLength();

                entity.Property(e => e.Note)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NOTE");

                entity.Property(e => e.NoteCreationTime)
                    .HasPrecision(6)
                    .HasColumnName("NOTE_CREATION_TIME");

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER");

                entity.Property(e => e.Product)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.ProductType)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_TYPE");

                entity.Property(e => e.RejectionReason)
                    .IsUnicode(false)
                    .HasColumnName("REJECTION_REASON");

                entity.Property(e => e.ReviewSlaStatus)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("REVIEW_SLA_STATUS");

                entity.Property(e => e.ReviewStepTime)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REVIEW_STEP_TIME");

                entity.Property(e => e.SlaDashboardAmber)
                    .HasPrecision(6)
                    .HasColumnName("SLA_DASHBOARD_AMBER");

                entity.Property(e => e.SlaDashboardRed)
                    .HasPrecision(6)
                    .HasColumnName("SLA_DASHBOARD_RED");

                entity.Property(e => e.SlaDeadline)
                    .HasPrecision(6)
                    .HasColumnName("SLA_DEADLINE");

                entity.Property(e => e.SlaRemainingTime)
                    .HasPrecision(15)
                    .HasColumnName("SLA_REMAINING_TIME");

                entity.Property(e => e.StepStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STEP_STATUS");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");

                entity.Property(e => e.WarningOverridden)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("WARNING_OVERRIDDEN")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ArtTiEcmAuditReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_TI_ECM_AUDIT_REPORT");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_ID");

                entity.Property(e => e.CaseStatCd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STAT_CD");

                entity.Property(e => e.Comments)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CutomerName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CUTOMER_NAME");

                entity.Property(e => e.EcmCaseCreationDate)
                    .HasPrecision(6)
                    .HasColumnName("ECM_CASE_CREATION_DATE");

                entity.Property(e => e.EcmEvent)
                    .IsUnicode(false)
                    .HasColumnName("ECM_EVENT");

                entity.Property(e => e.EcmReference)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("ECM_REFERENCE");

                entity.Property(e => e.EventCreationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EVENT_CREATION_DATE");

                entity.Property(e => e.EventName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_NAME")
                    .IsFixedLength();

                entity.Property(e => e.EventStatus)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STATUS");

                entity.Property(e => e.EventSteps)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("EVENT_STEPS");

                entity.Property(e => e.FtiReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FTI_REFERENCE")
                    .IsFixedLength();

                entity.Property(e => e.MasterAssignedTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_ASSIGNED_TO")
                    .IsFixedLength();

                entity.Property(e => e.PrimaryOwner)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_OWNER");

                entity.Property(e => e.Product)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT");

                entity.Property(e => e.Producttype)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTTYPE");

                entity.Property(e => e.StepStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("STEP_STATUS");

                entity.Property(e => e.TransactionAmount)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("TRANSACTION_AMOUNT");

                entity.Property(e => e.TransactionCurrency)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_CURRENCY");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USER_ID");
            });
        }
        public void OnKYCModelCreating(ModelBuilder modelBuilder)
        {
            //KYC
            modelBuilder.Entity<ArtAuditCorporateView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AUDIT_CORPORATE_VIEW");

                entity.Property(e => e.ActivityAmount)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_AMOUNT");

                entity.Property(e => e.ActivityAmountCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_AMOUNT_CURRENCY");

                entity.Property(e => e.ActivityEndDate)
                    .HasPrecision(6)
                    .HasColumnName("ACTIVITY_END_DATE");

                entity.Property(e => e.ActivityStartDate)
                    .HasPrecision(6)
                    .HasColumnName("ACTIVITY_START_DATE");

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE");

                entity.Property(e => e.ActivityTypeDtls)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE_DTLS");

                entity.Property(e => e.ActivityTypeSub)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_TYPE_SUB");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualNetIncomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ANNUAL_NET_INCOME_CD");

                entity.Property(e => e.BankingOrCorporate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKING_OR_CORPORATE");

                entity.Property(e => e.BankingOrOtherRef)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKING_OR_OTHER_REF");

                entity.Property(e => e.BudgetDate1)
                    .HasPrecision(6)
                    .HasColumnName("BUDGET_DATE_1");

                entity.Property(e => e.BudgetDate2)
                    .HasPrecision(6)
                    .HasColumnName("BUDGET_DATE_2");

                entity.Property(e => e.BudgetDate3)
                    .HasPrecision(6)
                    .HasColumnName("BUDGET_DATE_3");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_CODE");

                entity.Property(e => e.CalculateZakahFlag)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CALCULATE_ZAKAH_FLAG");

                entity.Property(e => e.Capital1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_1");

                entity.Property(e => e.Capital2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_2");

                entity.Property(e => e.Capital3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CAPITAL_3");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CharityDonationsInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITY_DONATIONS_IND");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_REASON_ID");

                entity.Property(e => e.CommercialName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIAL_NAME");

                entity.Property(e => e.CommercialNameEn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIAL_NAME_EN");

                entity.Property(e => e.CompanyStock)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_STOCK");

                entity.Property(e => e.CompanyStockName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_STOCK_NAME");

                entity.Property(e => e.CorporateName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CORPORATE_NAME");

                entity.Property(e => e.CorporateNameEn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CORPORATE_NAME_EN");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_REFERENCE");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.DateOfBudget)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DATE_OF_BUDGET");

                entity.Property(e => e.DealAbrdBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEAL_ABRD_BANK_DETAILS");

                entity.Property(e => e.DealtBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALT_BANK_DETAILS");

                entity.Property(e => e.DefaultBranch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicActivityCode5)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_ACTIVITY_CODE5");

                entity.Property(e => e.FfiType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FFI_TYPE");

                entity.Property(e => e.FinancialStartDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FINANCIAL_START_DATE");

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FOREIGN_CONSULATE_EMBASSY_IND");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.Giin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GIIN");

                entity.Property(e => e.GovOrgInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GOV_ORG_IND");

                entity.Property(e => e.HeadQuarterCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HEAD_QUARTER_COUNTRY");

                entity.Property(e => e.HoldingCorporation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOLDING_CORPORATION");

                entity.Property(e => e.HoldingCorporationCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOLDING_CORPORATION_CD");

                entity.Property(e => e.IdIssueCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ID_ISSUE_COUNTRY");

                entity.Property(e => e.IdentExpiryDate)
                    .HasPrecision(6)
                    .HasColumnName("IDENT_EXPIRY_DATE");

                entity.Property(e => e.IdentIssueDate)
                    .HasPrecision(6)
                    .HasColumnName("IDENT_ISSUE_DATE");

                entity.Property(e => e.IdentNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_NUMBER");

                entity.Property(e => e.IdentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDENT_TYPE");

                entity.Property(e => e.IncorporationCountryCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_COUNTRY_CODE");

                entity.Property(e => e.IncorporationDate)
                    .HasPrecision(6)
                    .HasColumnName("INCORPORATION_DATE");

                entity.Property(e => e.IncorporationLegalForm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_LEGAL_FORM");

                entity.Property(e => e.IncorporationState)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCORPORATION_STATE");

                entity.Property(e => e.Industry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY");

                entity.Property(e => e.InvestmentBalance)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INVESTMENT_BALANCE");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastQueryDate)
                    .HasPrecision(6)
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalFormOthers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_FORM_OTHERS");

                entity.Property(e => e.LegalFormSub)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_FORM_SUB");

                entity.Property(e => e.LegalStepMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_MAIN_CODE");

                entity.Property(e => e.LegalStepSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_SUB_CODE");

                entity.Property(e => e.LimitsAmount)
                    .HasPrecision(19)
                    .HasColumnName("LIMITS_AMOUNT");

                entity.Property(e => e.LimitsAmountCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LIMITS_AMOUNT_CURRENCY");

                entity.Property(e => e.MainLegalForm)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MAIN_LEGAL_FORM");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME_LANGUAGE");

                entity.Property(e => e.NationalityCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_COUNTRY");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.NoOfEmployees)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NO_OF_EMPLOYEES");

                entity.Property(e => e.NonProfitOrganization)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORGANIZATION");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PaidUpCapitalAmount)
                    .HasPrecision(19)
                    .HasColumnName("PAID_UP_CAPITAL_AMOUNT");

                entity.Property(e => e.PaidUpCapitalCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAID_UP_CAPITAL_CURRENCY");

                entity.Property(e => e.ReferenceEmployeeId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE_EMPLOYEE_ID");

                entity.Property(e => e.RegExpiryDate)
                    .HasPrecision(6)
                    .HasColumnName("REG_EXPIRY_DATE");

                entity.Property(e => e.RegNumberCity)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REG_NUMBER_CITY");

                entity.Property(e => e.RegNumberLastDate)
                    .HasPrecision(6)
                    .HasColumnName("REG_NUMBER_LAST_DATE");

                entity.Property(e => e.RegNumberOffice)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REG_NUMBER_OFFICE");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRATION_NUMBER");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CODE");

                entity.Property(e => e.RiskReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_REASON");

                entity.Property(e => e.RiskWeight)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_WEIGHT");

                entity.Property(e => e.SalesBasis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_BASIS");

                entity.Property(e => e.SalesVolume1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_1");

                entity.Property(e => e.SalesVolume2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_2");

                entity.Property(e => e.SalesVolume3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SALES_VOLUME_3");

                entity.Property(e => e.SizeOfSales)
                    .HasPrecision(19)
                    .HasColumnName("SIZE_OF_SALES");

                entity.Property(e => e.SizeOfTransaction)
                    .HasPrecision(19)
                    .HasColumnName("SIZE_OF_TRANSACTION");

                entity.Property(e => e.TaxIdNum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_ID_NUM");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.TotalNoOfUnits)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TOTAL_NO_OF_UNITS");

                entity.Property(e => e.TradeAddDate)
                    .HasPrecision(6)
                    .HasColumnName("TRADE_ADD_DATE");

                entity.Property(e => e.TypeOfBusiness)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_OF_BUSINESS");

                entity.Property(e => e.TypeOfBusinessOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_OF_BUSINESS_OTHER");

                entity.Property(e => e.UnderEstablishment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNDER_ESTABLISHMENT");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.WomenShare)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WOMEN_SHARE");

                entity.Property(e => e.WorthCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WORTH_CODE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasPrecision(6)
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            modelBuilder.Entity<ArtAuditIndividualsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_AUDIT_INDIVIDUALS_VIEW");

                entity.Property(e => e.AKA)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("A_K_A");

                entity.Property(e => e.AmlRiskCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK_CD");

                entity.Property(e => e.AnnualIncomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ANNUAL_INCOME_CD");

                entity.Property(e => e.BusinessCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_CODE");

                entity.Property(e => e.BusinessSector)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_SECTOR");

                entity.Property(e => e.BusinessSectorOthers)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BUSINESS_SECTOR_OTHERS");

                entity.Property(e => e.CalculateZakahFlag)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CALCULATE_ZAKAH_FLAG");

                entity.Property(e => e.CaseRk)
                    .HasPrecision(19)
                    .HasColumnName("CASE_RK");

                entity.Property(e => e.CbRiskId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_ID");

                entity.Property(e => e.CbRiskRate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE");

                entity.Property(e => e.CbRiskRateOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CB_RISK_RATE_OTHER");

                entity.Property(e => e.CharityFlag)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITY_FLAG");

                entity.Property(e => e.CitizenOrResident)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CITIZEN_OR_RESIDENT");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.CloseDate)
                    .HasPrecision(6)
                    .HasColumnName("CLOSE_DATE");

                entity.Property(e => e.ClosingReasonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_REASON_ID");

                entity.Property(e => e.ClosingReasonIdOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_REASON_ID_OTHER");

                entity.Property(e => e.CompanySalesAmountPerYear)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_SALES_AMOUNT_PER_YEAR");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CustomerStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_STATUS");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_TYPE");

                entity.Property(e => e.DealAbrdBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEAL_ABRD_BANK_DETAILS");

                entity.Property(e => e.DealtBankDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALT_BANK_DETAILS");

                entity.Property(e => e.DefaultBranch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_BRANCH");

                entity.Property(e => e.EconomicMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_MAIN_CODE");

                entity.Property(e => e.EconomicSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ECONOMIC_SUB_CODE");

                entity.Property(e => e.EducationId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDUCATION_ID");

                entity.Property(e => e.EducationIdOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EDUCATION_ID_OTHER");

                entity.Property(e => e.EmployedOrBusiness)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYED_OR_BUSINESS");

                entity.Property(e => e.EmployeeIndicator)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_INDICATOR");

                entity.Property(e => e.EmployerBusinessAdrs)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_ADRS");

                entity.Property(e => e.EmployerBusinessCity)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_CITY");

                entity.Property(e => e.EmployerBusinessCtry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_CTRY");

                entity.Property(e => e.EmployerBusinessName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_NAME");

                entity.Property(e => e.EmployerBusinessState)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_STATE");

                entity.Property(e => e.EmployerBusinessTown)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_BUSINESS_TOWN");

                entity.Property(e => e.EmployerCountryPhoneCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_COUNTRY_PHONE_CODE");

                entity.Property(e => e.EmployerPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE");

                entity.Property(e => e.EmploymentType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYMENT_TYPE");

                entity.Property(e => e.ExpenseIsoCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXPENSE_ISO_CURRENCY");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.FirstNameEng)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME_ENG");

                entity.Property(e => e.FullNameAr)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME_AR");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME_EN");

                entity.Property(e => e.GenderCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GENDER_CD");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.HomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HOME_CD");

                entity.Property(e => e.IncomeIsoCurrency)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INCOME_ISO_CURRENCY");

                entity.Property(e => e.KycStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("KYC_STATUS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.LastNameEng)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME_ENG");

                entity.Property(e => e.LastQueryDate)
                    .HasPrecision(6)
                    .HasColumnName("LAST_QUERY_DATE");

                entity.Property(e => e.LegalMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_MAIN_CODE");

                entity.Property(e => e.LegalStepDate)
                    .HasPrecision(6)
                    .HasColumnName("LEGAL_STEP_DATE");

                entity.Property(e => e.LegalStepMainCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_MAIN_CODE");

                entity.Property(e => e.LegalStepSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_STEP_SUB_CODE");

                entity.Property(e => e.LegalSubCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_SUB_CODE");

                entity.Property(e => e.MaritalStatusCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS_CD");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME");

                entity.Property(e => e.MiddleNameEng)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLE_NAME_ENG");

                entity.Property(e => e.MonthExpense)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_EXPENSE");

                entity.Property(e => e.MonthIncome)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MONTH_INCOME");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.NameLanguage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME_LANGUAGE");

                entity.Property(e => e.NationalityCode1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_CODE1");

                entity.Property(e => e.NationalityCode2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_CODE2");

                entity.Property(e => e.NationalityCode3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY_CODE3");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.NumberOfDependents)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMBER_OF_DEPENDENTS");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION");

                entity.Property(e => e.OccupationDtl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DTL");

                entity.Property(e => e.OpeningReasonId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPENING_REASON_ID");

                entity.Property(e => e.OpeningReasonIdOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPENING_REASON_ID_OTHER");

                entity.Property(e => e.OtherBankAccounts)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OTHER_BANK_ACCOUNTS");

                entity.Property(e => e.PepIndicator)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PEP_INDICATOR");

                entity.Property(e => e.PepIndicatorDtls)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PEP_INDICATOR_DTLS");

                entity.Property(e => e.PepIndicatorOth)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PEP_INDICATOR_OTH");

                entity.Property(e => e.RaceId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RACE_ID");

                entity.Property(e => e.ReferredPersonAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERRED_PERSON_ADDRESS");

                entity.Property(e => e.ReferredPersonPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERRED_PERSON_PHONE");

                entity.Property(e => e.RelationToBankCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELATION_TO_BANK_CODE");

                entity.Property(e => e.Religion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELIGION");

                entity.Property(e => e.ResidenceCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY");

                entity.Property(e => e.RiskClassValue)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS_VALUE");

                entity.Property(e => e.RiskCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CODE");

                entity.Property(e => e.RiskCodeOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CODE_OTHER");

                entity.Property(e => e.RiskReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_REASON");

                entity.Property(e => e.SectorAnalysesCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SECTOR_ANALYSES_CODE");

                entity.Property(e => e.SictorCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SICTOR_CODE");

                entity.Property(e => e.SourceOfIncomeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_OF_INCOME_CD");

                entity.Property(e => e.SourceOfIncomeOther)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOURCE_OF_INCOME_OTHER");

                entity.Property(e => e.SpouseBusiness)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSE_BUSINESS");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SPOUSE_NAME");

                entity.Property(e => e.TaxRegulationCtryCd1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_CTRY_CD1");

                entity.Property(e => e.TaxRegulationCtryCd2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_CTRY_CD2");

                entity.Property(e => e.TaxRegulationCtryCd3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_CTRY_CD3");

                entity.Property(e => e.TaxRegulationTin1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_TIN1");

                entity.Property(e => e.TaxRegulationTin2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_TIN2");

                entity.Property(e => e.TaxRegulationTin3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TAX_REGULATION_TIN3");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.VisaExpirationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("VISA_EXPIRATION_DATE");

                entity.Property(e => e.VisaType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VISA_TYPE");

                entity.Property(e => e.WorthLastCalcDate)
                    .HasPrecision(6)
                    .HasColumnName("WORTH_LAST_CALC_DATE");
            });

            modelBuilder.Entity<ArtKycExpiredId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_EXPIRED_ID");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.IdExpireDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ID_EXPIRE_DATE");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("ID_NUMBER");
            });

            modelBuilder.Entity<ArtKycHighExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_EXPIRED");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycHighOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_ONE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycHighThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_THREE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycHighTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_HIGH_TWO_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_EXPIRED");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_ONE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_THREE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycLowTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_LOW_TWO_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumExpired>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_EXPIRED");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumOneMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_ONE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumThreeMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_THREE_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycMediumTwoMonth>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_MEDIUM_TWO_MONTH");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(765)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_NUMBER");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(1020)
                    .IsUnicode(false)
                    .HasColumnName("ENTITY_NAME");

                entity.Property(e => e.Month)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTH");

                entity.Property(e => e.NextUpdateDate)
                    .HasPrecision(6)
                    .HasColumnName("NEXT_UPDATE_DATE");

                entity.Property(e => e.RiskClassIndustry)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISK_CLASS/INDUSTRY");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtKycSummaryByRisk>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_KYC_SUMMARY_BY_RISK");

                entity.Property(e => e.AmlRisk)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AML_RISK");

                entity.Property(e => e.NumberOfNotUpdatedKyc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_NOT_UPDATED_KYC");

                entity.Property(e => e.NumberOfUpdatedKyc)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_UPDATED_KYC");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Type)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });
        }

        public void OnDGECMModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DGCMGMT");

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

                entity.Property(e => e.AnyBicFieldBic)
                    .IsUnicode(false)
                    .HasColumnName("ANYBICFIELDBIC");

                entity.Property(e => e.ApplicantId)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTID");

                entity.Property(e => e.ApplicantName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTNAME");

                entity.Property(e => e.ApplicantRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("APPLICANTREF");

                entity.Property(e => e.ApplicationDate)
                    .HasPrecision(6)
                    .HasColumnName("APPLICATIONDATE");

                entity.Property(e => e.BehalfOfBranch)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("BEHALFOFBRANCH");

                entity.Property(e => e.BeneficiaryAccountNum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYACCOUNTNUM");

                entity.Property(e => e.BeneficiaryBirthYear)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYBIRTHYEAR");

                entity.Property(e => e.BeneficiaryCountry)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYCOUNTRY");

                entity.Property(e => e.BeneficiaryIdentity)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYIDENTITY");

                entity.Property(e => e.BeneficiaryNationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYNATIONALITY");

                entity.Property(e => e.BirthPlace)
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

                entity.Property(e => e.CreditorAgentBankBic)
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

                entity.Property(e => e.DebtorAgentBankBic)
                    .IsUnicode(false)
                    .HasColumnName("DEBTORAGENTBANKBIC");

                entity.Property(e => e.DeleteFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DELETE_FLAG")
                    .IsFixedLength();

                entity.Property(e => e.DocumentReference)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTREFERENCE");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND")
                    .IsFixedLength();

                entity.Property(e => e.EventName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EVENTNAME");

                entity.Property(e => e.EventRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("EVENTREF");

                entity.Property(e => e.ExpiryDate)
                    .HasPrecision(6)
                    .HasColumnName("EXPIRYDATE");

                entity.Property(e => e.HitsCount)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HITS_COUNT");

                entity.Property(e => e.InputName)
                    .IsUnicode(false)
                    .HasColumnName("INPUTNAME");

                entity.Property(e => e.IntermediaryCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("INTERMEDIARYCODE");

                entity.Property(e => e.InvestrUserId)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("INVESTR_USER_ID");

                entity.Property(e => e.IssueDate)
                    .HasPrecision(6)
                    .HasColumnName("ISSUEDATE");

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED_BY");

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MASTERREF");

                entity.Property(e => e.MaxSensitivityRank)
                    .HasColumnType("NUMBER(38,4)")
                    .HasColumnName("MAXSENSITIVITYRANK");

                entity.Property(e => e.Nationality)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY");

                entity.Property(e => e.OpenDate)
                    .HasPrecision(6)
                    .HasColumnName("OPEN_DATE");

                entity.Property(e => e.OthNationality)
                    .IsUnicode(false)
                    .HasColumnName("OTHNATIONALITY");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PARTYTYPEDESC");

                entity.Property(e => e.PayDestinationCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PAYDESTINATIONCOUNTRY");

                entity.Property(e => e.PayOriginCountry)
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

                entity.Property(e => e.ProductType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTTYPE");

                entity.Property(e => e.ReceiverBankBic)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVERBANKBIC");

                entity.Property(e => e.ReceiverBic)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVERBIC");

                entity.Property(e => e.ReceiverCtry)
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

                entity.Property(e => e.RemitterAccountNum)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERACCOUNTNUM");

                entity.Property(e => e.RemitterBirthYear)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERBIRTHYEAR");

                entity.Property(e => e.RemitterCountry)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERCOUNTRY");

                entity.Property(e => e.RemitterIdentity)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERIDENTITY");

                entity.Property(e => e.RemitterNationality)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REMITTERNATIONALITY");

                entity.Property(e => e.ReopenDate)
                    .HasPrecision(6)
                    .HasColumnName("REOPEN_DATE");

                entity.Property(e => e.SearchCountry)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("SEARCHCOUNTRY");

                entity.Property(e => e.SearchUnit)
                    .HasMaxLength(1000)
                    .HasColumnName("SEARCHUNIT");

                entity.Property(e => e.SearchUser)
                    .HasMaxLength(1000)
                    .HasColumnName("SEARCHUSER");

                entity.Property(e => e.SenderBankBic)
                    .IsUnicode(false)
                    .HasColumnName("SENDERBANKBIC");

                entity.Property(e => e.SenderBic)
                    .IsUnicode(false)
                    .HasColumnName("SENDERBIC");

                entity.Property(e => e.SenderCtry)
                    .IsUnicode(false)
                    .HasColumnName("SENDERCTRY");

                entity.Property(e => e.SenderReceiverAgentCode)
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

                entity.Property(e => e.TransactionBeneficiary)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_BENEFICIARY");

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

                entity.Property(e => e.TransactionReference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TRANSACTION_REFERENCE");

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

                entity.Property(e => e.WasPending)
                    .IsUnicode(false)
                    .HasColumnName("WASPENDING");

                entity.Property(e => e.WlCategory)
                    .IsUnicode(false)
                    .HasColumnName("WL_CATEGORY");

                entity.Property(e => e.XIdentity)
                    .IsUnicode(false)
                    .HasColumnName("X_IDENTITY");
            });

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

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MODULE_NAME");

                entity.Property(e => e.ParentRefTableName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_REF_TABLE_NAME");

                entity.Property(e => e.ParentValCd)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("PARENT_VAL_CD");

                entity.Property(e => e.SrcSysCd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SRC_SYS_CD");

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

        public void OnDgAuditModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnDgAMLModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnCRPModelCreating(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnFCFCOREModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FCFCORE");

            modelBuilder.Entity<FscBranchDim>(entity =>
            {
                entity.HasKey(e => e.BranchKey)
                    .HasName("XPKFSC_BRANCH_DIM");

                entity.ToTable("FSC_BRANCH_DIM");

                entity.HasIndex(e => e.BranchName, "XIE2FSC_BRANCH_DIM");

                entity.HasIndex(e => e.BranchNumber, "XIE3FSC_BRANCH_DIM");

                entity.Property(e => e.BranchKey)
                    .HasPrecision(12)
                    .ValueGeneratedNever()
                    .HasColumnName("BRANCH_KEY");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.BranchNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NUMBER");

                entity.Property(e => e.BranchTypeDesc)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_TYPE_DESC");

                entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_BEGIN_DATE");

                entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHANGE_CURRENT_IND")
                    .IsFixedLength();

                entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_END_DATE")
                    .HasDefaultValueSql("to_date('59990101','YYYYMMDD')\n		");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_2");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_CITY_NAME");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_NAME");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STREET_POSTAL_CODE")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_CODE")
                    .IsFixedLength();

                entity.Property(e => e.StreetStateName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_NAME");
            });

            modelBuilder.Entity<FscPartyDim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FSC_PARTY_DIM");

                //entity.Property(e => e.AddressComments)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("ADDRESS_COMMENTS");

                //entity.Property(e => e.AddressTown)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("ADDRESS_TOWN");

                //entity.Property(e => e.AddressType)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("ADDRESS_TYPE");

                //entity.Property(e => e.Alias)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("ALIAS");

                entity.Property(e => e.AnnualIncomeAmount)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ANNUAL_INCOME_AMOUNT");

                entity.Property(e => e.BenOwnExemptInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("BEN_OWN_EXEMPT_IND");

                //entity.Property(e => e.BirthPlace)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("BIRTH_PLACE");

                //entity.Property(e => e.BusinessClosed)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("BUSINESS_CLOSED");

                entity.Property(e => e.ChangeBeginDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_BEGIN_DATE");

                entity.Property(e => e.ChangeCurrentInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CHANGE_CURRENT_IND");

                //entity.Property(e => e.ChangeDate)
                //    .HasColumnType("DATE")
                //    .HasColumnName("CHANGE_DATE");

                entity.Property(e => e.ChangeEndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CHANGE_END_DATE");

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CHECK_CASHER_IND");

                entity.Property(e => e.CitizenshipCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_CODE");

                entity.Property(e => e.CitizenshipCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CITIZENSHIP_COUNTRY_NAME");

                //entity.Property(e => e.Comments)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("COMMENTS");

                entity.Property(e => e.CurrencyExchangeInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCY_EXCHANGE_IND");

                //entity.Property(e => e.CustomerBusinessSegment)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("CUSTOMER_BUSINESS_SEGMENT");

                entity.Property(e => e.CustomerSinceDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CUSTOMER_SINCE_DATE");

                //entity.Property(e => e.DateBusinessClosed)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("DATE_BUSINESS_CLOSED");

                //entity.Property(e => e.DateDeceased)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("DATE_DECEASED");

                //entity.Property(e => e.Deceased)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("DECEASED");

                entity.Property(e => e.DoingBusinessAsName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("DOING_BUSINESS_AS_NAME");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ADDRESS");

                entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_IND");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYEE_NUMBER");

                //entity.Property(e => e.EmployerAddress)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_ADDRESS");

                //entity.Property(e => e.EmployerAddressType)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_ADDRESS_TYPE");

                //entity.Property(e => e.EmployerCity)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_CITY");

                //entity.Property(e => e.EmployerComments)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_COMMENTS");

                //entity.Property(e => e.EmployerCommunicationType)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_COMMUNICATION_TYPE");

                //entity.Property(e => e.EmployerContactType)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_CONTACT_TYPE");

                //entity.Property(e => e.EmployerCountryCode)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_COUNTRY_CODE");

                //entity.Property(e => e.EmployerCountryPrefix)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_COUNTRY_PREFIX");

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_NAME");

                //entity.Property(e => e.EmployerNumber)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_NUMBER");

                entity.Property(e => e.EmployerPhoneNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EMPLOYER_PHONE_NUMBER");

                //entity.Property(e => e.EmployerState)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_STATE");

                //entity.Property(e => e.EmployerTown)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_TOWN");

                //entity.Property(e => e.EmployerZip)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPLOYER_ZIP");

                //entity.Property(e => e.EmpoyerExtension)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("EMPOYER_EXTENSION");

                entity.Property(e => e.EntitySegmentId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ENTITY_SEGMENT_ID");

                entity.Property(e => e.Errordesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ERRORDESC");

                entity.Property(e => e.ExternalPartyInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("EXTERNAL_PARTY_IND");

                entity.Property(e => e.ForeignConsulateEmbassyInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("FOREIGN_CONSULATE_EMBASSY_IND");

                //entity.Property(e => e.Gender)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("GENDER");

                //entity.Property(e => e.HoldMail)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("HOLD_MAIL");

                //entity.Property(e => e.IdNumber)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("ID_NUMBER");

                //entity.Property(e => e.IdentComments)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("IDENT_COMMENTS");

                //entity.Property(e => e.IdentExpiryDate)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("IDENT_EXPIRY_DATE");

                //entity.Property(e => e.IdentIssueCountry)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("IDENT_ISSUE_COUNTRY");

                //entity.Property(e => e.IdentIssueDate)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("IDENT_ISSUE_DATE");

                //entity.Property(e => e.IdentIssuedBy)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("IDENT_ISSUED_BY");

                //entity.Property(e => e.IncorporationDate)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("INCORPORATION_DATE");

                //entity.Property(e => e.IncorporationLegalForm)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("INCORPORATION_LEGAL_FORM");

                //entity.Property(e => e.IncorporationNumber)
                //    .HasColumnType("NUMBER(38)")
                //    .HasColumnName("INCORPORATION_NUMBER");

                //entity.Property(e => e.IncorporationState)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("INCORPORATION_STATE");

                entity.Property(e => e.IndustryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE");

                entity.Property(e => e.IndustryCodeRr)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_CODE_RR");

                entity.Property(e => e.IndustryDesc)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("INDUSTRY_DESC");

                entity.Property(e => e.InternetGamblingInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("INTERNET_GAMBLING_IND");

                entity.Property(e => e.IssuesBearerSharesInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ISSUES_BEARER_SHARES_IND");

                entity.Property(e => e.LastCashTransRptDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LAST_CASH_TRANS_RPT_DATE");

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_CONTACT_DATE");

                entity.Property(e => e.LastRiskAssessmentDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_RISK_ASSESSMENT_DATE");

                entity.Property(e => e.LastSuspActvRptDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LAST_SUSP_ACTV_RPT_DATE");

                //entity.Property(e => e.LegalEntityCode)
                //    .HasColumnType("NUMBER(38)")
                //    .HasColumnName("LEGAL_ENTITY_CODE");

                //entity.Property(e => e.LegalEntityDesc)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("LEGAL_ENTITY_DESC");

                entity.Property(e => e.LegalEntityType)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LEGAL_ENTITY_TYPE");

                entity.Property(e => e.LstUpdateDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("LST_UPDATE_DATE");

                entity.Property(e => e.MailingAddress1)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_1");

                entity.Property(e => e.MailingAddress2)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_ADDRESS_2");

                entity.Property(e => e.MailingCityName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_CITY_NAME");

                entity.Property(e => e.MailingCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_COUNTRY_CODE");

                entity.Property(e => e.MailingCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_COUNTRY_NAME");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_POSTAL_CODE");

                entity.Property(e => e.MailingStateCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_STATE_CODE");

                entity.Property(e => e.MailingStateName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MAILING_STATE_NAME");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MARITAL_STATUS_DESC");

                entity.Property(e => e.MatchCodeIndividual)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_INDIVIDUAL");

                entity.Property(e => e.MatchCodeMailingAddrLines)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_ADDR_LINES");

                entity.Property(e => e.MatchCodeMailingAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_ADDRESS");

                entity.Property(e => e.MatchCodeMailingCity)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_CITY");

                entity.Property(e => e.MatchCodeMailingCountry)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_COUNTRY");

                entity.Property(e => e.MatchCodeMailingState)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_MAILING_STATE");

                entity.Property(e => e.MatchCodeOrganization)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_ORGANIZATION");

                entity.Property(e => e.MatchCodeStreetAddrLines)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_ADDR_LINES");

                entity.Property(e => e.MatchCodeStreetAddress)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_ADDRESS");

                entity.Property(e => e.MatchCodeStreetCity)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_CITY");

                entity.Property(e => e.MatchCodeStreetCountry)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_COUNTRY");

                entity.Property(e => e.MatchCodeStreetState)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MATCH_CODE_STREET_STATE");

                entity.Property(e => e.MoneyOrdersInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MONEY_ORDERS_IND");

                entity.Property(e => e.MoneyTransmitterInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MONEY_TRANSMITTER_IND");

                //entity.Property(e => e.MothersName)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("MOTHERS_NAME");

                entity.Property(e => e.MsbInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("MSB_IND");

                //entity.Property(e => e.Nationality2)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("NATIONALITY2");

                //entity.Property(e => e.Nationality3)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("NATIONALITY3");

                entity.Property(e => e.NegativeNewsInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NEGATIVE_NEWS_IND");

                entity.Property(e => e.NetWorthAmount)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NET_WORTH_AMOUNT");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("NON_PROFIT_ORG_IND");

                //entity.Property(e => e.OccupationCode)
                //    .HasColumnType("NUMBER(38)")
                //    .HasColumnName("OCCUPATION_CODE");

                entity.Property(e => e.OccupationDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("OCCUPATION_DESC");

                entity.Property(e => e.OrgCountryOfBusinessCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ORG_COUNTRY_OF_BUSINESS_CODE");

                entity.Property(e => e.OrgCountryOfBusinessName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("ORG_COUNTRY_OF_BUSINESS_NAME");

                entity.Property(e => e.PartyDateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("PARTY_DATE_OF_BIRTH");

                entity.Property(e => e.PartyFirstName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_FIRST_NAME");

                entity.Property(e => e.PartyIdCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_ID_COUNTRY_CODE");

                entity.Property(e => e.PartyIdStateCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_ID_STATE_CODE");

                entity.Property(e => e.PartyIdentificationId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARTY_IDENTIFICATION_ID");

                entity.Property(e => e.PartyIdentificationTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_IDENTIFICATION_TYPE_DESC");

                entity.Property(e => e.PartyKey)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARTY_KEY");

                entity.Property(e => e.PartyLastName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_LAST_NAME");

                entity.Property(e => e.PartyMiddleName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_MIDDLE_NAME");

                entity.Property(e => e.PartyName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NAME");

                entity.Property(e => e.PartyNumber)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_NUMBER");

                entity.Property(e => e.PartyStatusDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_STATUS_DESC");

                entity.Property(e => e.PartyTaxId)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TAX_ID");

                entity.Property(e => e.PartyTaxIdTypeCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TAX_ID_TYPE_CODE");

                entity.Property(e => e.PartyTypeDesc)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PARTY_TYPE_DESC");

                //entity.Property(e => e.PassportCountry)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("PASSPORT_COUNTRY");

                entity.Property(e => e.PhoneNumber1)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_1");

                entity.Property(e => e.PhoneNumber2)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_2");

                entity.Property(e => e.PhoneNumber3)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER_3");

                entity.Property(e => e.PoliticallyExposedPersonInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("POLITICALLY_EXPOSED_PERSON_IND");

                entity.Property(e => e.PrepaidCardsInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PREPAID_CARDS_IND");

                entity.Property(e => e.PurgeDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("PURGE_DATE");

                entity.Property(e => e.ResidenceCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_CODE");

                entity.Property(e => e.ResidenceCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCE_COUNTRY_NAME");

                entity.Property(e => e.Result)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RESULT");

                //entity.Property(e => e.RiskAssessment)
                //    .HasColumnType("NUMBER(38)")
                //    .HasColumnName("RISK_ASSESSMENT");

                entity.Property(e => e.RiskClassification)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("RISK_CLASSIFICATION");

                entity.Property(e => e.ScreeningDate)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("SCREENING_DATE");

                //entity.Property(e => e.SegmentId)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("SEGMENT_ID");

                //entity.Property(e => e.SourceOfWealth)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("SOURCE_OF_WEALTH");

                entity.Property(e => e.StreetAddress1)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_1");

                entity.Property(e => e.StreetAddress2)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STREET_ADDRESS_2");

                entity.Property(e => e.StreetCityName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("STREET_CITY_NAME");

                entity.Property(e => e.StreetCountryCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_CODE");

                entity.Property(e => e.StreetCountryName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_COUNTRY_NAME");

                entity.Property(e => e.StreetPostalCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_POSTAL_CODE");

                entity.Property(e => e.StreetStateCode)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_CODE");

                entity.Property(e => e.StreetStateName)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("STREET_STATE_NAME");

                entity.Property(e => e.SuspActvRptCount)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("SUSP_ACTV_RPT_COUNT");

                //entity.Property(e => e.Title)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("TITLE");

                //entity.Property(e => e.TphComments)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("TPH_COMMENTS");

                //entity.Property(e => e.TphCommunicationType)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("TPH_COMMUNICATION_TYPE");

                //entity.Property(e => e.TphContactType)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("TPH_CONTACT_TYPE");

                //entity.Property(e => e.TphCountryPrefix)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("TPH_COUNTRY_PREFIX");

                //entity.Property(e => e.TphExtension)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("TPH_EXTENSION");

                entity.Property(e => e.TravelersChequesInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TRAVELERS_CHEQUES_IND");

                entity.Property(e => e.TrustAccountInd)
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasColumnName("TRUST_ACCOUNT_IND");

                entity.Property(e => e.UltimateParentName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ULTIMATE_PARENT_NAME");

                //entity.Property(e => e.Url)
                //    .HasMaxLength(26)
                //    .IsUnicode(false)
                //    .HasColumnName("URL");
            });

        }

        public void OnGoAmlModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TARGET")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Action)
                    .IsUnicode(false)
                    .HasColumnName("ACTION");

                entity.Property(e => e.CurrencyCodeLocal)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODELOCAL");

                entity.Property(e => e.EntityReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENTITYREFERENCE");

                entity.Property(e => e.FiuRefNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIUREFNUMBER");

                entity.Property(e => e.IsValid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ISVALID");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Priority)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.Reason)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.RentityBranch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RENTITYBRANCH");

                entity.Property(e => e.RentityId)
                    .HasPrecision(10)
                    .HasColumnName("RENTITYID");

                entity.Property(e => e.ReportClosedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTCLOSEDDATE");

                entity.Property(e => e.ReportCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTCODE");

                entity.Property(e => e.ReportCreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTCREATEDBY");

                entity.Property(e => e.ReportCreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTCREATEDDATE");

                entity.Property(e => e.ReportingPersonType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTINGPERSONTYPE");

                entity.Property(e => e.ReportRiskSignificance)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTRISKSIGNIFICANCE");

                entity.Property(e => e.ReportStatusCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTSTATUSCODE");

                entity.Property(e => e.ReportUserLockId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTUSERLOCKID");

                entity.Property(e => e.ReportXml)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REPORTXML");

                entity.Property(e => e.SubmissionCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUBMISSIONCODE");

                entity.Property(e => e.SubmissionDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SUBMISSIONDATE");

                entity.Property(e => e.Version)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VERSION");
            });

            modelBuilder.Entity<Taccount>(entity =>
            {
                entity.ToTable("TACCOUNT");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Account)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNT");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNAME");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER(19,2)")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Beneficiary)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARY");

                entity.Property(e => e.BeneficiaryComment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYCOMMENT");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH");

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTNUMBER");

                entity.Property(e => e.Closed)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLOSED");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE");

                entity.Property(e => e.DateBalance)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DATEBALANCE");

                entity.Property(e => e.Iban)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IBAN");

                entity.Property(e => e.InstitutionCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTIONCODE");

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INSTITUTIONNAME");

                entity.Property(e => e.IsReviewed)
                    .HasPrecision(1)
                    .HasColumnName("IS_REVIEWED");

                entity.Property(e => e.IsEntity)
                    .HasPrecision(1)
                    .HasColumnName("ISENTITY");

                entity.Property(e => e.NonBankInstitution)
                    .HasPrecision(1)
                    .HasColumnName("NONBANKINSTITUTION");

                entity.Property(e => e.Opened)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPENED");

                entity.Property(e => e.PersonalAccountType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PERSONALACCOUNTTYPE");

                entity.Property(e => e.ReportPartyTypeId)
                    .HasPrecision(10)
                    .HasColumnName("REPORTPARTYTYPE_ID");

                entity.Property(e => e.StatusCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUSCODE");

                entity.Property(e => e.Swift)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SWIFT");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");
            });
            modelBuilder.Entity<ReportIndicatorType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REPORTINDICATORTYPE");

                entity.Property(e => e.Indicator)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INDICATOR");

                entity.Property(e => e.ReportId)
                    .HasPrecision(10)
                    .HasColumnName("REPORT_ID");
            });

        }

        public void OnTiZoneModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TIZONE2")
                 .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Master>(entity =>
            {
                entity.HasKey(e => e.Key97)
                    .HasName("PKMASTER");

                entity.ToTable("MASTER");

                entity.HasIndex(e => e.Nprcustsbb, "X10MASTER");

                entity.HasIndex(e => e.Relmstrkey, "X1MASTER");

                entity.HasIndex(e => e.Canourref, "X2MASTER");

                entity.HasIndex(e => e.Canprnref, "X3MASTER");

                entity.HasIndex(e => e.Cannprnref, "X4MASTER");

                entity.HasIndex(e => e.Ccy, "X5MASTER");

                entity.HasIndex(e => e.Exemplar, "X6MASTER");

                entity.HasIndex(e => new { e.Pricustsbb, e.Pricustmnm }, "X7MASTER");

                entity.HasIndex(e => e.BhalfBrn, "X8MASTER");

                entity.HasIndex(e => e.Workgroup, "X9MASTER");

                entity.Property(e => e.Key97)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("KEY97");

                entity.Property(e => e.AcctBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ACCT_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasPrecision(15)
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.AmtOS)
                    .HasPrecision(15)
                    .HasColumnName("AMT_O_S");

                entity.Property(e => e.BhalfBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("BHALF_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Billlevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BILLLEVEL")
                    .IsFixedLength();

                entity.Property(e => e.Bookoffdat)
                    .HasColumnType("DATE")
                    .HasColumnName("BOOKOFFDAT");

                entity.Property(e => e.Cannprnref)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("CANNPRNREF")
                    .IsFixedLength();

                entity.Property(e => e.Canourref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANOURREF")
                    .IsFixedLength();

                entity.Property(e => e.Canprnref)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("CANPRNREF")
                    .IsFixedLength();

                entity.Property(e => e.Ccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CCY")
                    .IsFixedLength();

                entity.Property(e => e.ChargeFor)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHARGE_FOR")
                    .IsFixedLength();

                entity.Property(e => e.CtrctDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CTRCT_DATE");

                entity.Property(e => e.Datatakeon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DATATAKEON")
                    .IsFixedLength();

                entity.Property(e => e.DeactDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEACT_DATE");

                entity.Property(e => e.DfltWkgrp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DFLT_WKGRP")
                    .IsFixedLength();

                entity.Property(e => e.Docsprep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCSPREP")
                    .IsFixedLength();

                entity.Property(e => e.Docspreprq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCSPREPRQ")
                    .IsFixedLength();

                entity.Property(e => e.Ebankmsref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EBANKMSREF")
                    .IsFixedLength();

                entity.Property(e => e.EcflnkKey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ECFLNK_KEY");

                entity.Property(e => e.EcflnkRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ECFLNK_REF")
                    .IsFixedLength();

                entity.Property(e => e.Eligfordel)
                    .HasColumnType("DATE")
                    .HasColumnName("ELIGFORDEL");

                entity.Property(e => e.EvCount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EV_COUNT");

                entity.Property(e => e.Exemplar)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("EXEMPLAR");

                entity.Property(e => e.ExpiryDat)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DAT");

                entity.Property(e => e.ExpiryLoc)
                    .HasMaxLength(29)
                    .IsUnicode(false)
                    .HasColumnName("EXPIRY_LOC")
                    .IsFixedLength();

                entity.Property(e => e.Extfield)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("EXTFIELD");

                entity.Property(e => e.InputBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("INPUT_BRN")
                    .IsFixedLength();

                entity.Property(e => e.LiabAmt)
                    .HasPrecision(15)
                    .HasColumnName("LIAB_AMT");

                entity.Property(e => e.LiabCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("LIAB_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Locked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LOCKED")
                    .IsFixedLength();

                entity.Property(e => e.Mailtobrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("MAILTOBRN")
                    .IsFixedLength();

                entity.Property(e => e.MasterRef)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MASTER_REF")
                    .IsFixedLength();

                entity.Property(e => e.NoBrowse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NO_BROWSE")
                    .IsFixedLength();

                entity.Property(e => e.NpcSwBic)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NPC_SW_BIC")
                    .IsFixedLength();

                entity.Property(e => e.NpcpPty)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("NPCP_PTY");

                entity.Property(e => e.NprRef)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("NPR_REF")
                    .IsFixedLength();

                entity.Property(e => e.Nprcustmnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NPRCUSTMNM")
                    .IsFixedLength();

                entity.Property(e => e.Nprcustsbb)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NPRCUSTSBB")
                    .IsFixedLength();

                entity.Property(e => e.NprnameL1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("NPRNAME_L1")
                    .IsFixedLength();

                entity.Property(e => e.OrigRef)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ORIG_REF")
                    .IsFixedLength();

                entity.Property(e => e.Origbranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ORIGBRANCH")
                    .IsFixedLength();

                entity.Property(e => e.Origisuser)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ORIGISUSER")
                    .IsFixedLength();

                entity.Property(e => e.Origname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ORIGNAME")
                    .IsFixedLength();

                entity.Property(e => e.Origref1)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("ORIGREF")
                    .IsFixedLength();

                entity.Property(e => e.Origteam)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ORIGTEAM")
                    .IsFixedLength();

                entity.Property(e => e.Origuser)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("ORIGUSER");

                entity.Property(e => e.ParentEv)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PARENT_EV");

                entity.Property(e => e.Pccenddadj)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PCCENDDADJ")
                    .IsFixedLength();

                entity.Property(e => e.PcpPty)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PCP_PTY");

                entity.Property(e => e.PcpSwBic)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("PCP_SW_BIC")
                    .IsFixedLength();

                entity.Property(e => e.Prdclass)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PRDCLASS")
                    .IsFixedLength();

                entity.Property(e => e.PrevSts)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PREV_STS")
                    .IsFixedLength();

                entity.Property(e => e.PriRef)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("PRI_REF")
                    .IsFixedLength();

                entity.Property(e => e.Pricustmnm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PRICUSTMNM")
                    .IsFixedLength();

                entity.Property(e => e.Pricustsbb)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("PRICUSTSBB")
                    .IsFixedLength();

                entity.Property(e => e.Primarycus)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PRIMARYCUS");

                entity.Property(e => e.PrinameL1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PRINAME_L1")
                    .IsFixedLength();

                entity.Property(e => e.Prodtype)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("PRODTYPE");

                entity.Property(e => e.RefLock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REF_LOCK")
                    .IsFixedLength();

                entity.Property(e => e.RefnoBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_BRN")
                    .IsFixedLength();

                entity.Property(e => e.RefnoMbe)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_MBE")
                    .IsFixedLength();

                entity.Property(e => e.RefnoPfix)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("REFNO_PFIX")
                    .IsFixedLength();

                entity.Property(e => e.RefnoSerl)
                    .HasColumnType("NUMBER")
                    .HasColumnName("REFNO_SERL");

                entity.Property(e => e.ReimbChgs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("REIMB_CHGS")
                    .IsFixedLength();

                entity.Property(e => e.Relmstrkey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("RELMSTRKEY");

                entity.Property(e => e.Relmstrref)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RELMSTRREF")
                    .IsFixedLength();

                entity.Property(e => e.RespUser)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("RESP_USER");

                entity.Property(e => e.Sharedliab)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SHAREDLIAB")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Swiftversn)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SWIFTVERSN");

                entity.Property(e => e.TakeAmdno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TAKE_AMDNO");

                entity.Property(e => e.TakeDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TAKE_DATE");

                entity.Property(e => e.TakePayno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TAKE_PAYNO");

                entity.Property(e => e.Takeon)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TAKEON")
                    .IsFixedLength();

                entity.Property(e => e.TfrMthd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TFR_MTHD")
                    .IsFixedLength();

                entity.Property(e => e.Totliabamt)
                    .HasPrecision(15)
                    .HasColumnName("TOTLIABAMT");

                entity.Property(e => e.Totliabccy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("TOTLIABCCY")
                    .IsFixedLength();

                entity.Property(e => e.TransBrn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("TRANS_BRN")
                    .IsFixedLength();

                entity.Property(e => e.Tstamp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TSTAMP");

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");

                entity.Property(e => e.Usercode1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE1")
                    .IsFixedLength();

                entity.Property(e => e.Usercode2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE2")
                    .IsFixedLength();

                entity.Property(e => e.Usercode3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USERCODE3")
                    .IsFixedLength();

                entity.Property(e => e.Useroptn1)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN1");

                entity.Property(e => e.Useroptn2)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN2");

                entity.Property(e => e.Useroptn3)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN3");

                entity.Property(e => e.Useroptn4)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN4");

                entity.Property(e => e.Useroptn5)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USEROPTN5");

                entity.Property(e => e.UtilisAmt)
                    .HasPrecision(15)
                    .HasColumnName("UTILIS_AMT");

                entity.Property(e => e.UtilisCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("UTILIS_CCY")
                    .IsFixedLength();

                entity.Property(e => e.Verlevel)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VERLEVEL");

                entity.Property(e => e.Workgroup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WORKGROUP")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.Key97)
                    .HasName("PKNOTE");

                entity.ToTable("NOTE");

                entity.HasIndex(e => e.MasterKey, "X1NOTEENT");

                entity.Property(e => e.Key97)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("KEY97");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODE")
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Createdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDATE");

                entity.Property(e => e.Createtime)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CREATETIME")
                    .IsFixedLength();

                entity.Property(e => e.Emphasis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EMPHASIS")
                    .IsFixedLength();

                entity.Property(e => e.MasterKey)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("MASTER_KEY");

                entity.Property(e => e.NoteEvent)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("NOTE_EVENT");

                entity.Property(e => e.NoteText)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("NOTE_TEXT");

                entity.Property(e => e.Style)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("STYLE")
                    .IsFixedLength();

                entity.Property(e => e.Tstamp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TSTAMP");

                entity.Property(e => e.Type)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("TYPE");

                entity.Property(e => e.Typeflag)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TYPEFLAG");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(20)")
                    .HasColumnName("USERID");
            });

            modelBuilder.HasSequence("DBOBJECTID_SEQUENCE").IncrementsBy(50);

            modelBuilder.HasSequence("HIBERNATE_SEQUENCE");

            modelBuilder.HasSequence("SQASYNC_SERVICE");

            modelBuilder.HasSequence("SQDLTCOMPONENTS");

            modelBuilder.HasSequence("SQJOBCONTROL");

            modelBuilder.HasSequence("SQSTEPCONTROL");
        }

        public void OnDGMGMGModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupDg>(entity =>
            {
                entity.ToTable("GROUP_DG");

                entity.HasIndex(e => e.Name, "UK_79KWWAF53VDTGFXWSEMB2Q3AU")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataUpdate)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_TYPE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<RoleDg>(entity =>
            {
                entity.ToTable("ROLE_DG");

                entity.HasIndex(e => e.Name, "UK_9DG6BNIG1Y6LU7H5NJSIGD013")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataUpdate)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_TYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<UserDg>(entity =>
            {
                entity.ToTable("USER_DG");

                entity.HasIndex(e => e.Name, "UK_KKXMXCSCCSDOXTGQLX5ROVTT2")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasPrecision(1)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CounterLock)
                    .HasPrecision(10)
                    .HasColumnName("COUNTER_LOCK");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataUpdate)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enable)
                    .HasPrecision(1)
                    .HasColumnName("ENABLE");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_FAILED_LOGIN");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_LOGIN_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");
            });
        }

        public void OnDGMGMGMAUDodelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AccountAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("SYS_C00137858");

                entity.ToTable("ACCOUNT_AUD");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Rev)
                    .HasPrecision(10)
                    .HasColumnName("REV");

                entity.Property(e => e.AuthenticationDomain)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AUTHENTICATION_DOMAIN");

                entity.Property(e => e.DataUpdate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Revtype)
                    .HasPrecision(3)
                    .HasColumnName("REVTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserId)
                    .HasPrecision(10)
                    .HasColumnName("USER_ID");
            });

            modelBuilder.Entity<GroupDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("SYS_C00137861");

                entity.ToTable("GROUP_DG_AUD");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Rev)
                    .HasPrecision(10)
                    .HasColumnName("REV");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataUpdate)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_TYPE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Revtype)
                    .HasPrecision(3)
                    .HasColumnName("REVTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<LoggedUserAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("SYS_C00137868");

                entity.ToTable("LOGGED_USER_AUD");

                entity.Property(e => e.Id)
                    .HasPrecision(19)
                    .HasColumnName("ID");

                entity.Property(e => e.Rev)
                    .HasPrecision(10)
                    .HasColumnName("REV");

                entity.Property(e => e.AppName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("APP_NAME");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_NAME");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVICE_TYPE");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Revtype)
                    .HasPrecision(3)
                    .HasColumnName("REVTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TokenId)
                    .HasPrecision(10)
                    .HasColumnName("TOKEN_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");
            });

            modelBuilder.Entity<RoleDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("SYS_C00137873");

                entity.ToTable("ROLE_DG_AUD");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Rev)
                    .HasPrecision(10)
                    .HasColumnName("REV");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataUpdate)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Revtype)
                    .HasPrecision(3)
                    .HasColumnName("REVTYPE");

                entity.Property(e => e.RoleType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_TYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<UserDgAud>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Rev })
                    .HasName("SYS_C00137880");

                entity.ToTable("USER_DG_AUD");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Rev)
                    .HasPrecision(10)
                    .HasColumnName("REV");

                entity.Property(e => e.Active)
                    .HasPrecision(1)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CounterLock)
                    .HasPrecision(10)
                    .HasColumnName("COUNTER_LOCK");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.DataUpdate)
                    .IsUnicode(false)
                    .HasColumnName("DATA_UPDATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DISPLAY_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enable)
                    .HasPrecision(1)
                    .HasColumnName("ENABLE");

                entity.Property(e => e.LastFailedLogin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_FAILED_LOGIN");

                entity.Property(e => e.LastLoginDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_LOGIN_DATE");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_BY");

                entity.Property(e => e.LastUpdatedDate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LAST_UPDATED_DATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Revtype)
                    .HasPrecision(3)
                    .HasColumnName("REVTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USER_TYPE");
            });
        }

        public void OnDGFATCAModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("FAGPDB");


        }
        public void OnFATCAModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ART")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<ArtFatcaAlert>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_ALERTS");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(1200)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IncidentId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("INCIDENT_ID");

                entity.Property(e => e.Type)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<ArtFatcaCace>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_CACES");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CaseType)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_TYPE");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(1200)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");
            });

            modelBuilder.Entity<ArtFatcaCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_CUSTOMERS");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_NAME");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.CaseStatus)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(6)
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.CustClsFlag)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CUST_CLS_FLAG");

                entity.Property(e => e.CustKey)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CUST_KEY");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(1200)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.MainNationality)
                    .HasColumnType("VARCHAR2(12000)")
                    .HasColumnName("MAIN_NATIONALITY");

                entity.Property(e => e.SignW8)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W8");

                entity.Property(e => e.SignW9)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W9");

                entity.Property(e => e.W8SignDate)
                    .HasColumnType("DATE")
                    .HasColumnName("W8_SIGN_DATE");

                entity.Property(e => e.W9SignDate)
                    .HasColumnType("DATE")
                    .HasColumnName("W9_SIGN_DATE");
            });

            modelBuilder.Entity<ArtFatcaDormantAccountsSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_DORMANT_ACCOUNTS_SUMMARY");

                entity.Property(e => e.AmountInUsd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT_IN_USD");

                entity.Property(e => e.NumberOfAccounts)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_ACCOUNTS");
            });

            modelBuilder.Entity<ArtFatcaIrsReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ART_FATCA_IRS_REPORT");

                entity.Property(e => e.Accountbalance)
                    .HasColumnType("FLOAT")
                    .HasColumnName("ACCOUNTBALANCE");

                entity.Property(e => e.Accountclosed)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCLOSED");

                entity.Property(e => e.AccountcountFatca201)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA201")
                    .IsFixedLength();

                entity.Property(e => e.AccountcountFatca202)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA202")
                    .IsFixedLength();

                entity.Property(e => e.AccountcountFatca203)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ACCOUNTCOUNT_FATCA203");

                entity.Property(e => e.AccountcountFatca204)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA204")
                    .IsFixedLength();

                entity.Property(e => e.AccountcountFatca205)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA205")
                    .IsFixedLength();

                entity.Property(e => e.AccountcountFatca206)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCOUNT_FATCA206")
                    .IsFixedLength();

                entity.Property(e => e.Accountholdertype)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTHOLDERTYPE");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNUMBER");

                entity.Property(e => e.Accounttype)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTTYPE");

                entity.Property(e => e.AddressfreeE)
                    .HasMaxLength(1065)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESSFREE_E");

                entity.Property(e => e.AddressfreeI)
                    .HasMaxLength(1065)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESSFREE_I");

                entity.Property(e => e.Birthdate)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("BIRTHDATE")
                    .IsFixedLength();

                entity.Property(e => e.Countrycode)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYCODE");

                entity.Property(e => e.Countrycodeadd)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYCODEADD");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(750)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(1200)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(750)
                    .IsUnicode(false)
                    .HasColumnName("MIDDLENAME");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITY");

                entity.Property(e => e.OwnerAddress)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_ADDRESS")
                    .IsFixedLength();

                entity.Property(e => e.OwnerFirstName)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_FIRST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.OwnerLastName)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_LAST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.OwnerResCountryCode)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_RES_COUNTRY_CODE")
                    .IsFixedLength();

                entity.Property(e => e.OwnerTin)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("OWNER_TIN")
                    .IsFixedLength();

                entity.Property(e => e.Paymentamnt501)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PAYMENTAMNT_501");

                entity.Property(e => e.Paymentamnt502)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PAYMENTAMNT_502");

                entity.Property(e => e.Paymentamnt503)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PAYMENTAMNT_503");

                entity.Property(e => e.Paymentamnt504)
                    .HasColumnType("FLOAT")
                    .HasColumnName("PAYMENTAMNT_504");

                entity.Property(e => e.PoolbalanceFatca201)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA201")
                    .IsFixedLength();

                entity.Property(e => e.PoolbalanceFatca202)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA202")
                    .IsFixedLength();

                entity.Property(e => e.PoolbalanceFatca203)
                    .HasColumnType("FLOAT")
                    .HasColumnName("POOLBALANCE_FATCA203");

                entity.Property(e => e.PoolbalanceFatca204)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA204")
                    .IsFixedLength();

                entity.Property(e => e.PoolbalanceFatca205)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA205")
                    .IsFixedLength();

                entity.Property(e => e.PoolbalanceFatca206)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("POOLBALANCE_FATCA206")
                    .IsFixedLength();

                entity.Property(e => e.SignW8)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W8");

                entity.Property(e => e.SignW9)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_W9");

                entity.Property(e => e.Tin)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TIN");
            });

            modelBuilder.HasSequence("HF_JOB_ID_SEQ");

            modelBuilder.HasSequence("HF_SEQUENCE");



        }
        public void OnTRADE_BASEModelCreating(ModelBuilder modelBuilder)
        {

            throw new NotImplementedException();
        }
    }
}
