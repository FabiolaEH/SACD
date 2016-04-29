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
        int idSemestre = 5;
        int periodo = 0;
        int año = 0;

        public PopupRegistro(String pNombreProfesor, int pPeriodo, int pAño)
        {
            InitializeComponent();

            nombreProfesor = pNombreProfesor;
            periodo = pPeriodo;
            año = pAño;

            cargarInformacion();
           
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
            /*label_cargaSimpleHorasReporte.Content = profe.getHorasAsig();

            decimal porcentaje = Decimal.Multiply(profe.getHorasAsig(), 100);
            porcentaje = Decimal.Divide(porcentaje, 40);
            label_cargaSimplePorcReporte.Content = porcentaje;*/

            cargarTablas(profe.getId(), periodo, año);

        }

        private void cargarTablas(int pIdProfe, int pPeriodo, int pAño)
        {
            cargarAsignaciones(pIdProfe, pPeriodo, pAño);
            cargarAmpliaciones(pIdProfe, pPeriodo, pAño);
        }

        private void cargarAsignaciones(int pIdProfe, int pPeriodo, int pAño)
        {
            List<Asignacion> asignaciones = AsignacsManager.getAsignaciones(pIdProfe, idSemestre, pPeriodo, pAño);
            decimal horasTotalInve = 0;
            decimal horasTotalAdmi = 0;
            decimal horasTotalDoce = 0;
            decimal porcTotalInve = 0;
            decimal porcTotalAdmi = 0;
            decimal porcTotalDoce = 0;

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
                    Grupo grupo = (Grupo)asignacion.getActividad();
                    decimal porcGrupo = Decimal.Multiply(asignacion.getValorHoras(), 100);
                    porcGrupo = Decimal.Divide(porcGrupo, 40);

                    horasTotalDoce += asignacion.getValorHoras();
                    porcTotalDoce += porcGrupo;


                    dgDocencia.Items.Add(new Reporte_Docencia_GUI()
                    {
                        curso = grupo.getCurso().getNombre(),
                        grp = grupo.getNumero(),
                        horas = asignacion.getValorHoras(),
                        porc = porcGrupo
                    });
                }

                label_TotHrInvest.Content = horasTotalInve;
                label_TotPrInvest.Content = porcTotalInve;
                label_TotHrAdmi.Content = horasTotalAdmi;
                label_TotPrAdmi.Content = porcTotalAdmi;
                label_TotHrDocencia.Content = horasTotalDoce;
                label_TotPrDocencia.Content = porcTotalDoce;
            }

            label_cargaSimplePorcReporte.Content = (porcTotalInve + porcTotalAdmi + porcTotalDoce);
            label_cargaSimpleHorasReporte.Content = (horasTotalInve + horasTotalAdmi + horasTotalDoce);
        }

        private void cargarAmpliaciones(int pIdProfe, int pPeriodo, int pAño)
        {
            List<Ampliacion> ampliaciones = AsignacsManager.getAmpliaciones(pIdProfe, pPeriodo, pAño);
            decimal horasTotalAmpl = 0;
            decimal porcTotalAmpl = 0;

            foreach (Ampliacion ampliacion in ampliaciones)
            {
                String doble = "";
                Grupo grupo = (Grupo)ampliacion.getActividad();
                decimal porcGrupo = Decimal.Multiply(ampliacion.getValorHoras(), 5);

                horasTotalAmpl += ampliacion.getValorHoras();
                porcTotalAmpl += porcGrupo;

                if (ampliacion.getIsDouble())
                {
                    doble = "X";
                }

                dgAmpliacion.Items.Add(new Reporte_Ampli_GUI()
                {
                    curso = grupo.getCurso().getNombre(),
                    db = doble,
                    horas = ampliacion.getValorHoras(),
                    porc = porcGrupo
                });
            }

            label_TotHrAmpli.Content = horasTotalAmpl;
            label_TotPrAmpli.Content = porcTotalAmpl;
        }
    }
}
