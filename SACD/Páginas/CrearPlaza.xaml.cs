using SACD_Controlador;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                    MessageBox.Show("Error al crear la plaza");
                else
                    MessageBox.Show("Plaza creada correctamente");
            }
            else
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod))
                e.Handled = true;
        }
    }
}
