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
            ActvAdmin nueva;
        }

        //eliminar actividad
        public static void eliminar(int pId)
        {

        }

        //editar actividad
        public static void editar(int pId, Actividad pNuevaActv)
        {

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
        public static Dictionary<string, decimal[]> getTabl2Calculos()
        {
            /*Estructura

            tabla = {1 a 15: [valTeorico[2a4Horas, 5oMas], valPractica, valTeorPrac],
                     1 a 15: [valTeorico[2a4Horas, 5oMas], valPractica, valTeorPrac],
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

        //calcular valor en horas de un curso
        public static decimal calcValorCurso(int pIdGrupo, string pCodCurso, string pModalidad, int cantEstud, 
                                             decimal horasPresen) //modalidad= nuevo - exist - ant - paral1 - paral2
        {
            Dictionary<string, decimal[]> tabla1Calcs = getTabl1Calculos();
            List<Object[]>  tiposCur = DatosManager.getTipoCurso(pCodCurso);
            List<TipoCurso> tiposList = new List<TipoCurso>();
            TipoCurso tipoC;
            decimal valHoras = 0;

            //calc valor de tabla 1 para cada tipo
            foreach (Object[] obj in tiposCur)
            {
                tipoC = new TipoCurso((string)obj[0], (decimal)obj[1]);
                decimal[] val = tabla1Calcs[pModalidad]; 

                if(tipoC.getTipo().Equals("teor", StringComparison.InvariantCultureIgnoreCase))
                    valHoras += tipoC.getHoras() * val[0];

                else //prac
                    valHoras += tipoC.getHoras() * val[1];

                tiposList.Add(tipoC);
            }

            //calc valor de tabla 2 para cada tipo
            if (tiposCur.Count > 1) // teopract
            {
            }

            else // es teor ó prac
            {
            }

            //dos decimales
            return valHoras;//decimal.Truncate(valHoras * 10) / 10;
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
                ActvAdmin grupo = new ActvAdmin(1, "ADMI", 0, "asjk");
                return grupo;
            }
        }
    }
}
