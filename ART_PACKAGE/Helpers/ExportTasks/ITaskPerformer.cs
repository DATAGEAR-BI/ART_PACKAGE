using Data.Data.ExportSchedular;

namespace ART_PACKAGE.Helpers.ExportTasks
{
    public interface ITaskPerformer
    {
        public Task PerformTask(ExportTask task);

        public Func<string> GetPeriod(ExportTask task);
    }
}
