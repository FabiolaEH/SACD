using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Grupo : Actividad 
    {
        private int numero;
        private int cantEstudiantes;
        private Curso curso;

        public Grupo(int pId, string pTipo, float pHoras, int pNumero, int pCantEstudiantes, 
            Curso pCurso) : base(pId, pTipo, pHoras)
        {
            numero = pNumero;
            cantEstudiantes = pCantEstudiantes;
            curso = pCurso;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setNumero(int pNumero)
        {
            numero = pNumero;
        }

        public int getCantEstudiantes()
        {
            return cantEstudiantes;
        }

        public void setCantEstudiantes(int pCantEstudiantes)
        {
            cantEstudiantes = pCantEstudiantes;
        }

        public Curso getCurso()
        {
            return curso;
        }

        public void setCurso(Curso pCurso)
        {
            curso = pCurso;
        }

    }
}
