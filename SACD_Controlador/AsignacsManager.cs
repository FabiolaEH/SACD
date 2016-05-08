using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACD_Modelo;
using SACD_AccesoDatos;

namespace SACD_Controlador
{
    public static class AsignacsManager
    {
        //asignar actividad a un profesor
        public static int asignarActiv(int pIdActividad, int pIdProfesor, int pIdSemestre, decimal pValHoras)
        {
            int result = DatosManager.insertAsignacion(pIdActividad, pIdProfesor, pIdSemestre, pValHoras);
            return result;
        }


        //asignar ampliación a un profesor
        public static int asignarAmpl(int pIdGrupo, int pIdProfe, int pIdSemestre, decimal pValHoras, int pIsDoble)
        {
            int result = DatosManager.insertAmpliacion(pIdGrupo, pIdProfe, pIdSemestre, pValHoras, pIsDoble);
            return result;
        }


        //Obtener lista de asignaciones de un profesor
        public static List<Asignacion> getAsignaciones(int pIdProfesor, int idSemestre, int pPeriodo, int pAño)
        {
            List<Object[]> asignListObject = new List<Object[]>();
            List<Asignacion> asignList = new List<Asignacion>();
            Asignacion asignacion;
            Actividad actividad;

            asignListObject = DatosManager.getAsignaciones(pIdProfesor, pPeriodo, pAño);

            foreach (Object[] obj in asignListObject)
            {
                actividad = ActividadesManager.buscar((int)obj[0]);

                asignacion = new Asignacion((decimal)obj[3], actividad, new Semestre(idSemestre, pAño, pPeriodo)); 
                asignList.Add(asignacion);
            }

            return asignList;
        }


        //Obtener lista de ampliaciones de un profesor
        public static List<Ampliacion> getAmpliaciones(int pIdProfesor, int idSemestre, int pPeriodo, int pAño)
        {
            List<Object[]> ampliListObject = new List<Object[]>();
            List<Ampliacion> ampliList = new List<Ampliacion>();
            Ampliacion ampliacion;
            Actividad grupo;

            ampliListObject = DatosManager.getAmpliaciones(pIdProfesor, pPeriodo, pAño);

            foreach (Object[] obj in ampliListObject)
            {
                grupo = ActividadesManager.buscar((int)obj[0]);

                ampliacion = new Ampliacion((decimal)obj[3], grupo, new Semestre(idSemestre, pAño, pPeriodo), (bool)obj[4]);
                ampliList.Add(ampliacion);
            }

            return ampliList;
        }


        //Borrar una asignación de la BD
        public static void borrarAsignacion(int pIdActividad, int pIdProfesor, int pIdSemestre)
        {
            DatosManager.borrarAsignacion(pIdActividad, pIdProfesor, pIdSemestre);
        }


        //Borrar una ampliación de la BD
        public static void borrarAmpliacion(int pIdGrupo, int pIdProfesor, int pIdSemestre)
        {
            DatosManager.borrarAmpliacion(pIdGrupo, pIdProfesor, pIdSemestre);
        }
    }
}
