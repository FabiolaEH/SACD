using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Curso 
    {
        private string codigo;
        private string nombre;
        private decimal totalHorasPresen;
        private List<TipoCurso> tipos;

        public Curso(string pCodigo,  string pNombre, decimal pTotalHorasPresen)            
        {
            codigo = pCodigo;
            nombre = pNombre;
            totalHorasPresen = pTotalHorasPresen;
            tipos = new List<TipoCurso>();
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string pNombre)
        {
            nombre = pNombre;
        }

        public string getCodigo()
        {
            return codigo;
        }

        public void setCodigo(string pCodigo)
        {
            codigo = pCodigo;
        }

        public decimal getHorasPresen()
        {
            return totalHorasPresen;
        }

        public void setHorasPresen(decimal pHoras)
        {
            totalHorasPresen = pHoras;
        }

        public void addTipo(string pTipo, decimal pHoras)
        {
            tipos.Add(new TipoCurso(pTipo, pHoras));
        }
        
    }


}
