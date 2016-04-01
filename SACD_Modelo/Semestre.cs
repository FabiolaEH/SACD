using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Semestre
    {
        private int id;
        private int anio;
        private int periodo;

        public Semestre(int pId, int pAnio, int pPeriodo)
        {
            id = pId;
            anio = pAnio;
            periodo = pPeriodo;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int pId)
        {
            id = pId;
        }

        public int getAnio()
        {
            return anio;
        }

        public void setAnio(int pAnio)
        {
            anio = pAnio;
        }

        public int getPeriodo()
        {
            return periodo;
        }

        public void setPeriodo(int pPeriodo)
        {
            periodo = pPeriodo;
        }
    }
}
