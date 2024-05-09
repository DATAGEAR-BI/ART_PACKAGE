using  Data.Services.DbContextExtentions ;
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

            if (_context.Database.IsMySqlDb())
                return new MySqlModelCreatingStrategy();

            throw new NotSupportedException();
        }
    }
}
