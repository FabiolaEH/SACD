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
            conn.ConnectionString = "Server = JHOELPC; Database =SACD_DB; Trusted_Connection = true; Integrated Security=True";
            //conn.ConnectionString = "Server = BRANDON-PC; Database = SACD_DB; Trusted_Connection = true; Integrated Security = True";
            //conn.ConnectionString = "Server = DESKTOP-78JIJ14; Database =SACD_DB; Trusted_Connection = true; Integrated Security=True";

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
        /************* Usuarios ***************/
        //Obtener lista de usuarios
        public static List<Object[]> getUsuariosList()
        {
            List<Object[]> usuariosList = new List<Object[]>();        

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFUSUARIOS", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] profeInfo = new Object[3];
                    profeInfo[0] = reader.GetString(0);
                    profeInfo[1] = reader.GetString(1);
                    profeInfo[2] = reader.GetString(2);
                    usuariosList.Add(profeInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return usuariosList;
        }

        //Buscar usuario por correo
        public static Boolean verificarCorreo(string pCorreo)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT count(*) FROM SACDFUSUARIOS WHERE TXT_EMAIL = @correo", conn);
                command.Parameters.AddWithValue("@correo", pCorreo);
                int result = (int)command.ExecuteScalar();
                if (result > 0)
                    isValido = true;
                else
                    isValido = false;
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }


            return isValido;
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

        /************* Actv. Administrativas ***************/
        //Obtener lista de investigaciones
        public static List<Object[]> getAdministvsList()
        {
            List<Object[]> administvsList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFADMINISTRAT", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] administvInfo = new Object[3];
                    administvInfo[0] = reader.GetInt32(0);
                    administvInfo[1] = reader.GetString(1);
                    administvInfo[2] = reader.GetDecimal(2);
                    administvsList.Add(administvInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return administvsList;
        }

        /************* Grupos ***************/
        //Obtener lista de grupos
        public static List<Object[]> getGruposList()
        {
            List<Object[]> gruposList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT g.COD_CURSO, c.NOM_CURSO, g.ID_GRUPO, g.NUM_GRUPO, g.NUM_ESTUDIANTES " 
                                                    + "FROM SACDFGRUPOS g " 
                                                    + "JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO "
                                                    + "ORDER BY c.NOM_CURSO", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] grupoInfo = new Object[5];
                    grupoInfo[0] = reader.GetString(0);
                    grupoInfo[1] = reader.GetString(1);
                    grupoInfo[2] = reader.GetInt32(2);
                    grupoInfo[3] = reader.GetInt32(3); //numeric
                    grupoInfo[4] = reader.GetInt32(4); //numeric
                    gruposList.Add(grupoInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return gruposList;
        }

        /*---------------------------------   MODIFICAR  --------------------------------------*/


        /*---------------------------------   ELIMINAR  --------------------------------------*/
    }
}
