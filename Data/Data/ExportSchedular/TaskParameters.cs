namespace Data.Data.ExportSchedular
{
    public class TaskParameters
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string ParameterName { get; set; } = null!;
        public string? ParameterValue { get; set; }
        public string Operator { get; set; } = null!;

        public ExportTask Task { get; set; } = null!;
    }
}
