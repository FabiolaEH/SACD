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
                    //Mostrar y ocultar labels
                    lblTitulo.Text = "Se ha enviado un código de verificación a la dirección electrónica: " + tbxCorreo.Text + ".";
                    lblCorreo.Visibility = Visibility.Hidden;
                    lblCodigo.Visibility = Visibility.Visible;
                    lblPassword.Visibility = Visibility.Visible;
                    lblPasswordVerif.Visibility = Visibility.Visible;
                    //Mostrar y ocultar cajas de texto
                    tbxCorreo.Visibility = Visibility.Hidden;
                    tbxCodigo.Visibility = Visibility.Visible;
                    tbxPassword.Visibility = Visibility.Visible;
                    tbxPasswordVerif.Visibility = Visibility.Visible;
                    //Mostrar y ocultar botones
                    btnSiguiente.Visibility = Visibility.Hidden;
                    btnAceptar.Visibility = Visibility.Visible;
                    isValido = UsuariosManager.enviarCorreo(tbxCorreo.Text.Trim());
                }
                else
                {
                    MessageBox.Show("El correo no se encuentra registrado en el sistema.");
                }
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if(tbxCodigo.Text.Equals("") || tbxPassword.Password.Equals("") || tbxPassword.Password.Equals(""))
            {
                MessageBox.Show("Favor completar los espacios vacíos.");
            }
            else
            {
                if (!tbxPassword.Password.Equals(tbxPasswordVerif.Password))
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }
                else
                {
                    String codigo = UsuariosManager.verificarCodigo(tbxCorreo.Text.Trim());
                    
                    if (tbxCodigo.Text.Equals(codigo))
                    {
                        Boolean isValido = UsuariosManager.actualizarPassword(tbxCorreo.Text.Trim(),tbxPassword.Password);
                        if (isValido)
                        {
                            MessageBox.Show("Contraseña actualizada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al intentear actualizar la contraseña.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código ingresado es incorrecto. Favor intentar de nuevo.");
                    }

                }
            }
        }
        
    }
}
