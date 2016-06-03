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
        public static Boolean editar(int pId, String pNombre)
        {
            Boolean isValido = DatosManager.editarProfesor(pId.ToString(), pNombre);
            return isValido;
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

            Profesor profesor = new Profesor((int) profeInfo[0], (string) profeInfo[1]);

            return profesor;
        }

        //buscar profesor por nombre
        public static Profesor buscarPorNombre(String pNombre)
        {
            Object[] profeInfo = new Object[3];
            profeInfo = DatosManager.getProfeInfoPorNombre(pNombre);

            Profesor profesor = new Profesor((int)profeInfo[0], (string)profeInfo[1]);

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
                profe = new Profesor((int)obj[0], (string)obj[1]);
                profesList.Add(profe);
            }

            return profesList;
        }

        //calcular horas mín. laborales
        public static decimal calcHorasMin(Profesor pProfesor)
        {
            decimal horas = 0;

            foreach(PlazaAsignada plaza in pProfesor.getPlazasAsig())
            {
                horas += plaza.getHorAsig();
            }

            return horas;
        }

        //calcular total horas asignadas
        public static decimal calcHorasAsig(Profesor pProfesor)
        {
            decimal horas = 0;

            //sumar horas de asignaciones
            foreach(Asignacion asig in pProfesor.getAsignaciones())
            {
                horas += asig.getValorHoras();
            }

            //sumar horas de ampliaciones
            foreach (Ampliacion ampl in pProfesor.getAmpliaciones())
            {
                horas += ampl.getValorHoras();
            }

            return horas;
        }
        
        
        /**************SUS PLAZAS*********************/

        //insertar relación Plaza - Profesor
        public static Boolean insertPlazaProfe(string pIdProfe, string pIdPlaza, string pHoras, bool pIsPropiedad)
        {
            String propiedad = "";
            if (pIsPropiedad)
                propiedad = "1";
            else
                propiedad = "0";

            Boolean isValido = DatosManager.insertPlazaProfe(pIdProfe, pIdPlaza, pHoras, propiedad);
            return isValido;
        }

        //obtener lista de elementos en relación Plaza - Profesor
        public static List<PlazaAsignada> getPlazasDeProfesor(int pId)
        {
            List<Object[]> plazasAsignadasObj = DatosManager.getPlazasDeProfesor(pId.ToString());
            List<PlazaAsignada> plazasAsignadasList = new List<PlazaAsignada>();
            PlazaAsignada plazaAsignada;

            foreach (Object[] obj in plazasAsignadasObj)
            {
                plazaAsignada = new PlazaAsignada(new Plaza((String)obj[0], 0), (decimal)obj[2], (bool)obj[1]);
                plazasAsignadasList.Add(plazaAsignada);
            }

            return plazasAsignadasList;
        }

        //Borrar plazas de un profesor
        public static Boolean eliminarPlazasProfe(int pProfeID)
        {
            Boolean isValido = DatosManager.eliminarPlazasProfe(pProfeID.ToString());
            return isValido;
        }
    }
}
