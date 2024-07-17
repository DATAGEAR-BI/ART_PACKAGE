using ART_PACKAGE.Helpers.Handlers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ART_PACKAGE.Controllers
{
    public class ProcessController : Controller
    {
        private readonly ILogger _logger;
        private readonly ProcessesHandler _processesHandler;
        public ProcessController(ProcessesHandler processesHandler)
        {
                _processesHandler = processesHandler;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ContentResult All()
        {
            
            return Content(JsonConvert.SerializeObject(_processesHandler.processes),"application/json");
        }
        public ContentResult ProcessData(string Id)
        {
            var process = _processesHandler.processes.Where(s => s.Id == Id).FirstOrDefault();
            if (process!=null)
            {
                return Content(JsonConvert.SerializeObject(process), "application/json");

            }
            return Content(JsonConvert.SerializeObject("Process Not Exist"), "application/json");
        }
        public ContentResult UserProcesses()
        {
            
            var process = _processesHandler.processes.Where(p=>p.UserName==User.Identity.Name).FirstOrDefault();
            if (process != null)
            {
                return Content(JsonConvert.SerializeObject(process), "application/json");

            }
            return Content(JsonConvert.SerializeObject("Process Not Exist"), "application/json");
        }

        public ContentResult DeleteProcesses()
        {

             _processesHandler.processes.RemoveAll(x=>true);

          
            return Content(JsonConvert.SerializeObject("Processes Deleted successfully"), "application/json");
        }
        public ContentResult DeleteProcess(string Id)
        {

            _processesHandler.processes.RemoveAll(x => x.Id==Id);


            return Content(JsonConvert.SerializeObject("Processes Deleted successfully"), "application/json");
        }
        public ContentResult DeleteUser(string UserName)
        {

            _processesHandler.processes.RemoveAll(x => x.UserName==UserName);


            return Content(JsonConvert.SerializeObject("Processes Deleted successfully"), "application/json");
        }
        public ContentResult DeleteCurrentUser()
        {

            _processesHandler.processes.RemoveAll(x => x.UserName == User.Identity?.Name);


            return Content(JsonConvert.SerializeObject("Processes Deleted successfully"), "application/json");
        }


    }
}
