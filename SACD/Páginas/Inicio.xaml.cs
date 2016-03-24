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



namespace SACD
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();
            List<Profesor> users = new List<Profesor>();
            users.Add(new Profesor() { Nombre = "John Doe", Horas = 22});
            users.Add(new Profesor() { Nombre = "Jane Doe", Horas = 14});

            dgProfesores.ItemsSource = users;
        }

        public class Profesor
        {
            public string Nombre { get; set; }

            public int Horas { get; set; }
        }
    }
}
