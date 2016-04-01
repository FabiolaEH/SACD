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

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : Page
    {
        public Reportes()
        {
            InitializeComponent();
            cargarInformacion();

        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            PopupRegistro popup = new PopupRegistro(1);
        }

        private void cargarInformacion()
        {
            String nombre;
            int anio = -1;
            int periodo;
            List<Profesor> profes = ProfesManager.listar();
            List<Semestre> semestres = SemestresManager.listar();
            foreach (Profesor profe in profes){
                nombre = profe.getNombre();
                cmb_Profe.Items.Add(nombre);
            }

            foreach (Semestre semestre in semestres)
            {
                if (semestre.getAnio() != anio)
                {
                    anio = semestre.getAnio();
                    cmb_Anio.Items.Add(anio);
                }
            }

            cmb_Semestre.Items.Add(1);
            cmb_Semestre.Items.Add(2);
        }
    }
}
