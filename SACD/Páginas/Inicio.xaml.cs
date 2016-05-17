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
using System.Windows.Controls.DataVisualization.Charting;
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
        int contAdm = 0;
        int contInv = 0;
        int contAca = 0;
        MainWindow mainWindow;

        public Inicio()
        {
            InitializeComponent();

            int[] distribPlazas = PlazasManager.getDistribPlazas();
            
            cargarInformacion();
            //Seleccionar el semestre y año actual
            mainWindow = (MainWindow)Application.Current.MainWindow;
            int indexAnio = cmb_Anio.Items.IndexOf(mainWindow.anio_global);
            int indexPeriodo= cmb_Semestre.Items.IndexOf(mainWindow.periodo_global);

            cmb_Anio.SelectedIndex = indexAnio;
            cmb_Semestre.SelectedIndex = indexPeriodo;
            
            LoadPieChartData(distribPlazas);
            guardarAsign(mainWindow);
            LoadPieChartData2();
        }

        private void guardarAsign(MainWindow pMainWindow)
        {
            List<Asignacion> asignacionesProf = AsignacsManager.getAsignaciones(-1, pMainWindow.semestre_global ,pMainWindow.periodo_global , pMainWindow.anio_global, true);
            
            for (int i = 0; i < asignacionesProf.Count; i++)
            {
                String tipo = asignacionesProf[i].getActividad().getTipo().ToString();
                if (tipo.Equals("GRUP"))
                {
                    contAca++;
                }
                else if(tipo.Equals("ADMI"))
                {
                    contAdm++;
                }
                else if(tipo.Equals("INVE"))
                {
                    contInv++;
                }
            }
        }

        private void LoadPieChartData(int[] pDistribPlazas)
        {
            chartPie.ItemsSource = new KeyValuePair<string, int>[]{
                        new KeyValuePair<string,int>("Interinos", pDistribPlazas[0]),
                        new KeyValuePair<string,int>("Propietarios", pDistribPlazas[1])
            };
        }

        private void LoadPieChartData2()
        {
            chartPie2.ItemsSource = new KeyValuePair<string, int>[]{
                        new KeyValuePair<string,int>("Administrativas", contAdm),
                        new KeyValuePair<string,int>("Investigación", contInv),
                        new KeyValuePair<string,int>("Académicas", contAca)
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
                    contAdm = 0;
                    contInv = 0;
                    contAca = 0;
                    guardarAsign(mainWindow);
                    LoadPieChartData2();
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
