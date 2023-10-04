namespace Data.Audit.DGMGMT_AUD
{
    public partial class GroupDgAud
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public short? Revtype { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? GroupType { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? DataUpdate { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? LastUpdatedDate { get; set; }
    }
}
