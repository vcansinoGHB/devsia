using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using devSia.DAL;
using devSia.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace devSia.Controllers
{
    [Route("api/cxp")]
    [EnableCors("AllowOrigin")]
    public class CxPController : ControllerBase
    {
        private readonly ICxP _providerDal;

        public CxPController(ICxP providerDal)
        {
            _providerDal = providerDal;
        }

        [HttpGet("{id}/proveedor")]
        public IActionResult GetProveedorCuenta(int id)
        {
            try {

                var resultado = _providerDal.ObtenerCuentaProveeodres(id);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);

            } catch (Exception e) {
                return StatusCode(500, e.Message.ToString());
            }                      
        }

    }

}