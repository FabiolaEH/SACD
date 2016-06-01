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
    public partial class CrearSemestre : Page
    {
        public CrearSemestre()
        {
            InitializeComponent();

            //Cargar comboBox
            cmb_Periodos.Items.Add("1");
            cmb_Periodos.Items.Add("2");
            cmb_Periodos.SelectedIndex = 0;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxAnio.Text != "")
            {
                Boolean isValido = SemestresManager.crear(tbxAnio.Text, (String)cmb_Periodos.SelectedValue);
                if (!isValido)
                    MessageBox.Show("Error al crear el semestre");
                else
                    MessageBox.Show("Semestre creado correctamente");
            }
            else
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9)) 
                e.Handled = true;
        }
    }
}
