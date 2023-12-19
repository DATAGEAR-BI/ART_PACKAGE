using Data.Data.ExportSchedular;
using Hangfire;

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
        public bool EndOfMonth { get; set; }

        public DateTime? LastExceutionDate { get; set; }
        public DateTime? NextExceutionDate { get; set; }


        public string CronExpression
        {
            get
            {
                if (Period == TaskPeriod.Minutely)
                    return Cron.Minutely();
                else if (Period == TaskPeriod.Hourly)
                    return Cron.Hourly(Minute ?? 0);
                else if (Period == TaskPeriod.Daily)
                    return Cron.Daily(Hour ?? 0, Minute ?? 0);
                else if (Period == TaskPeriod.Weekly)
                    return Cron.Weekly(DayOfWeek ?? 0, Hour ?? 0, Minute ?? 0);
                else if (Period == TaskPeriod.Monthly)
                {
                    string day = !EndOfMonth ? $"{Day ?? 0}" : "L";
                    return $"{Minute ?? 0} {Hour ?? 0} {day} * *";
                }
                else if (Period == TaskPeriod.Yearly)
                {
                    string day = !EndOfMonth ? $"{Day ?? 0}" : "L";
                    return $"{Minute ?? 0} {Hour ?? 0} {day} {Month ?? 1} *";
                }
                else if (Period == TaskPeriod.Quarterly)
                {
                    string day = !EndOfMonth ? $"{Day ?? 0}" : "L";
                    int? month = Month;
                    List<int?> quarters = new();

                    for (int i = 0; i < 4; i++)
                    {
                        int? qmonth = month % 12;
                        if (qmonth == 0)
                            quarters.Add(12);
                        else
                            quarters.Add(qmonth);
                        month += 3;
                    }
                    return $"{Minute} {Hour} {day} {string.Join(",", quarters)} *";
                }
                else return Cron.Never();
            }
        }

    }
}
