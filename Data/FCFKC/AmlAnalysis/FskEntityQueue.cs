namespace Data.FCFKC.AmlAnalysis
{
    public partial class FskEntityQueue
    {
        public string? QueueCode { get; set; }
        public string AlertedEntityLevelCode { get; set; } = null!;
        public string AlertedEntityNumber { get; set; } = null!;
        public string? OwnerUserid { get; set; }

        public string InsertString
        {
            get
            {
                var aelc = AlertedEntityLevelCode is null ? "NULL" : $"'{AlertedEntityLevelCode}'";
                var qc = QueueCode is null ? "NULL" : $"'{QueueCode}'";
                var aen = AlertedEntityNumber is null ? "NULL" : $"'{AlertedEntityNumber}'";
                var qui = OwnerUserid is null ? "NULL" : $"'{OwnerUserid}'";
                return $"({aelc},{aen},{qui},{qc})";
            }
        }
    }
}
