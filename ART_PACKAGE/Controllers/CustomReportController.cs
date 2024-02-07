using ART_PACKAGE.Helpers.Grid;
using Data.Services.CustomReport;
using Microsoft.AspNetCore.Mvc;

namespace ART_PACKAGE.Controllers
{
    public class CustomReportController : BaseReportController<ICustomReportGridConstructor, ICustomReportRepo, AuthContext, object>
    {


        public CustomReportController(ICustomReportGridConstructor gridConstructor, UserManager<AppUser> um) : base(gridConstructor, um)
        {
        }

         [HttpPost("{id}")]
        public IActionResult GetData([FromRoute] int id, [FromBody]  GridRequest request)
        {
            if (request.IsIntialize)
            {
                
            }
            else
            {

                
            }

            return Ok();
        }
        

        public override IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}