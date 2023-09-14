using Microsoft.EntityFrameworkCore;

namespace Data.ModelCreatingStrategies
{
    public class ModelCreatingStrategyFactory
    {

        private readonly DbContext _context;

        public ModelCreatingStrategyFactory(DbContext context)
        {
            _context = context;
        }


        public IBaseModelCreatingStrategy CreateModelCreatingStrategyInstance()
        {
            if (_context.Database.IsSqlServer())
                return new SqlServerModelCreatingStrategy();

            if (_context.Database.IsOracle())
                return new OracleModelCreatingStrategy();

            throw new NotSupportedException();
        }
    }
}
