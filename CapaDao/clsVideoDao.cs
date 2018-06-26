using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaCodigo;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaDao
{
   public class clsVideoDao : clsConexion
    {
        clsvideos vid = new clsvideos();
        public void InsertarClientes(clsvideos cli)
        {
            SqlCommand cmd = new SqlCommand("PA_INSERTAR_VIDEO", Conexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GENERO", vid.genero);
            cmd.Parameters.AddWithValue("@IDDIRECTOR", vid.coddirector);
            cmd.Parameters.AddWithValue("@IDACTOR", vid.codactor);
            cmd.Parameters.AddWithValue("@TITULO", vid.titulo);
            cmd.Parameters.AddWithValue("@ESTRENO", vid.estreno);
            cmd.Parameters.AddWithValue("@DESCRIPCION", vid.descripcion);
            cmd.Parameters.AddWithValue("@CLASIFICACION", vid.clasificacion);
            cmd.Parameters.AddWithValue("@STOCK", vid.stock);
            cmd.Parameters.AddWithValue("@IDIOMA", vid.idioma);
            cmd.Parameters.AddWithValue("@RESOLUCION", vid.resolucion);
            cmd.Parameters.AddWithValue("@PRECIO", vid.precio);
            cmd.Parameters.AddWithValue("@PRECIOCOMPRA", vid.preciocompra);
            cmd.Parameters.AddWithValue("@PRECIONVENTA", vid.precioventa);
            cmd.Parameters.AddWithValue("@PRECIOALQUILER", vid.precioalquiler);
            cmd.ExecuteNonQuery();

        }
        public DataTable llenarVideos()
        {
            SqlDataAdapter da = new SqlDataAdapter("select IDVIDEO, from VIDEOS", Conexion());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public void ELiminarVideo(int i)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_VIDEO", Conexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", i);
            cmd.ExecuteNonQuery();
        }
    }
}
