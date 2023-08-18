using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public interface IModelCreatingStrategy
    {
        public void OnModelCreating(ModelBuilder modelBuilder);
        public void OnSegmentionModelCreating(ModelBuilder modelBuilder);
        public void OnARTGOAMLModelCreating(ModelBuilder modelBuilder);
        void OnARTDGAMLModelCreating(ModelBuilder modelBuilder);
    }
}
