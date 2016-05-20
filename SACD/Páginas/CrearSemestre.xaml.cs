using SACD_Controlador;
using System;
using System.Windows;
using System.Windows.Controls;

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
                if (!isValido) { 
                    MessageBox.Show("Error al insertar el semestre");
                }
                else
                    MessageBox.Show("Semestre insertado correctamente");
            }
            else
            {
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
            }
        }
    }
}
