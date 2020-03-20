using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devSia.Modelos.Proveedor.Usuarios;
using devSia.Modelos.Proveedor.Factura;
using devSia.Modelos.Proveedor.Contrarecibo;

namespace devSia.Interfaces
{
    public interface IProveedor
    {
        ListaUser Usuarios_ListaProv(UsuarioRequest solicitud);
        Proveedor ProveedorByID(int userID);
        int AtualizarUsuarioProveedor(Proveedor solicitud, int idusuario);
        int AtualizarFactura(FacturaItem solicitud, int idfactura);
        FacturaProviderResponse FacturasProveedor_Lista(FacturaRequest solicitud);
        int InsertaFactura(FacturaItem solicitud);
        IEnumerable<CuponPreview> GetCuponesPreview(int zonaID, int facturaID);

        int InsertaFactura_Cupones(CuponFacturaRequest solicitud);
        LoginResponse LoginData(LoginRequest Solicitud);
        LoginResponse CambioData(CambioRequest Solicitud);
        IEnumerable<ContraResponse> GetContrarecibo(ContraRequest Solicitud);
    }
}
