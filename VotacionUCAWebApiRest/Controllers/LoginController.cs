using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VotacionUCAWebApiRest.Models;

namespace VotacionUCAWebApiRest.Controllers
{
    public class LoginController : ApiController
    {
        private VotacionUCA votacionBD = new VotacionUCA();

        [HttpPost]
        public IHttpActionResult Login([FromBody]LoginModel login)
        {
            if (ModelState.IsValid)
            {
                Usuarios us = votacionBD.Usuarios.Where(u => u.Usuario == login.Usuario && u.Clave == login.Clave).FirstOrDefault();

                if (us != null)
                {
                    return Ok(us);
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
