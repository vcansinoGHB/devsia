using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Usuarios
{
    public class Proveedor
    {
        public int provusr_id { get; set; }
        public string provusr_nombre { get; set; }
        public string provusr_email { get; set; }
        public string provusr_clave { get; set; }
        public int provusr_activo { get; set; }
        public int provusr_admon { get; set; }
        public int provusr_factura { get; set;}
        public int provusr_facturacupon { get; set; }
        public int provusr_cambioprov { get; set; }
        public string proveedor_nombre { get; set; }
        public string zona_nombre { get; set; }
        public string proveedor_rfc { get; set; }
        public string empresa_nombre { get; set; }
        public string locacion_name { get; set; }

        public int totalDeResultados { get; set; }

        public int provusr_proveedorID { get; set; }

        public int provusr_zonaID { get; set; }

        public int provusr_locacionID { get; set; }
        public int provusr_empresaID { get; set; }



    }
}
