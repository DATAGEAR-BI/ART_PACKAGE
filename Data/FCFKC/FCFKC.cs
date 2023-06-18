
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FCFKC
{
    public class FCFKC : DbContext
    {
        public FCFKC(DbContextOptions<FCFKC> opts) : base(opts)
        {

        }
        public virtual DbSet<FskLov> FskLovs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FskLov>(entity =>
            {
                entity.HasKey(e => new { e.LovTypeName, e.LovTypeCode, e.LovLanguageDesc })
                    .HasName("PK_LOV");

                entity.ToTable("FSK_LOV", "FCFKC");

                entity.Property(e => e.LovTypeName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("lov_type_name");

                entity.Property(e => e.LovTypeCode)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("lov_type_code");

                entity.Property(e => e.LovLanguageDesc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lov_language_desc");

                entity.Property(e => e.ActiveFlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("active_flg")
                    .HasDefaultValueSql("('Y')")
                    .IsFixedLength();

                entity.Property(e => e.LovSortPositionNumber).HasColumnName("lov_sort_position_number");

                entity.Property(e => e.LovTypeDesc)
                    .HasMaxLength(100)
                    .HasColumnName("lov_type_desc");
            });


        }
    }
}
