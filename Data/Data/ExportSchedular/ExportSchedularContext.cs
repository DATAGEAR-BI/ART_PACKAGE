using Data.Data.Audit;
using Microsoft.EntityFrameworkCore;

namespace Data.Data.ExportSchedular
{
    public class ExportSchedularContext : DbContext
    {
        public ExportSchedularContext(DbContextOptions<ArtAuditContext> options) : base(options)
        {
        }
    }
}
