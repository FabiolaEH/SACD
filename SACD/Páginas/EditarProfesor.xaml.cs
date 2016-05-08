using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class EditarProfesor : Page
    {
        List<Plaza> plazasList = new List<Plaza>();
        List<Profesor> profesList = new List<Profesor>();
        List<Plazas_GUI> plazasListGUI = new List<Plazas_GUI>();

        public EditarProfesor()
        {
            InitializeComponent();
            actualizarCombobox();
            cargarPlazas();
            cargarTabla();
        }

        private void actualizarCombobox()
        {
            //Cargar comboboxes
            profesList = ProfesManager.listar();
            foreach (Profesor profe in profesList)
            {
                cmb_Profes.Items.Add(profe.getNombre());
            }
        }

        private void cargarPlazas()
        {
            plazasList = new List<Plaza>();
            plazasListGUI = new List<Plazas_GUI>();

            plazasList = PlazasManager.listarPlazas();
        }

        private void cargarTabla()
        {
            foreach (Plaza plaza in plazasList)
            {
                plazasListGUI.Add(new Plazas_GUI() { numero = plaza.getId(), porcentaje = plaza.getPorcentaje() });
            }

            dgPlazas.ItemsSource = plazasListGUI;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Boolean exito = true;
            if (tbxNombre.Text != "")
            {
                Profesor profe = buscarProfesor();

                //Primero actualizar el profesor
                Boolean isValido = ProfesManager.editar(profe.getId(), tbxNombre.Text);
                if (!isValido)
                {
                    MessageBox.Show("Error al actualizar el profesor");
                    exito = false;
                }
                else
                {
                    //Borrar las Plaza_Profesor viejas
                    isValido = ProfesManager.eliminarPlazasProfe(profe.getId());
                    if (!isValido)
                    {
                        MessageBox.Show("Error al eliminar las plaza anteriores");
                        exito = false;
                    }
                    else
                    {
                        //Crear relación Plaza_Profesor
                        foreach (Plazas_GUI plazaInfo in plazasListGUI)
                        {
                            if (plazaInfo.porcAsignado != null)
                            {
                                isValido = ProfesManager.insertPlazaProfe(profe.getId().ToString(), plazaInfo.numero.ToString(),
                                    plazaInfo.porcAsignado, plazaInfo.isPropiedad);
                                if (!isValido)
                                {
                                    MessageBox.Show("Error al actualizar la plaza");
                                    exito = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (exito)
                    MessageBox.Show("Profesor editado correctamente");
            }
            else
            {
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
            }
        }

        private Profesor buscarProfesor()
        {
            String nombreProfesor = (String)cmb_Profes.SelectedValue;

            foreach (Profesor profe in profesList)
            {
                if (profe.getNombre() == nombreProfesor)
                    return profe;
            }

            return null;
        }

        private PlazaAsignada checkPlaza(List<PlazaAsignada> pPlazasAsignadas, int pId)
        {
            PlazaAsignada plazaAsignada = null;

            foreach (PlazaAsignada plaza in pPlazasAsignadas)
            {
                if (plaza.getPlaza().getId() == pId)
                {
                    plazaAsignada = plaza;
                    break;
                }
            }

            return plazaAsignada;
        }

        private void cmb_Profes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profesor profe = buscarProfesor();
            tbxNombre.Text = profe.getNombre();

            PlazaAsignada plazaAsignada = null;
            List<PlazaAsignada> plazasAsignadas = ProfesManager.getPlazasDeProfesor(profe.getId());

            foreach (Plazas_GUI plazaGUI in plazasListGUI)
            {
                plazaAsignada = checkPlaza(plazasAsignadas, plazaGUI.numero);
                if (plazaAsignada != null)
                {
                    plazaGUI.isSelected = true;
                    plazaGUI.isPropiedad = plazaAsignada.getIsPropiedad();
                    plazaGUI.porcAsignado = plazaAsignada.getPorcentajeAsig().ToString().Replace(",",".");
                }
                else
                {
                    plazaGUI.isSelected = false;
                    plazaGUI.isPropiedad = false;
                    plazaGUI.porcAsignado = null;
                }
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key > Key.D0 && e.Key < Key.D9) || e.Key == Key.OemPeriod))
            { 
                e.Handled = true;
            }
        }
    }
}
