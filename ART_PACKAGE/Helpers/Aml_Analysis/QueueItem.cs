namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public class QueueItem
    {
        public int QueueKey { get; set; }
        public string QueueCode { get; set; }
        public string QueueDescription { get; set; }
        public string AccessRoleName { get; set; }
        public string LstUpdateUser { get; set; }
        public string LogicalDeleteInd { get; set; }
        public string ActiveInd { get; set; }
        public DateTime ChangeBeginDate { get; set; }
        public DateTime ChangeEndDate { get; set; }
        public string ChangeCurrentInd { get; set; }
        public List<object> Links { get; set; }
    }

}
