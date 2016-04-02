using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Plaza
    {
        private int id;
        private decimal porcentaje;

        public void setId(int pId)
        {
            id = pId;
        }

        public int getId()
        {
            return id;
        }

        public void setPorcentaje(decimal pPorcentaje)
        {
            porcentaje = pPorcentaje;
        }

        public decimal getPorcentaje()
        {
            return porcentaje;
        }

    }
}
