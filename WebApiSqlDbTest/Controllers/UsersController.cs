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
            catch (Exception ex) { return this.Bad(ex); }
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
            catch (Exception ex) { return this.Bad(ex); }
        }
    }
}
