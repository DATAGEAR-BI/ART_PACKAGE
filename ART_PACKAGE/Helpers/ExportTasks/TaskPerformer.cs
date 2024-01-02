using ART_PACKAGE.Helpers.ContextPerReport;
using ART_PACKAGE.Helpers.Csv;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.Mail;
using Data.Data.ExportSchedular;
using Hangfire;
using Hangfire.Server;
using Hangfire.Storage;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ART_PACKAGE.Helpers.ExportTasks
{
    public class TaskPerformer : ITaskPerformer
    {
        private readonly ExportSchedularContext exContext;
        private readonly ICsvExport _csvSrv;
        private readonly IMailSender _mailSender;
        private readonly ContextPerReportFactory contextFactory;
        public TaskPerformer(ICsvExport csvSrv, IMailSender mailSender, ContextPerReportFactory contextFactory, ExportSchedularContext exContext)
        {
            _csvSrv = csvSrv;
            _mailSender = mailSender;
            this.contextFactory = contextFactory;
            this.exContext = exContext;
        }

        public async Task PerformTask(ExportTask task, PerformContext hangContext)
        {
            string noramlizedReportName = (task.ReportName + "controller").ToLower();
            Type? modelType = ReportModelMap.GetReportModels(noramlizedReportName)[0];
            Type? controllerType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                      .FirstOrDefault(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested && a.Namespace.Contains($"ART_PACKAGE.Controllers") && a.Name.ToLower() == noramlizedReportName);

            MethodInfo? ExportMethod = typeof(ICsvExport).GetMethod("ExportForSchedulaedTask").MakeGenericMethod(modelType, controllerType);

            DbContext context = contextFactory.GetContextOf(task.ReportName);


            Task<IEnumerable<DataFile>>? res = (Task<IEnumerable<DataFile>>?)ExportMethod.Invoke(_csvSrv, new object[] { context, task.ParametersJson });
            List<DataFile> files = new();
            if (res is not null)
                files.AddRange(await res);


            if (task.IsMailed)
            {
                bool mailRes = _mailSender.SendEmail(new Message(task.Mails, task.DisplayName, task.MailContent, files));
            }

            if (task.IsSavedOnServer)
            {
                if (!Directory.Exists(Path.Combine(task.Path, task.DisplayName)))
                    _ = Directory.CreateDirectory(Path.Combine(task.Path, task.DisplayName));
                foreach (DataFile file in files)
                {
                    File.WriteAllBytes(Path.Combine(Path.Combine(task.Path, task.DisplayName), file.Name), file.Bytes);
                }
            }



            _ = BackgroundJob.ContinueWith(hangContext.BackgroundJob.Id, () => updateExcutionDates(task));


        }

        public void updateExcutionDates(ExportTask job)
        {
            ExportTask? jobfromdb = exContext.ExportsTasks.Find(job.Id);
            (DateTime? lastDate, DateTime? nextDate) = GetExecutionDateTimes(job.Name);
            jobfromdb.NextExceutionDate = nextDate;
            jobfromdb.LastExceutionDate = lastDate;

            _ = exContext.SaveChanges();
        }

        public (DateTime? lastDate, DateTime? nextDate) GetExecutionDateTimes(string jobName)
        {
            DateTime? lastExecutionDateTime = null;
            DateTime? nextExecutionDateTime = null;
            using (IStorageConnection connection = JobStorage.Current.GetConnection())
            {
                RecurringJobDto? job = connection.GetRecurringJobs().FirstOrDefault(p => p.Id == jobName);

                if (job != null && job.LastExecution.HasValue)
                    lastExecutionDateTime = job.LastExecution;

                if (job != null && job.NextExecution.HasValue)
                    nextExecutionDateTime = job.NextExecution;
            }
            return (lastExecutionDateTime, nextExecutionDateTime);
        }

    }
}
