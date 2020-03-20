using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Usuarios
{
    public class CambioRequest
    {
       public int empresaID { get; set; }
	   public int locacionID { get; set; }
	   public int proveedorID { get; set; }
    }

}
