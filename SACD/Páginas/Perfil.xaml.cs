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
using SACD_Controlador;
using SACD_Modelo;
using SACD.Clases;

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        int idProfesor;

        public Perfil(int profeId)
        {
            InitializeComponent();

            //cargar info profesor
            idProfesor = profeId;
            Profesor profesor = ProfesManager.buscar(idProfesor);
            label_Prof.Content = profesor.getNombre();
            //label_HorasAsig.Content = profesor.getHorasAsig();

            //cargar plazas
            List<PlazasAsig_GUI> plazasListGUI = new List<PlazasAsig_GUI>();
            plazasListGUI.Add(new PlazasAsig_GUI() { id = 001, horas = 40, modalidad = "Propietario" });
            dgPlazas.ItemsSource = plazasListGUI;

            //cargar actividades
            List<ActivsAsig_GUI> activsListGUI = new List<ActivsAsig_GUI>();
            activsListGUI.Add(new ActivsAsig_GUI() { nombre = "Consejo de escuela", horas = 10, ampliacion = "-", dbAmpliacion = "-" });
            activsListGUI.Add(new ActivsAsig_GUI() { nombre = "Genética", horas = 13.5m, ampliacion = "-", dbAmpliacion = "-" });
            activsListGUI.Add(new ActivsAsig_GUI() { nombre = "Biotecnologia para Todos", horas = 5, ampliacion = "-", dbAmpliacion = "-" });
            dgActividades.ItemsSource = activsListGUI;
        }

        private void btn_Asignar_Click(object sender, RoutedEventArgs e)
        {
            Ventanas.PopupAsignacion popup = new Ventanas.PopupAsignacion(idProfesor);
            popup.Show();
        }
    }
}
