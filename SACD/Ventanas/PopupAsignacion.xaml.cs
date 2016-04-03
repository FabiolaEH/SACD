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
using System.Windows.Shapes;
using SACD.Clases;
using SACD_Modelo;
using SACD_Controlador;


namespace SACD.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PopupAsignacion.xaml
    /// </summary>
    public partial class PopupAsignacion : Window
    {
        string modalidad; //simp - amp - dbamp
        int idProfesor;

        public PopupAsignacion(int profeId)
        {
            InitializeComponent();

            idProfesor = profeId;
            //Cargar actividades
            cargarGrupos();
            cargarActvsAdmin();
            cargarInvestig();

        }

        //cargar lista de actividades académicas
        public void cargarGrupos()
        {
            List<Grupo> grupos = ActividadesManager.listarGrupos();
            List<Grupos_GUI> gruposListGUI = new List<Grupos_GUI>();

            foreach (Grupo grupo in grupos)
            {
                gruposListGUI.Add(new Grupos_GUI() { nombre = grupo.getCurso().getNombre(),
                                                     numGrupo = grupo.getNumero(),
                                                     cantEstud = grupo.getCantEstudiantes(),
                                                     valHoras = grupo.getHoras(),
                                                     horasPresen = grupo.getCurso().getHorasPresen(),
                                                     id = grupo.getId(),
                                                     codCurso = grupo.getCurso().getCodigo()});
            }

            this.dgGrupos.ItemsSource = gruposListGUI;
        }

        //cargar lista de actividades administrativas
        public void cargarActvsAdmin()
        {
            List<ActvAdmin> actvsAdmin = ActividadesManager.listarAdministvs();
            List<ActvsAdmin_GUI> actvsAdminListGUI = new List<ActvsAdmin_GUI>();

            foreach (ActvAdmin admin in actvsAdmin)
            {
                actvsAdminListGUI.Add(new ActvsAdmin_GUI() { nombre = admin.getNombre(),
                                                             valHoras = admin.getHoras(),
                                                             id = admin.getId()});
            }

            this.dgAdmin.ItemsSource = actvsAdminListGUI;
        }

        //cargar lista de investigaciones
        public void cargarInvestig()
        {
            List<Investigacion> investigaciones = ActividadesManager.listarInvestigs();
            List<Investigs_GUI> investigsListGUI = new List<Investigs_GUI>();

            foreach (Investigacion invest in investigaciones)
            {
                investigsListGUI.Add(new Investigs_GUI() { id = invest.getId(),
                                                           nombre = invest.getNombre(),
                                                           valHoras = invest.getHoras(),
                                                           inicio = invest.getInicio(),
                                                           fin = invest.getFin() });
            }

            this.dgInvestig.ItemsSource = investigsListGUI;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void calcularHoras(object sender, RoutedEventArgs e)
        {
            if(modalidad.Equals("simp"))
            {
                int idGrupo = Int32.Parse((sender as Button).Uid);
                PopupTipoCurso ventTipoCurso = new PopupTipoCurso(idGrupo);
                ventTipoCurso.Show();
            }
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            //Recorrer tabla de cursos
            foreach (Grupos_GUI grupoInfo in dgGrupos.ItemsSource)
            {
                bool isChecked = grupoInfo.isSelected;
                if (isChecked)
                {
                    AsignacsManager.asignarActiv(grupoInfo.id, idProfesor, 1, grupoInfo.valHoras);
                    MessageBox.Show(grupoInfo.nombre);
                }
            }

            //Recorrer tabla de actividades adaministrativas
            foreach (ActvsAdmin_GUI adminInfo in dgAdmin.ItemsSource)
            {
                bool isChecked = adminInfo.isSelected;
                if (isChecked)
                {
                    AsignacsManager.asignarActiv(adminInfo.id, idProfesor, 1, adminInfo.valHoras);
                    MessageBox.Show(adminInfo.nombre);
                }
            }

            //Recorrer tabla de investigaciones
            foreach (Investigs_GUI investInfo in dgInvestig.ItemsSource)
            {
                bool isChecked = investInfo.isSelected;
                if (isChecked)
                {
                    AsignacsManager.asignarActiv(investInfo.id, idProfesor, 1, investInfo.valHoras);
                    MessageBox.Show(investInfo.nombre);
                }
            }
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButt = sender as RadioButton;
            if (radioButt.IsChecked.Value)
            {
                switch (radioButt.Content.ToString())
                {
                    case "Simple":
                        {
                            modalidad = "simp";
                            break;
                        }

                    case "Ampliación":
                        {
                            modalidad = "amp";
                            break;
                        }

                    case "Doble Ampliación":
                        {
                            modalidad = "dbamp";
                            break;
                        }
                }               
            }
        }
    }
}
