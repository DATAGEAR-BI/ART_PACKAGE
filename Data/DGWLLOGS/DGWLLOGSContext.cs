using Data.DGECM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DGWLLOGS
{
    public class DGWLLOGSContext : DbContext
    {
        public DGWLLOGSContext() { }
        public DGWLLOGSContext(DbContextOptions<DGWLLOGSContext> options)
            : base(options)
        {
        }

    }
}
