using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    class TipoCurso
    {
        private string tipo; // teor - pract - teopract
        private decimal horas;

        public TipoCurso(string pTipo, decimal pHoras)
        {
            tipo = pTipo;
            horas = pHoras;
        }
    }
}
