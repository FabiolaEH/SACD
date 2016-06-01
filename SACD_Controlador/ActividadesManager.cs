using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACD_Modelo;
using SACD_AccesoDatos;

namespace SACD_Controlador
{
    public class ActividadesManager
    {
        //crear actividad
        public static void crear(string pTipo) //cur - invest - admin
        {
            
        }

        //Crear actividades administrativas
        public static Boolean crearActAdministrativa(string pNombre, decimal pHoras)
        {
            ActvAdmin admin = new ActvAdmin(0, "admin", pHoras, pNombre);
            Boolean isExitoso = DatosManager.insertarActvAdmin(admin.getNombre(), admin.getHoras());
            return isExitoso;
        }

        //Crear investigación
        public static Boolean crearActInvestigacion(string pNombre, decimal pHoras, DateTime pFechaInicio, DateTime pFechaFin) {
            Investigacion invest = new Investigacion(0, "invest", pHoras, pNombre, pFechaInicio, pFechaFin);
            Boolean isExitoso = DatosManager.insertarActvInvest(invest.getNombre(), invest.getHoras(), invest.getInicio(), invest.getFin());
            return isExitoso;
        }
        
        //Crear curso
        public static Boolean crearActCurso(string pNombre, string pCodigo)
        {
            Curso curso = new Curso(pCodigo, pNombre, 0);
            Boolean isExitoso = DatosManager.insertarActCurso(curso.getCodigo(), curso.getNombre());
            return isExitoso;
        }

        public static Boolean crearTipoCursos(string pCodigo,string pTipo, string pHoras){
            Boolean isExitoso= DatosManager.crearTipoCurso(pCodigo, pTipo, Decimal.Parse(pHoras));
            return isExitoso;
        }

        //Crear grupos
        public static Boolean crearActGrupos(List<Grupo> pGrupos)
        {
            Boolean isExitoso = false;
            for (int i = 0; i < pGrupos.Count; i++)
            {
                isExitoso = DatosManager.insertarActGrupo(pGrupos[i].getNumero(), pGrupos[i].getCantEstudiantes(), pGrupos[i].getCurso().getCodigo());
            }
            return isExitoso;
        }
        
        //eliminar curso
        public static Boolean eliminarCurso(string pCodigo)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.eliminarCurso(pCodigo);
            return isExitoso;
        }

        //Eliminar curso que posee asignación
        public static Boolean eliminarCursoAsig(string pCodigo, int pIdActividad)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.eliminarCursoAsign(pCodigo, pIdActividad);
            return isExitoso;
        }

        //eliminar grupos 
        public static Boolean eliminarGrupos(string pCodigo, string pConsulta)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.eliminarGrupos(pCodigo, pConsulta);
            return isExitoso;
        }

        //eliminar investigación
        public static Boolean eliminarInvest(int pId)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.eliminarInvest(pId);
            return isExitoso;
        }

        //Eliminar actividad administrativa
        public static Boolean eliminarAdmin(int pId)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.eliminarAdmin(pId);
            return isExitoso;
        }
        
        //editar curso
        public static Boolean editarCurso(string pCodigo, string pNombre)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.editarCurso(pCodigo, pNombre);
            return isExitoso;
        }

        //Listar horas teóricas
        public static decimal listarHorasCurso(string pCodigo, string pTipo)
        {
            return DatosManager.listarHorasCurso(pCodigo, pTipo);
        }

        //Editar horas tipo curso
        public static void editarHorasTipoCurso(string pCodigo, string pTipo, string pHoras)
        {
            DatosManager.editarHorasTipoCurso(pCodigo, pTipo, Decimal.Parse(pHoras));
        }

        //editar investigación
        public static Boolean editarInvestigacion(int pIdInvest, string pNombre, decimal pHoras, DateTime pFechaInicio, DateTime pFechaFin)
        {
            Boolean isExitoso = false;
            isExitoso = DatosManager.editarInvestigacion(pIdInvest, pNombre, pHoras, pFechaInicio, pFechaFin);
            return isExitoso;
        }

        //editar adminstrativa
        public static Boolean editarAdmin(int pIdAdmin, string pNombre, decimal pHoras){
            Boolean isExitoso = false;
            isExitoso = DatosManager.editarAdmin(pIdAdmin, pNombre, pHoras);
            return isExitoso;
        }

        //Listar id de actividades que poseen asignaciones
        public static List<int> listarIdAsignaciones()
        {
            return DatosManager.listarIdAsignaciones();
        }

        //Obtener tabla 1 de cálculos
        public static Dictionary<string, decimal[]> getTabl1Calculos()
        {
            /*Estructura

            tabla = {Nuevo: [valTeoria, valPractica],
                     Existente: [valTeoria, valPractica],
                     Imp. ant: [valTeoria, valPractica],
                     ...}

            */

            Dictionary<string, decimal[]> tabla = new Dictionary<string, decimal[]>();

            decimal[] valsNuevo = new decimal[2];
            valsNuevo[0] = 2.5m;
            valsNuevo[1] = 2;
            tabla.Add("nuevo", valsNuevo); //nuevo - exist - ant - paral1 - paral2

            decimal[] valsExist = new decimal[2];
            valsExist[0] = 2;
            valsExist[1] = 1.75m;
            tabla.Add("exist", valsExist);

            decimal[] valsAnt = new decimal[2];
            valsAnt[0] = 1.75m;
            valsAnt[1] = 1.5m;
            tabla.Add("ant", valsAnt);

            decimal[] valsParal1 = new decimal[2];
            valsParal1[0] = 1.5m;
            valsParal1[1] = 1.25m;
            tabla.Add("paral1", valsParal1);

            decimal[] valsParal2 = new decimal[2];
            valsParal2[0] = 1.25m;
            valsParal2[1] = 1;
            tabla.Add("paral2", valsParal2);

            return tabla;
        }

        //Obtener tabla 2 de cálculos
        public static Dictionary<string, List<decimal[]>> getTabl2Calculos()
        {
            /*Estructura

            tabla = {1 a 15: [valTeorico[2a4Horas, 5oMas], valPractica, valTeorPrac],
                     16 a 25: [valTeorico[2a4Horas, 5oMas], valPractica, valTeorPrac],
                     26 a 35: [valTeorico[2a4Horas, 5oMas], valPractica, valTeorPrac],
                     ...}

            */

            Dictionary<string, List<decimal[]>> tabla = new Dictionary<string, List<decimal[]>>();

            List<decimal[]> vals1_15 = new List<decimal[]>();
            decimal[] valTeorico1 = new decimal[2];
            valTeorico1[0] = 2;
            valTeorico1[1] = 2.75m;
            decimal[] valPract1 = new decimal[1] { 3 };
            decimal[] valTeorprac1 = new decimal[1] { 2.5m };
            vals1_15.Add(valTeorico1);
            vals1_15.Add(valPract1);
            vals1_15.Add(valTeorprac1);
            tabla.Add("1_15", vals1_15);

            List<decimal[]> vals16_25 = new List<decimal[]>();
            decimal[] valTeorico2 = new decimal[2];
            valTeorico2[0] = 3;
            valTeorico2[1] = 3.75m;
            decimal[] valPract2 = new decimal[1] { 4.5m };
            decimal[] valTeorprac2 = new decimal[1] { 3.75m };
            vals16_25.Add(valTeorico2);
            vals16_25.Add(valPract2);
            vals16_25.Add(valTeorprac2);
            tabla.Add("16_25", vals16_25);

            List<decimal[]> vals26_35 = new List<decimal[]>();
            decimal[] valTeorico3 = new decimal[2];
            valTeorico3[0] = 4;
            valTeorico3[1] = 4.75m;
            decimal[] valPract3 = new decimal[1] { 6 };
            decimal[] valTeorprac3 = new decimal[1] { 5.25m };
            vals26_35.Add(valTeorico3);
            vals26_35.Add(valPract3);
            vals26_35.Add(valTeorprac3);
            tabla.Add("26_35", vals26_35);

            List<decimal[]> vals36_45 = new List<decimal[]>();
            decimal[] valTeorico4 = new decimal[2];
            valTeorico4[0] = 5;
            valTeorico4[1] = 5.75m;
            decimal[] valPract4 = new decimal[1] { 0 };
            decimal[] valTeorprac4 = new decimal[1] { 6.5m };
            vals36_45.Add(valTeorico4);
            vals36_45.Add(valPract4);
            vals36_45.Add(valTeorprac4);
            tabla.Add("36_45", vals36_45);

            List<decimal[]> vals46_ = new List<decimal[]>();
            decimal[] valTeorico5 = new decimal[2];
            valTeorico5[0] = 6;
            valTeorico5[1] = 6.75m;
            decimal[] valPract5 = new decimal[1] { 0 };
            decimal[] valTeorprac5 = new decimal[1] { 0 };
            vals46_.Add(valTeorico5);
            vals46_.Add(valPract5);
            vals46_.Add(valTeorprac5);
            tabla.Add("46_", vals46_);

            return tabla;
        }

        //calcular valor en horas de un curso
        public static decimal calcValorCurso(int pIdGrupo, string pCodCurso, string pModalidad, 
                                             int pCantEstud) //modalidad= nuevo - exist - ant - paral1 - paral2
        {
            Dictionary <string, decimal[]> tabla1Calcs = getTabl1Calculos();
            Dictionary<string, List<decimal[]>> tabla2Calcs = getTabl2Calculos();
            List<Object[]>  tiposCur = DatosManager.getTipoCurso(pCodCurso);
            List<TipoCurso> tiposList = new List<TipoCurso>();
            TipoCurso tipoC;
            decimal valHoras = 0;

            //calc valor de tabla 1 para cada tipo
            foreach (Object[] obj in tiposCur)
            {
                tipoC = new TipoCurso((string)obj[0], (decimal)obj[1]);
                decimal[] filaTb1 = tabla1Calcs[pModalidad]; 

                if(tipoC.getTipo().Equals("teor", StringComparison.InvariantCultureIgnoreCase))
                    valHoras += tipoC.getHoras() * filaTb1[0];

                else //prac
                    valHoras += tipoC.getHoras() * filaTb1[1];

                tiposList.Add(tipoC);
            }

            //calc valor de tabla 2 para cada tipo
            //obtener rango de estudiantes
            string rango;
            if (pCantEstud >= 16 && pCantEstud <= 15)
                rango = "1_15";

            else if (pCantEstud >= 1 && pCantEstud <= 25)
                rango = "16_25";

            else if (pCantEstud >= 26 && pCantEstud <= 35)
                rango = "26_35";

            else if (pCantEstud >= 36 && pCantEstud <= 45)
                rango = "36_45";

            else
                rango = "46_";

            List <decimal[]> filaTb2 = tabla2Calcs[rango];

            //obtener columna tipo curso
            decimal[] val;
            if (tiposCur.Count > 1) // teopract
            {
                val = filaTb2[2];
                valHoras += val[0];
            }

            else // es teor ó prac
            {
                tipoC = tiposList.First();
                if (tipoC.getTipo().Equals("teor", StringComparison.InvariantCultureIgnoreCase))
                {
                    val = filaTb2[0];
                    if(tipoC.getHoras() >= 2 && tipoC.getHoras() <= 4)
                        valHoras += val[0];

                    else
                        valHoras += val[1];
                }

                else //prac
                {
                    val = filaTb2[1];
                    valHoras += val[0];
                }
            }

            //dos decimales
            valHoras = Math.Truncate(100 * valHoras) / 100;
            return valHoras;
        }

        //calcular valor en horas de un curso en ampliación
        public static float calcValorCurso_Ampl()
        {
            return 0;
        }

        //obtener lista de investigaciones registradas
        public static List<Investigacion> listarInvestigs()
        {
            List<Object[]> investigsObj = DatosManager.getInvestigList();
            List<Investigacion> investigsList = new List<Investigacion>();
            Investigacion investig;

            foreach (Object[] obj in investigsObj)
            {
                investig = new Investigacion((int) obj[0], "invest", (decimal) obj[1], 
                           (string) obj[4], (DateTime) obj[2], (DateTime)obj[3]);
                investigsList.Add(investig);
            }

            return investigsList;

        }

        //obtener lista de actv. administrativas registradas
        public static List<ActvAdmin> listarAdministvs()
        {
            List<Object[]> administvsObj = DatosManager.getAdministvsList();
            List<ActvAdmin> administvsList = new List<ActvAdmin>();
            ActvAdmin actvAdmin;

            foreach (Object[] obj in administvsObj)
            {
                actvAdmin = new ActvAdmin((int)obj[0], "admin", (decimal)obj[2], (string)obj[1]);
                administvsList.Add(actvAdmin);
            }

            return administvsList;

        }


        //obtener lista de cursos registradas
        public static List<Curso> listarCursos()
        {

            List<Object[]> cursosObj = DatosManager.getCursosList();
            List<Curso> cursosList = new List<Curso>();
            Curso curso;

            foreach (Object[] obj in cursosObj)
            {
                curso = new Curso((string)obj[0], (string)obj[1], 0);
                cursosList.Add(curso);
            }

            return cursosList;

        }
        //obtener lista de grupos registrados
        public static List<Grupo> listarGrupos() 
        {
            List<Object[]> gruposObj = DatosManager.getGruposList();
            List<Grupo> gruposList = new List<Grupo>();
            Grupo grupo;

            foreach (Object[] obj in gruposObj)
            {
                decimal horasPresen = DatosManager.getHorasCurso((string)obj[1]);
                grupo = new Grupo((int)obj[0],"cur", horasPresen, (int)obj[3], (int)obj[4], 
                                  new Curso((string)obj[1], (string)obj[2], horasPresen));
                gruposList.Add(grupo);
            }

            return gruposList;
        }

        //obtener lista de grupos registrados
        public static Actividad buscar(int pIdActividad)
        {
            Object[] actividadInfo = new Object[2];
            actividadInfo = DatosManager.getActividadInfo(pIdActividad);

            if((string)actividadInfo[1] == "INVE")
            {
                Object[] investInfo = DatosManager.getInvestigInfo(pIdActividad);
                Investigacion invest = new Investigacion(pIdActividad, "INVE", (decimal)investInfo[1], 
                    (String)investInfo[4], (DateTime)investInfo[2], (DateTime)investInfo[3]);
                return invest;

            }
            else if((string)actividadInfo[1] == "ADMI")
            {
                Object[] admiInfo = DatosManager.getAdministvsInfo(pIdActividad);
                ActvAdmin admin = new ActvAdmin(pIdActividad, "ADMI", (decimal)admiInfo[2], (String)admiInfo[1]);
                return admin;
            }
            else
            {
                Object[] grupoInfo = DatosManager.getGrupoInfo(pIdActividad);

                Grupo grupo = new Grupo(pIdActividad, "GRUP", 0, (int)grupoInfo[2], (int)grupoInfo[3], 
                    new Curso((String)grupoInfo[0], (String)grupoInfo[1], 0));
                return grupo;
            }
        }

        //Obtener lista de grupos por código de curso
        public static List<Grupo> getGrupoInfoCodigo(string pCodigo)
        {
            List<Object[]> gruposObj = DatosManager.getGrupoInfoCodigo(pCodigo);
            Console.WriteLine(gruposObj);
            List<Grupo> gruposList = new List<Grupo>();
            Grupo grupo;

            foreach (Object[] obj in gruposObj)
            {
                grupo = new Grupo((int)obj[0], "cur", -1, (int)obj[3], (int)obj[4], new Curso(obj[1].ToString(), obj[2].ToString(), -1));
                gruposList.Add(grupo);
            }

            return gruposList;
        }
    }
}
