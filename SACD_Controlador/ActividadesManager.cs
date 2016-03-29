﻿using System;
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
        public static List<Investigacion> listarInvestigs()
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

        //obtener lista de actv. administrativas registradas
        public static List<ActvAdmin> listarAdministvs()
        {
            List<Object[]> administvsObj = DatosManager.getAdministvsList();
            List<ActvAdmin> administvsList = new List<ActvAdmin>();
            ActvAdmin actvAdmin;

            foreach (Object[] obj in administvsObj)
            {
                actvAdmin = new ActvAdmin((int)obj[0], "admin", (decimal)obj[2], (string)obj[1]);
                administvsList.Add(actvAdmin);
            }

            return administvsList;

        }

        //obtener lista de grupos registradas
        public static List<Grupo> listarGrupos() //g.COD_CURSO, c.NOM_CURSO, g.ID_GRUPO, g.NUM_GRUPO, g.NUM_ESTUDIANTES" 
        {
            List<Object[]> gruposObj = DatosManager.getGruposList();
            List<Grupo> gruposList = new List<Grupo>();
            Grupo grupo;

            foreach (Object[] obj in gruposObj)
            {
                grupo = new Grupo((int)obj[2], "cur", 0, (int)obj[3], (int)obj[4], new Curso((string)obj[0], (string)obj[1]));
                gruposList.Add(grupo);
            }

            return gruposList;

        }

    }
}
