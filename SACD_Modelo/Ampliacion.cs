﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Ampliacion : Asignacion
    {
        private bool isDoble;


        public Ampliacion(decimal pValorHoras, Actividad pActividad, Semestre pSemestre, bool pIsDoble) : base(pValorHoras, pActividad, pSemestre)
        {
            isDoble = pIsDoble;
        }

        public bool getIsDouble()
        {
            return isDoble;
        }

        public void setIsDoble(bool pIsDouble)
        {
            isDoble = pIsDouble;
        }


    }
}
