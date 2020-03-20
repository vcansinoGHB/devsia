using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devSia.Modelos.SICOP;

namespace devSia.Interfaces
{
    public interface ISicop
    {
        IEnumerable<Response> ObtenerInformacion(Request Solicitud);
    }

}
