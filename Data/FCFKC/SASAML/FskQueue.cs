namespace Data.FCFKC.SASAML
{
    public partial class FskQueue
    {
        public decimal QueueKey { get; set; }
        public string QueueCode { get; set; }
        public string QueueDescription { get; set; }
        public string AccessRoleName { get; set; }
        public string LastUpdateUser { get; set; }
        public char? LogicalDeleteIndicator { get; set; }
        public char? ActiveIndicator { get; set; }
        public DateTime ChangeBeginDate { get; set; }
        public DateTime ChangeEndDate { get; set; }
        public char ChangeCurrentIndicator { get; set; }
    }
}
