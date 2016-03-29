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
    /// Lógica de interacción para PopupRegistro.xaml
    /// </summary>
    public partial class PopupRegistro : Window
    {
        public PopupRegistro(int pIdProfesor)
        {
            InitializeComponent();
            this.Show();
        }

        private void btnCerrarReporte_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmContenido_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
