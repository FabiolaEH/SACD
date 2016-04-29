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
            cargarInformacion();
            //Seleccionar el semestre y año actual
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            int indexAnio = cmb_Anio.Items.IndexOf(mainWindow.anio_global);
            int indexPeriodo= cmb_Semestre.Items.IndexOf(mainWindow.periodo_global);

            cmb_Anio.SelectedIndex = indexAnio;
            cmb_Semestre.SelectedIndex = indexPeriodo;

            LoadPieChartData();

        }

        private void LoadPieChartData()
        {
            pieSeries.ItemsSource = new KeyValuePair<string, int>[]{
                        new KeyValuePair<string,int>("Interinos", 22),
                        new KeyValuePair<string,int>("Propiedad", 28),
            };
        }


        private void cargarInformacion()
        {
            int anio = -1;
            List<Semestre> semestres = SemestresManager.listar();

            foreach (Semestre semestre in semestres)
            {
                if (semestre.getAnio() != anio)
                {
                    anio = semestre.getAnio();
                    cmb_Anio.Items.Add(anio);
                }
            }

            cmb_Semestre.Items.Add(1);
            cmb_Semestre.Items.Add(2);
        }

        private void btn_Ver_Estadisticas(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(cmb_Semestre.SelectedValue != null && cmb_Anio.SelectedValue != null)
            {
                int periodo = (int)cmb_Semestre.SelectedValue;
                int anio = (int)cmb_Anio.SelectedValue;
                //Asignar el semestre y año actual
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.periodo_global = periodo;
                mainWindow.anio_global = anio;
                Boolean isExitoso = SemestresManager.editar_actual(periodo, anio);
                if (isExitoso)
                {
                    List<int> semestre = SemestresManager.getSemestreGlobal();
                    mainWindow.semestre_global = semestre[0];
                    MessageBox.Show("Se han guardado los datos correctamente.");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un problema al actualizar el semestre actual.");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un semestre y año válido.");
            }
        }
    }
}
