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

                asignacion = new Asignacion((decimal)obj[3], actividad);
                asignList.Add(asignacion);
            }

            return asignList;
        }

        public static void getAmpliaciones()
        {

        }
    }
}
