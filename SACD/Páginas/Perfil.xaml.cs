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

            /* //cargar listboxes         
             CheckBox checkBoxField = new CheckBox();
             checkBoxField.Content = "Grupo 1 --- 2hrs";
             string str = (string) checkBoxField.Content;

             MessageBoxButton button = MessageBoxButton.YesNoCancel;
             MessageBoxImage icon = MessageBoxImage.Warning;

             MessageBox.Show(str, "Titulo", button, icon);


             list_Grupos.Items.Add(checkBoxField);*/

            cargarInvestig();

        }

        //cargar lista de actividades académicas
        public void cargarGrupos()
        {

        }

        //cargar lista de actividades administrativas
        public void cargarActvAdmin()
        {

        }

        //cargar lista de investigaciones
        public void cargarInvestig()
        {
            List<Investigacion> investigaciones = ActividadesManager.listarInvestig();
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
    }
}
