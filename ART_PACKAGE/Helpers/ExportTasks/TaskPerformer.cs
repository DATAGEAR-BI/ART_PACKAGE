using ART_PACKAGE.Helpers.ContextPerReport;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.Mail;
using Data.Data.ExportSchedular;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ART_PACKAGE.Helpers.ExportTasks
{
    public class TaskPerformer : ITaskPerformer
    {
        private readonly ICsvExport _csvSrv;
        private readonly IMailSender _mailSender;
        private readonly ContextPerReportFactory contextFactory;
        public TaskPerformer(ICsvExport csvSrv, IMailSender mailSender, ContextPerReportFactory contextFactory)
        {
            _csvSrv = csvSrv;
            _mailSender = mailSender;
            this.contextFactory = contextFactory;
        }

        public Func<string> GetPeriod(ExportTask task)
        {
            if (task.Period == TaskPeriod.Minutely)
                return () => Cron.Minutely();
            else if (task.Period == TaskPeriod.Hourly)
                return () => Cron.Hourly(task.Minute ?? 0);
            else if (task.Period == TaskPeriod.Daily)
                return () => Cron.Daily(task.Hour ?? 0, task.Minute ?? 0);
            else if (task.Period == TaskPeriod.Weekly)
                return () => Cron.Weekly(task.DayOfWeek ?? 0, task.Hour ?? 0, task.Minute ?? 0);
            else if (task.Period == TaskPeriod.Monthly)
                return () => Cron.Monthly(task.Day ?? 0, task.Hour ?? 0, task.Minute ?? 0);
            else if (task.Period == TaskPeriod.Yearly)
                return () => Cron.Yearly(task.Month ?? 1, task.Day ?? 0, task.Hour ?? 0, task.Minute ?? 0);
            else return () => Cron.Never();


        }

        public async Task PerformTask(ExportTask task)
        {
            string noramlizedReportName = (task.ReportName + "controller").ToLower();
            Type? modelType = ReportModelMap.GetReportModels(noramlizedReportName)[0];
            Type? controllerType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                      .FirstOrDefault(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested && a.Namespace.Contains($"ART_PACKAGE.Controllers") && a.Name.ToLower() == noramlizedReportName);

            MethodInfo? ExportMethod = typeof(ICsvExport).GetMethod("ExportForSchedulaedTask").MakeGenericMethod(modelType, controllerType);

            DbContext context = contextFactory.GetContextOf(task.ReportName);


            Task<IEnumerable<DataFile>>? res = (Task<IEnumerable<DataFile>>?)ExportMethod.Invoke(_csvSrv, new object[] { context, task.Parameters });
            List<DataFile> files = new();
            if (res is not null)
                files.AddRange(await res);


            if (task.IsMailed)
            {
                bool mailRes = _mailSender.SendEmail(new Message(task.Mails.Select(x => x.Mail), "TEST JOB", "TEST Maail", files));
            }

            if (task.IsSavedOnServer)
            {

            }



        }
    }
}
