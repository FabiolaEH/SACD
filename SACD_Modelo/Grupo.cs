using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Grupo 
    {
        private int id;
        private int numero;
        private int cantEstudiantes;
        private Curso curso;

        public Grupo(int pId, int pNumero, int pCantEstudiantes, Curso pCurso) 
        {
            id = pId;
            numero = pNumero;
            cantEstudiantes = pCantEstudiantes;
            curso = pCurso;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int pId)
        {
            id = pId;
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
