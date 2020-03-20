using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using devSia.Interfaces;
using devSia.Modelos.SICOP;

namespace devSia.Controllers
{
    [Route("api/sicop")]
    [ApiController]
    public class SicopController : ControllerBase
    {
        private readonly ISicop _providerDal;

        public SicopController(ISicop providerDal)
        {
            _providerDal = providerDal;
        }

        [HttpPost]
        [Route("getVentas")]
        public IActionResult VtasInformacion([FromBody] Request Solicitud)
        {
            try {
                var resultado = _providerDal.ObtenerInformacion(Solicitud);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }

        }

    }
}