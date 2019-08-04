using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotacionUCAWebApiRest.Models;

namespace VotacionUCAWebApiRest.Controllers
{
    public class VotosController : ApiController
    {
        private VotacionUCA votacionBD = new VotacionUCA();

        [HttpGet]
        public IEnumerable<Votos> Get()
        {
            return votacionBD.Votos.ToList();
        }

        [HttpGet]
        public Votos Get(int id)
        {
            return votacionBD.Votos.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public IHttpActionResult PostVotos([FromBody]Votos vot)
        {
            if (ModelState.IsValid)
            {
                votacionBD.Votos.Add(vot);
                votacionBD.SaveChanges();
                return Ok(vot);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteVotos(int id)
        {
            var vot = votacionBD.Votos.Find(id);

            if (vot != null)
            {
                votacionBD.Votos.Remove(vot);
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
