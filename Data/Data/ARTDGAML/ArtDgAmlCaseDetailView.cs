using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtDgAmlCaseDetailView
    {
        public string CaseId { get; set; } = null!;
        public string? EntityName { get; set; }
        public string? EntityNumber { get; set; }
        public string? BranchName { get; set; }
        public string? CasePriority { get; set; }
        public string? CaseStatusCode { get; set; }
        public string? CaseStatus { get; set; }
        public string? CaseCategoryCode { get; set; }
        public string? CaseCategory { get; set; }
        public string? CaseSubCategoryCode { get; set; }
        public string? EntityLevel { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
