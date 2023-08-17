using Data.Data;
using Data.DGCMGMT;
using Data.DGECM;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ModelCreatingConfigurator
    {
        public static void SqlServerOnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public static void DGECMSqlServerOnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public static void DGECMOracleOnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public static void OracleOnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
