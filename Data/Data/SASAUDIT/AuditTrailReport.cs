using System;
using System.Collections.Generic;

#nullable disable

namespace DataGear_RV_Ver_1._7.dbcmcaudit
{
    public partial class AuditTrailReport
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ActionDetails { get; set; }
        public string ActionType { get; set; }
        public string ActionOn { get; set; }
        public DateTime? DateTime { get; set; }
        public string Description { get; set; }
        public string ObjectName { get; set; }
        public string ObjectType { get; set; }
    }
}
