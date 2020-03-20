using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Contrarecibo
{
    public class ContraResponse
    {
        public string facprov_factura { get; set; }
        public string facprov_facturanum { get; set; }
        public string facprov_fechaRegistro { get; set; }
        public string facprov_fecha { get; set; }
        public decimal facprov_tipocambio { get; set; }
        public decimal facprov_montototal { get; set; }
        public string facprov_moneda { get; set; }
        public string gastos { get; set; }
        public string cupones { get; set; }



    }


}
