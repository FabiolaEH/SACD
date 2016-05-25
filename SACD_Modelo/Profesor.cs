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
        private List<Ampliacion> ampliaciones;
        private List<PlazaAsignada> plazasAsig;

        public Profesor(int pId, string pNombre)
        {
            id = pId;
            nombre = pNombre;
            asignaciones = new List<Asignacion>();
            ampliaciones = new List<Ampliacion>();
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

        public List<Asignacion> getAsignaciones()
        {
            return asignaciones;
        }

        public void setAsignaciones(List<Asignacion> pAsignaciones)
        {
            asignaciones = pAsignaciones;
        }

        public void addAsignacion(Asignacion pAsignacion)
        {
            asignaciones.Add(pAsignacion);
        }

        public void borrarAsignacion(int pIdActv)
        {
            Actividad actvAux;

            foreach (Asignacion asig in asignaciones)
            {
                actvAux = asig.getActividad();
                if (actvAux.getId() == pIdActv)
                {
                    asignaciones.Remove(asig);
                    break;
                }
            }
        }

        public Asignacion buscarAsig(int pIdActv)
        {
            Actividad actvAux;
            Asignacion asigEncontrada = null;

            foreach (Asignacion asig in asignaciones)
            {
                actvAux = asig.getActividad();
                if (actvAux.getId() == pIdActv)
                    asigEncontrada = asig;

            }

            return asigEncontrada;
        }

        public List<Ampliacion> getAmpliaciones()
        {
            return ampliaciones;
        }

        public void setAmpliaciones(List<Ampliacion> pAmpliaciones)
        {
            ampliaciones = pAmpliaciones;
        }

        public void addAmpliacion(Ampliacion pAmpliacion)
        {
            ampliaciones.Add(pAmpliacion);
        }

        public void borrarAmpliacion(int pIdGrupo)
        {
            Actividad actvAux;

            foreach (Ampliacion ampl in ampliaciones)
            {
                actvAux = ampl.getActividad();
                if (actvAux.getId() == pIdGrupo)
                {
                    ampliaciones.Remove(ampl);
                    break;
                }
            }
        }

        public Ampliacion buscarAmpl(int pIdActv)
        {
            Actividad actvAux;
            Ampliacion asigEncontrada = null;

            foreach (Ampliacion ampl in ampliaciones)
            {
                actvAux = ampl.getActividad();
                if (actvAux.getId() == pIdActv)
                    asigEncontrada = ampl;
                
            }

            return asigEncontrada;
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
