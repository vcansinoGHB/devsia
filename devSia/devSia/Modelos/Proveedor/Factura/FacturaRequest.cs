using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Factura
{
    public class FacturaRequest
    {
        public int paginaActual { get; set; }
        public string Busqueda { get; set; } 
        public int Tipofactura { get; set; }
        public int proveedorID { get; set; }
        public int locationID { get; set; }        
        public int companyID { get; set; }
}
}
