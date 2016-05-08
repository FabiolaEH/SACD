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
        public static Boolean crear(String pNombre)
        {
            Boolean isValido = DatosManager.insertProfesor(pNombre);
            return isValido;
        }

        //eliminar profesor
        public static Boolean eliminar(int pId)
        {
            Boolean isValido = DatosManager.eliminarProfe(pId.ToString());
            return isValido;
        }

        //editar profesor
        public static void editar(int pId, Profesor pNuevoProf)
        {

        }

        //obtener último profesor insertado
        public static int getUltimoProfesor()
        {
            Object[] ultimo = new Object[1];
            ultimo = DatosManager.getUltimoProfe();

            return (int)ultimo[0];
        }

        //buscar profesor
        public static Profesor buscar(int pId)
        {
            Object[] profeInfo = new Object[3];
            profeInfo = DatosManager.getProfeInfo(pId);

            Profesor profesor = new Profesor((int) profeInfo[0], (string) profeInfo[1], (decimal) profeInfo[2]);

            return profesor;
        }

        //buscar profesor por nombre
        public static Profesor buscarPorNombre(String pNombre)
        {
            Object[] profeInfo = new Object[3];
            profeInfo = DatosManager.getProfeInfoPorNombre(pNombre);

            Profesor profesor = new Profesor((int)profeInfo[0], (string)profeInfo[1], (decimal)profeInfo[2]);

            return profesor;
        }

        //obtener lista de profesores registrados
        public static List<Profesor> listar()
        {
            List<Object[]> profesListObject = new List<Object[]>();
            List<Profesor> profesList = new List<Profesor>();
            Profesor profe;

            profesListObject = DatosManager.getProfesoresList();
            
            foreach (Object[] obj in profesListObject)
            {
                profe = new Profesor((int)obj[0], (string)obj[1], (decimal)obj[2]);
                profesList.Add(profe);
            }

            return profesList;
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
        
        //insertar relación Plaza - Profesor
        public static Boolean insertPlazaProfe(string pIdProfe, string pNumeroPlaza, string pPorcentaje, bool pIsPropiedad)
        {
            String propiedad = "";
            if (pIsPropiedad)
                propiedad = "1";
            else
                propiedad = "0";

            Boolean isValido = DatosManager.insertPlazaProfe(pIdProfe, pNumeroPlaza, pPorcentaje, propiedad);
            return isValido;
        }
    }
}
