using System.Text.Json.Serialization;

namespace Data.Data.ExportSchedular
{
    public class TaskMails
    {
        public int TaskId { get; set; }
        public string Mail { get; set; } = null!;
        [JsonIgnore]
        public ExportTask Task { get; set; } = null!;
    }
}
