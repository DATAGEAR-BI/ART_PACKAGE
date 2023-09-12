using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.DBModel
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

        public virtual DbSet<AcAlarm> AcAlarms { get; set; } = null!;
        public virtual DbSet<AcAlarm1> AcAlarms1 { get; set; } = null!;
        public virtual DbSet<AcAlarmEvent> AcAlarmEvents { get; set; } = null!;
        public virtual DbSet<AcSuspectedObject> AcSuspectedObjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                _ = optionsBuilder.UseSqlServer("Server=192.168.1.45;Database=DGAML;User Id=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<AcAlarm>(entity =>
            {
                _ = entity.HasKey(e => e.AlarmId);

                _ = entity.ToTable("AC_Alarm", "AC");

                _ = entity.Property(e => e.AlarmId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarm_Id");

                _ = entity.Property(e => e.ActualValueTxt)
                    .HasMaxLength(255)
                    .HasColumnName("Actual_Value_Txt");

                _ = entity.Property(e => e.AlarmCategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Categ_Cd");

                _ = entity.Property(e => e.AlarmDesc)
                    .HasMaxLength(100)
                    .HasColumnName("Alarm_Desc");

                _ = entity.Property(e => e.AlarmScore).HasColumnName("Alarm_Score");

                _ = entity.Property(e => e.AlarmStatusCd)
                    .HasMaxLength(3)
                    .HasColumnName("Alarm_Status_Cd");

                _ = entity.Property(e => e.AlarmSubcategCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Subcateg_Cd");

                _ = entity.Property(e => e.AlarmType)
                    .HasMaxLength(50)
                    .HasColumnName("Alarm_Type");

                _ = entity.Property(e => e.AlarmTypeCd)
                    .HasMaxLength(32)
                    .HasColumnName("Alarm_Type_Cd");

                _ = entity.Property(e => e.AlarmedObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarmed_Obj_Key");

                _ = entity.Property(e => e.AlarmedObjLevelCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("Alarmed_Obj_Level_Cd")
                    .IsFixedLength();

                _ = entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Alarmed_Obj_Name");

                _ = entity.Property(e => e.AlarmedObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Alarmed_Obj_No");

                _ = entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                _ = entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                _ = entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                _ = entity.Property(e => e.LogicDelInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Logic_Del_Ind")
                    .IsFixedLength();

                _ = entity.Property(e => e.MlRiskScore).HasColumnName("Ml_Risk_Score");

                _ = entity.Property(e => e.PrimObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Prim_Obj_Key");

                _ = entity.Property(e => e.PrimObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Prim_Obj_level_Cd");

                _ = entity.Property(e => e.PrimObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Prim_Obj_Name");

                _ = entity.Property(e => e.PrimObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Prim_Obj_No");

                _ = entity.Property(e => e.ProdType)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type");

                _ = entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Routine_Id");

                _ = entity.Property(e => e.RoutineName)
                    .HasMaxLength(35)
                    .HasColumnName("Routine_Name");

                _ = entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Run_Date");

                _ = entity.Property(e => e.SAnlysis)
                    .HasMaxLength(1000)
                    .HasColumnName("S_Anlysis");

                _ = entity.Property(e => e.SScore).HasColumnName("S_Score");

                _ = entity.Property(e => e.SupprEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Suppr_End_Date");

                _ = entity.Property(e => e.TfRiskScore).HasColumnName("Tf_Risk_Score");

                _ = entity.Property(e => e.UnSAnlysis)
                    .HasMaxLength(1000)
                    .HasColumnName("UnS_Anlysis");

                _ = entity.Property(e => e.UnSScore).HasColumnName("UnS_Score");

                _ = entity.Property(e => e.VerNo).HasColumnName("Ver_No");
            });

            _ = modelBuilder.Entity<AcAlarm1>(entity =>
            {
                _ = entity.HasKey(e => e.AlarmId)
                    .HasName("PK__AC_ALARM__84139119CF79C7A7");

                _ = entity.ToTable("AC_ALARM");

                _ = entity.Property(e => e.AlarmId)
                    .ValueGeneratedNever()
                    .HasColumnName("alarm_id");

                _ = entity.Property(e => e.ActualValuesText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("actual_values_text");

                _ = entity.Property(e => e.AlarmCategoryCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarm_category_cd");

                _ = entity.Property(e => e.AlarmDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarm_description");

                _ = entity.Property(e => e.AlarmStatusCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarm_status_code");

                _ = entity.Property(e => e.AlarmSubcategoryCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarm_subcategory_cd");

                _ = entity.Property(e => e.AlarmTypeCd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarm_type_cd");

                _ = entity.Property(e => e.AlarmedObjKey)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("alarmed_obj_key");

                _ = entity.Property(e => e.AlarmedObjLevelCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarmed_obj_level_code");

                _ = entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarmed_obj_name");

                _ = entity.Property(e => e.AlarmedObjNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alarmed_obj_number");

                _ = entity.Property(e => e.CreateDate).HasColumnName("create_date");

                _ = entity.Property(e => e.CreateUserId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id");

                _ = entity.Property(e => e.EmployeeInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("employee_ind");

                _ = entity.Property(e => e.LogicalDeleteInd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("logical_delete_ind");

                _ = entity.Property(e => e.MoneyLaunderingRiskScore)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("money_laundering_risk_score");

                _ = entity.Property(e => e.PrimaryObjKey)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("primary_obj_key");

                _ = entity.Property(e => e.PrimaryObjLevelCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("primary_obj_level_code");

                _ = entity.Property(e => e.PrimaryObjName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("primary_obj_name");

                _ = entity.Property(e => e.PrimaryObjNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("primary_obj_number");

                _ = entity.Property(e => e.ProductType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_type");

                _ = entity.Property(e => e.RoutineId)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("routine_id");

                _ = entity.Property(e => e.RoutineName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("routine_name");

                _ = entity.Property(e => e.RunDate).HasColumnName("run_date");

                _ = entity.Property(e => e.SuppressionEndDate).HasColumnName("suppression_end_date");

                _ = entity.Property(e => e.TerrorFinancingRiskScore)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("terror_financing_risk_score");

                _ = entity.Property(e => e.VersionNumber)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("version_number");
            });

            _ = modelBuilder.Entity<AcAlarmEvent>(entity =>
            {
                _ = entity.HasKey(e => e.EventId);

                _ = entity.ToTable("AC_Alarm_Event", "AC");

                _ = entity.Property(e => e.EventId)
                    .HasColumnType("numeric(12, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Event_Id");

                _ = entity.Property(e => e.AlarmId)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarm_Id");

                _ = entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Date");

                _ = entity.Property(e => e.CreateUserId)
                    .HasMaxLength(60)
                    .HasColumnName("Create_User_Id");

                _ = entity.Property(e => e.EventDesc)
                    .HasMaxLength(255)
                    .HasColumnName("Event_Desc");

                _ = entity.Property(e => e.EventTypeCd)
                    .HasMaxLength(3)
                    .HasColumnName("Event_Type_Cd");
            });

            _ = modelBuilder.Entity<AcSuspectedObject>(entity =>
            {
                _ = entity.HasKey(e => new { e.AlarmedObjLevelCd, e.AlarmedObjKey })
                    .HasName("XPKAC_Suspected_Object");

                _ = entity.ToTable("AC_Suspected_Object", "AC");

                _ = entity.Property(e => e.AlarmedObjLevelCd)
                    .HasMaxLength(3)
                    .HasColumnName("Alarmed_Obj_level_Cd");

                _ = entity.Property(e => e.AlarmedObjKey)
                    .HasColumnType("numeric(12, 0)")
                    .HasColumnName("Alarmed_Obj_Key");

                _ = entity.Property(e => e.AgeOldAlarm).HasColumnName("Age_Old_Alarm");

                _ = entity.Property(e => e.AggAmt)
                    .HasColumnType("numeric(15, 3)")
                    .HasColumnName("Agg_Amt");

                _ = entity.Property(e => e.AlarmedObjName)
                    .HasMaxLength(100)
                    .HasColumnName("Alarmed_Obj_Name");

                _ = entity.Property(e => e.AlarmedObjNo)
                    .HasMaxLength(50)
                    .HasColumnName("Alarmed_Obj_No");

                _ = entity.Property(e => e.AlarmsCount).HasColumnName("Alarms_Count");

                _ = entity.Property(e => e.Branch).HasMaxLength(50);

                _ = entity.Property(e => e.CreateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Timestamp");

                _ = entity.Property(e => e.EmpInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Ind")
                    .IsFixedLength();

                _ = entity.Property(e => e.MlScore).HasColumnName("ML_Score");

                _ = entity.Property(e => e.OwnerUid)
                    .HasMaxLength(240)
                    .HasColumnName("Owner_UID");

                _ = entity.Property(e => e.PoliticalExpPersonInd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Political_Exp_Person_Ind")
                    .IsFixedLength();

                _ = entity.Property(e => e.ProdType)
                    .HasMaxLength(3)
                    .HasColumnName("Prod_Type");

                _ = entity.Property(e => e.RiskScoreCd)
                    .HasMaxLength(32)
                    .HasColumnName("Risk_Score_Cd");

                _ = entity.Property(e => e.SuspectIdentity)
                    .HasMaxLength(50)
                    .HasColumnName("Suspect_Identity");

                _ = entity.Property(e => e.SuspectQueue)
                    .HasMaxLength(50)
                    .HasColumnName("Suspect_Queue");

                _ = entity.Property(e => e.TransCount).HasColumnName("Trans_Count");
            });

            _ = modelBuilder.HasSequence("hibernate_sequence");

            _ = modelBuilder.HasSequence("sequence_generator_AC_List", "AC");

            _ = modelBuilder.HasSequence("sequence_generator_AC_List_Category", "AC");

            _ = modelBuilder.HasSequence("sequence_generator_AC_List_Element", "AC");

            _ = modelBuilder.HasSequence("sequence_generator_AC_Risk_Assessment", "AC");

            _ = modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier", "AC");

            _ = modelBuilder.HasSequence("sequence_generator_AC_Risk_Classifier_Category", "AC");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
