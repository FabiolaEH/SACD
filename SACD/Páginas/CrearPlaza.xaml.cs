using SACD_Controlador;
using System;
using System.Windows;
using System.Windows.Controls;

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
                Boolean isValido = PlazasManager.crear(tbxNumero.Text, tbxPorcentaje.Text);
                if(!isValido)
                    MessageBox.Show("Error al insertar la plaza");
            }
            else
            {
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
            }
        }
    }
}
