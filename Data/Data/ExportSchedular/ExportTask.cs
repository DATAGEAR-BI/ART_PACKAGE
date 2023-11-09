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

        public ICollection<TaskMails> Mails { get; set; } = null!;

    }
}
