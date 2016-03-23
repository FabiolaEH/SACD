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
        private int porcentaje;

        public void setId(int pId)
        {
            id = pId;
        }

        public int getId()
        {
            return id;
        }

        public void setPorcentaje(int pPorcentaje)
        {
            porcentaje = pPorcentaje;
        }

        public int getPorcentaje()
        {
            return porcentaje;
        }

    }
}
