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
        private decimal horasAsig;
        private List<Asignacion> asignaciones;
        private List<PlazaAsignada> plazasAsig;

        public Profesor(int pId, string pNombre, decimal pHorasAsig)
        {
            id = pId;
            nombre = pNombre;
            horasAsig = pHorasAsig;
            asignaciones = new List<Asignacion>();
            plazasAsig = new List<PlazaAsignada>();
        }

        public int getId()
        {
            return id;
        }

        public void setId(int pId)
        {
            id = pId;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string pNombre)
        {
            nombre = pNombre;
        }

        public decimal getHorasAsig()
        {
            return horasAsig;
        }

        public void setHorasAsig(decimal pHorasAsig)
        {
            horasAsig = pHorasAsig;
        }

        public List<Asignacion> getAsignaciones()
        {
            return asignaciones;
        }

        public void addAsignacion(Asignacion pAsignacion)
        {
            asignaciones.Add(pAsignacion);
        }

        public List<PlazaAsignada> getPlazasAsig()
        {
            return plazasAsig;
        }

        public void addPlaza(PlazaAsignada pPlaza)
        {
            plazasAsig.Add(pPlaza);
        }
    }
}
