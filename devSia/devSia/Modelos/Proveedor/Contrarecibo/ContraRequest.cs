using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Contrarecibo
{
    public class ContraRequest
    {
		public int tipo { get; set; }
		public int proveedorID { get; set; }
		public string fechainicial { get; set; }
		public string fechafinal { get; set; }
		public int locacionID { get; set; }
		public int empresaID { get; set; }

    }
}
