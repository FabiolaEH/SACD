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

        //calcular valor en horas de un curso
        public static float calcValorCurso(Curso pCurso, string pParametro) //parámetro del profesor= nuevo, existente...
        {
            return 0;
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
                decimal valHoras = DatosManager.getHorasCurso((string)obj[1]);
                grupo = new Grupo((int)obj[0],"cur", valHoras, (int)obj[3], 0, new Curso((string)obj[1], (string)obj[2]));
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
