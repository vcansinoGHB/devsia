using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.SICOP
{
    public class Request
    {
        public string fechaInicio { get; set; }
		public string fechaFin { get; set; }
		public int tipo { get; set; }
		public int opcion { get; set; }
    }
}
