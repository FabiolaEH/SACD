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
        private SqlConnection conn;


        public string crearConexion()
        {
            conn = new SqlConnection();
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

            return "";

        }
    }
}
