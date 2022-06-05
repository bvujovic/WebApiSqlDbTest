using ClassLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSqlDbTest.Data;

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
        public ActionResult<List<User>> GetAll()
        {
            return ctx.Users.ToList();
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
    }
}
