using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DGAML
{
    public partial class DGAMLContext : DbContext
    {
        public DGAMLContext()
        {
        }

        public DGAMLContext(DbContextOptions<DGAMLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcLkpTable> AcLkpTables { get; set; } = null!;
        public virtual DbSet<AcRoutine> AcRoutines { get; set; } = null!;
        public virtual DbSet<AcScenarioEvent> AcScenarioEvents { get; set; } = null!;
        public virtual DbSet<AcSuspectedObject> AcSuspectedObjects { get; set; } = null!;
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<ExternalCustomer> ExternalCustomers { get; set; } = null!;

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<AcRoutineParameter> AcRoutineParameters { get; set; } = null!;
        public virtual DbSet<AcAlarm> AcAlarms { get; set; } = null!;
        public virtual DbSet<AcAlarmEvent> AcAlarmEvents { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcAlarmEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("AC_Alarm_Event", "AC");

                entity.Property(e => e.EventId)
                    .HasColumnType("numeric(12, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Event_Id");

                entity.Property(e => e.AlarmId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarm_Id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Event_Desc");

                entity.Property(e => e.EventTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("Event_Type_Cd");
            });

            modelBuilder.Entity<AcAlarm>(entity =>
            {
                entity.HasKey(e => e.AlarmId);

                entity.ToTable("AC_Alarm", "AC");

                entity.Property(e => e.AlarmId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarm_Id");

                entity.Property(e => e.ActualValueTxt)
                    .HasMaxLength(255)
                    .HasColumnName("Actual_Value_Txt");

                entity.Property(e => e.AlarmCategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Categ_Cd");

                entity.Property(e => e.AlarmDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Alarm_Desc");

                entity.Property(e => e.AlarmScore).HasColumnName("Alarm_Score");

                entity.Property(e => e.AlarmStatusCd)
                    .HasMaxLength(3)
                    .HasColumnName("Alarm_Status_Cd");

                entity.Property(e => e.AlarmSubcategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Subcateg_Cd");

                entity.Property(e => e.AlarmType)
                    .HasMaxLength(50)
                    .HasColumnName("Alarm_Type");

                entity.Property(e => e.AlarmTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Type_Cd");

                entity.Property(e => e.AlarmedObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarmed_Obj_Key");

                entity.Property(e => e.AlarmedObjLevelCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Alarmed_Obj_Level_Cd")
                    .IsFixedLength();

                entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Alarmed_Obj_Name");

                entity.Property(e => e.AlarmedObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Alarmed_Obj_No");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.LogicDelInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Logic_Del_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MlRiskScore).HasColumnName("Ml_Risk_Score");

                entity.Property(e => e.PrimObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Prim_Obj_Key");

                entity.Property(e => e.PrimObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Prim_Obj_level_Cd");

                entity.Property(e => e.PrimObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Prim_Obj_Name");

                entity.Property(e => e.PrimObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Prim_Obj_No");

                entity.Property(e => e.ProdType)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type");

                entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Routine_Id");

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(35)
                    .HasColumnName("Routine_Name");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Run_Date");

                entity.Property(e => e.SAnlysis)
                    .HasMaxLength(1000)
                    .HasColumnName("S_Anlysis");

                entity.Property(e => e.SScore).HasColumnName("S_Score");

                entity.Property(e => e.SupprEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Suppr_End_Date");

                entity.Property(e => e.TfRiskScore).HasColumnName("Tf_Risk_Score");

                entity.Property(e => e.UnSAnlysis)
                    .HasMaxLength(1000)
                    .HasColumnName("UnS_Anlysis");

                entity.Property(e => e.UnSScore).HasColumnName("UnS_Score");

                entity.Property(e => e.VerNo).HasColumnName("Ver_No");
            });
            modelBuilder.Entity<AcLkpTable>(entity =>
            {
                entity.HasKey(e => new { e.LkpName, e.LkpValCd, e.LkpLangDesc })
                    .HasName("AC_LKP_Table_PK2");

                entity.ToTable("AC_LKP_Table", "AC");

                entity.Property(e => e.LkpName)
                    .HasMaxLength(50)
                    .HasColumnName("LKP_Name");

                entity.Property(e => e.LkpValCd)
                    .HasMaxLength(100)
                    .HasColumnName("LKP_Val_Cd");

                entity.Property(e => e.LkpLangDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LKP_Lang_Desc");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Active_Flg")
                    .IsFixedLength();

                entity.Property(e => e.Deleted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DELETED")
                    .IsFixedLength();

                entity.Property(e => e.DisplayOrdrNo)
                    .HasColumnType("numeric(6, 0)")
                    .HasColumnName("Display_Ordr_No");

                entity.Property(e => e.LkpLangDescParent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LKP_Lang_Desc_parent");

                entity.Property(e => e.LkpNameParent)
                    .HasMaxLength(50)
                    .HasColumnName("LKP_Name_parent");

                entity.Property(e => e.LkpValCdParent)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LKP_Val_Cd_parent");

                entity.Property(e => e.LkpValDesc)
                    .HasMaxLength(4000)
                    .HasColumnName("LKP_Val_Desc");
            });
            modelBuilder.Entity<AcRoutine>(entity =>
            {
                entity.HasKey(e => e.RoutineId);

                entity.ToTable("AC_Routine", "AC");

                entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(12, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Routine_Id");

                entity.Property(e => e.AdminStatusCd)
                    .HasMaxLength(25)
                    .HasColumnName("admin_status_cd");

                entity.Property(e => e.AlarmCategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Categ_Cd");

                entity.Property(e => e.AlarmSubcategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Subcateg_Cd");

                entity.Property(e => e.AlarmTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Type_Cd");

                entity.Property(e => e.ComparedDateAttribute)
                    .HasMaxLength(255)
                    .HasColumnName("Compared_Date_Attribute");

                entity.Property(e => e.CorrespondingViewNm)
                    .HasMaxLength(1024)
                    .HasColumnName("corresponding_view_NM");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.CurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Current_Ind")
                    .IsFixedLength();

                entity.Property(e => e.DfltSupprDurCount).HasColumnName("Dflt_Suppr_Dur_Count");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.EndUserId)
                    .HasMaxLength(60)
                    .HasColumnName("End_User_Id");

                entity.Property(e => e.ExecProbRate)
                    .HasColumnType("numeric(7, 7)")
                    .HasColumnName("Exec_Prob_Rate");

                entity.Property(e => e.HeaderId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("header_id");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Update_Date");

                entity.Property(e => e.LastUpdateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Last_Update_User_Id");

                entity.Property(e => e.LogicDelInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Logic_Del_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MlBayesWeight)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("ML_Bayes_Weight");

                entity.Property(e => e.ObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Obj_Level_Cd");

                entity.Property(e => e.OrderInHeader).HasColumnName("Order_In_Header");

                entity.Property(e => e.PrimObjNoVarName)
                    .HasMaxLength(32)
                    .HasColumnName("Prim_Obj_No_Var_Name");

                entity.Property(e => e.ProdTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type_Cd");

                entity.Property(e => e.RiskFactInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Risk_Fact_Ind")
                    .IsFixedLength();

                entity.Property(e => e.RootKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("root_key");

                entity.Property(e => e.RouteGrpId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Route_Grp_Id");

                entity.Property(e => e.RouteUserLongId)
                    .HasMaxLength(60)
                    .HasColumnName("Route_User_Long_Id");

                entity.Property(e => e.RoutineCategCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Categ_Cd");

                entity.Property(e => e.RoutineCdLocDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Routine_Cd_Loc_Desc");

                entity.Property(e => e.RoutineDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Routine_Desc");

                entity.Property(e => e.RoutineDurCount).HasColumnName("Routine_Dur_Count");

                entity.Property(e => e.RoutineMsgTxt)
                    .HasMaxLength(255)
                    .HasColumnName("Routine_Msg_Txt");

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(32)
                    .HasColumnName("Routine_Name");

                entity.Property(e => e.RoutineRunFreqCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Run_Freq_Cd");

                entity.Property(e => e.RoutineShortDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Routine_Short_Desc");

                entity.Property(e => e.RoutineStatusCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Status_Cd");

                entity.Property(e => e.RoutineTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("Routine_Type_Cd");

                entity.Property(e => e.SaveTrigTransInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Save_Trig_Trans_Ind")
                    .IsFixedLength();

                entity.Property(e => e.SkipIfNoTransCcyDayInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Skip_If_No_Trans_Ccy_Day_Ind")
                    .IsFixedLength();

                entity.Property(e => e.TfBayesWeight)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("TF_Bayes_Weight");

                entity.Property(e => e.VerNo).HasColumnName("Ver_No");

                entity.Property(e => e.VsdInstallationName)
                    .HasMaxLength(255)
                    .HasColumnName("VSD_Installation_Name");

                entity.Property(e => e.VsdWinName)
                    .HasMaxLength(25)
                    .HasColumnName("VSD_Win_Name");
            });

            modelBuilder.Entity<AcScenarioEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("AC_Scenario_Event", "AC");

                entity.Property(e => e.EventId)
                    .HasColumnType("numeric(12, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Event_Id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                entity.Property(e => e.EventDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Event_Desc");

                entity.Property(e => e.EventTypeCd)
                    .HasMaxLength(60)
                    .HasColumnName("Event_Type_Cd");

                entity.Property(e => e.ScenarioRootKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Scenario_Root_Key");
            });
            modelBuilder.Entity<AcSuspectedObject>(entity =>
            {
                entity.HasKey(e => new { e.AlarmedObjLevelCd, e.AlarmedObjKey })
                    .HasName("XPKAC_Suspected_Object");

                entity.ToTable("AC_Suspected_Object", "AC");

                entity.Property(e => e.AlarmedObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Alarmed_Obj_level_Cd");

                entity.Property(e => e.AlarmedObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarmed_Obj_Key");

                entity.Property(e => e.AgeOldAlarm).HasColumnName("Age_Old_Alarm");

                entity.Property(e => e.AggAmt)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("Agg_Amt");

                entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Alarmed_Obj_Name");

                entity.Property(e => e.AlarmedObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Alarmed_Obj_No");

                entity.Property(e => e.AlarmsCount).HasColumnName("Alarms_Count");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CreateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Timestamp");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MlScore).HasColumnName("ML_Score");

                entity.Property(e => e.OwnerUid)
                    .HasMaxLength(240)
                    .HasColumnName("Owner_UID");

                entity.Property(e => e.PoliticalExpPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Political_Exp_Person_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ProdType)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type");

                entity.Property(e => e.RiskScoreCd)
                    .HasMaxLength(32)
                    .HasColumnName("Risk_Score_Cd");

                entity.Property(e => e.SuspectIdentity)
                    .HasMaxLength(50)
                    .HasColumnName("Suspect_Identity");

                entity.Property(e => e.SuspectQueue)
                    .HasMaxLength(50)
                    .HasColumnName("Suspect_Queue");

                entity.Property(e => e.TransCount).HasColumnName("Trans_Count");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AcctKey);

                entity.ToTable("Account", "DGAMLCORE");

                entity.Property(e => e.AcctKey).HasColumnName("Acct_Key");

                entity.Property(e => e.AcctCcyCd)
                    .HasMaxLength(3)
                    .HasColumnName("Acct_Ccy_Cd");

                entity.Property(e => e.AcctCcyName)
                    .HasMaxLength(100)
                    .HasColumnName("Acct_Ccy_Name");

                entity.Property(e => e.AcctCloseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Acct_Close_Date");

                entity.Property(e => e.AcctName)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_Name");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_No");

                entity.Property(e => e.AcctOpenDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Acct_Open_Date");

                entity.Property(e => e.AcctPrimBranchName)
                    .HasMaxLength(35)
                    .HasColumnName("Acct_Prim_Branch_Name");

                entity.Property(e => e.AcctRegName)
                    .HasMaxLength(255)
                    .HasColumnName("Acct_Reg_Name");

                entity.Property(e => e.AcctRegTypeDesc)
                    .HasMaxLength(35)
                    .HasColumnName("Acct_Reg_Type_Desc");

                entity.Property(e => e.AcctStatusDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_Status_Desc");

                entity.Property(e => e.AcctTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Acct_Tax_Id");

                entity.Property(e => e.AcctTaxIdTypeCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Acct_Tax_Id_Type_Cd")
                    .IsFixedLength();

                entity.Property(e => e.AcctTaxStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Acct_Tax_State_Cd");

                entity.Property(e => e.AcctTypeDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Acct_Type_Desc");

                entity.Property(e => e.AltName)
                    .HasMaxLength(50)
                    .HasColumnName("Alt_Name");

                entity.Property(e => e.CashIntsBusInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Cash_Ints_Bus_Ind")
                    .IsFixedLength();

                entity.Property(e => e.CcyBasedAcctInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ccy_Based_Acct_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_Begin_Date");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Chg_Current_Ind")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength();

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_End_Date")
                    .HasDefaultValueSql("('5999-01-01 00:00:00.000')");

                entity.Property(e => e.ColtrlTypeCd)
                    .HasMaxLength(50)
                    .HasColumnName("Coltrl_Type_Cd");

                entity.Property(e => e.ColtrlTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Coltrl_Type_Desc");

                entity.Property(e => e.DormInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Dorm_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.InstAmt)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("Inst_Amt");

                entity.Property(e => e.InsurAmt)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("Insur_Amt");

                entity.Property(e => e.LeaseTransfer).HasMaxLength(3);

                entity.Property(e => e.LetterCrOnfileInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Letter_Cr_Onfile_Ind")
                    .IsFixedLength();

                entity.Property(e => e.LineBusName)
                    .HasMaxLength(50)
                    .HasColumnName("Line_Bus_Name");

                entity.Property(e => e.MailAddr1)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_1");

                entity.Property(e => e.MailAddr2)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_City_Name");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Mail_Cntry_Cd")
                    .IsFixedLength();

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Mail_Cntry_Name");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Mail_Post_Cd")
                    .IsFixedLength();

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Mail_State_Cd")
                    .IsFixedLength();

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_State_Name");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Maturity_Date");

                entity.Property(e => e.OrigLoanAmt)
                    .HasColumnType("numeric(15, 5)")
                    .HasColumnName("Orig_Loan_Amt");

                entity.Property(e => e.ProdCategName)
                    .HasMaxLength(35)
                    .HasColumnName("Prod_Categ_Name");

                entity.Property(e => e.ProdLineName)
                    .HasMaxLength(35)
                    .HasColumnName("Prod_Line_Name");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(100)
                    .HasColumnName("Prod_Name");

                entity.Property(e => e.ProdNo)
                    .HasMaxLength(25)
                    .HasColumnName("Prod_No");

                entity.Property(e => e.ProdTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("Prod_Type_Name");

                entity.Property(e => e.Tenure).HasMaxLength(10);

                entity.Property(e => e.TradeFinInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Trade_Fin_Ind")
                    .IsFixedLength();

                entity.Property(e => e.Vinno)
                    .HasMaxLength(50)
                    .HasColumnName("VINNO");
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustKey);

                entity.ToTable("Customer", "DGAMLCORE");

                entity.Property(e => e.CustKey).HasColumnName("Cust_Key");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_2");

                entity.Property(e => e.AnnualIncomeAmt)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Annual_Income_Amt");

                entity.Property(e => e.CcyExchInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ccy_Exch_Ind")
                    .IsFixedLength();

                entity.Property(e => e.CheckCasherInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Check_Casher_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ChgBeginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_Begin_Date");

                entity.Property(e => e.ChgCurrentInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Chg_Current_Ind")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength();

                entity.Property(e => e.ChgEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Chg_End_Date")
                    .HasDefaultValueSql("('5999-01-01 00:00:00.000')");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Citizen_Cntry_Cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Citizen_Cntry_Name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("City_Name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Cntry_Cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Cntry_name");

                entity.Property(e => e.CustBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Birth_Date");

                entity.Property(e => e.CustFname)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_FName");

                entity.Property(e => e.CustGen)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Gen")
                    .IsFixedLength();

                entity.Property(e => e.CustIdCntryCd)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_Id_Cntry_Cd");

                entity.Property(e => e.CustIdStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Cust_Id_State_Cd");

                entity.Property(e => e.CustIdentExpDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Ident_Exp_Date");

                entity.Property(e => e.CustIdentId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Ident_Id");

                entity.Property(e => e.CustIdentIssDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Ident_Iss_Date");

                entity.Property(e => e.CustIdentTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Ident_Type_Desc");

                entity.Property(e => e.CustLname)
                    .HasMaxLength(100)
                    .HasColumnName("Cust_LName");

                entity.Property(e => e.CustMname)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_MName");

                entity.Property(e => e.CustName)
                    .HasMaxLength(200)
                    .HasColumnName("Cust_Name");

                entity.Property(e => e.CustNo)
                    .HasMaxLength(50)
                    .HasColumnName("Cust_No");

                entity.Property(e => e.CustSinceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Cust_Since_Date");

                entity.Property(e => e.CustStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Status_Desc");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Tax_Id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Tax_Id_Type_Cd")
                    .IsFixedLength();

                entity.Property(e => e.CustTypeDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Cust_Type_Desc");

                entity.Property(e => e.DoBusAsName)
                    .HasMaxLength(35)
                    .HasColumnName("Do_Bus_As_Name");

                entity.Property(e => e.EmailAddr)
                    .HasMaxLength(35)
                    .HasColumnName("Email_Addr");

                entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(20)
                    .HasColumnName("Emp_No");

                entity.Property(e => e.EmprName)
                    .HasMaxLength(35)
                    .HasColumnName("Empr_Name");

                entity.Property(e => e.EmprTelNo)
                    .HasMaxLength(25)
                    .HasColumnName("Empr_Tel_No");

                entity.Property(e => e.ExtCustInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Ext_Cust_Ind")
                    .IsFixedLength();

                entity.Property(e => e.FrgnConsulate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Frgn_Consulate")
                    .IsFixedLength();

                entity.Property(e => e.IndsCd)
                    .HasMaxLength(10)
                    .HasColumnName("Inds_Cd");

                entity.Property(e => e.IndsCdRr)
                    .HasMaxLength(10)
                    .HasColumnName("Inds_Cd_RR");

                entity.Property(e => e.IndsDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Inds_Desc");

                entity.Property(e => e.InternetGmblngInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Internet_Gmblng_Ind")
                    .IsFixedLength();

                entity.Property(e => e.IssBearsSharesInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Iss_Bears_Shares_Ind")
                    .IsFixedLength();

                entity.Property(e => e.LastContactDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Contact_Date");

                entity.Property(e => e.LegalObjType)
                    .HasMaxLength(30)
                    .HasColumnName("Legal_Obj_Type");

                entity.Property(e => e.LstCashTransReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Cash_Trans_Report_Date");

                entity.Property(e => e.LstRiskAssmntDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Risk_Assmnt_Date");

                entity.Property(e => e.LstSuspActReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Susp_Act_Report_Date");

                entity.Property(e => e.LstUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Lst_Update_Date");

                entity.Property(e => e.MachCdMailAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("Mach_Cd_Mail_Addr_Line");

                entity.Property(e => e.MailAddr1)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_1");

                entity.Property(e => e.MailAddr2)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_Addr_2");

                entity.Property(e => e.MailCityName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_City_Name");

                entity.Property(e => e.MailCntryCd)
                    .HasMaxLength(50)
                    .HasColumnName("Mail_Cntry_Cd");

                entity.Property(e => e.MailCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Mail_Cntry_Name");

                entity.Property(e => e.MailPostCd)
                    .HasMaxLength(10)
                    .HasColumnName("Mail_Post_Cd");

                entity.Property(e => e.MailStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Mail_State_Cd");

                entity.Property(e => e.MailStateName)
                    .HasMaxLength(35)
                    .HasColumnName("Mail_State_Name");

                entity.Property(e => e.MaritalStatusDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Marital_Status_Desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr_Line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_City");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Indv");

                entity.Property(e => e.MatchCdMailAddr)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_Addr");

                entity.Property(e => e.MatchCdMailCity)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_City");

                entity.Property(e => e.MatchCdMailCntry)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_Cntry");

                entity.Property(e => e.MatchCdMailState)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Mail_State");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_State");

                entity.Property(e => e.MoneyOrderInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Money_Order_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyServiceBusInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Money_Service_Bus_Ind")
                    .IsFixedLength();

                entity.Property(e => e.MoneyTransmtrInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Money_Transmtr_Ind")
                    .IsFixedLength();

                entity.Property(e => e.NationalAddr)
                    .HasMaxLength(250)
                    .HasColumnName("National_Addr");

                entity.Property(e => e.NegtvNewsInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Negtv_News_Ind")
                    .IsFixedLength();

                entity.Property(e => e.NetWorthAmt)
                    .HasColumnType("numeric(10, 0)")
                    .HasColumnName("Net_Worth_Amt");

                entity.Property(e => e.NonProfitOrgInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Non_Profit_Org_Ind")
                    .IsFixedLength();

                entity.Property(e => e.OccupDesc)
                    .HasMaxLength(35)
                    .HasColumnName("Occup_Desc");

                entity.Property(e => e.OrgCntryOfBusCd)
                    .HasMaxLength(3)
                    .HasColumnName("Org_Cntry_of_Bus_Cd");

                entity.Property(e => e.OrgCntryOfBusName)
                    .HasMaxLength(100)
                    .HasColumnName("Org_Cntry_of_Bus_Name");

                entity.Property(e => e.ParentName)
                    .HasMaxLength(35)
                    .HasColumnName("Parent_Name");

                entity.Property(e => e.PoliticalExpPrsnInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Political_Exp_Prsn_Ind")
                    .IsFixedLength();

                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("Post_Cd");

                entity.Property(e => e.PrepCardInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Prep_Card_Ind")
                    .IsFixedLength();

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Resid_Cntry_Cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Resid_Cntry_Name");

                entity.Property(e => e.RiskClass).HasColumnName("Risk_Class");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("State_Cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(35)
                    .HasColumnName("State_Name");

                entity.Property(e => e.SuspActRptCount)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("Susp_Act_RPT_Count");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_2");

                entity.Property(e => e.TelNo3)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_3");

                entity.Property(e => e.TravChekInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Trav_Chek_Ind")
                    .IsFixedLength();

                entity.Property(e => e.TrustAcctInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Trust_Acct_Ind")
                    .IsFixedLength();
            });
            modelBuilder.Entity<ExternalCustomer>(entity =>
            {
                entity.HasKey(e => e.ExtCustAcctKey);

                entity.ToTable("External_Customer", "DGAMLCORE");

                entity.Property(e => e.ExtCustAcctKey).HasColumnName("Ext_Cust_Acct_Key");

                entity.Property(e => e.AcctNo)
                    .HasMaxLength(50)
                    .HasColumnName("Acct_No");

                entity.Property(e => e.Addr1)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_1");

                entity.Property(e => e.Addr2)
                    .HasMaxLength(35)
                    .HasColumnName("Addr_2");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(35)
                    .HasColumnName("Branch_Name");

                entity.Property(e => e.BranchNo)
                    .HasMaxLength(25)
                    .HasColumnName("Branch_No");

                entity.Property(e => e.CitizenCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Citizen_Cntry_Cd");

                entity.Property(e => e.CitizenCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Citizen_Cntry_Name");

                entity.Property(e => e.CityName)
                    .HasMaxLength(35)
                    .HasColumnName("City_Name");

                entity.Property(e => e.CntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Cntry_Cd");

                entity.Property(e => e.CntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Cntry_Name");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(35)
                    .HasColumnName("Cust_Tax_Id");

                entity.Property(e => e.CustTaxIdTypeCd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Tax_Id_Type_Cd")
                    .IsFixedLength();

                entity.Property(e => e.ExtBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ext_Birth_Date");

                entity.Property(e => e.ExtCustNo)
                    .HasMaxLength(100)
                    .HasColumnName("Ext_Cust_No");

                entity.Property(e => e.ExtCustTypeDesc)
                    .HasMaxLength(50)
                    .HasColumnName("Ext_Cust_Type_Desc");

                entity.Property(e => e.ExtFname)
                    .HasMaxLength(50)
                    .HasColumnName("Ext_FName");

                entity.Property(e => e.ExtFullName)
                    .HasMaxLength(200)
                    .HasColumnName("Ext_Full_Name");

                entity.Property(e => e.ExtLname)
                    .HasMaxLength(100)
                    .HasColumnName("Ext_LName");

                entity.Property(e => e.ExtMname)
                    .HasMaxLength(50)
                    .HasColumnName("Ext_MName");

                entity.Property(e => e.FiNo)
                    .HasMaxLength(25)
                    .HasColumnName("FI_No");

                entity.Property(e => e.IdentCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Ident_Cntry_Cd");

                entity.Property(e => e.IdentCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Ident_Cntry_Name");

                entity.Property(e => e.IdentId)
                    .HasMaxLength(35)
                    .HasColumnName("Ident_Id");

                entity.Property(e => e.IdentStateCd)
                    .HasMaxLength(3)
                    .HasColumnName("Ident_State_Cd");

                entity.Property(e => e.IdentTypeDesc)
                    .HasMaxLength(4)
                    .HasColumnName("Ident_Type_Desc");

                entity.Property(e => e.MatchCdAddr)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr");

                entity.Property(e => e.MatchCdAddrLine)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Addr_Line");

                entity.Property(e => e.MatchCdCity)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_City");

                entity.Property(e => e.MatchCdCntry)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Cntry");

                entity.Property(e => e.MatchCdIndv)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Indv");

                entity.Property(e => e.MatchCdOrg)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_Org");

                entity.Property(e => e.MatchCdState)
                    .HasMaxLength(200)
                    .HasColumnName("Match_Cd_State");

                entity.Property(e => e.PostCd)
                    .HasMaxLength(10)
                    .HasColumnName("Post_Cd");

                entity.Property(e => e.ResidCntryCd)
                    .HasMaxLength(3)
                    .HasColumnName("Resid_Cntry_Cd");

                entity.Property(e => e.ResidCntryName)
                    .HasMaxLength(100)
                    .HasColumnName("Resid_Cntry_Name");

                entity.Property(e => e.StateCd)
                    .HasMaxLength(3)
                    .HasColumnName("State_Cd");

                entity.Property(e => e.StateName)
                    .HasMaxLength(35)
                    .HasColumnName("State_Name");

                entity.Property(e => e.TelNo1)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_1");

                entity.Property(e => e.TelNo2)
                    .HasMaxLength(25)
                    .HasColumnName("Tel_No_2");
            });
            modelBuilder.Entity<AcRoutineParameter>(entity =>
            {
                entity.HasKey(e => new { e.RoutineId, e.ParmName });

                entity.ToTable("AC_Routine_Parameter", "AC");

                entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Routine_Id");

                entity.Property(e => e.ParmName)
                    .HasMaxLength(32)
                    .HasColumnName("Parm_Name");

                entity.Property(e => e.DayType)
                    .HasMaxLength(10)
                    .HasColumnName("Day_Type");

                entity.Property(e => e.ParamCondition)
                    .HasMaxLength(1000)
                    .HasColumnName("param_condition");

                entity.Property(e => e.ParmDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Parm_Desc");

                entity.Property(e => e.ParmTypeDesc)
                    .HasMaxLength(32)
                    .HasColumnName("Parm_Type_Desc");

                entity.Property(e => e.ParmValue)
                    .HasMaxLength(1024)
                    .HasColumnName("Parm_Value");

                entity.Property(e => e.ValueCate)
                    .HasMaxLength(32)
                    .HasColumnName("value_cate");
            });

            modelBuilder.HasSequence("hibernate_sequence");

            modelBuilder.HasSequence("sequence_generator_AC_List", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_List_Category", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_List_Element", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Assessment", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier", "AC");

            modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier_Category", "AC");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
