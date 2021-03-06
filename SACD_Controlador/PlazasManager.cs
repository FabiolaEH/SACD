﻿using System;
using System.Collections.Generic;
using SACD_Modelo;
using SACD_AccesoDatos;

namespace SACD_Controlador
{
    public static class PlazasManager
    {
        //crear Plaza
        public static Boolean crear(String pId, String pPorcentaje)
        {
            Boolean isValido = DatosManager.insertPlaza(pId, pPorcentaje);
            return isValido;
        }

        //eliminar Plaza
        public static Boolean eliminar(String pId)
        {
            Boolean isValido = DatosManager.eliminarPlaza(pId);
            return isValido;
        }

        //editar Plaza
        public static Boolean editar(String pId, String pPorcentaje)
        {
            Boolean isValido = DatosManager.editarPlaza(pId, pPorcentaje);
            return isValido;
        }

        //obtener lista de plazas registradas
        public static List<Plaza> listarPlazas()
        {
            List<Object[]> plazasObj = DatosManager.getPlazasList();
            List<Plaza> plazasList = new List<Plaza>();
            Plaza plaza;

            foreach (Object[] obj in plazasObj)
            {
                plaza = new Plaza((String)obj[0], (decimal)obj[1]);
                plazasList.Add(plaza);
            }

            return plazasList;
        }

        //Obtener cantidad de plazas propietarias y interinas. 
        //El primer valor son las prop. y el segundo los interinos
        public static int[] getDistribPlazas()
        {
            int[] result = DatosManager.getDistribPlazas();

            return result;
        }
    }
}
