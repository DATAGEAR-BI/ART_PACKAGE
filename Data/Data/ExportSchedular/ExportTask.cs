using CronExpressionDescriptor;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Data.ExportSchedular
{
    public class ExportTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ReportName { get; set; } = null!;


        public string DisplayName => Name.Split("##")[0];

        public TaskPeriod Period { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }

        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }

        public bool IsMailed { get; set; }

        public bool IsSavedOnServer { get; set; }

        public string? Path { get; set; }
        public string ParametersJson { get; set; } = null!;
        public string? MailContent { get; set; }

        public bool Deleted { get; set; }
        public bool EndOfMonth { get; set; }
        public string CornExpression { get; set; } = null!;

        public string? UserId { get; set; }


        public DateTime? LastExceutionDate { get; set; }
        public DateTime? NextExceutionDate { get; set; }

        // This property is stored in the database
        public string? MailsSerialized { get; set; }

        // Not mapped to the database, handled through serialization
        [NotMapped]
        public List<string> Mails
        {
            get { return MailsSerialized is not null ? JsonConvert.DeserializeObject<List<string>>(MailsSerialized) : null; }
            set { MailsSerialized = JsonConvert.SerializeObject(value); }
        }
        [NotMapped]
        public string CornReadable => ExpressionDescriptor.GetDescription(CornExpression);








    }
}
