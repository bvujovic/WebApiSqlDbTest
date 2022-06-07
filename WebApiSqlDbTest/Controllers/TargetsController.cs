﻿using ClassLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSqlDbTest.Data;
using WebApiSqlDbTest.Data.DTOs;

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
                var res = ctx.Targets.Include(it => it.UserOwner).ToList();
                res.First().UserOwner.OwnedTargets = null;
                res.First().UserOwner.ModifiedTargets = null;
                res.First().UserOwner.AccessedTargets = null;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TargetDto t)
        {
            try
            {
                var owner = ctx.Users.Find(t.OwnerId);
                if (owner != null)
                {
                    var newTarget = Target.CreateTarget(t.Title, t.Text, t.Tags
                        , DateTime.Now, owner);
                    
                    ctx.Targets.Add(newTarget);
                    ctx.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest($"User with Id {t.OwnerId} doesn't exists.");
            }
            catch (Exception ex)
            {
                return this.Bad(ex);
            }
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
