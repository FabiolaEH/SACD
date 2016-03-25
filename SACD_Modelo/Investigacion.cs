using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Investigacion : Actividad
    {
        private string nombre;
        private DateTime inicio;
        private DateTime fin;


        public Investigacion(int pId, string pTipo, decimal pHoras, string pNombre,
            DateTime pInicio, DateTime pFin) : base(pId, pTipo, pHoras)
        {
            nombre = pNombre;
            inicio = pInicio;
            fin = pFin;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string pNombre)
        {
            nombre = pNombre;
        }

        public DateTime getInicio()
        {
            return inicio;
        }

        public void setInicio(DateTime pInicio)
        {
            inicio = pInicio;
        }

        public DateTime getFin()
        {
            return fin;
        }

        public void setFin(DateTime pFin)
        {
            fin = pFin;
        }
    }
}
