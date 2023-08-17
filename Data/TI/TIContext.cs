using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.TI
{
    public class TIContext :DbContext
    {
        public TIContext() { }
        public TIContext(DbContextOptions<TIContext> options) : base(options) { }
    }
}
