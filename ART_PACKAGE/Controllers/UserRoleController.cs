using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace ART_PACKAGE.Controllers
{

    [Authorize(Roles = "Preferences", Policy = "License")]
    public class UserRoleController : Controller
    {
        // private FCF71_AuthContext db = new FCF71_AuthContext();
        private readonly RoleManager<IdentityRole> _rm;
        private readonly UserManager<AppUser> _um;
        //private readonly INotyfService _notify;
        public UserRoleController(RoleManager<IdentityRole> rm, UserManager<AppUser> um)//, INotyfService notify)
        {
            _rm = rm;
            _um = um;
            // _notify = notify;
        }

        public IActionResult Roles()
        {
            return View();
        }

        public ContentResult GetRolesData()
        {
            var Data = _rm.Roles.Select(r => new { r.Id, r.Name }).ToList();
            return Content(JsonConvert.SerializeObject(Data), "application/json");
        }

        //public ContentResult GetUsersData()
        //{
        //    var Data = db.AspNetUsers.ToList();
        //    return Content(JsonConvert.SerializeObject(Data), "application/json");
        //}

        public IActionResult UsersRolesMatrix()
        {
            return View();
        }





        public async Task<ContentResult> GetUsersRolesData()
        {
            List<IdentityRole> RolesData = _rm.Roles.OrderBy(ur => ur.Id).ToList();
            List<AppUser> UsersData = _um.Users.OrderBy(ur => ur.UserName).ToList();
            List<Dictionary<string, dynamic>> data = new();

            foreach (AppUser user in UsersData)
            {
                Dictionary<string, dynamic> item = new()
                {
                    { "UserName", user.Email }
                };
                foreach (IdentityRole role in RolesData)
                {
                    bool isInRole = await _um.IsInRoleAsync(user, role.Name);
                    if (isInRole)
                    {
                        item.Add(role.Name, 1);
                    }
                    else
                    {
                        item.Add(role.Name, 0);

                    }
                }
                data.Add(item);
            }
            return Content(JsonConvert.SerializeObject(data), "application/json");
        }

        //public ContentResult GetUsersRolesMatrixData()
        //{

        ////    //if (db.AspNetRoles.Count() != 0)
        ////    //{
        ////    //    var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
        ////    //    SqlConnection conn = new SqlConnection(connectionString);
        ////    //    string TableQuery = @"	EXEC User_Roles_Matrix;";//to see this PROCEDURE goto sql1.txt and goto line 36 
        ////    //    SqlCommand cmd = new SqlCommand(TableQuery, conn);
        ////    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        ////    //    DataTable dt = new DataTable();
        ////    //    da.Fill(dt);
        ////    //    return Content(JsonConvert.SerializeObject(dt), "application/json");
        ////    //}
        ////    //else
        ////    //{
        ////    //    var users = db.AspNetUsers.Select(u => new { u.UserName }).AsEnumerable();

        ////    //    return Content(JsonConvert.SerializeObject(users), "application/json");
        ////    //}
        //}

        public ContentResult GetUserRolesMatrexColumns()
        {
            List<string> first = new() { "UserName" };
            List<string> RolesNames = _rm.Roles.Select(r => r.Name).ToList();
            List<string> columns = first.Concat(RolesNames).ToList();
            return Content(JsonConvert.SerializeObject(columns), "application/json");
        }

        public async Task<IActionResult> testde()
        {
            IQueryable<IdentityRole> roles = _rm.Roles;
            foreach (IdentityRole r in roles)
            {
                _ = await _rm.DeleteAsync(r);
                IdentityRole e = new()
                {
                    Name = r.Name
                };
                _ = await _rm.CreateAsync(e);
            }
            return Ok(_rm.Roles);

        }
        public async Task<IActionResult> ControllUserRolles(string UserName, string RoleName, bool CheckBoxValue)
        {
            AppUser? user = _um.Users.FirstOrDefault(u => u.Email == UserName);
            IdentityRole? role = _rm.Roles.FirstOrDefault(r => r.Name == RoleName);
            if (user != null && role != null)
            {
                if (CheckBoxValue)
                {
                    //var user_role = new AspNetUserRole();
                    //user_role.RoleId = role.Id;
                    //user_role.UserId = user.Id;
                    //db.Add(user_role);
                    //db.SaveChangesAsync();
                    IdentityResult r = await _um.AddToRoleAsync(user, role.Name);
                    return r.Succeeded ? RedirectToAction(nameof(UsersRolesMatrix)) : NotFound();
                }
                else
                {
                    _ = await _um.RemoveFromRoleAsync(user, role.Name);
                    return RedirectToAction(nameof(UsersRolesMatrix));
                    //var user_role = db.AspNetUserRoles.FirstOrDefault(ur => ur.UserId == user.Id && ur.RoleId == role.Id);
                    //if (user_role != null)
                    //{
                    //    db.Entry(user_role).State = EntityState.Deleted;
                    //    db.SaveChangesAsync();
                    //    return RedirectToAction(nameof(UsersRolesMatrix));
                    //}
                    //else
                    //{
                    //    return BadRequest();
                    //}
                }
            }
            else
            {
                return BadRequest();
            }

        }

        public ContentResult GetDataByID(string id)
        {
            //var result = (from r in db.AspNetRoles select r).Where(r => r.Id == id).ToList();

            //var json = JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings()
            //{ ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            List<IdentityRole> role = _rm.Roles.Where(r => r.Id == id).ToList();
            string json = JsonConvert.SerializeObject(role, Formatting.None, new JsonSerializerSettings()
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Content(json, "application/json");
        }

        public async Task<IActionResult> AddRole(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                IdentityRole? isExist = await _rm.FindByNameAsync(role);
                if (isExist is not null)
                {
                    //_notify.Error($"{role} already Exists");
                    return RedirectToAction("Roles");
                }

                IdentityRole Role = new()
                {
                    Name = role
                };
                IdentityResult result = await _rm.CreateAsync(Role);
                if (result.Succeeded)
                {
                    //_notify.Success($"Role {Role.Name} Added Successfully");
                    return RedirectToAction("Roles");
                }
                foreach (IdentityError? err in result.Errors)
                {
                    //  _notify.Error($"{err.Description}");
                }

                return RedirectToAction("Roles");
            }
            //_notify.Warning($"Role Cant be Empty");
            return RedirectToAction("Roles");

        }

        public async Task<IActionResult> EditRole(string id, string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                IdentityRole? isExist = await _rm.FindByIdAsync(id);
                if (isExist is null)
                {
                    // _notify.Error($"No Such a role with name : {role}");
                    return RedirectToAction("Roles");
                }

                _ = await _rm.FindByNameAsync(role);
                if (isExist is not null)
                {
                    //_notify.Error($"{role} already Exists");
                    return RedirectToAction("Roles");
                }

                _ = isExist.Name;
                isExist.Name = role;
                IdentityResult result = await _rm.UpdateAsync(isExist);
                if (result.Succeeded)
                {
                    //_notify.Success($"Role changed from {old} to {isExist.Name}");
                    return RedirectToAction("Roles");
                }
                foreach (IdentityError? err in result.Errors)
                {
                    // _notify.Error($"{err.Description}");
                }

                return RedirectToAction("Roles");
            }
            //_notify.Warning($"Role Cant be Empty");
            return RedirectToAction("Roles");
        }

        public IActionResult Users()
        {
            return View();
        }

        public ContentResult GetUsersData()
        {
            //var Data = db.AspNetUsers.Select(u => new { u.UserName, u.Active }).ToList();

            var Data = _um.Users.Select(u => new { u.UserName, u.Active }).ToList();
            return Content(JsonConvert.SerializeObject(Data), "application/json");
        }




        public async Task<IActionResult> EditUser(string BeforeEdit, string AfterEdit, string active)
        {
            if (!string.IsNullOrEmpty(AfterEdit))
            {

                AppUser found = await _um.FindByNameAsync(BeforeEdit);
                AppUser? found_byAfter = await _um.FindByNameAsync(AfterEdit);
                if (found_byAfter is not null)
                {
                    //_notify.Error($"There is already a user with that user name : {AfterEdit}");
                    return RedirectToAction("Users");
                }
                AppUser old = found;
                found.UserName = AfterEdit;
                found.Active = active != null;

                IdentityResult result = await _um.UpdateAsync(found);
                if (result.Succeeded)
                {
                    //_notify.Success($"user chanded from {old.UserName}-{old.Active} => {found.UserName}-{found.Active}");
                    return RedirectToAction("Users");
                }
                //_notify.Error("Something wrong happenned");
                return RedirectToAction("Users");

            }
            else
            {
                //_notify.Error("Something wrong happenned");
                return RedirectToAction("Users");
            }
        }

        public async Task<ContentResult> GetUserByUserName(string username)
        {
            //var result = (from u in db.AspNetUsers select u).Where(u => u.UserName == username).ToList();
            AppUser result = await _um.FindByNameAsync(username);
            string json = JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings()
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Content(json, "application/json");
        }
    }
}
