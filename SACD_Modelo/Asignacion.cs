using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Asignacion
    {
        private float valorHoras;
        private Actividad actividad;


        public Asignacion(float pValorHoras, Actividad pActividad)
        {
            valorHoras = pValorHoras;
            actividad = pActividad;
        }

        public float getValorHoras()
        {
            return valorHoras;
        }

        public void setValorHoras(float pValorHoras)
        {
            valorHoras = pValorHoras;
        }

        public Actividad getActividad()
        {
            return actividad;
        }

        public void setActividad(Actividad pActividad)
        {
            actividad = pActividad;
        }
    }
}
