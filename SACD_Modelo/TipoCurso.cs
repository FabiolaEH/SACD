using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class TipoCurso
    {
        private string tipo; // teor - prac - teopract
        private decimal horas;

        public TipoCurso(string pTipo, decimal pHoras)
        {
            tipo = pTipo;
            horas = pHoras;
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
