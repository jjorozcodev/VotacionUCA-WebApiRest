using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VotacionUCAWebApiRest.Models;

namespace VotacionUCAWebApiRest.Controllers
{
    public class UsuariosController : ApiController
    {
        private VotacionUCA votacionBD = new VotacionUCA();
        
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return votacionBD.Usuarios.ToList();
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
