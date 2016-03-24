using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD_Modelo
{
    public class Profesor
    {
        private int id;
        private string nombre;
        private List<Asignacion> asignaciones;
        //private float horasAsig;
        private List<PlazaAsignada> plazasAsig;
    }
}
