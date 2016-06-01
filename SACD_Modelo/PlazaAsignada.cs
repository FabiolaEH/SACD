using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class PlazaAsignada
    {
        private Plaza plaza;
        private decimal horAsig;
        private bool isPropiedad;

        public PlazaAsignada(Plaza pPlaza, decimal pHorAsig, bool pIsPropiedad)
        {
            plaza = pPlaza;
            horAsig = pHorAsig;
            isPropiedad = pIsPropiedad;
        }

        public Plaza getPlaza()
        {
            return plaza;
        }

        public bool getIsPropiedad()
        {
            return isPropiedad;
        }

        public decimal getHorAsig()
        {
            return horAsig;
        }
    }
}
