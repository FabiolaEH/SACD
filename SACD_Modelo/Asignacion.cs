using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Asignacion
    {
        private decimal valorHoras;
        private Actividad actividad;


        public Asignacion(decimal pValorHoras, Actividad pActividad)
        {
            valorHoras = pValorHoras;
            actividad = pActividad;
        }

        public decimal getValorHoras()
        {
            return valorHoras;
        }

        public void setValorHoras(decimal pValorHoras)
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
