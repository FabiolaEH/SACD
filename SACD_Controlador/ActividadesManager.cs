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
        public static List<Investigacion> listarInvestig()
        {
            List<Object[]> investigsObj = DatosManager.getInvestigList();
            List<Investigacion> investigsList = new List<Investigacion>();
            Investigacion investig;

            foreach (Object[] obj in investigsObj)
            {
                investig = new Investigacion((int) obj[0], "invest", (decimal) obj[2], 
                           (string) obj[1], (DateTime) obj[3], (DateTime)obj[4]);
                investigsList.Add(investig);
            }

            return investigsList;

        }
        
    }
}
