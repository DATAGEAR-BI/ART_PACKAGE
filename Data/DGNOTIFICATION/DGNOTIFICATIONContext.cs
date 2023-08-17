using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DGNOTIFICATION
{
    public class DGNOTIFICATIONContext :DbContext
    {
        public DGNOTIFICATIONContext()
        {

        }
        public DGNOTIFICATIONContext(DbContextOptions<DGNOTIFICATIONContext> options) : base(options) { }
    }
}
