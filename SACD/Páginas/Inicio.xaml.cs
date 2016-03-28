using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
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
            listarProfesores();
        }

        public void listarProfesores()
        {
            List<Profesor> profesList;
            List<Profesor_GUI> profesListGUI = new List<Profesor_GUI>();
            profesList = ProfesManager.listar();
            
            foreach (Profesor profe in profesList)
            {
                profesListGUI.Add(new Profesor_GUI() { id = profe.getId(), nombre = profe.getNombre(), horasAsig = profe.getHorasAsig() });
            }
            this.dgProfesores.ItemsSource = profesListGUI;

        }
        
        public void verPerfil(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Uid.ToString());
        }

    }
}
