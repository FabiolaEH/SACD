using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACD_Modelo;
using SACD_AccesoDatos;

namespace SACD_Controlador
{
    public static class SemestresManager
    {
        //crear semestre
        public static void crear()
        {

        }

        //eliminar semestre
        public static void eliminar(int pId)
        {

        }

        //editar semestre
        public static void editar(int pId, Profesor pNuevoProf)
        {

        }

        //Editar semestre actual
        public static Boolean editar_actual(int semestre, int anio)
        {
            Boolean isExitoso = DatosManager.editar_Semestre_Actual(semestre, anio);
            return isExitoso;
        }

        //Obtener semestre global
        public static List<int> getSemestreGlobal()
        {
            List<int> datosGlobales = DatosManager.get_Semestre_Global();
            return datosGlobales;
        }

        //obtener lista de semestres registrados
        public static List<Semestre> listar()
        {
            List<Object[]> semestresListObject = new List<Object[]>();
            List<Semestre> semestresList = new List<Semestre>();
            Semestre semestre;

            semestresListObject = DatosManager.getSemestresList();

            foreach (Object[] obj in semestresListObject)
            {
                semestre = new Semestre((int)obj[0], (int)obj[1], (int)obj[2]);
                semestresList.Add(semestre);
            }

            return semestresList;
        }
    }
}
