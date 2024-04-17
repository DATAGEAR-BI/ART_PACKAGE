namespace Data.GOAML
{
    public partial class Lookup
    {
        public int Id { get; set; }
        public string BusinessUnit { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? LookupKey { get; set; }
        public string? LookupName { get; set; }
        public string? LookupValue { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
