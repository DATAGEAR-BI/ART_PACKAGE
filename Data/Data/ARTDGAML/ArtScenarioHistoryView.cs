using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtScenarioHistoryView
    {
        public string? RoutineName { get; set; }
        public string? RoutineShortDesc { get; set; }
        public string? EventDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreateUserName { get; set; }
    }
}
