using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using torneos.Clases;
using torneos.Models;

namespace torneos.Controllers
{
  [RoutePrefix("api/torneos")]
  public class TorneosController : ApiController
  {
    [HttpPost]
    [Route("guardar")]
    public string Insertar([FromBody] Torneo torneo)
    {
      clsTorneos torneos = new clsTorneos();
      torneos.torneo = torneo;
      return torneos.Guardar();
    }
  }
}