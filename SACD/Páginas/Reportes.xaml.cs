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
    public partial class Reportes : Page
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            popup_reporte.IsOpen = true;
        }

        private void checkIsMouseDirectlyOver(object sender, DependencyPropertyChangedEventArgs e)
        {
            ImageBrush equis = new ImageBrush();
            equis.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Equis.png"));
            ImageBrush equisR = new ImageBrush();
            equisR.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/EquisR.png"));
            if (btnCerrarReporte.IsMouseOver)
            {
                btnCerrarReporte.Background = equisR;
            }
            else
            {
                btnCerrarReporte.Background = equis;
            }
        }

        private void btnCerrarReporte_Click(object sender, RoutedEventArgs e)
        {
            popup_reporte.IsOpen = false;
        }
    }
}
