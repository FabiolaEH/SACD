using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Plaza
    {
        private String id;
        private decimal porcentaje;

        public Plaza(String pId, decimal pPorcentaje)
        {
            id = pId;
            porcentaje = pPorcentaje;
        }

        public void setId(String pId)
        {
            id = pId;
        }

        public String getId()
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
