using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Usuarios
{
    public class LoginResponse
    {
       public string token { get; set; } 
       public string expiration { get; set; }
       public string razonsocial { get; set; }
       public string rfc { get; set; }
       public string usuario { get; set; }
       public string nombre { get; set; }
       public int proveedorID { get; set; }	
       public int zonaID { get; set; }
       public int empresaID { get; set; } 
       public int locacionID { get; set; }
       public int admon { get; set; }
       public int factura { get; set; }
       public int facturacupon { get; set; } 
       public int cambioprov { get; set; }
       public string empresa { get; set; }
       public string domicilio { get; set; }
       public string empresarfc { get; set; }
       public string empresanombre { get; set; }
    }
}
