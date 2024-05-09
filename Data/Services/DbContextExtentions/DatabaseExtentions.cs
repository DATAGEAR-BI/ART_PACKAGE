using Microsoft.EntityFrameworkCore.Infrastructure;
using MySql.EntityFrameworkCore.Infrastructure.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Data.Services.DbContextExtentions
{
    public static  class DatabaseExtentions
    {
        public static bool IsMySqlDb([NotNull] this DatabaseFacade database)
        {
            var mysqlProviderName = typeof(MySQLOptionsExtension).GetTypeInfo().Assembly.GetName().Name;
            var or = StringComparison.Ordinal;
            var result =  database.ProviderName.Equals(
               typeof(MySQLOptionsExtension).GetTypeInfo().Assembly.GetName().Name,
               StringComparison.Ordinal);
            return result;
        }
    }
}
