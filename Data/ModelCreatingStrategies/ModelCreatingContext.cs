using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelCreatingStrategies
{
    public class ModelCreatingContext : IModelCreatingStrategy
    {
        private readonly IModelCreatingStrategy _strategy;

        public ModelCreatingContext(IModelCreatingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            _strategy.OnModelCreating(modelBuilder);
        }
    }
}
