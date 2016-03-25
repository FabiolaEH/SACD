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
            this.dgProfesores.Items.Add(new Profesor { nombre = "Jhoel Marenco", horas = 12 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Fabiola Espinoza", horas = 40 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
            this.dgProfesores.Items.Add(new Profesor { nombre = "Brandon Campos", horas = 30 });
        }

        public class Profesor
        {
            public string nombre { get; set; }

            public int horas { get; set; }
        }

        public void ButtonCommand()
        {
            MessageBox.Show("Botón");
        }
    }
}
