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
        private decimal porcentajeAsig;
        private bool isPropiedad;

        public PlazaAsignada(Plaza pPlaza, decimal pPorcAsign, bool pIsPropiedad)
        {
            plaza = pPlaza;
            porcentajeAsig = pPorcAsign;
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

        public decimal getPorcentajeAsig()
        {
            return porcentajeAsig;
        }
    }
}
