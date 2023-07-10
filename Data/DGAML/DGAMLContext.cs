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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
