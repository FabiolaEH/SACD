using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACD_Modelo;

namespace SACD_Controlador
{
    public class ActividadesManager
    {
        //crear actividad
        public void crear(string pTipo) //cur - invest - admin
        {
            ActvAdmin nueva;
        }

        //eliminar actividad
        public void eliminar(int id)
        {

        }

        //editar actividad
        public void editar(int id, Actividad pNuevaActv)
        {

        }

        //calcular valor en horas de un curso
        public float calcValorCurso(Curso pCurso, string pParametro) //parámetro del profesor= nuevo, existente...
        {
            return 0;
        }

        //calcular valor en horas de un curso en ampliación
        public float calcValorCurso_Ampl()
        {
            return 0;
        }
    }
}
