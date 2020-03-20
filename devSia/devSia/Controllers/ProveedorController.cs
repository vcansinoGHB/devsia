using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using devSia.Interfaces;
using devSia.Modelos.Proveedor.Usuarios;
using devSia.Modelos.Proveedor.Factura;
using devSia.Modelos.Proveedor.Contrarecibo;
using Microsoft.AspNetCore.Cors;
using System.IO;
using System.Collections;
using System.Web;

namespace devSia.Controllers
{
   [Route("json/Proveedores")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedor _providerDal;

        public ProveedorController(IProveedor providerDal)
        {
            _providerDal = providerDal;
        }


        [HttpPost]
        [Route("ContraRecibo")]
        public IActionResult getDataContrarecibo([FromBody] ContraRequest Solicitud)
        {
            try
            {
                var resultado = _providerDal.GetContrarecibo(Solicitud);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }

        }

        [HttpPost]
        [Route("CambioProveedor")]
        public IActionResult CambioProv([FromBody] CambioRequest Solicitud)
        {
            try {
                var resultado = _providerDal.CambioData(Solicitud); 

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }

        }


        [HttpPost]
        [Route("LoginProveedor")]
        public IActionResult Login([FromBody] LoginRequest Solicitud)
        {
            try {
                
              var resultado = _providerDal.LoginData(Solicitud);

              if (resultado == null)
                return NotFound();

              return Ok(resultado);

            } catch (Exception e) {
              return StatusCode(500, e.Message.ToString());
            }

        }

        [HttpGet]
        [Route("getArchivo")]
        public async Task<IActionResult> Download(string filename)
        {
            try
            {
                if (filename == null)
                    return Content("El archivo no existe");

                var path = Path.Combine(Directory.GetCurrentDirectory(), "facturas", filename);

                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(path), Path.GetFileName(path));

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }

        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".xml", "application/xml"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        [HttpPost]
        [Route("uploading")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {

            try
            {
                if (file == null || file.Length == 0)
                    return Content("El archivo no fué seleccionado, favor de verificar.");

                var path = Path.Combine(Directory.GetCurrentDirectory(), "facturas", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(file.FileName);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
            
             //return RedirectToAction("Files");
            //return Ok(new { file, path });
        }

       

        [HttpPost]
        [Route("InsertFacturaCupones")]
        public IActionResult insertaFacturaCupones([FromBody] CuponFacturaRequest Solicitud)
        {
            try
            {
                var resultado = _providerDal.InsertaFactura_Cupones(Solicitud);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpPost]
        [Route("InsertFactura")]
        public IActionResult insertaFactura([FromBody] FacturaItem Solicitud)
        {
            try
            {
                var resultado = _providerDal.InsertaFactura(Solicitud);

                return Ok(resultado);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }

        [HttpPost]
        [Route("ListUsuarios")]
        public IActionResult GetListaProvUsuarios([FromBody] UsuarioRequest Solicitud)
        {
            try {
                
               var resultado = _providerDal.Usuarios_ListaProv(Solicitud);

               if (resultado == null)
                    return NotFound();

                return Ok(resultado);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }


        [HttpPost]
        [Route("ListFacturas")]
        public IActionResult GetListaFacturas([FromBody] FacturaRequest Solicitud)
        {
            try {
                
                 var resultado = _providerDal.FacturasProveedor_Lista(Solicitud);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }


        [HttpGet]
        [Route("getCuponPreview")]
        public IActionResult GetCuponesPreview(int zonaID, int facturaID)
        {
            try {
                var resultado = _providerDal.GetCuponesPreview(zonaID,facturaID);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);

            } catch (Exception e) {
                return StatusCode(500, e.Message.ToString());
            }
        }


        [HttpGet]
        [Route("getUserByID")]
        public IActionResult GetUsuarioByID(int usuarioid)
        {
            try
            {

                var resultado = _providerDal.ProveedorByID(usuarioid);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());
            }
        }


        [HttpPut]
        [Route("UpdateUsuario")]
        public IActionResult ActualizaUsuario([FromBody] Proveedor Solicitud, int usuarioID)
        {

            try
            {
                if (Solicitud == null)
                    return BadRequest();

                var status = _providerDal.AtualizarUsuarioProveedor(Solicitud, usuarioID);
                return Ok(status);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message.ToString());

            }
          
        }


        [HttpPut]
        [Route("UpdateFactura")]
        public IActionResult UpdateFactura([FromBody] FacturaItem Solicitud, int facturaID)
        {
            try {
                
               if (Solicitud == null) return BadRequest();

                var status = _providerDal.AtualizarFactura(Solicitud, 
                                                           facturaID);
                return Ok(status);

            } catch (Exception e) {
                return StatusCode(500, e.Message.ToString());
            }

        }


    }

}