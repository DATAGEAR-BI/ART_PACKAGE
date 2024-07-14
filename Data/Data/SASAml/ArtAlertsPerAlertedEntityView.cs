using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public partial class ArtAlertsPerAlertedEntityView
    {

        [Key]
        [StringLength(26)]
        public string AlertedEntityNumber { get; set; }

        [StringLength(128)]
        public string AlertedEntityName { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(40)]
        public string BranchNumber { get; set; }

        [StringLength(60)]
        public string OwnerUserId { get; set; }

        public decimal? NumberOfAlerts { get; set; }
    }
}
