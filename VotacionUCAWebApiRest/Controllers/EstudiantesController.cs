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
    }
}
