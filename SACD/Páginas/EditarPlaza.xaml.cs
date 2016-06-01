using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SACD.Páginas
{
    public partial class EditarPlaza : Page
    {
        List<Plaza> plazasList = new List<Plaza>();

        public EditarPlaza()
        {
            InitializeComponent();
            actualizarComponentes();
        }

        private void actualizarComponentes()
        {
            //Cargar comboboxes
            plazasList = PlazasManager.listarPlazas();
            foreach (Plaza plaza in plazasList)
                cmb_Plazas.Items.Add(plaza.getId().ToString());
        }
    
        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(tbxPorcentaje.Text != "")
            {
                Boolean isValido = PlazasManager.editar(tbxNumero.Text, tbxPorcentaje.Text);
                if (!isValido)
                    MessageBox.Show("Error al editar la plaza");
                else
                {
                    foreach (Plaza plaza in plazasList)
                    {
                        if (plaza.getId() == tbxNumero.Text)
                            plaza.setPorcentaje(Decimal.Parse(tbxPorcentaje.Text));
                    }
                    MessageBox.Show("Plaza editada correctamente");
                }
            }
            else
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
        }

        private void cmb_Plazas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String id = (String)cmb_Plazas.SelectedValue;
            tbxNumero.Text = id;

            foreach (Plaza plaza in plazasList)
            {
                if (plaza.getId() == id)
                {
                    tbxPorcentaje.Text = plaza.getPorcentaje().ToString().Replace(",",".");
                    tbxPorcentaje.IsEnabled = true;
                    btn_Aceptar.IsEnabled = true;
                }
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod))
                e.Handled = true;
        }
    }
}
