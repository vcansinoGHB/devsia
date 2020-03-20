using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using devSia.Interfaces;
using devSia.Modelos.SICOP;

namespace devSia.DAL
{
    public class SicopDAL: ISicop
    {
        readonly string _connectionString;
        public SicopDAL(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("SicopConnection");
        }


        public IEnumerable<Response> ObtenerInformacion(Request Solicitud)
        {
            var Lista = new List<Response>();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("spVtaArticulos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@fechaInicio", Solicitud.fechaInicio);
                cmd.Parameters.AddWithValue("@fechaFin", Solicitud.fechaFin );
                cmd.Parameters.AddWithValue("@tipo", Solicitud.tipo);
                cmd.Parameters.AddWithValue("@opcion", Solicitud.opcion);

                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new Response
                    {
                        fecha             = reader["fecha"].ToString(),
                        concepto          = reader["concepto"].ToString(),
                        cantidad          =  Convert.ToInt32(reader["cantidad"].ToString()),
                        precio            =  Convert.ToDecimal(reader["precio"].ToString()),
                        totalVta          = Convert.ToDecimal(reader["totalVta"].ToString()),
                        guia              = reader["guia"].ToString(),
                        estatus           = reader["estatus"].ToString(),
                        status            =  Convert.ToInt32(reader["status"].ToString()),
                        incentivos        = Convert.ToInt32(reader["incentivos"].ToString()),
                        montoincentivo    = Convert.ToDecimal(reader["montoincentivo"].ToString()),
                        montoincentivomxn = Convert.ToDecimal(reader["preciomxn"].ToString()),
                        tipocambio        = Convert.ToDecimal(reader["tc"].ToString()),
                        totalvta          = Convert.ToDecimal(reader["totalVta"].ToString()),
                        totalvtamxn       = Convert.ToDecimal(reader["totalVtamxn"].ToString()),
                        totalfinal        = Convert.ToDecimal(reader["totalfinal"].ToString()),
                        totalfinalmxn     = Convert.ToDecimal(reader["totalfinalmxn"].ToString()),
                        totalincentivo    = Convert.ToDecimal(reader["totalincentivo"].ToString())
                    };

                    Lista.Add(item);
                }
                con.Close();
            }
            return Lista;
        }


    }
}
