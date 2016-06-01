using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


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
                }

                reader.Close();
                cerrarConexion();
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

                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }


            return profeInfo;
        }


        //Obtener último ID insertado
        public static Object[] getUltimoProfe()
        {
            Object[] profeInfo = new Object[1];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT TOP(1) ID_PROFESOR FROM SACDFPROFESORES ORDER BY ID_PROFESOR DESC", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    profeInfo[0] = reader.GetInt32(0);

                }

                reader.Close();
                cerrarConexion();
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
                cerrarConexion();
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
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return investInfo;
        }


        /************* Actv. Administrativas ***************/

        //Obtener lista de administrativas
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
                cerrarConexion();
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
                cerrarConexion();
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
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return gruposList;
        }


        //Buscar grupo por id
        public static Object[] getGrupoInfo(int id)
        {
            Object[] grupoInfo = new Object[4];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT g.COD_CURSO, c.NOM_CURSO, g.NUM_GRUPO, g.NUM_ESTUDIANTES FROM SACDFGRUPOS g JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO WHERE G.ID_GRUPO = " + id.ToString() + " ORDER BY c.NOM_CURSO", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    grupoInfo[0] = reader.GetString(0);
                    grupoInfo[1] = reader.GetString(1);
                    grupoInfo[2] = reader.GetInt32(2);
                    grupoInfo[3] = reader.GetInt32(3);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return grupoInfo;
        }

        //Buscar grupo por cod Curso
        public static List<Object[]> getGrupoInfoCodigo(string pCodigo)
        {
            List<Object[]> grupos = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT g.ID_GRUPO, g.COD_CURSO, c.NOM_CURSO, g.NUM_GRUPO, g.NUM_ESTUDIANTES FROM SACDFGRUPOS g JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO WHERE G.COD_CURSO = @codigo ORDER BY c.NOM_CURSO", conn);
                command.Parameters.AddWithValue("@codigo", pCodigo);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] grupoInfo = new Object[5];
                    grupoInfo[0] = reader.GetInt32(0);
                    grupoInfo[1] = reader.GetString(1);
                    grupoInfo[2] = reader.GetString(2);
                    grupoInfo[3] = reader.GetInt32(3);
                    grupoInfo[4] = reader.GetInt32(4);
                    grupos.Add(grupoInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            cerrarConexion();
            return grupos;
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
                cerrarConexion();
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
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return tiposList;
        }


        public static List<Object[]> getCursosList()
        {
            List<Object[]> cursosList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT COD_CURSO, NOM_CURSO FROM SACDFCURSO", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] info = new Object[2];
                    info[0] = reader.GetString(0);
                    info[1] = reader.GetString(1);
                    cursosList.Add(info);
                }

                reader.Close();
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return cursosList;
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
     

        //Obtener semestre actual
        public static List<int> get_Semestre_Global()
        {
            List<int> semestre = new List<int>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT ID_SEMESTRE, NUM_AÑO, NUM_PERIODO FROM SACDFSEMESTRES WHERE DSC_ACTUAL = 1", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int semes = reader.GetInt32(0);
                    int anio = reader.GetInt32(1);
                    int periodo = reader.GetInt32(2);
                    semestre.Add(semes);
                    semestre.Add(anio);
                    semestre.Add(periodo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }
            conn.Close();
            return semestre;
        }


        /************* Asignaciones ***************/

        //buscar asignaciones 
        public static List<Object[]> getAsignaciones(int pIdProfe, int pPeriodo, int pAño, bool pTipoConsulta)
        {
            List<Object[]> asignacionesList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command;
                if (pTipoConsulta) //lista de asignaciones de un semestre
                {
                    command = new SqlCommand("SELECT a.ID_ACTIVIDAD, b.ID_SEMESTRE, a.NUM_VALOR_HORAS FROM(SACDFASIGNACIONES a LEFT JOIN SACDFSEMESTRES b ON a.ID_SEMESTRE = b.ID_SEMESTRE) WHERE b.NUM_PERIODO = @periodo AND b.NUM_AÑO = @anio", conn);
                    command.Parameters.AddWithValue("@periodo", pPeriodo);
                    command.Parameters.AddWithValue("@anio", pAño);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine(pPeriodo);
                        Console.WriteLine(pAño);
                        Object[] grupoInfo = new Object[3];
                        grupoInfo[0] = reader.GetInt32(0);
                        grupoInfo[1] = reader.GetInt32(1);
                        grupoInfo[2] = reader.GetDecimal(2);
                        asignacionesList.Add(grupoInfo);
                    }

                    reader.Close();
                }
                else //lista de asignaciones de un profe
                {
                    command = new SqlCommand("SELECT a.ID_ACTIVIDAD, a.ID_PROFESOR, b.ID_SEMESTRE, a.NUM_VALOR_HORAS FROM (SACDFASIGNACIONES a LEFT JOIN SACDFSEMESTRES b ON a.ID_SEMESTRE = b.ID_SEMESTRE)"
                    + " LEFT JOIN SACDFPROFESORES c ON a.ID_PROFESOR = c.ID_PROFESOR"
                    + " WHERE b.NUM_PERIODO = " + pPeriodo.ToString() + " AND b.NUM_AÑO = " + pAño.ToString()
                    + " AND c.ID_PROFESOR = " + pIdProfe.ToString(), conn);
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
                conn.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return asignacionesList;
        }

        //Listar ids de actividades que poseen asignaciones 
        public static List<int> listarIdAsignaciones()
        {
            List<int> ids = new List<int>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT a.ID_ACTIVIDAD FROM SACDFACTIVIDADES a JOIN SACDFASIGNACIONES asi ON a.ID_ACTIVIDAD = asi.ID_ACTIVIDAD", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    ids.Add(id);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }
            cerrarConexion();
            return ids;
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
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return actividadInfo;
        }

        //Insertar actividad administrativa
        public static Boolean insertarActvAdmin(string pNombre, decimal pHoras)
        {
            Boolean isExitoso = false;

            if (crearConexion() == true)
            {
                    SqlCommand cmd = new SqlCommand("pr_SACDFADMINISTRAT_Insertar", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pNOM_ADMINITRATIV", pNombre));
                    cmd.Parameters.Add(new SqlParameter("@pCAN_HORAS", pHoras));
                    cmd.ExecuteNonQuery();
                    isExitoso = true;
                    cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return isExitoso;
        }

        //Insertar investigación
        public static Boolean insertarActvInvest(string pNombre, decimal pHoras, DateTime pFechaInicio, DateTime pFechaFin)
        {
            Boolean isExitoso = false;

            if (crearConexion() == true)
            {
                SqlCommand cmd = new SqlCommand("pr_SACDFINVESTIG_Insertar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pNOM_INVESTIG", pNombre));
                cmd.Parameters.Add(new SqlParameter("@pCAN_HORAS", pHoras));
                cmd.Parameters.Add(new SqlParameter("@pFEC_INICIO", pFechaInicio));
                cmd.Parameters.Add(new SqlParameter("@pFEC_FIN", pFechaFin));
                cmd.ExecuteNonQuery();
                isExitoso = true;
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return isExitoso;
        }

        //Insertar curso
        public static Boolean insertarActCurso(string pCodigo, string pNombre)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFCURSO VALUES(@codigo, @nombre)", conn);
                    command.Parameters.AddWithValue("@codigo", pCodigo);
                    command.Parameters.AddWithValue("@nombre", pNombre);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.insertActCurso -> Problema al insertar profesor: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }

        //Insertar grupos
        public static Boolean insertarActGrupo(int pNumGrupo, int pCantEstud, string pCodigo)
        {
            Boolean isExitoso = false;

            if (crearConexion() == true)
            {
                SqlCommand cmd = new SqlCommand("pr_SACDFGRUPOS_Insertar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pCOD_CURSO", pCodigo));
                cmd.Parameters.Add(new SqlParameter("@pNUM_GRUPO", pNumGrupo));
                cmd.Parameters.Add(new SqlParameter("@pNUM_ESTUDIANTES", pCantEstud));
                cmd.ExecuteNonQuery();
                isExitoso = true;
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return isExitoso;
        }

        /************* Ampliaciones ***************/

        //buscar ampliaciones 
        public static List<Object[]> getAmpliaciones(int pIdProfe, int pPeriodo, int pAño)
        {
            List<Object[]> ampliacionesList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM (SACDFAMPLIACION a LEFT JOIN SACDFSEMESTRES b ON a.ID_SEMESTRE = b.ID_SEMESTRE)"
                    + " LEFT JOIN SACDFPROFESORES c ON a.ID_PROFESOR = c.ID_PROFESOR"
                    + " WHERE b.NUM_PERIODO = " + pPeriodo.ToString() + " AND b.NUM_AÑO = " + pAño.ToString()
                    + " AND c.ID_PROFESOR = " + pIdProfe.ToString(), conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] grupoInfo = new Object[5];
                    grupoInfo[0] = reader.GetInt32(0);
                    grupoInfo[1] = reader.GetInt32(1);
                    grupoInfo[2] = reader.GetInt32(2);
                    grupoInfo[3] = reader.GetDecimal(3);
                    grupoInfo[4] = reader.GetBoolean(4);
                    ampliacionesList.Add(grupoInfo);
                }

                reader.Close();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return ampliacionesList;
        }


        /************* Plazas ***************/

        public static List<Object[]> getPlazasList()
        {
            List<Object[]> plazasList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT ID_PLAZA, POR_PLAZA FROM SACDFPLAZAS", conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] plazaInfo = new Object[5];
                    plazaInfo[0] = reader.GetString(0);
                    plazaInfo[1] = reader.GetDecimal(1);
                    plazasList.Add(plazaInfo);
                }

                reader.Close();
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return plazasList;
        }


        public static int[] getDistribPlazas()
        {
            int[] result = new int[2];

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT COUNT(DSC_PROPIEDAD) " +
                                                    "FROM SACDFPLAZA_PROFE " +
                                                    "WHERE DSC_PROPIEDAD = 1 " +
                                                    "UNION " +
                                                    "SELECT COUNT(DSC_PROPIEDAD) " +
                                                    "FROM SACDFPLAZA_PROFE " +
                                                    "WHERE DSC_PROPIEDAD = 0 ", conn);

                SqlDataReader reader = command.ExecuteReader();

                int index = 0;
                while (reader.Read())
                {
                    result[index] = reader.GetInt32(0);
                    index++;
                }

                reader.Close();
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return result;
        }


        public static List<Object[]> getPlazasDeProfesor(String pId)
        {
            List<Object[]> plazasList = new List<Object[]>();

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("SELECT ID_PLAZA, DSC_PROPIEDAD, HOR_ASIGNADAS FROM SACDFPLAZA_PROFE WHERE ID_PROFESOR = " + pId, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Object[] plazaInfo = new Object[3];
                    plazaInfo[0] = reader.GetString(0);
                    plazaInfo[1] = reader.GetBoolean(1);
                    plazaInfo[2] = reader.GetDecimal(2);
                    plazasList.Add(plazaInfo);
                }

                reader.Close();
                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return plazasList;
        }



        /*---------------------------------   INSERTAR  --------------------------------------*/

        /************* Usuarios ***************/

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

        /************* Asignaciones ***************/

        public static int insertAsignacion(int pIdActv, int pIdProfe, int pIdSemestre, decimal pHoras)
        {
            int result = 1;
            //Evitar que las horas se conviertan a un decimal separado por coma
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFASIGNACIONES VALUES(" + pIdActv + ", " + pIdProfe
                                                                                                 + ", " + pIdSemestre + ", "
                                                                                                 + pHoras + ")", conn);
                    command.ExecuteNonQuery();
                }

                catch(Exception e)
                {
                    result = 0;
                }

                cerrarConexion();      
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return result;
        }


        /************* Ampliaciones ***************/

        public static int insertAmpliacion(int pIdGrupo, int pIdProfe, int pIdSemestre, decimal pHoras, int pIsDoble)
        {
            int result = 1;
            //Evitar que las horas se conviertan a un decimal separado por coma
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFAMPLIACION VALUES(" + pIdGrupo + ", " + pIdProfe
                                                                                                 + ", " + pIdSemestre + ", "
                                                                                                 + pHoras + ", " + pIsDoble + ")", conn);
                    command.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    result = 0;
                }

                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return result;
        }


        /************* Plazas ***************/

        //Registrar plaza
        public static Boolean insertPlaza(string pId, string pPorcentaje)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFPLAZAS VALUES(@id, @porcentaje)", conn);
                    command.Parameters.AddWithValue("@id", pId);
                    command.Parameters.AddWithValue("@porcentaje", pPorcentaje);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.insertPlaza -> Problema al insertar plaza: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }


        /************* Profesores ***************/

        //Insertar Profesor
        public static Boolean insertProfesor(string pNombre)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFPROFESORES VALUES(@nombre)", conn);
                    command.Parameters.AddWithValue("@nombre", pNombre);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.insertProfesor -> Problema al insertar profesor: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }


        //Insertar plaza Profesor
        public static Boolean insertPlazaProfe(string pIdProfe, string pIdPlaza, string pHoras, string pIsPropiedad)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFPLAZA_PROFE(ID_PROFESOR, ID_PLAZA, HOR_ASIGNADAS, DSC_PROPIEDAD) VALUES(@idProfe, @idPlaza, @horas, @isPropiedad)", conn);
                    command.Parameters.AddWithValue("@idProfe", pIdProfe);
                    command.Parameters.AddWithValue("@idPlaza", pIdPlaza);
                    command.Parameters.AddWithValue("@horas", pHoras);
                    command.Parameters.AddWithValue("@isPropiedad", pIsPropiedad);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.insertPlazaProfe -> Problema al insertar Plaza_Profesor: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }


        /************* Semestres ***************/

        //Registrar plaza
        public static Boolean insertSemestre(string pAnio, string pPeriodo)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO SACDFSEMESTRES(NUM_AÑO, NUM_PERIODO) VALUES(@anio, @periodo)", conn);
                    command.Parameters.AddWithValue("@anio", pAnio);
                    command.Parameters.AddWithValue("@periodo", pPeriodo);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.insertSemestre -> Problema al insertar semestre: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }

        /*---------------------------------   MODIFICAR  --------------------------------------*/

        /************* Usuarios ***************/

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


        /************* Semestres ***************/

        //Editar semestre actual
        public static Boolean editar_Semestre_Actual(int pPeriodo, int pAnio)
        {
            Boolean isExitoso = false;

            if (crearConexion() == true)
            {
                SqlCommand command = new SqlCommand("UPDATE SACDFSEMESTRES SET DSC_ACTUAL = NULL", conn);
                command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand("UPDATE SACDFSEMESTRES SET DSC_ACTUAL = 1 WHERE NUM_AÑO = @anio AND NUM_PERIODO = @periodo", conn);
                command2.Parameters.AddWithValue("@anio", pAnio);
                command2.Parameters.AddWithValue("@periodo", pPeriodo);
                command2.ExecuteNonQuery();
                isExitoso = true;
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isExitoso = false;
            }
            conn.Close();
            return isExitoso;
        }


        /************* Plazas ***************/

        public static Boolean editarPlaza(string pId, string pPorcentaje)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE SACDFPLAZAS SET POR_PLAZA = @porcentaje WHERE ID_PLAZA = @id", conn);
                    command.Parameters.AddWithValue("@porcentaje", pPorcentaje);
                    command.Parameters.AddWithValue("@id", pId);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.editarPlaza -> Problema al editar plaza: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }


        /************* Profesor ***************/

        public static Boolean editarProfesor(string pId, string pNombre)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE SACDFPROFESORES SET NOM_PROFESOR = @nombre WHERE ID_PROFESOR = @id", conn);
                    command.Parameters.AddWithValue("@id", pId);
                    command.Parameters.AddWithValue("@nombre", pNombre);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.editarProfesor -> Problema al editar profesor: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }

        //Editar nombre del curso

        public static Boolean editarCurso(string pCodigo, string pNombre)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE SACDFCURSO SET NOM_CURSO = @nombre WHERE COD_CURSO = @codigo", conn);
                    command.Parameters.AddWithValue("@codigo", pCodigo);
                    command.Parameters.AddWithValue("@nombre", pNombre);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.editarCurso -> Problema al editar el nombre del curso: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            cerrarConexion();
            return isValido;
        }

        // Editar Investigaciones
        
        public static Boolean editarInvestigacion(int pIdInvest, string pNombre, decimal pHoras, DateTime pFechaInicio, DateTime pFechaFin) 
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE SACDFINVESTIG SET CAN_HORAS = @horas, FEC_INICIO = @inicio, FEC_FIN = @fin, NOM_INVESTIG = @nombre WHERE ID_INVESTIGACION = @id", conn);
                    command.Parameters.AddWithValue("@id", pIdInvest);
                    command.Parameters.AddWithValue("@nombre", pNombre);
                    command.Parameters.AddWithValue("@horas", pHoras);
                    command.Parameters.AddWithValue("@inicio", pFechaInicio);
                    command.Parameters.AddWithValue("@fin", pFechaFin);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.editarInvestigacion -> Problema al editar la investigación: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }

        //Editar actividades administrativas
        public static Boolean editarAdmin(int pIdAdmin, string pNombre, decimal pHoras)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("UPDATE SACDFADMINISTRAT SET CAN_HORAS = @horas, NOM_ADMINITRATIV = @nombre WHERE ID_ADMINISTRATIV = @id", conn);
                    command.Parameters.AddWithValue("@id", pIdAdmin);
                    command.Parameters.AddWithValue("@nombre", pNombre);
                    command.Parameters.AddWithValue("@horas", pHoras);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.editarAdmin -> Problema al editar la actividad administrativa: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }


        /*---------------------------------   ELIMINAR  --------------------------------------*/

        /************* Asignaciones ***************/
        public static int borrarAsignacion(int pIdActv, int pIdProfe, int pIdSemestre)
        {
            int result = 1;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM SACDFASIGNACIONES" +
                                                        " WHERE ID_ACTIVIDAD = " + pIdActv + 
                                                        " AND ID_PROFESOR = " + pIdProfe +
                                                        " AND ID_SEMESTRE = " + pIdSemestre, conn);
                    command.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    result = 0;
                }

                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return result;
        }


        /************* Ampliaciones ***************/
        public static int borrarAmpliacion(int pIdGrupo, int pIdProfe, int pIdSemestre)
        {
            int result = 1;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM SACDFAMPLIACION" +
                                                        " WHERE ID_GRUPO = " + pIdGrupo +
                                                        " AND ID_PROFESOR = " + pIdProfe +
                                                        " AND ID_SEMESTRE = " + pIdSemestre, conn);
                    command.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    result = 0;
                }

                cerrarConexion();
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
            }

            return result;
        }


        /************* Plazas ***************/

        public static Boolean eliminarPlaza(string pId)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM SACDFPLAZAS WHERE ID_PLAZA = @id", conn);
                    command.Parameters.AddWithValue("@id", pId);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarPlaza -> Problema al eliminar plaza: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }


        /************* Profesores ***************/

        public static Boolean eliminarProfe(string pId)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM SACDFPROFESORES WHERE ID_PROFESOR = @id", conn);
                    command.Parameters.AddWithValue("@id", pId);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarProfe -> Problema al eliminar profesor: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }


        public static Boolean eliminarPlazasProfe(string pProfeId)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM SACDFPLAZA_PROFE WHERE ID_PROFESOR = @id", conn);
                    command.Parameters.AddWithValue("@id", pProfeId);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarPlazasProfe -> Problema al eliminar plazas de un profesor: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }

        //Cursos
        public static Boolean eliminarCurso(string pCodigo)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("" +
                        "DELETE FROM SACDFTIPO_CURSO WHERE COD_CURSO = @codigo " +
                        "DELETE a FROM SACDFACTIVIDADES a " +
                        "INNER JOIN SACDFGRUPOS g ON a.ID_ACTIVIDAD = g.ID_GRUPO Where g.COD_CURSO = @codigo  " +
                        "DELETE g FROM SACDFGRUPOS g INNER JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO " +
                        "Where g.COD_CURSO = @codigo " +
                        "DELETE FROM SACDFCURSO WHERE COD_CURSO = @codigo", conn);
                    command.Parameters.AddWithValue("@codigo", pCodigo);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarCurso -> Problema al eliminar un curso: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }

        //Eliminar Curso con asignaciones
        public static Boolean eliminarCursoAsign(string pCodigo, int pIdActividad)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("" +
                        "DELETE FROM SACDFASIGNACIONES WHERE ID_ACTIVIDAD = @id " +
                        "DELETE FROM SACDFTIPO_CURSO WHERE COD_CURSO = @codigo " +
                        "DELETE a FROM SACDFACTIVIDADES a " +
                        "INNER JOIN SACDFGRUPOS g ON a.ID_ACTIVIDAD = g.ID_GRUPO Where g.COD_CURSO = @codigo  " +
                        "DELETE g FROM SACDFGRUPOS g INNER JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO " +
                        "Where g.COD_CURSO = @codigo " +
                        "DELETE FROM SACDFCURSO WHERE COD_CURSO = @codigo", conn);
                    command.Parameters.AddWithValue("@id", pIdActividad);
                    command.Parameters.AddWithValue("@codigo", pCodigo);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarCursoAsign -> Problema al eliminar un curso: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }

        //Investigación

        public static Boolean eliminarInvest(int pIdInvestigacion)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("" +
                        "DELETE FROM SACDFASIGNACIONES WHERE ID_ACTIVIDAD = @id " +
                        "DELETE a FROM SACDFACTIVIDADES a " +
                        "INNER JOIN SACDFINVESTIG i ON a.ID_ACTIVIDAD = i.ID_INVESTIGACION " +
                        "WHERE i.ID_INVESTIGACION = @id " +
                        "DELETE FROM SACDFINVESTIG WHERE ID_INVESTIGACION = @id", conn);
                    command.Parameters.AddWithValue("@id", pIdInvestigacion);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarInvest -> Problema al eliminar una investigación: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }

        // Administrativa

        public static Boolean eliminarAdmin(int pIdAdministrativa)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("" +
                        "DELETE FROM SACDFASIGNACIONES WHERE ID_ACTIVIDAD = @id " +
                        "DELETE a FROM SACDFACTIVIDADES a " +
                        "INNER JOIN SACDFADMINISTRAT ad ON a.ID_ACTIVIDAD = ad.ID_ADMINISTRATIV " +
                        "WHERE ad.ID_ADMINISTRATIV = @id " +
                        "DELETE FROM SACDFADMINISTRAT WHERE ID_ADMINISTRATIV = @id", conn);
                    command.Parameters.AddWithValue("@id", pIdAdministrativa);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarAdmin -> Problema al eliminar una actividad administrativa: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }

        // Grupos
        public static Boolean eliminarGrupos(string pCodigo, string pConsulta)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("" +
                        "DELETE a FROM SACDFACTIVIDADES a " +
                        "INNER JOIN SACDFGRUPOS g ON a.ID_ACTIVIDAD = g.ID_GRUPO Where g.COD_CURSO = @codigo AND ( " + pConsulta + " ) " +
                        "DELETE g FROM SACDFGRUPOS g INNER JOIN SACDFCURSO c ON g.COD_CURSO = c.COD_CURSO " +
                        "Where g.COD_CURSO = @codigo AND ( " + pConsulta + " ) ", conn);
                    command.Parameters.AddWithValue("@codigo", pCodigo);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarGrupos -> Problema al eliminar los grupos: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }
            cerrarConexion();
            return isValido;
        }


        /************* Semestres ***************/
        public static Boolean eliminarSemestre(string pId)
        {
            Boolean isValido = false;

            if (crearConexion() == true)
            {
                try
                {
                    SqlCommand command = new SqlCommand("DELETE FROM SACDFSEMESTRES WHERE ID_SEMESTRE = @id", conn);
                    command.Parameters.AddWithValue("@id", pId);
                    command.ExecuteNonQuery();
                    isValido = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("DatosManager.eliminarSemestre -> Problema al eliminar semestre: " + e.ToString());
                    isValido = false;
                }
            }

            else
            {
                Console.WriteLine("No se ha podido establecer conexión con la base de datos");
                isValido = false;
            }

            return isValido;
        }
    }
}
