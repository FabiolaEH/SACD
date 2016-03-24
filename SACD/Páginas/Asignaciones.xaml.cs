using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Asignaciones.xaml
    /// </summary>
    public partial class Asignaciones : Page
    {
        public Asignaciones()
        {
            InitializeComponent();

            // Populate list
            this.listView.Items.Add(new MyItem { Profesor = "Jhoen maria", Horas = 1 });

        }

        public class MyItem
        {
            public string Profesor { get; set; }

            public int Horas { get; set; }
        }

    }
}
