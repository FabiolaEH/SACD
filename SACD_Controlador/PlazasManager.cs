using System;
using System.Collections.Generic;
using SACD_Modelo;
using SACD_AccesoDatos;

namespace SACD_Controlador
{
    public static class PlazasManager
    {
        //crear Plaza
        public static Boolean crear(String pNumero, String pPorcentaje)
        {
            Boolean isValido = DatosManager.insertPlaza(pNumero, pPorcentaje);
            return isValido;
        }

        //eliminar semestre
        public static Boolean eliminar(int pNumero)
        {
            Boolean isValido = DatosManager.eliminarPlaza(pNumero.ToString());
            return isValido;
        }

        //editar Plaza
        public static Boolean editar(String pNumero, String pPorcentaje)
        {
            Boolean isValido = DatosManager.editarPlaza(pNumero, pPorcentaje);
            return isValido;
        }

        //Editar semestre actual
        public static Boolean editar_actual(int semestre, int anio)
        {
            Boolean isExitoso = DatosManager.editar_Semestre_Actual(semestre, anio);
            return isExitoso;
        }

        //obtener lista de investigaciones registradas
        public static List<Plaza> listarPlazas()
        {
            List<Object[]> plazasObj = DatosManager.getPlazasList();
            List<Plaza> plazasList = new List<Plaza>();
            Plaza plaza;

            foreach (Object[] obj in plazasObj)
            {
                plaza = new Plaza((int)obj[0], (decimal)obj[1]);
                plazasList.Add(plaza);
            }

            return plazasList;
        }
    }
}
