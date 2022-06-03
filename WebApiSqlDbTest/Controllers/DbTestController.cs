using ClassLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSqlDbTest.Data;
namespace WebApiSqlDbTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private readonly Data.DataContext ctx;

        public DbTestController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<ClassLib.Target> Get()
        {
            return ctx.Targets.ToList();
        }

        [HttpPost]
        public IActionResult Post(Target t)
        {
            var existingTarget = ctx.Targets.Find(t.Id);
            if (existingTarget == null)
            {
                ctx.Targets.Add(t);
                ctx.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(existingTarget.Name + " already exists in DB.");
        }
    }
}
