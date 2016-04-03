using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD.Clases
{
    class Grupos_GUI
    {
        public string nombre { get; set; }
        public int numGrupo { get; set; }
        public int cantEstud { get; set; }
        public int idGrupo { get; set; }
        public string codCurso { get; set; }
        public decimal valHoras { get; set; }
        public decimal horasPresen { get; set; } //presenciales del curso
        public bool isSelected { get; set; }

    }
}
