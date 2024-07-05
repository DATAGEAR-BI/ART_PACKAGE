using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.DGAMLCORE
{
    public partial class DGAMLCOREContext : DbContext
    {
        public DGAMLCOREContext()
        {
        }

        public DGAMLCOREContext(DbContextOptions<DGAMLCOREContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}
