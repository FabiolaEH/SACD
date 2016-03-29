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

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Page
    {
        public Perfil(/*int profesorId*/)
        {
            InitializeComponent();

            //Info profesor
            Profesor profesor = ProfesManager.buscar(1/*profesorId*/);
            label_Prof.Content = profesor.getNombre();
            label_HorasAsig.Content = profesor.getHorasAsig();

            //Cargar listas de actividades
            //cargarGrupos();
            cargarActvsAdmin();
            cargarInvestig();


        }

        //cargar lista de actividades académicas
        public void cargarGrupos()
        {
            List<Grupo> grupos = ActividadesManager.listarGrupos();
            CheckBox checkBoxField;

            foreach (Grupo grupo in grupos)
            {
                checkBoxField = new CheckBox();
                checkBoxField.Content = grupo.getCurso().getNombre() + " - Grupo " + grupo.getNumero() + " - "+ grupo.getHoras() + " hrs";
                listbx_Grupos.Items.Add(checkBoxField);
            }
        }

        //cargar lista de actividades administrativas
        public void cargarActvsAdmin()
        {
            List<ActvAdmin> actvsAdmin = ActividadesManager.listarAdministvs();
            CheckBox checkBoxField;

            foreach (ActvAdmin admin in actvsAdmin)
            {
                checkBoxField = new CheckBox();
                checkBoxField.Content = admin.getNombre() + " - " + admin.getHoras() + " hrs";
                listbx_Admin.Items.Add(checkBoxField);
            }
        }

        //cargar lista de investigaciones
        public void cargarInvestig()
        {
            List<Investigacion> investigaciones = ActividadesManager.listarInvestigs();
            CheckBox checkBoxField;

            foreach (Investigacion invest in investigaciones)
            {
                checkBoxField = new CheckBox();
                checkBoxField.Content = invest.getNombre() + " - " + invest.getHoras() + " hrs";
                //string str = (string)checkBoxField.Content;
                //checkBoxField.Click += (RoutedEventHandler) new EventHandler(listbx_Grupos_Item_Click); 
                listbx_Investig.Items.Add(checkBoxField);
            }



    }



        private void listbx_Grupos_Item_Click(object sender, EventArgs e)
        {
            // Instantiate the dialog box
            Ventanas.Parametros dlg = new Ventanas.Parametros();

            // Configure the dialog box
            /* dlg.Owner = this;
             dlg.DocumentMargin = this.documentTextBox.Margin;*/

            // Open the dialog box modally 
            dlg.ShowDialog();
        }

        private void checkBox_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Instantiate the dialog box
            Ventanas.Parametros dlg = new Ventanas.Parametros();

            // Configure the dialog box
            /* dlg.Owner = this;
             dlg.DocumentMargin = this.documentTextBox.Margin;*/

            // Open the dialog box modally 
            dlg.ShowDialog();
        }
    }
}
