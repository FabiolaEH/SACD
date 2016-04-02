using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACD.Clases
{
    class Investigs_GUI
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal valHoras { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fin { get; set; }
        public bool isSelected { get; set; }
    }
}
