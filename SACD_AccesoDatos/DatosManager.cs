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

        }

        public void cerrarConexion()
        {
            if (conn != null)
                conn.Close();
            else
                Console.WriteLine("La conexión no ha sido creada");
        }

        /*---------------------------------   CONSULTAR   -------------------------------------*/
        public List<Object> getProfesoresList()
        {
            List<Object> profesList = new List<object>();        

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Table_1", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] profeInfo = new Object[4];
                    profeInfo[0] = reader.GetString(0);
                    profeInfo[1] = reader.GetInt32(1);
                    profeInfo[2] = reader.GetDouble(2);
                    profeInfo[3] = reader.GetDecimal(3);
                    profesList.Add(profeInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return profesList;
        }


        /*---------------------------------   MODIFICAR  --------------------------------------*/


        /*---------------------------------   ELIMINAR  --------------------------------------*/
    }
}
