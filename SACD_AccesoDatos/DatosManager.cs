using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_AccesoDatos
{
    public class DatosManager
    {
        private SqlConnection conn = null;


        public bool crearConexion()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server =DESKTOP-78JIJ14; Database =Prueba; Trusted_Connection = true; Integrated Security=True";
            /*Server =[server_name]; Database =[database_name]; Trusted_Connection = true*/
            try
            {
                conn.Open();
                Console.WriteLine("Conexión exitosa");
                return true;
            }

            catch (SqlException ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }

            /*conn = new SqlConnection();
            conn.ConnectionString = "Server =DESKTOP-78JIJ14; Database =Prueba; Trusted_Connection = true; Integrated Security=True";

            try
            {
                conn.Open();
                //return "Connected successfully";

                //CONSULTA
                SqlCommand command = new SqlCommand("SELECT * FROM Table_1", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    return reader.GetString(0);
                }

                reader.Close();


            }
            catch (SqlException ex)
            {
                return "ERROR DE BD" + ex.Message;
                Console.WriteLine("ERROR DE BD" + ex.Message);
            }

            conn.Close();

            return "";*/

        }

        public void cerrarConexion()
        {
            if (conn != null)
                conn.Close();
            else
                Console.WriteLine("La conexión no ha sido creada");
        }
    }
}
