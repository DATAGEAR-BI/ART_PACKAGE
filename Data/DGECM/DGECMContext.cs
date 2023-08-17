using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DGECM
{
    public partial class DGECMContext : DbContext
    {
        public DGECMContext()
        {
        }

        public DGECMContext(DbContextOptions<DGECMContext> options)
            : base(options)
        {
        }
    }
}
