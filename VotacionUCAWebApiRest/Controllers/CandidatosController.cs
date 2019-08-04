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
    public class CandidatosController : ApiController
    {
        private VotacionUCA votacionBD = new VotacionUCA();

        [HttpGet]
        public IEnumerable<Candidatos> Get()
        {
            return votacionBD.Candidatos.ToList();
        }

        [HttpGet]
        public Candidatos Get(int id)
        {
            return votacionBD.Candidatos.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public IHttpActionResult PostCandidatos([FromBody]Candidatos cand)
        {
            if (ModelState.IsValid)
            {
                votacionBD.Candidatos.Add(cand);
                votacionBD.SaveChanges();
                return Ok(cand);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult PutCandidatos(int id, [FromBody]Candidatos cand)
        {
            if (ModelState.IsValid)
            {
                var CandExists = votacionBD.Candidatos.Count(c => c.Id == id) > 0;

                if (CandExists)
                {
                    votacionBD.Entry(cand).State = EntityState.Modified;
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
        public IHttpActionResult DeleteCandidatos(int id)
        {
            var cand = votacionBD.Candidatos.Find(id);

            if(cand != null)
            {
                votacionBD.Candidatos.Remove(cand);
                votacionBD.SaveChanges();

                return Ok(cand);
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
