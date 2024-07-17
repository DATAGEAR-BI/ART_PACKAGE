namespace ART_PACKAGE.Helpers.Handlers
{
    public class ProcessesHandler
    {
        private readonly UsersConnectionIds connections;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public List<ProcessessModel> processes = new List<ProcessessModel>();
        public ProcessesHandler(UsersConnectionIds connections, IHttpContextAccessor httpContextAccessor)
        {
            this.connections = connections;
            this._httpContextAccessor = httpContextAccessor;
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
            var currentUser = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            
            var process = processes.Where(p => p.Id == processId).FirstOrDefault();
            if (process == null&&currentUser!=null)
            {
                processes.Add(new() { Id = processId ,UserName=currentUser,UserConnectioId=connections.GetConnections(currentUser) });
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
        public string UserName { get;set; }
        public List<string> UserConnectioId { get; set; }
}
}
