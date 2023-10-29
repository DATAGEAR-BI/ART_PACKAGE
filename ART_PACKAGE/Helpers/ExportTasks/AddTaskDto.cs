using Data.Data.ExportSchedular;

namespace ART_PACKAGE.Helpers.ExportTasks
{
    public class AddTaskDto
    {
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
        public List<Parameter> Parameters { get; set; } = null!;
        public bool IsMailed { get; set; }

        public bool IsSavedOnServer { get; set; }

    }
}
