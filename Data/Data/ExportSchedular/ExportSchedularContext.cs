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
                e.HasMany(e => e.Parameters).WithOne(p => p.Task).HasForeignKey(p => p.TaskId);
                e.HasMany(e => e.Mails).WithOne(p => p.Task).HasForeignKey(p => p.TaskId);
                e.Property(p => p.Deleted).HasDefaultValue(false);
                e.HasIndex(p => p.Name).IsUnique();
            });

            modelBuilder.Entity<TaskMails>(e =>
            {
                e.HasKey(p => new { p.TaskId, p.Mail });
                e.HasOne(p => p.Task).WithMany(p => p.Mails).HasForeignKey(p => p.TaskId); ;
            });


            modelBuilder.Entity<TaskParameters>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasOne(p => p.Task).WithMany(p => p.Parameters).HasForeignKey(p => p.TaskId); ;

            });

        }
    }
}