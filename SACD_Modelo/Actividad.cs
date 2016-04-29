using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public abstract class Actividad
    {
        private int id;
        private string tipo; //GROUP - ADMI - INVE
        private decimal horas;


        public Actividad(int pId, string pTipo, decimal pHoras)
        {
            id = pId;
            tipo = pTipo;
            horas = pHoras;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int pId)
        {
            id = pId;
        }

        public string getTipo()
        {
            return tipo;
        }

        public void setTipo(string pTipo)
        {
            tipo = pTipo;
        }

        public decimal getHoras()
        {
            return horas;
        }

        public void setHoras(decimal pHoras)
        {
            horas = pHoras;
        }



    }

}
