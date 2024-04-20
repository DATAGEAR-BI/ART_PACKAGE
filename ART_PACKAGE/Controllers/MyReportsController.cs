using System.Linq.Expressions;
using ART_PACKAGE.Helpers.Grid;
using Data.Services.CustomReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Controllers
{
    public class MyReportsController : BaseReportController<IGridConstructor<IMyReportsRepo, AuthContext, ArtSavedCustomReport>, IMyReportsRepo, AuthContext, ArtSavedCustomReport>
    {

        public MyReportsController(IGridConstructor<IMyReportsRepo, AuthContext, ArtSavedCustomReport> gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
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

        [HttpPost]
        public async Task<IActionResult> ShareReport([FromBody] ShareReportDto shareRequest)
        {
            IQueryable<AppUser> users = _um.Users.Include(x => x.UserReports).Where(x => shareRequest.Recievers.Contains(x.Email));
            AppUser currentUser = await GetUser();

            try
            {
                bool IsShared = await _gridConstructor.Repo.ShareReport(shareRequest, currentUser, users);
                if (IsShared)
                    return Ok();
                else
                    return BadRequest();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> UnShareReport([FromBody] UnShareDto unShareRequest)
        {
            IQueryable<AppUser> users = _um.Users.Where(x => unShareRequest.Holders.Contains(x.Email));
            AppUser currentUser = await GetUser();
            try
            {
                bool IsUnShared = await _gridConstructor.Repo.UnShareReport(unShareRequest, currentUser, users);
                if (IsUnShared)
                    return Ok();
                else
                    return BadRequest();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveReport([FromBody] SaveReportDto model)
        {
            bool isSaved = await _gridConstructor.Repo.SaveReport(model, await GetUser());
            if (isSaved)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("[controller]/{id}/Users")]
        public async Task<IActionResult> ReportUsers(int id)
        {
            IEnumerable<AppUser>? users = await _gridConstructor.Repo.GetReportUsers(id);
            AppUser owner = await GetUser();
            if (users is null)
                return BadRequest();

            return Ok(users.Where(x => x.Email != owner.Email).Select(x => x.Email));
        }

        public override async Task<IActionResult> GetData(GridRequest request)
        {
            AppUser user =await  GetUser();
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