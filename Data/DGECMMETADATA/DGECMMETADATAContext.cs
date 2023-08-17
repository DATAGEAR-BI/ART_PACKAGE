using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DGECMMETADATA
{
    public class DGECMMETADATAContext:DbContext
    {
        public DGECMMETADATAContext() { }
        public DGECMMETADATAContext(DbContextOptions<DGECMMETADATAContext> options) : base(options) { }
    }
}
