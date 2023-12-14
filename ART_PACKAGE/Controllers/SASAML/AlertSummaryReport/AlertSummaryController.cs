using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers.SASAML.AlertSummaryReport
{
    //////[Authorize(Roles = "AlertSummary")]
    public class AlertSummaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
