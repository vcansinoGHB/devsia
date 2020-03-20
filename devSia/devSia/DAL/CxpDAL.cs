using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devSia.Modelos;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using devSia.Interfaces;

namespace devSia.DAL
{
    public class CxpDAL: ICxP
    {
        readonly string _connectionString;
        public CxpDAL(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ProveedorCuentasB> ObtenerCuentaProveeodres(int proveedorID)
        {
            var Lista = new List<ProveedorCuentasB>();

            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("cxpProveedorGetCuentas", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@provedorID", proveedorID);

                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = new ProveedorCuentasB
                    {
                        Cuenta     = reader["cuenta"].ToString(),
                        Clabe      = reader["clabe"].ToString(),
                        Divisa     = reader["divisa"].ToString(),
                        Banco      = reader["banco"].ToString(),
                        Referencia = reader["referencia"].ToString()
                    };

                    Lista.Add(item);
                }
                con.Close();
            }
            return Lista;
        }

    }
}
