using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Factura
{
    public class CuponPreview
    {
        public string serie { get; set; }
        public string res_code { get; set; }
        public int res_numadults { get; set; }
        public int res_numchild { get; set; }
        public decimal res_costototal { get; set; }
        public string res_tourclave { get; set; }
        public string tour_nameesp { get; set; }
        public int res_tourid { get; set; }
	    public int res_validacupon { get; set; }
        public decimal tipocambio { get; set; } 
        public decimal costomxn { get; set; }	
    }
}
