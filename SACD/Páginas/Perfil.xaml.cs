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
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;     
        int idProfesor;
        int idSemestre;
        int periodo;
        int anio;

        public Perfil(int profeId)
        {
            InitializeComponent();

            //Obtener info semestre
            idSemestre = mainWindow.semestre_global;
            periodo = mainWindow.periodo_global;
            anio = mainWindow.anio_global;

            //cargar info profesor
            idProfesor = profeId;
            Profesor profesor = ProfesManager.buscar(idProfesor);
            label_Prof.Content = profesor.getNombre();
            //label_HorasAsig.Content = profesor.getHorasAsig();

            //cargar plazas
            cargarPlazas();

            //cargar actividades
            cargarAsignaciones();
        }

        public void cargarPlazas()
        {
            List<PlazasAsig_GUI> plazasListGUI = new List<PlazasAsig_GUI>();
            List<PlazaAsignada> plazasAsignadasList = new List<PlazaAsignada>();
            plazasAsignadasList = ProfesManager.getPlazasDeProfesor(idProfesor);
            foreach (PlazaAsignada plaza in plazasAsignadasList)
            {
                string idPlaza = plaza.getPlaza().getId();
                decimal cantHoras = plaza.getHorAsig();
                Boolean tipo = plaza.getIsPropiedad();
                string tipo_modalidad = "Interino";
                if (tipo)
                    tipo_modalidad = "Propietario";
                plazasListGUI.Add(new PlazasAsig_GUI() { id = idPlaza, horas = cantHoras, modalidad = tipo_modalidad});
            }
            dgPlazas.ItemsSource = plazasListGUI;
        }

        public void cargarAsignaciones()
        {
            string actvNombre = "";
            Grupo grupo;
            ActvAdmin actv;
            Investigacion investg;
            List<ActivsAsig_GUI> activsListGUI = new List<ActivsAsig_GUI>();

            //Asignaciones simples
            List<Asignacion> asignaciones = AsignacsManager.getAsignaciones(idProfesor, idSemestre, periodo, anio, false);

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

            //Ampliaciones
            List<Ampliacion> ampliaciones = AsignacsManager.getAmpliaciones(idProfesor, idSemestre, periodo, anio);

            foreach (Ampliacion ampl in ampliaciones)
            {
                if (ampl.getActividad().getTipo().Equals("GRUP"))
                {
                    string amp = "-";
                    string dobAmp = "-";
                    grupo = (Grupo)ampl.getActividad();
                    actvNombre = grupo.getCurso().getNombre();
                    if (ampl.getIsDouble())
                        dobAmp = "X";
                    else
                        amp = "X";

                    activsListGUI.Add(new ActivsAsig_GUI()
                    {
                        nombre = actvNombre,
                        ampliacion = amp,
                        dbAmpliacion = dobAmp,
                        horas = ampl.getValorHoras()
                    });
                }
            }
            dgActividades.ItemsSource = activsListGUI;






        }

    private void btn_Asignar_Click(object sender, RoutedEventArgs e)
        {
            Ventanas.PopupAsignacion popup = new Ventanas.PopupAsignacion(idProfesor);
            popup.Show();
        }
    }
}
