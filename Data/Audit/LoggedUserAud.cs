using System;
using System.Collections.Generic;

namespace Data.Audit
{
    public partial class LoggedUserAud
    {
        public long Id { get; set; }
        public int Rev { get; set; }
        public short? Revtype { get; set; }
        public string? Status { get; set; }
        public string? AppName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? DeviceName { get; set; }
        public string? DeviceType { get; set; }
        public string? Ip { get; set; }
        public string? Location { get; set; }
        public int? TokenId { get; set; }
        public string? UserName { get; set; }
    }
}
