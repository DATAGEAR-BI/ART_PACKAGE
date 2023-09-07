using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DGCALENDAR
{
    public class DGCALENDARContext : DbContext
    {
        public DGCALENDARContext()
        {

        }
        public DGCALENDARContext(DbContextOptions<DGCALENDARContext> dbContextOptions) : base(dbContextOptions) { }
    }
}
