using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class ActvAdmin : Actividad
    {
        private string nombre;


        public ActvAdmin(int pId, string pTipo, decimal pHoras, string pNombre) : base(pId, pTipo, pHoras)
        {
            nombre = pNombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string pNombre)
        {
            nombre = pNombre;
        }
    }

    
}
