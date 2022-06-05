using ClassLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSqlDbTest.Data;
namespace WebApiSqlDbTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetsController : ControllerBase
    {
        private readonly DataContext ctx;

        public TargetsController(DataContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Target>> Get()
        {
            try
            {
                return Ok(ctx.Targets.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Target t)
        {
            var existingTarget = ctx.Targets.Find(t.TargetId);
            if (existingTarget == null)
            {
                ctx.Targets.Add(t);
                ctx.SaveChanges();
                return Ok();
            }
            else
                return BadRequest(existingTarget.Title + " already exists in DB.");
        }

        [HttpDelete]
        public IActionResult Clear()
        {
            var targets = ctx.Targets.ToArray();
            ctx.RemoveRange(targets);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
