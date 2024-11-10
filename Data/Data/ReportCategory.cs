using ART_PACKAGE.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ReportCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        // Self-referencing relationship
        public int? ParentId { get; set; }

        // Navigation property to the parent category
        public virtual ReportCategory? Parent { get; set; }

        // Navigation property for child categories
        public virtual ICollection<ReportCategory> Children { get; set; } = new List<ReportCategory>();
        public virtual ICollection<ArtCustomReport> ArtCustomReports { get; set; } = new List<ArtCustomReport>();


    }
}
