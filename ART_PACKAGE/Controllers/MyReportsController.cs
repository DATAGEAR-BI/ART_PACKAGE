using System.Linq.Expressions;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.Grid;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers
{
    public class MyReportsController : BaseReportController<AuthContext, ArtSavedCustomReport>
    {
        private readonly UserManager<AppUser> _um;
        public MyReportsController(IGridConstructor<AuthContext, ArtSavedCustomReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor)
        {
            _um = um;
        }
        // GET
        public override IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            IQueryable<string> users = _um.Users.Select(x => x.Email);
            return Ok(users);
        }

        public override async Task<IActionResult> GetData(GridRequest request)
        {
            AppUser user = await _um.GetUserAsync(User);
            baseCondition = x => x.Users.Contains(user);
            includes = new List<Expression<Func<ArtSavedCustomReport, object>>>()
            {
                x => x.Users,
                x => x.UserReports
            };
            return await base.GetData(request);
        }
    }
}