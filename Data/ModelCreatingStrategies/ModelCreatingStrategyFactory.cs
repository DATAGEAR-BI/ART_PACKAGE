using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ModelCreatingStrategies
{
    public class ModelCreatingStrategyFactory
    {

        private readonly DbContext _context;

        public ModelCreatingStrategyFactory(DbContext context)
        {
            _context = context;
        }


        public IModelCreatingStrategy CreateModelCreatingStrategyInstance()
        {
            if (_context.Database.IsSqlServer())
                return new SqlServerModelCreatingStrategy();

            if (_context.Database.IsOracle())
                return new OracleModelCreatingStrategy();

            throw new NotSupportedException();
        }
    }
}
