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
    public partial class CrearPlaza : Page
    {
        public CrearPlaza()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(tbxNumero.Text != "" && tbxPorcentaje.Text != "")
            {

            }
            else
            {
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
            }
        }
    }
}
