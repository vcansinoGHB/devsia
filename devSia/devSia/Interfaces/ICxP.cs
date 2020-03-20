using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devSia.Modelos;

namespace devSia.Interfaces
{
    public interface ICxP
    {
        IEnumerable<ProveedorCuentasB> ObtenerCuentaProveeodres(int proveedorID);
    }

}
