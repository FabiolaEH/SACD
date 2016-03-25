using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACD_Modelo;
using SACD_AccesoDatos;


namespace SACD_Controlador
{
    public static class ProfesManager
    {
        //crear profesor
        public static void crear()
        {

        }

        //eliminar profesor
        public static void eliminar(int pId)
        {

        }

        //editar profesor
        public static void editar(int pId, Profesor pNuevoProf)
        {

        }

        //buscar profesor
        public static Profesor buscar(int pId)
        {
            Object[] profeInfo = new Object[3];
            profeInfo = DatosManager.getProfeInfo(pId);

            Profesor profesor = new Profesor((int) profeInfo[0], (string) profeInfo[1], (decimal) profeInfo[2]);

            return profesor;
        }

        //obtener lista de profesores registrados
        public static List<Profesor> listar()
        {
            return null;
        }

        //calcular horas mín. laborales
        public static float calcHorasMin(Profesor pProfesor)
        {
            return 0;
        }

        //calcular total horas asignadas
        public static float calcHorasAsig(Profesor pProfesor)
        {
            //recorrer la lista de asignaciones
            return 0;
        }
        
    }
}
