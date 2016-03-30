using SACD_Controlador;
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
    /// Lógica de interacción para Registrar_Usuario.xaml
    /// </summary>
    public partial class Registrar_Usuario : Page
    {
        public Registrar_Usuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxCorreo.Text.Equals("") || tbxNombre.Text.Equals("") || 
                tbxPassword.Password.Equals("") || tbxPasswordVerif.Password.Equals(""))
            {
                MessageBox.Show("Favor completar los espacios vacíos.");
            }
            else
            {
                if (tbxPassword.Password.Equals(tbxPasswordVerif.Password))
                {
                    Boolean isValido = UsuariosManager.registrarUsuario(tbxNombre.Text.Trim(), tbxCorreo.Text.Trim(), tbxPassword.Password);
                    if (isValido)
                    {
                        MessageBox.Show("Usuario registrado correctamente.");
                        tbxNombre.Text = "";
                        tbxCorreo.Text = "";
                        tbxPassword.Password = "";
                        tbxPasswordVerif.Password = "";
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un problema al intentar registrar el usuario.");
                    }
                }
                else
                {
                    MessageBox.Show("Las constraseñas no coinciden.");
                }
            }
        }
    }
}
