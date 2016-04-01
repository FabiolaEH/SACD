using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
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


namespace SACD
{
    /// <summary>
    /// Lógica de interacción para PopupRegistro.xaml
    /// </summary>
    public partial class PopupRegistro : Window
    {
        String nombreProfesor = "";
        int periodo = 0;
        int año = 0;

        public PopupRegistro(String pNombreProfesor, int pPeriodo, int pAño)
        {
            InitializeComponent();

            nombreProfesor = pNombreProfesor;
            periodo = pPeriodo;
            año = pAño;

            cargarInformacion();
            dgDocencia.Items.Add(new Reporte_Docencia_GUI() { curso = "Introducción a la Biología", grp = 1, horas = 3, porc = 15});
            dgDocencia.Items.Add(new Reporte_Docencia_GUI() { curso = "Introducción a la Biología", grp = 1, horas = 3, porc = 15 });

            this.Show();
        }

        private void btnCerrarReporte_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmContenido_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void cargarInformacion()
        {
            label_ProfeReporte.Content = nombreProfesor;
            label_PeriodoReporte.Content = periodo;
            label_AnioReporte.Content = año;

            Profesor profe = ProfesManager.buscarPorNombre(nombreProfesor);
            label_cargaHorasReporte.Content = profe.getHorasAsig();

            decimal porcentaje = Decimal.Multiply(profe.getHorasAsig(), 100);
            porcentaje = Decimal.Divide(porcentaje, 40);
            label_cargaPorcReporte.Content = porcentaje;

            cargarTablas(profe.getId(), periodo, año);

        }

        private void cargarTablas(int pIdProfe, int pPeriodo, int pAño)
        {
            List<Asignacion> asignaciones = AsignacsManager.getAsignaciones(pIdProfe, pPeriodo, pAño);
            decimal horasTotalInve = 0;
            decimal horasTotalAdmi = 0;
            decimal horasTotalDoce = 0;
            decimal horasTotalAmpl = 0;
            decimal porcTotalInve = 0;
            decimal porcTotalAdmi = 0;
            decimal porcTotalDoce = 0;
            decimal porcTotalAmpl = 0;

            foreach (Asignacion asignacion in asignaciones)
            {
                if (asignacion.getActividad().getTipo() == "INVE")
                {
                    Investigacion inve = (Investigacion)asignacion.getActividad();
                    decimal porcInve = Decimal.Multiply(inve.getHoras(), 100);
                    porcInve = Decimal.Divide(porcInve, 40);

                    horasTotalInve += inve.getHoras();
                    porcTotalInve += porcInve;

                    dgInvestigacion.Items.Add(new Reporte_Investigacion_GUI() { proyecto = inve.getNombre(), horas = inve.getHoras(), porc = porcInve });
                }
                else if (asignacion.getActividad().getTipo() == "ADMI")
                {
                    ActvAdmin admi = (ActvAdmin)asignacion.getActividad();
                    decimal porcAdmi = Decimal.Multiply(admi.getHoras(), 100);
                    porcAdmi = Decimal.Divide(porcAdmi, 40);

                    horasTotalAdmi += admi.getHoras();
                    porcTotalAdmi += porcAdmi;

                    dgAdministracion.Items.Add(new Reporte_Admin_GUI() { actividad = admi.getNombre(), horas = admi.getHoras(), porc = porcAdmi });
                }
                else
                {

                }

                label_TotHrInvest.Content = horasTotalInve;
                label_TotPrInvest.Content = porcTotalInve;
                label_TotHrAdmi.Content = horasTotalAdmi;
                label_TotPrAdmi.Content = porcTotalAdmi;
            }
        }
    }
}
