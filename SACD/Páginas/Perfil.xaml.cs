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
        int idSemestre = 5;
        int periodo = 1;
        int anio = 2016;

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
            cargarAsignaciones();
        }

        public void cargarAsignaciones()
        {
            string actvNombre = "";
            Grupo grupo;
            ActvAdmin actv;
            Investigacion investg;
            List<ActivsAsig_GUI> activsListGUI = new List<ActivsAsig_GUI>();

            //Asignaciones simples
            List<Asignacion> asignaciones = AsignacsManager.getAsignaciones(idProfesor, idSemestre, periodo, anio);

            foreach (Asignacion asig in asignaciones)
            {
                
                if (asig.getActividad().getTipo().Equals("GRUP"))
                {
                    grupo = (Grupo)asig.getActividad();
                    actvNombre = grupo.getCurso().getNombre();
                }

                else if (asig.getActividad().getTipo().Equals("ADMI"))
                {
                    actv = (ActvAdmin)asig.getActividad();
                    actvNombre = actv.getNombre();
                }

                else
                {
                    investg = (Investigacion)asig.getActividad();
                    actvNombre = investg.getNombre();
                }

                activsListGUI.Add(new ActivsAsig_GUI(){ nombre = actvNombre,
                                                        ampliacion = "-",
                                                        dbAmpliacion = "-",
                                                        horas = asig.getValorHoras() });
            }

           /* //Ampliaciones
            List<Ampliacion> ampliaciones = AsignacsManager.getAmpliaciones(idProfesor, periodo, anio);

            foreach(Ampliacion ampl in ampliaciones)
            {
                if (ampl.getActividad().getTipo().Equals("GRUP"))
                {
                    grupo = (Grupo)ampl.getActividad();
                    actvNombre = grupo.getCurso().getNombre();

                }*/

            dgActividades.ItemsSource = activsListGUI;






        }

    private void btn_Asignar_Click(object sender, RoutedEventArgs e)
        {
            Ventanas.PopupAsignacion popup = new Ventanas.PopupAsignacion(idProfesor);
            popup.Show();
        }
    }
}
