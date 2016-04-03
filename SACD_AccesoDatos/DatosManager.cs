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
         
            //conn.ConnectionString = "Server = JHOELPC; Database =SACD_DB; Trusted_Connection = true; Integrated Security=True";
            conn.ConnectionString = "Server = BRANDON-PC; Database = SACD_DB; Trusted_Connection = true; Integrated Security = True";
            //conn.ConnectionString = "Server = DESKTOP-78JIJ14; Database =SACD_DB; Trusted_Connection = true; Integrated Security=True";
            //conn.ConnectionString = "Server = ecRhin\\estudiantes; Database =SACD_DB; Trusted_Connection = true; Integrated Security=True";

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

        //Actualizar código de verificación del usuario
        public static Boolean generarCodigo(string pCodigo, string pCorreo)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("UPDATE SACDFUSUARIOS SET COD_RECUPERA = @cod_recup WHERE TXT_EMAIL = @correo", conn);
                command.Parameters.AddWithValue("@cod_recup", pCodigo);
                command.Parameters.AddWithValue("@correo", pCorreo);
                command.ExecuteNonQuery();
                return true;
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }
        
        //Verificar código
        public static string verificarCodigo(string pCorreo)
        {
            String codigo = "";

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT COD_RECUPERA FROM SACDFUSUARIOS WHERE TXT_EMAIL = @correo", conn);
                command.Parameters.AddWithValue("@correo", pCorreo);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    codigo = reader.GetString(0);

            }
            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }
            return codigo;
        }

        //Actualizar Contraseña
        public static Boolean actualizarPassword(string pCorreo, string pPassword)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("UPDATE SACDFUSUARIOS SET TXT_CONTRAS = @password WHERE TXT_EMAIL = @correo", conn);
                command.Parameters.AddWithValue("@password", pPassword);
                command.Parameters.AddWithValue("@correo", pCorreo);
                command.ExecuteNonQuery();
                return true;
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            
            return isValido;
        }

        //Registrar usuario
        public static Boolean registrarUsuario(string pNombre, string pCorreo, string pPassword)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("INSERT INTO SACDFUSUARIOS VALUES(@nombre, @correo, @password,'')", conn);
                command.Parameters.AddWithValue("@nombre", pNombre);
                command.Parameters.AddWithValue("@password", pPassword);
                command.Parameters.AddWithValue("@correo", pCorreo);
                command.ExecuteNonQuery();
                return true;
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }

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
        public static Object[] getProfeInfo(int pId)
        {
            Object[] profeInfo = new Object[3];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFPROFESORES "
                                                    + "WHERE ID_PROFESOR = '" +pId+ "'", conn);
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


        //Buscar profesor por nombre
        public static Object[] getProfeInfoPorNombre(String pNombre)
        {
            Object[] profeInfo = new Object[3];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFPROFESORES WHERE NOM_PROFESOR = '"+ pNombre + "'", conn);
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
                    investigInfo[1] = reader.GetDecimal(1);
                    investigInfo[2] = reader.GetDateTime(2);
                    investigInfo[3] = reader.GetDateTime(3);
                    investigInfo[4] = reader.GetString(4);
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

        //Buscar investigacion por id
        public static Object[] getInvestigInfo(int id)
        {
            Object[] investInfo = new Object[5];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFINVESTIG WHERE ID_INVESTIGACION = " + id.ToString(), conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    investInfo[0] = reader.GetInt32(0);
                    investInfo[1] = reader.GetDecimal(1);
                    investInfo[2] = reader.GetDateTime(2);
                    investInfo[3] = reader.GetDateTime(3);
                    investInfo[4] = reader.GetString(4);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return investInfo;
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

        //Buscar administrativas por id
        public static Object[] getAdministvsInfo(int id)
        {
            Object[] admiInfo = new Object[3];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFADMINISTRAT WHERE ID_ADMINISTRATIV = " + id.ToString(), conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    admiInfo[0] = reader.GetInt32(0);
                    admiInfo[1] = reader.GetString(1);
                    admiInfo[2] = reader.GetDecimal(2);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return admiInfo;
        }

        /************* Grupos ***************/

        //Obtener lista de grupos
        public static List<Object[]> getGruposList()
        {
            List<Object[]> gruposList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT g.ID_GRUPO, g.COD_CURSO, c.NOM_CURSO, g.NUM_GRUPO, g.NUM_ESTUDIANTES "
                                                    + "FROM SACDFGRUPOS g " 
                                                    + "JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO "
                                                    + "ORDER BY c.NOM_CURSO", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] grupoInfo = new Object[5];
                    grupoInfo[0] = reader.GetInt32(0);
                    grupoInfo[1] = reader.GetString(1);
                    grupoInfo[2] = reader.GetString(2);
                    grupoInfo[3] = reader.GetInt32(3);
                    grupoInfo[4] = reader.GetInt32(4);
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

        /************* Cursos ***************/

        //Obtener total de horas presenciales de un curso
        public static decimal getHorasCurso(string pCodigo)
        {
            decimal valHoras = 0;

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT SUM(CAN_HORAS) "
                                                   + "FROM SACDFTIPO_CURSO "
                                                   + "WHERE COD_CURSO = '" + pCodigo + "'", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    valHoras = reader.GetDecimal(0);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return valHoras;
        }

        public static List<Object[]> getTipoCurso(string pCodigo)
        {
            List<Object[]> tiposList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT TXT_TIPO, CAN_HORAS "
                                                   + "FROM SACDFTIPO_CURSO "
                                                   + "WHERE COD_CURSO = '" + pCodigo + "'", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] tipoInfo = new Object[2];
                    tipoInfo[0] = reader.GetString(0);
                    tipoInfo[1] = reader.GetDecimal(1);
                    tiposList.Add(tipoInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return tiposList;
        }


        /************* Semestres ***************/

        //Obtener lista de grupos
        public static List<Object[]> getSemestresList()
        {
            List<Object[]> semestresList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFSEMESTRES", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] grupoInfo = new Object[3];
                    grupoInfo[0] = reader.GetInt32(0);
                    grupoInfo[1] = reader.GetInt32(1);
                    grupoInfo[2] = reader.GetInt32(2);
                    semestresList.Add(grupoInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return semestresList;
        }



        /************* Asignaciones ***************/

        //buscar asignaciones 
        public static List<Object[]> getAsignaciones(int pIdProfe, int pPeriodo, int pAño)
        {
            List<Object[]> asignacionesList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM (SACDFASIGNACIONES a LEFT JOIN SACDFSEMESTRES b ON a.ID_SEMESTRE = b.ID_SEMESTRE)"  
                    + " LEFT JOIN SACDFPROFESORES c ON a.ID_PROFESOR = c.ID_PROFESOR" 
                    + " WHERE b.NUM_PERIODO = "+ pPeriodo.ToString() +" AND b.NUM_AÑO = "+ pAño.ToString() 
                    + " AND c.ID_PROFESOR = "+pIdProfe.ToString(), conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] grupoInfo = new Object[4];
                    grupoInfo[0] = reader.GetInt32(0);
                    grupoInfo[1] = reader.GetInt32(1);
                    grupoInfo[2] = reader.GetInt32(2);
                    grupoInfo[3] = reader.GetDecimal(3);
                    asignacionesList.Add(grupoInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return asignacionesList;
        }


        /************* Actividades ***************/

        //Buscar actividad por id
        public static Object[] getActividadInfo(int id)
        {
            Object[] actividadInfo = new Object[2];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM SACDFACTIVIDADES WHERE ID_ACTIVIDAD = "+id.ToString(), conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    actividadInfo[0] = reader.GetInt32(0);
                    actividadInfo[1] = reader.GetString(1);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return actividadInfo;
        }

        /*---------------------------------   MODIFICAR  --------------------------------------*/


        /*---------------------------------   ELIMINAR  --------------------------------------*/
    }
}
