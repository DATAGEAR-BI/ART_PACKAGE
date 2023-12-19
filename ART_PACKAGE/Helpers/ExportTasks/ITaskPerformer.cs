using Data.Data.ExportSchedular;
using Hangfire.Server;

namespace ART_PACKAGE.Helpers.ExportTasks
{
    public interface ITaskPerformer
    {
        public Task PerformTask(ExportTask task, PerformContext hangContext);

        public (DateTime? lastDate, DateTime? nextDate) GetExecutionDateTimes(string jobName);

    }
}
