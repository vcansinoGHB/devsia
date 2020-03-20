using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JW;

namespace devSia.Modelos.Proveedor.Usuarios
{
    public class ListaUser
    {
        public Pager Paginas;
        public IEnumerable<Proveedor> ListaItems;
    }
}
