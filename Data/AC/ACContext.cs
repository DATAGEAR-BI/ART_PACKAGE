using Data.ModelCreatingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Data.AC
{
    public partial class ACContext : DbContext
    {
        public ACContext()
        {
        }

        public ACContext(DbContextOptions<ACContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}
