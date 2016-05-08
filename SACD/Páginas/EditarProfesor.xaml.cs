using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            actualizarTabla();
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

        private void actualizarTabla()
        {
            foreach (Plaza plaza in plazasList)
            {
                plazasListGUI.Add(new Plazas_GUI() { numero = plaza.getId(), porcentaje = plaza.getPorcentaje() });
            }

            dgPlazas.ItemsSource = plazasListGUI;
        }


        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(tbxNombre.Text != "")
            {
                //Primero insertar el profesor
                Boolean isValido = ProfesManager.crear(tbxNombre.Text);
                if (!isValido)
                    MessageBox.Show("Error al insertar el profesor");
                else
                {
                    //Obtener ID del profe insertado
                    int idProfe = ProfesManager.getUltimoProfesor();

                    //Crear relación Plaza_Profesor
                    foreach (Plazas_GUI plazaInfo in plazasListGUI)
                    {
                        if (plazaInfo.porcAsignado != null)
                        {
                            isValido = ProfesManager.insertPlazaProfe(idProfe.ToString(), plazaInfo.numero.ToString(),
                                plazaInfo.porcAsignado, plazaInfo.isPropiedad);
                            if (!isValido)
                            {
                                MessageBox.Show("Error al ligar la plaza");
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
            }
        }

        private void cmb_Profes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*int id = Int32.Parse((String)cmb_Plazas.SelectedValue);
            tbxNumero.Text = id.ToString();

            foreach (Plaza plaza in plazasList)
            {
                if (plaza.getId() == id)
                {
                    tbxPorcentaje.Text = plaza.getPorcentaje().ToString().Replace(",", ".");
                    tbxPorcentaje.IsEnabled = true;
                    btn_Aceptar.IsEnabled = true;
                }
            }*/
        }
    }
}
