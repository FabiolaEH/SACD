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
        public static void asignarActiv(Semestre pSemestre, Profesor pProfesor, Actividad pActividad)
        {

        }

        //asignar ampliación a un profesor
        public static void asignarAmpl(bool pIsDoble, Semestre pSemestre, Profesor pProfesor, Actividad pActividad)
        {

        }

        public static List<Asignacion> getAsignaciones(int pIdProfesor, int pPeriodo, int pAño)
        {
            List<Object[]> asignListObject = new List<Object[]>();
            List<Asignacion> asignList = new List<Asignacion>();
            Asignacion asignacion;
            Actividad actividad;

            asignListObject = DatosManager.getAsignaciones(pIdProfesor, pPeriodo, pAño);

            foreach (Object[] obj in asignListObject)
            {
                actividad = ActividadesManager.buscar((int)obj[0]);

                asignacion = new Asignacion((decimal)obj[3], actividad, new Semestre(0,0,0)); //PONER BIEN EL SEMESTRE
                asignList.Add(asignacion);
            }

            return asignList;
        }

        public static List<Ampliacion> getAmpliaciones(int pIdProfesor, int pPeriodo, int pAño)
        {
            List<Object[]> ampliListObject = new List<Object[]>();
            List<Ampliacion> ampliList = new List<Ampliacion>();
            Ampliacion ampliacion;
            Actividad grupo;

            ampliListObject = DatosManager.getAmpliaciones(pIdProfesor, pPeriodo, pAño);

            foreach (Object[] obj in ampliListObject)
            {
                grupo = ActividadesManager.buscar((int)obj[0]);

                ampliacion = new Ampliacion((decimal)obj[3], grupo, new Semestre(0, 0, 0), (bool)obj[4]); //PONER BIEN EL SEMESTRE
                ampliList.Add(ampliacion);
            }

            return ampliList;
        }
    }
}
