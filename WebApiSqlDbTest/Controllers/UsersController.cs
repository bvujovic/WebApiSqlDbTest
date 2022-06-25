using ClassLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSqlDbTest.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApiSqlDbTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext ctx;

        public UsersController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await ctx.Users.Include(it => it.OwnedTargets)
                .Include(it => it.MemberOf).ThenInclude(it => it.Group).ToListAsync();
            //foreach (var u in users)
            //    u.OwnedTargets?.ForEach(it => it.UserAccessed = it.UserOwner = it.UserModified = null);
            //foreach (var u in users)
            //    u.MemberOf.ForEach(it => { it.User = null; it.Group.Members = null; });
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + Environment.NewLine + ex.InnerException.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                var u = ctx.Users.Find(user.UserId);
                if (u == null)
                    return BadRequest($"No user with Id: {user.UserId}.");
                u.Username = user.Username;
                u.Password = user.Password;
                u.FullName = user.FullName;
                u.Email = user.Email;
                ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return this.Bad(ex);
            }
        }

        //private BadRequestObjectResult Bad(Exception ex)
        //{
        //    var msg = ex.Message;
        //    if (ex.InnerException != null)
        //        msg += Environment.NewLine + ex.InnerException.Message;
        //    return BadRequest(msg);
        //}
    }
}
