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
        public PopupAsignacion()
        {
            InitializeComponent();

            //Cargar actividades
            cargarGrupos();

        }

        //cargar lista de actividades académicas
        public void cargarGrupos()
        {
            List<Grupo> grupos = ActividadesManager.listarGrupos();
            List<Grupos_GUI> gruposListGUI = new List<Grupos_GUI>();

            foreach (Grupo grupo in grupos)
            {
                gruposListGUI.Add(new Grupos_GUI() { curso = grupo.getCurso().getNombre(), numGrupo = grupo.getNumero(), valHoras = 0, idGrupo = grupo.getId(), isSelected = true });
            }

            this.dgGrupos.ItemsSource = gruposListGUI;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void calcularHoras(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Uid.ToString());
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Grupos_GUI grupoInfo in dgGrupos.ItemsSource)
            {
                bool isChecked = grupoInfo.isSelected;
                if (isChecked)
                    MessageBox.Show(grupoInfo.curso);
            }
        }
    }
}
