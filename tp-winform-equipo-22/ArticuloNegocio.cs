using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tp_winform_equipo_22
{
    internal class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_P3_DB;integrated security=true";
                comando.CommandType=System.Data.CommandType.Text;
                comando.CommandText = "select Id, Codigo, Nombre, Descripcion, Precio from ARTICULOS";
                comando.Connection= conexion;

                conexion.Open();
                lector=comando.ExecuteReader();

                while(lector.Read())
                {
                    Articulo aux= new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
                
            }
            catch (Exception ex)
          
            {
                throw ex;
            }
            
        }
        
    }
}
