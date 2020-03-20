using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using devSia.Interfaces;
using devSia.Modelos.Proveedor.Usuarios;
using devSia.Modelos.Proveedor.Factura;
using devSia.Modelos.Proveedor.Contrarecibo;
using Microsoft.Extensions.Configuration;
using JW;

namespace devSia.DAL
{
    public class ProveedorDAL : IProveedor
    {
        readonly string _connectionString;
        public ProveedorDAL(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ContraResponse> GetContrarecibo(ContraRequest Solicitud)
        {
            var Lista = new List<ContraResponse>();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedoresContrarecibo", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@tipo", Solicitud.tipo);
                cmd.Parameters.AddWithValue("@proveedorID", Solicitud.proveedorID );
                cmd.Parameters.AddWithValue("@fechainicial", Solicitud.fechainicial);
                cmd.Parameters.AddWithValue("@fechafinal", Solicitud.fechafinal);
                cmd.Parameters.AddWithValue("@locacionID", Solicitud.locacionID);
                cmd.Parameters.AddWithValue("@empresaID", Solicitud.empresaID);

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var item = new ContraResponse();

                        if (reader["facprov_factura"] == null)
                        {
                            item.facprov_factura = "";
                        }
                        else
                        {
                            item.facprov_factura = reader["facprov_factura"].ToString();
                        }

                        if (reader["facprov_facturanum"] == null)
                        {
                            item.facprov_facturanum = "";
                        }
                        else
                        {
                            item.facprov_facturanum = reader["facprov_facturanum"].ToString();
                        }


                        if (reader["facprov_fechaRegistro"] == null)
                        {
                            item.facprov_fechaRegistro = "";
                        }
                        else
                        {
                            item.facprov_fechaRegistro = reader["facprov_fechaRegistro"].ToString();
                        }

                        if (reader["facprov_fecha"] == null)
                        {
                            item.facprov_fecha = "";
                        }
                        else
                        {
                            item.facprov_fecha = reader["facprov_fecha"].ToString();
                        }

                        if (reader["facprov_tipocambio"] == null)
                        {
                            item.facprov_tipocambio = 0;
                        }
                        else
                        {
                            item.facprov_tipocambio = Convert.ToDecimal(  reader["facprov_tipocambio"].ToString());
                        }

                        if (reader["facprov_montototal"] == null)
                        {
                            item.facprov_montototal = 0;
                        }
                        else
                        {
                            item.facprov_montototal = Convert.ToDecimal(reader["facprov_montototal"].ToString());
                        }

                        if (reader["facprov_moneda"] == null)
                        {
                            item.facprov_moneda = "";
                        }
                        else
                        {
                            item.facprov_moneda = reader["facprov_moneda"].ToString();
                        }

                        if (reader["gastos"] == null)
                        {
                            item.gastos = "";
                        }
                        else
                        {
                            item.gastos = reader["gastos"].ToString();
                        }

                        if (reader["cupones"] == null)
                        {
                            item.cupones = "";
                        }
                        else
                        {
                            item.cupones = reader["cupones"].ToString();
                        }

                        Lista.Add(item);
                    }

                }
                con.Close();
            }

            return Lista;
        }


        public LoginResponse CambioData(CambioRequest Solicitud)
        {
            var item = new LoginResponse();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorCambio", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                 
                cmd.Parameters.AddWithValue("@empresaID", Solicitud.empresaID );
                cmd.Parameters.AddWithValue("@locacionID", Solicitud.locacionID );
                cmd.Parameters.AddWithValue("@proveedorID", Solicitud.proveedorID );

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (reader["proveedorID"] == null)
                        {
                            item.proveedorID = 0;
                        }
                        else
                        {
                            item.proveedorID = Convert.ToInt32(reader["proveedorID"].ToString());
                        }

                        if (reader["email"] == null)
                        {
                            item.usuario = "";
                        }
                        else
                        {
                            item.usuario = reader["email"].ToString();
                        }

                        if (reader["nombre"] == null)
                        {
                            item.nombre = "";
                        }
                        else
                        {
                            item.nombre = reader["nombre"].ToString();
                        }

                        if (reader["admon"] == null)
                        {
                            item.admon = 0;
                        }
                        else
                        {
                            item.admon = Convert.ToInt32(reader["admon"].ToString());
                        }


                        if (reader["factura"] == null)
                        {
                            item.factura = 0;
                        }
                        else
                        {
                            item.factura = Convert.ToInt32(reader["factura"].ToString());
                        }

                        if (reader["facturacupon"] == null)
                        {
                            item.facturacupon = 0;
                        }
                        else
                        {
                            item.facturacupon = Convert.ToInt32(reader["facturacupon"].ToString());
                        }

                        if (reader["cambioprov"] == null)
                        {
                            item.cambioprov = 0;
                        }
                        else
                        {
                            item.cambioprov = Convert.ToInt32(reader["cambioprov"].ToString());
                        }

                        if (reader["zonaID"] == null)
                        {
                            item.zonaID = 0;
                        }
                        else
                        {
                            item.zonaID = Convert.ToInt32(reader["zonaID"].ToString());
                        }

                        if (reader["empresaID"] == null)
                        {
                            item.empresaID = 0;
                        }
                        else
                        {
                            item.empresaID = Convert.ToInt32(reader["empresaID"].ToString());
                        }


                        if (reader["locacionID"] == null)
                        {
                            item.locacionID = 0;
                        }
                        else
                        {
                            item.locacionID = Convert.ToInt32(reader["locacionID"].ToString());
                        }

                        if (reader["proveedor_rfc"] == null)
                        {
                            item.rfc = "";
                        }
                        else
                        {
                            item.rfc = reader["proveedor_rfc"].ToString();
                        }


                        if (reader["proveedor_razonsocial"] == null)
                        {
                            item.razonsocial = "";
                        }
                        else
                        {
                            item.razonsocial = reader["proveedor_razonsocial"].ToString();
                        }

                        if (reader["empresa_etiqueta"] == null)
                        {
                            item.empresa = "";
                        }
                        else
                        {
                            item.empresa = reader["empresa_etiqueta"].ToString();
                        }

                        if (reader["empresa_domicilio"] == null)
                        {
                            item.domicilio = "";
                        }
                        else
                        {
                            item.domicilio = reader["empresa_domicilio"].ToString();
                        }

                        if (reader["empresa_rfc"] == null)
                        {
                            item.empresarfc = "";
                        }
                        else
                        {
                            item.empresarfc = reader["empresa_rfc"].ToString();
                        }

                        if (reader["empresa_nombre"] == null)
                        {
                            item.empresanombre = "";
                        }
                        else
                        {
                            item.empresanombre = reader["empresa_nombre"].ToString();
                        }

                        


                    }

                }

                con.Close();
            }
            return item;
        }



        public int InsertaFactura_Cupones(CuponFacturaRequest solicitud)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorFacturaGuardaCupones", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@sqlCommand", solicitud.sqlCommand );
                cmd.Parameters.AddWithValue("@facturaID", solicitud.facturaID );

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }


        public IEnumerable<CuponPreview> GetCuponesPreview(int zonaID,int facturaID)
        {
            var Lista = new List<CuponPreview>();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorFacturaCupon", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@facturaID", facturaID);
                cmd.Parameters.AddWithValue("@zonaID", zonaID);

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var item = new CuponPreview();

                        if (reader["serie"] == null)
                        {
                            item.serie = "";
                        }
                        else
                        {
                            item.serie = reader["serie"].ToString();
                        }

                        if (reader["res_code"] == null)
                        {
                            item.res_code = "";
                        }
                        else
                        {
                            item.res_code = reader["res_code"].ToString();
                        }


                        if (reader["res_numadults"] == null)
                        {
                            item.res_numadults = 0;
                        }
                        else
                        {
                            item.res_numadults = Convert.ToInt32(reader["res_numadults"].ToString());
                        }

                        if (reader["res_numchild"] == null)
                        {
                            item.res_numchild = 0;
                        }
                        else
                        {
                            item.res_numchild = Convert.ToInt32(reader["res_numchild"].ToString());
                        }

                        if (reader["res_costototal"] == null)
                        {
                            item.res_costototal = 0;
                        }
                        else
                        {
                            item.res_costototal = Convert.ToDecimal(reader["res_costototal"].ToString());
                        }


                        if (reader["res_tourclave"] == null)
                        {
                            item.res_tourclave = "";
                        }
                        else
                        {
                            item.res_tourclave = reader["res_tourclave"].ToString();
                        }


                        if (reader["res_tourid"] == null)
                        {
                            item.res_tourid = 0;
                        }
                        else
                        {
                            item.res_tourid =  Convert.ToInt32(reader["res_tourid"].ToString());
                        }


                        if (reader["res_validacupon"] == null)
                        {
                            item.res_validacupon = 0;
                        }
                        else
                        {
                            item.res_validacupon = Convert.ToInt32(reader["res_validacupon"].ToString());
                        }


                        if (reader["tipocambio"] == null)
                        {
                            item.tipocambio = 0;
                        }
                        else
                        {
                            item.tipocambio = Convert.ToDecimal(reader["res_validacupon"].ToString());
                        }

                        if (reader["costomxn"] == null)
                        {
                            item.costomxn = 0;
                        }
                        else
                        {
                            item.costomxn = Convert.ToDecimal(reader["costomxn"].ToString());
                        }


                        if (reader["tour_nameesp"] == null)
                        {
                            item.tour_nameesp = "";
                        }
                        else
                        {
                            item.tour_nameesp = reader["tour_nameesp"].ToString();
                        }

                        Lista.Add(item);
               }

          }
             con.Close();
          }

           return Lista;
        }


        public int InsertaFactura(FacturaItem solicitud)
        {
            int facturaid = 0;

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorInsertFactura", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@facprov_UUID", solicitud.facprov_UUID);
                cmd.Parameters.AddWithValue("@facprov_xml", solicitud.facprov_xml);
                cmd.Parameters.AddWithValue("@facprov_pdf", solicitud.facprov_pdf);
                cmd.Parameters.AddWithValue("@facprov_fechaRegistro", solicitud.facprov_fechaRegistro);
                cmd.Parameters.AddWithValue("@facprov_fecha", solicitud.facprov_fecha);
                cmd.Parameters.AddWithValue("@facprov_factura", solicitud.facprov_factura);
                cmd.Parameters.AddWithValue("@facprov_facturanum", solicitud.facprov_facturanum);
                cmd.Parameters.AddWithValue("@facprov_tipocambio", solicitud.facprov_tipocambio);
                cmd.Parameters.AddWithValue("@facprov_montototal", solicitud.facprov_montototal);
                cmd.Parameters.AddWithValue("@facprov_moneda", solicitud.facprov_moneda);
                cmd.Parameters.AddWithValue("@facprov_zonaparidad", solicitud.facprov_zonaparidad);
                cmd.Parameters.AddWithValue("@facprov_descuento", solicitud.facprov_descuento);
                cmd.Parameters.AddWithValue("@facprov_subtotal", solicitud.facprov_subtotal);
                cmd.Parameters.AddWithValue("@facprov_IVA", solicitud.facprov_IVA);
                cmd.Parameters.AddWithValue("@facprov_retIVA", solicitud.facprov_retIVA);
                cmd.Parameters.AddWithValue("@facprov_ISR", solicitud.facprov_ISR);
                cmd.Parameters.AddWithValue("@facprov_retISR", solicitud.facprov_retISR);
                cmd.Parameters.AddWithValue("@facprov_IEPS", solicitud.facprov_IEPS);
                cmd.Parameters.AddWithValue("@facprov_retotros", solicitud.facprov_retotros);
                cmd.Parameters.AddWithValue("@facprov_otros", solicitud.facprov_otros);

                cmd.Parameters.AddWithValue("@facprov_tipo", solicitud.facprov_tipo);

                cmd.Parameters.AddWithValue("@proveedorID", solicitud.facprov_proveedorID);
                cmd.Parameters.AddWithValue("@locacionID", solicitud.facprov_locacionID);
                cmd.Parameters.AddWithValue("@empresaID", solicitud.facprov_empresaID);


                //con.Open();
                //return cmd.ExecuteNonQuery();

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (reader["facturaid"] == null)
                        {
                            facturaid = 0;
                        } else
                        {
                            facturaid = Convert.ToInt32(reader["facturaid"].ToString());
                        }

                    }
                }

                con.Close();
            }

            return facturaid;
        }


        //Actiualiza factura
        public int AtualizarFactura(FacturaItem solicitud, int idfactura)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorEditFactura", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@facprov_ID", solicitud.facprov_ID);
                cmd.Parameters.AddWithValue("@facprov_UUID", solicitud.facprov_UUID);
                cmd.Parameters.AddWithValue("@facprov_xml", solicitud.facprov_xml);
                cmd.Parameters.AddWithValue("@facprov_pdf", solicitud.facprov_pdf);
                cmd.Parameters.AddWithValue("@facprov_fechaRegistro", solicitud.facprov_fechaRegistro );
                cmd.Parameters.AddWithValue("@facprov_fecha", solicitud.facprov_fecha);
                cmd.Parameters.AddWithValue("@facprov_factura", solicitud.facprov_factura);
                cmd.Parameters.AddWithValue("@facprov_facturanum", solicitud.facprov_facturanum);
                cmd.Parameters.AddWithValue("@facprov_tipocambio", solicitud.facprov_tipocambio);
                cmd.Parameters.AddWithValue("@facprov_montototal", solicitud.facprov_montototal);
                cmd.Parameters.AddWithValue("@facprov_moneda", solicitud.facprov_moneda);
                cmd.Parameters.AddWithValue("@facprov_zonaparidad", solicitud.facprov_zonaparidad);
                cmd.Parameters.AddWithValue("@facprov_descuento", solicitud.facprov_descuento);
                cmd.Parameters.AddWithValue("@facprov_subtotal", solicitud.facprov_subtotal);
                cmd.Parameters.AddWithValue("@facprov_IVA", solicitud.facprov_IVA );
                cmd.Parameters.AddWithValue("@facprov_retIVA", solicitud.facprov_retIVA );
                cmd.Parameters.AddWithValue("@facprov_ISR", solicitud.facprov_ISR);
                cmd.Parameters.AddWithValue("@facprov_retISR", solicitud.facprov_retISR);
                cmd.Parameters.AddWithValue("@facprov_IEPS", solicitud.facprov_IEPS);
                cmd.Parameters.AddWithValue("@facprov_retotros", solicitud.facprov_retotros);
                cmd.Parameters.AddWithValue("@facprov_otros", solicitud.facprov_otros);
                cmd.Parameters.AddWithValue("@proveedorID", solicitud.facprov_proveedorID);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //Atualizar un usuario
        public int AtualizarUsuarioProveedor(Proveedor solicitud, int idusuario)
        {

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorUsuarioEdit", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@userprovID", idusuario);
                cmd.Parameters.AddWithValue("@nombre", solicitud.provusr_nombre );
                cmd.Parameters.AddWithValue("@email", solicitud.provusr_email);
                cmd.Parameters.AddWithValue("@clave", solicitud.provusr_clave);
                cmd.Parameters.AddWithValue("@provedorID", solicitud.provusr_proveedorID);
                cmd.Parameters.AddWithValue("@empresaID", solicitud.provusr_empresaID );
                cmd.Parameters.AddWithValue("@locacionID", solicitud.provusr_locacionID);
                cmd.Parameters.AddWithValue("@zonaID", solicitud.provusr_zonaID);
                cmd.Parameters.AddWithValue("@activo", solicitud.provusr_activo);
                cmd.Parameters.AddWithValue("@admon", solicitud.provusr_admon);
                cmd.Parameters.AddWithValue("@factura", solicitud.provusr_factura);
                cmd.Parameters.AddWithValue("@facturacupon", solicitud.provusr_facturacupon);
                cmd.Parameters.AddWithValue("@cambioprov", solicitud.provusr_cambioprov);

                con.Open();
                return cmd.ExecuteNonQuery();
            }

        }


        public LoginResponse LoginData(LoginRequest Solicitud)
        {
            var item = new LoginResponse();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorLogin", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@usuario", Solicitud.usuario);
                cmd.Parameters.AddWithValue("@clave", Solicitud.clave);

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                   while (reader.Read())
                   {

                        if (reader["proveedorID"] == null)
                        {
                            item.proveedorID = 0;
                        }
                        else
                        {
                            item.proveedorID = Convert.ToInt32(reader["proveedorID"].ToString());
                        }

                        if (reader["email"] == null)
                        {
                            item.usuario = "";
                        }
                        else
                        {
                            item.usuario = reader["email"].ToString();
                        }

                        if (reader["nombre"] == null)
                        {
                            item.nombre = "";
                        }
                        else
                        {
                            item.nombre = reader["nombre"].ToString();
                        }

                        if (reader["admon"] == null)
                        {
                            item.admon = 0;
                        }
                        else
                        {
                            item.admon = Convert.ToInt32(reader["admon"].ToString());
                        }


                        if (reader["factura"] == null)
                        {
                           item.factura = 0;
                        }
                        else
                        {
                           item.factura = Convert.ToInt32(reader["factura"].ToString());
                        }

                        if (reader["facturacupon"] == null)
                        {
                            item.facturacupon = 0;
                        }
                        else
                        {
                            item.facturacupon = Convert.ToInt32(reader["facturacupon"].ToString());
                        }

                        if (reader["cambioprov"] == null)
                        {
                            item.cambioprov = 0;
                        }
                        else
                        {
                            item.cambioprov = Convert.ToInt32(reader["cambioprov"].ToString());
                        }

                        if (reader["zonaID"] == null)
                        {
                            item.zonaID = 0;
                        }
                        else
                        {
                            item.zonaID = Convert.ToInt32(reader["zonaID"].ToString());
                        }

                        if (reader["empresaID"] == null)
                        {
                            item.empresaID = 0;
                        }
                        else
                        {
                            item.empresaID = Convert.ToInt32(reader["empresaID"].ToString());
                        }


                        if (reader["locacionID"] == null)
                        {
                            item.locacionID = 0;
                        }
                        else
                        {
                            item.locacionID = Convert.ToInt32(reader["locacionID"].ToString());
                        }

                        if (reader["proveedor_rfc"] == null)
                        {
                            item.rfc = "";
                        }
                        else
                        {
                            item.rfc = reader["proveedor_rfc"].ToString();
                        }


                        if (reader["proveedor_razonsocial"] == null) {
                           item.razonsocial = "";
                        } else {
                           item.razonsocial = reader["proveedor_razonsocial"].ToString();
                        }

                        if (reader["empresa_etiqueta"] == null) {
                          item.empresa = "";
                        }  else {
                          item.empresa = reader["empresa_etiqueta"].ToString();
                        }

                        if (reader["empresa_domicilio"] == null)
                        {
                            item.domicilio = "";
                        }
                        else
                        {
                            item.domicilio = reader["empresa_domicilio"].ToString();
                        }

                        if (reader["empresa_rfc"] == null)
                        {
                            item.empresarfc = "";
                        }
                        else
                        {
                            item.empresarfc = reader["empresa_rfc"].ToString();
                        }

                        if (reader["empresa_nombre"] == null)
                        {
                            item.empresanombre = "";
                        }
                        else
                        {
                            item.empresanombre = reader["empresa_nombre"].ToString();
                        }                        

                    }

                }

                con.Close();
            }
            return item;
        }



        public Proveedor ProveedorByID (int userID)
        {
            var item = new Proveedor();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorUsuarioByID", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@provuserID", userID);
 
                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {


                        if (reader["provusr_id"] == null)
                        {
                            item.provusr_id = 0;
                        }
                        else
                        {
                            item.provusr_id = Convert.ToInt32(reader["provusr_id"].ToString());
                        }

                        if (reader["zontc_nombre"] == null)
                        {
                            item.zona_nombre = "";
                        }
                        else
                        {
                            item.zona_nombre = reader["zontc_nombre"].ToString();
                        }


                        if (reader["provusr_email"] == null)
                        {
                            item.provusr_email = "";
                        }
                        else
                        {
                            item.provusr_email = reader["provusr_email"].ToString();
                        }

                        

                        if (reader["provusr_clave"] == null)
                        {
                            item.provusr_clave = "";
                        }
                        else
                        {
                            item.provusr_clave = reader["provusr_clave"].ToString();
                        }

                        if (reader["provusr_activo"] == null)
                        {
                            item.provusr_activo = 0;
                        }
                        else
                        {
                            item.provusr_activo = Convert.ToInt32(reader["provusr_activo"].ToString());
                        }

                        if (reader["locacion_name"] == null)
                        {
                            item.locacion_name = "";
                        }
                        else
                        {
                            item.locacion_name = reader["locacion_name"].ToString();
                        }

                        if (reader["empresa_nombre"] == null)
                        {
                            item.empresa_nombre = "";
                        }
                        else
                        {
                            item.empresa_nombre = reader["empresa_nombre"].ToString();
                        }

                        if (reader["provusr_nombre"] == null)
                        {
                            item.provusr_nombre = "";
                        }
                        else
                        {
                            item.provusr_nombre = reader["provusr_nombre"].ToString();
                        }


                        if (reader["proveedor_nombre"] == null)
                        {
                            item.proveedor_nombre = "";
                        }
                        else
                        {
                            item.proveedor_nombre = reader["proveedor_nombre"].ToString();
                        }

                        if (reader["provusr_proveedorID"] == null)
                        {
                            item.provusr_proveedorID = 0;
                        }
                        else
                        {
                            item.provusr_proveedorID = Convert.ToInt32(reader["provusr_proveedorID"].ToString());
                        }

                        if (reader["provusr_zonaID"] == null)
                        {
                            item.provusr_zonaID = 0;
                        }
                        else
                        {
                            item.provusr_zonaID = Convert.ToInt32(reader["provusr_zonaID"].ToString());
                        }

                        if (reader["provusr_admon"] == null)
                        {
                            item.provusr_admon = 0;
                        }
                        else
                        {
                            item.provusr_admon = Convert.ToInt32(reader["provusr_admon"].ToString());
                        }

                        if (reader["provusr_factura"] == null)
                        {
                            item.provusr_factura = 0;
                        }
                        else
                        {
                            item.provusr_factura = Convert.ToInt32(reader["provusr_factura"].ToString());
                        }

                        if (reader["provusr_facturacupon"] == null)
                        {
                            item.provusr_facturacupon = 0;
                        }
                        else
                        {
                            item.provusr_facturacupon = Convert.ToInt32(reader["provusr_facturacupon"].ToString());
                        }

                        if (reader["provusr_cambioprov"] == null)
                        {
                            item.provusr_cambioprov = 0;
                        }
                        else
                        {
                            item.provusr_cambioprov = Convert.ToInt32(reader["provusr_cambioprov"].ToString());
                        }

                        if (reader["provusr_empresaID"] == null)
                        {
                            item.provusr_empresaID = 0;
                        }
                        else
                        {
                            item.provusr_empresaID = Convert.ToInt32(reader["provusr_empresaID"].ToString());
                        }

                        if (reader["provusr_locacionID"] == null)
                        {
                            item.provusr_locacionID = 0;
                        }
                        else
                        {
                            item.provusr_locacionID = Convert.ToInt32(reader["provusr_locacionID"].ToString());
                        }
                      
                        
                    }

                   }

                con.Close();
            }
            return item;
        }

        public ListaUser Usuarios_ListaProv(UsuarioRequest solicitud)
        {
            var ListatoShow = new ListaUser();

            int totalDeResultados = 0;

            var Lista = new List<Proveedor>();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorUsuarioGetAll", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paginaActual", solicitud.pagina);
                cmd.Parameters.AddWithValue("@busqueda", solicitud.busqueda);
                cmd.Parameters.AddWithValue("@empresaID", solicitud.id_empresa);
                cmd.Parameters.AddWithValue("@locacionID", solicitud.id_locacion );
                cmd.Parameters.AddWithValue("@proveedorID", solicitud.id_proveedor );

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    
                   while (reader.Read())
                   {
                       var item = new Proveedor();

                        if (reader["provusr_id"] == null)
                        {
                            item.provusr_id = 0;
                        }
                        else
                        {
                            item.provusr_id = Convert.ToInt32(reader["provusr_id"].ToString());
                        }


                        if (reader["provusr_email"] == null)
                        {
                            item.provusr_email = "";
                        }
                        else
                        {
                            item.provusr_email = reader["provusr_email"].ToString();
                        }

                        if (reader["provusr_clave"] == null)
                        {
                            item.provusr_clave = "";
                        }
                        else
                        {
                            item.provusr_clave = reader["provusr_clave"].ToString();
                        }

                        if (reader["provusr_activo"] == null)
                        {
                            item.provusr_activo = 0;
                        }
                        else
                        {
                            item.provusr_activo = Convert.ToInt32(reader["provusr_activo"].ToString());
                        }

                        if (reader["locacion_name"] == null)
                        {
                            item.locacion_name = "";
                        }
                        else
                        {
                            item.locacion_name = reader["locacion_name"].ToString();
                        }

                        if (reader["empresa_nombre"] == null)
                        {
                            item.empresa_nombre = "";
                        }
                        else
                        {
                            item.empresa_nombre = reader["empresa_nombre"].ToString();
                        }

                        if (reader["provusr_nombre"] == null)
                        {
                            item.provusr_nombre = "";
                        }
                        else
                        {
                            item.provusr_nombre = reader["provusr_nombre"].ToString();
                        }


                        if (reader["proveedor_nombre"] == null)
                        {
                            item.proveedor_nombre = "";
                        }
                        else
                        {
                            item.proveedor_nombre = reader["proveedor_nombre"].ToString();
                        }



                        if (reader["totalresultados"] == null)
                        {
                            totalDeResultados = 0;
                            item.totalDeResultados = 0;
                        }
                        else
                        {
                            item.totalDeResultados = Convert.ToInt32(reader["totalresultados"].ToString());
                            
                            totalDeResultados = Convert.ToInt32(reader["totalresultados"].ToString());
                        }
                        
                        Lista.Add(item);                        
                    }

                    ListatoShow.ListaItems = Lista;

                    var pagerF = new Pager(totalDeResultados, solicitud.pagina, 15);
                    ListatoShow.Paginas = pagerF;
                }

                con.Close();
            }
            return ListatoShow;
        }


        public FacturaProviderResponse FacturasProveedor_Lista(FacturaRequest solicitud)
        {
            var ListatoShow = new FacturaProviderResponse();

            int totalDeResultados = 0;

            var Lista = new List<FacturaItem>();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("proveedorGetFacturasProv", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paginaActual", solicitud.paginaActual);
                cmd.Parameters.AddWithValue("@busqueda", solicitud.Busqueda);
                cmd.Parameters.AddWithValue("@tipofactura", solicitud.Tipofactura);
                cmd.Parameters.AddWithValue("@proveedorID", solicitud.proveedorID);
                cmd.Parameters.AddWithValue("@locacionID", solicitud.locationID);
                cmd.Parameters.AddWithValue("@empresaID", solicitud.companyID);

                con.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var item = new FacturaItem();
                        
                        if (reader["totalResultados"] == null)
                        {
                            item.totalResultados = 0;
                            totalDeResultados = 0;
                        }
                        else
                        {
                            item.totalResultados = Convert.ToInt32(reader["totalResultados"].ToString());
                            totalDeResultados =  Convert.ToInt32(reader["totalResultados"].ToString());
                        }

                        if (reader["facprov_otros"] == null)
                        {
                            item.facprov_otros = 0;
                        }
                        else
                        {
                            item.facprov_otros = Convert.ToDecimal(reader["facprov_otros"].ToString());
                        }

                        if (reader["facprov_retotros"] == null)
                        {
                            item.facprov_retotros = 0;
                        }
                        else
                        {
                            item.facprov_retotros = Convert.ToDecimal(reader["facprov_retotros"].ToString());
                        }

                        if (reader["facprov_IEPS"] == null)
                        {
                            item.facprov_IEPS = 0;
                        }
                        else
                        {
                            item.facprov_IEPS = Convert.ToDecimal(reader["facprov_IEPS"].ToString());
                        }


                        if (reader["facprov_retISR"] == null)
                        {
                            item.facprov_retISR = 0;
                        }
                        else
                        {
                            item.facprov_retISR = Convert.ToDecimal(reader["facprov_retISR"].ToString());
                        }

                        if (reader["facprov_ISR"] == null)
                        {
                            item.facprov_ISR = 0;
                        }
                        else
                        {
                            item.facprov_ISR = Convert.ToDecimal(reader["facprov_ISR"].ToString());
                        }

                        if (reader["facprov_retIVA"] == null)
                        {
                            item.facprov_retIVA = 0;
                        }
                        else
                        {
                            item.facprov_retIVA = Convert.ToDecimal(reader["facprov_retIVA"].ToString());
                        }

                        if (reader["facprov_IVA"] == null)
                        {
                            item.facprov_IVA = 0;
                        }
                        else
                        {
                            item.facprov_IVA = Convert.ToDecimal(reader["facprov_IVA"].ToString());
                        }

                        if (reader["facprov_subtotal"] == null)
                        {
                            item.facprov_subtotal = 0;
                        }
                        else
                        {
                            item.facprov_subtotal = Convert.ToDecimal(reader["facprov_subtotal"].ToString());
                        }

                        if (reader["facprov_descuento"] == null)
                        {
                            item.facprov_descuento = 0;
                        }
                        else
                        {
                            item.facprov_descuento = Convert.ToDecimal(reader["facprov_descuento"].ToString());
                        }

                        if (reader["facprov_zonaparidad"] == null) {
                            item.facprov_zonaparidad = 0;
                        } else {
                            item.facprov_zonaparidad =  Convert.ToInt32(reader["facprov_zonaparidad"].ToString());
                        }

                        if (reader["facprov_moneda"] == null)
                        {
                            item.facprov_moneda = "";
                        }
                        else
                        {
                            item.facprov_moneda = reader["facprov_moneda"].ToString();
                        }

                        if (reader["facprov_montototal"] == null)
                        {
                            item.facprov_montototal = 0;
                        }
                        else
                        {
                            item.facprov_montototal = Convert.ToDecimal(reader["facprov_montototal"].ToString());
                        }

                        if (reader["facprov_tipocambio"] == null)
                        {
                            item.facprov_tipocambio = 0;
                        }
                        else
                        {
                            item.facprov_tipocambio = Convert.ToDecimal(reader["facprov_tipocambio"].ToString());
                        }

                        if (reader["facprov_id"] == null)
                        {
                            item.facprov_ID = 0;
                        }
                        else
                        {
                            item.facprov_ID = Convert.ToInt32(reader["facprov_id"].ToString());
                        }


                        if (reader["facprov_UUID"] == null)
                        {
                            item.facprov_UUID = "";
                        }
                        else
                        {
                            item.facprov_UUID = reader["facprov_UUID"].ToString();
                        }

                        if (reader["facprov_xml"] == null)
                        {
                            item.facprov_xml = "";
                        }
                        else
                        {
                            item.facprov_xml = reader["facprov_xml"].ToString();
                        }

                        if (reader["facprov_pdf"] == null)
                        {
                            item.facprov_pdf = "";
                        }
                        else
                        {
                            item.facprov_pdf = reader["facprov_pdf"].ToString();
                        }
                        
                        if (reader["facprov_fechaRegistro"] == null)
                        {
                            item.facprov_fechaRegistro = "";
                        }
                        else
                        {
                            item.facprov_fechaRegistro = reader["facprov_fechaRegistro"].ToString();
                        }

                        if (reader["facprov_fecha"] == null)
                        {
                            item.facprov_fecha = "";
                        }
                        else
                        {
                            item.facprov_fecha = reader["facprov_fecha"].ToString();
                        }

                        if (reader["facprov_factura"] == null)
                        {
                            item.facprov_factura = "";
                        }
                        else
                        {
                            item.facprov_factura = reader["facprov_factura"].ToString();
                        }


                        if (reader["facprov_facturanum"] == null)
                        {
                            item.facprov_facturanum = "";
                        }
                        else
                        {
                            item.facprov_facturanum = reader["facprov_facturanum"].ToString();
                        }
                        

                        if (reader["totalresultados"] == null)
                        {
                            totalDeResultados = 0;
                            item.totalResultados = 0;
                        }
                        else
                        {
                            item.totalResultados = Convert.ToInt32(reader["totalresultados"].ToString());

                            totalDeResultados = Convert.ToInt32(reader["totalresultados"].ToString());
                        }

                        Lista.Add(item);
                    }

                    ListatoShow.ListaFacturas = Lista;

                    var pagerF = new Pager(totalDeResultados, solicitud.paginaActual , 15);
                    ListatoShow.Paginas = pagerF;
                }

                con.Close();
            }
            return ListatoShow;
        }


    }

}
