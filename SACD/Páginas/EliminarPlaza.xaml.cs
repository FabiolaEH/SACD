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
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class EliminarPlaza : Page
    {
        List<Plaza> plazasList = new List<Plaza>();
        List<Plazas_GUI> plazasListGUI = new List<Plazas_GUI>();

        public EliminarPlaza()
        {
            InitializeComponent();
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            plazasList = new List<Plaza>();
            plazasListGUI = new List<Plazas_GUI>();

            plazasList = PlazasManager.listarPlazas();

            foreach (Plaza plaza in plazasList)
            {
                plazasListGUI.Add(new Plazas_GUI() { numero = plaza.getId(), porcentaje = plaza.getPorcentaje()});
            }

            //dgPlazas.ItemsSource = null;
            dgPlazas.ItemsSource = plazasListGUI;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Plazas_GUI plazaInfo in plazasListGUI)
            {
                if (plazaInfo.isSelected)
                {
                    Boolean isValido = PlazasManager.eliminar(plazaInfo.numero);
                    if (!isValido)
                        MessageBox.Show("Error al eliminar la plaza");
                    else
                        actualizarTabla();
                }
            }
        }
    }
}
