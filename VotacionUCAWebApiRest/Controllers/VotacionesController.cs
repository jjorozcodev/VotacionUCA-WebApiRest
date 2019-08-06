using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotacionUCAWebApiRest.Models;

namespace VotacionUCAWebApiRest.Controllers
{
    [Authorize]
    public class VotacionesController : ApiController
    {
        private VotacionUCA votacionBD = new VotacionUCA();

        [HttpGet]
        public IEnumerable<Votaciones> Get()
        {
            return votacionBD.Votaciones.ToList();
        }

        [HttpGet]
        public Votaciones Get(int id)
        {
            return votacionBD.Votaciones.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public IHttpActionResult PostVotaciones([FromBody]Votaciones vot)
        {
            if (ModelState.IsValid)
            {
                votacionBD.Votaciones.Add(vot);
                votacionBD.SaveChanges();
                return Ok(vot);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult PutVotaciones(int id, [FromBody]Votaciones vot)
        {
            if (ModelState.IsValid)
            {
                var VotExists = votacionBD.Votaciones.Count(c => c.Id == id) > 0;

                if (VotExists)
                {
                    votacionBD.Entry(vot).State = EntityState.Modified;
                    votacionBD.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteVotaciones(int id)
        {
            var vot = votacionBD.Votaciones.Find(id);

            if (vot != null)
            {
                votacionBD.Votaciones.Remove(vot);
                votacionBD.SaveChanges();

                return Ok(vot);
            }
            else
            {
                return NotFound();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                votacionBD.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
