namespace ART_PACKAGE.Helpers.Handlers
{
    public class ProcessesHandler
    {
        public List<ProcessessModel> processes = new List<ProcessessModel>();
        public ProcessesHandler()
        {

        }
        public bool isProcessRunning(string processId)
        {
            var process = processes.Where(p => p.Id == processId).FirstOrDefault();
            return process != null ? !process.canceld : false;
        }
        public bool isProcessCanceld(string processId)
        {
            var process = processes.Where(p => p.Id == processId).FirstOrDefault();
            return process != null ? process.canceld : true;
        }
        public bool AddProcess(string processId)
        {
            var process = processes.Where(p => p.Id == processId).FirstOrDefault();
            if (process == null)
            {
                processes.Add(new() { Id = processId });
                return true;
            }
            return false;
        }
        public void CancelProcess(string processId)
        {
            var process = processes.Where(p => p.Id == processId).FirstOrDefault();
            if (process != null)
            {
                processes.Remove(process);
            }
        }
        public decimal? GetCompletionPercentage(string processId)=> processes.Where(p => p.Id == processId).FirstOrDefault().CompletionPercentage;

        public void UpdateCompletionPercentage(string processId, decimal value) {

            var process = processes.Where(p => p.Id == processId).FirstOrDefault();
            if (process!=null)
            {
                process.CompletionPercentage = value;
            }

        }



    }
    public class ProcessessModel
    {
        public string Id { get; set; }
        public bool canceld { get; set; } = false;
        public decimal? CompletionPercentage { get; set; }
}
}
