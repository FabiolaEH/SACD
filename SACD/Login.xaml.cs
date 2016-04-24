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
using System.Windows.Shapes;

namespace SACD
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxCorreo.Text.Equals("") || tbxPassword.Password.Equals(""))
            {
                MessageBox.Show("Favor llenar los espacios vacíos.");
            }
            else
            {
                Boolean isValido = UsuariosManager.verificarUsuario(tbxCorreo.Text, tbxPassword.Password);
                if (isValido)
                {
                    new MainWindow().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El correo y contraseña no coinciden con los registrados en el sistema.");
                }
            }
        }

        private void olvidarContr(object sender, RoutedEventArgs e)
        {
            PopupOlvidarContraseña popup = new PopupOlvidarContraseña(tbxCorreo.Text);
        }
    }
}
