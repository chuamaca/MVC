using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using PruebaMVC.Models;

namespace PruebaMVC.Entidad
{
    public class Brand
    {

        public List<MBrand> Listar_Marcas(String marca, int id)
        {
            List<MBrand> listar = null;
            string sqlquery = "SP_LISTAR_MARCA";
            try
            {
                using (SqlConnection cn = new SqlConnection(Utils.Conexion.conexionDB))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nmbrand", DbType.String).Value =marca;
                        cmd.Parameters.AddWithValue("@idbrand", DbType.Int16).Value = id;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            listar = new List<MBrand>();
                            listar = (from DataRow fila in dt.Rows
                                      select new MBrand()
                                      {
                                          idbrand = (int)fila["idbrand"],
                                          nmbrand = fila["nmbrand"].ToString(),
                                          descbrand = fila["descbrand"].ToString(),
                                          // descbrand = Convert.ToBoolean(fila["con_tran"]),
                                          stbrand = (int)fila["idbrand"]
                                      }
                                    ).ToList();
                        }
                    }
                }
            }
            catch
            {
                listar = new List<MBrand>();
            }
            return listar;
        }


        public bool QuitarMarcas(int id)
        {
            bool result = false;
            string sqlquery = "SP_QUITAR_MARCA";
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(Utils.Conexion.conexionDB);
                if (cn.State == 0) cn.Open();
                cmd = new SqlCommand(sqlquery, cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idbrand", Convert.ToInt32(id));
               // cmd.Parameters.AddWithValue("@idpedido", pedido);
                cmd.ExecuteNonQuery();

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

    }
}