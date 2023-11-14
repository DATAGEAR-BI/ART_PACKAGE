using Data.Data.ExportSchedular;

namespace ART_PACKAGE.Helpers.ExportTasks
{
    public class ExportTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ReportName { get; set; } = null!;

        public TaskPeriod Period { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }

        public int? Month { get; set; }
        public int? Day { get; set; }
        public int? Hour { get; set; }
        public int? Minute { get; set; }

        public List<string> Mails { get; set; } = null!;
        public string Parameters { get; set; } = null!;
        public bool IsMailed { get; set; }
        public string? MailContent { get; set; }
        public string? Path { get; set; }
        public string DisplayName => Name.Split("##")[0];
        public bool IsSavedOnServer { get; set; }

        public DateTime? LastExceutionDate { get; set; }
        public DateTime? NextExceutionDate { get; set; }

    }
}
