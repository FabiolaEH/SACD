using SACD.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SACD_Controlador;
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
    /// Lógica de interacción para PopupOlvidarContraseña.xaml
    /// </summary>
    public partial class PopupOlvidarContraseña : Window
    {
        public PopupOlvidarContraseña(string pCorrreo)
        {
            InitializeComponent();
            tbxCorreo.Text = pCorrreo;
            this.Show();
        }
        private void btnCerrarOlvidar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (tbxCorreo.Text.Equals(""))
            {
                MessageBox.Show("Favor ingresar el correo.");
            }
            else
            {
                Boolean isValido = UsuariosManager.verificarCorreo(tbxCorreo.Text.Trim());
                if (isValido)
                {
                    lblTitulo.Text = "Se ha enviado un código de verificación a la dirección electrónica: " + tbxCorreo.Text + ".";
                }
                else
                {
                    MessageBox.Show("El correo no se encuentra registrado en el sistema.");
                }
            }
        }        
    }
}
