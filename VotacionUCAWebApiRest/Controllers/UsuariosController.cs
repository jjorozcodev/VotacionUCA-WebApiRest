﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VotacionUCAWebApiRest.Models;

namespace VotacionUCAWebApiRest.Controllers
{
    [Authorize]
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
