using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_AccesoDatos
{
    public static class DatosManager
    {
        private static SqlConnection conn = null;


        public static bool crearConexion()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server =BRANDON-PC; Database =SACD_DB; Trusted_Connection = true; Integrated Security=True";
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

        public static void cerrarConexion()
        {
            if (conn != null)
                conn.Close();
            else
                Console.WriteLine("La conexión no ha sido creada");
        }

        /*---------------------------------   CONSULTAR   -------------------------------------*/
        /************* Profesores ***************/
        //Obtener lista de profesores
        public static List<Object[]> getProfesoresList()
        {
            List<Object[]> profesList = new List<Object[]>();        

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFPROFESORES", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] profeInfo = new Object[3];
                    profeInfo[0] = reader.GetInt32(0);
                    profeInfo[1] = reader.GetString(1);
                    profeInfo[2] = reader.GetDecimal(2);
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

        //Buscar profesor por id
        public static Object[] getProfeInfo(int id)
        {
            Object[] profeInfo = new Object[3];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFPROFESORES", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    profeInfo[0] = reader.GetInt32(0);
                    profeInfo[1] = reader.GetString(1);
                    profeInfo[2] = reader.GetDecimal(2);

                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }


            return profeInfo;
        }

        /************* Investigaciones ***************/
        //Obtener lista de investigaciones
        public static List<Object[]> getInvestigList()
        {
            List<Object[]> investigList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFINVESTIG", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] investigInfo = new Object[5];
                    investigInfo[0] = reader.GetInt32(0);
                    investigInfo[1] = reader.GetString(1);
                    investigInfo[2] = reader.GetDecimal(2);
                    investigInfo[3] = reader.GetDateTime(3);
                    investigInfo[4] = reader.GetDateTime(4);
                    investigList.Add(investigInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return investigList;
        }

        /*---------------------------------   MODIFICAR  --------------------------------------*/


        /*---------------------------------   ELIMINAR  --------------------------------------*/
    }
}
