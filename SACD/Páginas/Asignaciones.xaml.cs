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


namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Asignaciones.xaml
    /// </summary>
    public partial class Asignaciones : Page
    {
        public Frame frame;
        public Asignaciones(Frame pFrame)
        {
            InitializeComponent();
            listarProfesores();
            frame = pFrame;
            /*
            Seleccionar el semestre y año actual
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            MessageBox.Show(mainWindow.semestre_global.ToString());
            MessageBox.Show(mainWindow.anio_global.ToString());
            */
        }

        public void listarProfesores()
        {
            List<Profesor> profesList;
            List<Profesor_GUI> profesListGUI = new List<Profesor_GUI>();
            profesList = ProfesManager.listar();

            foreach (Profesor profe in profesList)
            {
                profesListGUI.Add(new Profesor_GUI() { id = profe.getId(), nombre = profe.getNombre() });
            }
            this.dgProfesores.ItemsSource = profesListGUI;

        }

        public void verPerfil(object sender, RoutedEventArgs e)
        {
            Perfil ventanaPerfil = new Perfil(Int32.Parse((sender as Button).Uid.ToString()));
            frame.Navigate(ventanaPerfil);
        }

        private void tbxBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            List<Profesor> profesList;
            List<Profesor_GUI> profesListGUI = new List<Profesor_GUI>();
            profesList = ProfesManager.listar();

            foreach (Profesor profe in profesList)
            {
                if(profe.getNombre().IndexOf(this.tbxBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    profesListGUI.Add(new Profesor_GUI() { id = profe.getId(), nombre = profe.getNombre()});
            }
            this.dgProfesores.ItemsSource = profesListGUI;
            this.dgProfesores.Items.Refresh();
        }
    }
}
