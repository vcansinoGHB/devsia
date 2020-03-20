using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devSia.Modelos.Proveedor.Usuarios
{
    public class UsuarioRequest
    {
        public int pagina { get; set; }
        public string busqueda { get; set; }
        public int id_empresa { get; set; }
        public int id_locacion { get; set; }
        public int id_proveedor { get; set; }
    }
}
