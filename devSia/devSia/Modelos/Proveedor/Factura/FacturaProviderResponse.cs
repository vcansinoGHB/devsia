using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JW;

namespace devSia.Modelos.Proveedor.Factura
{
    public class FacturaProviderResponse
    {
        public Pager Paginas;
        public IEnumerable<FacturaItem> ListaFacturas;
    }
}
