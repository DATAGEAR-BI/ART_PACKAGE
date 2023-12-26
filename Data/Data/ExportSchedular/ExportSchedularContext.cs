using Microsoft.EntityFrameworkCore;

namespace Data.Data.ExportSchedular
{
    public class ExportSchedularContext : DbContext
    {

        public DbSet<ExportTask> ExportsTasks { get; set; } = null!;
        public ExportSchedularContext(DbContextOptions<ExportSchedularContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExportTask>(e =>
             {
                 e.HasQueryFilter(x => !x.Deleted);
                 e.Property(p => p.Period).HasConversion(v => v.ToString(), v => (TaskPeriod)Enum.Parse(typeof(TaskPeriod), v)).HasDefaultValue(TaskPeriod.Never);
                 e.Property(p => p.DayOfWeek).HasConversion(v => v.ToString(), v => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), v));
                 e.Property(p => p.Deleted).HasDefaultValue(false);
                 e.HasIndex(p => p.Name).IsUnique();
             });






        }
    }
}