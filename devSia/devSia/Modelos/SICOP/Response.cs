using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.SICOP
{
    public class Response
    {
        public string fecha { get; set; }
        public string concepto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal totalVta { get; set; }
        public string guia { get; set; }
        public string estatus { get; set; }
        public int status { get; set; }

        //datos para incentivos

        public int incentivos { get; set; }
        public decimal montoincentivo { get; set; }
        public decimal montoincentivomxn { get; set; }
        public decimal tipocambio { get; set; }

        public decimal totalvta { get; set; }
        public decimal totalvtamxn { get; set; }

        public decimal totalfinal { get; set; }
        public decimal totalfinalmxn { get; set; }

        public decimal totalincentivo { get; set; }

    }
}
