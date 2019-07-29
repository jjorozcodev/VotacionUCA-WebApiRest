using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VotacionUCAWebApiRest.Models;

namespace VotacionUCAWebApiRest.Controllers
{
    public class EstudiantesController : ApiController
    {
        private VotacionUCA votacionBD = new VotacionUCA();

        [HttpGet]
        public IEnumerable<Estudiantes> Get()
        {
            return votacionBD.Estudiantes.ToList();
        }

        [HttpGet]
        public Estudiantes Get(int id)
        {
            return votacionBD.Estudiantes.FirstOrDefault(e => e.Id == id);
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
