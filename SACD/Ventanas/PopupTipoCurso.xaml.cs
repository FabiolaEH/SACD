using SACD.Clases;
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
using SACD_Controlador;

namespace SACD.Ventanas
{
    /// <summary>
    /// Lógica de interacción para PopupTipoCurso.xaml
    /// </summary>
    public partial class PopupTipoCurso : Window
    {
        string modalidad; //nuevo - exist - ant - paral1 - paral2
        int idGrupo;

        public PopupTipoCurso(int pIdGrupo)
        {
            InitializeComponent();
            idGrupo = pIdGrupo;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            //Actualizar las horas del PopupAsignación
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(PopupAsignacion))
                {
                    DataGrid dgGrupos = (window as PopupAsignacion).dgGrupos;

                    //Buscar la fila
                    foreach (Grupos_GUI grupoInfo in dgGrupos.ItemsSource)
                    {
                        if (grupoInfo.idGrupo == idGrupo)
                        {
                            
                            grupoInfo.valHoras = ActividadesManager.calcValorCurso(grupoInfo.idGrupo, 
                                                                                   grupoInfo.codCurso, 
                                                                                   modalidad, 
                                                                                   grupoInfo.cantEstud, 
                                                                                   grupoInfo.horasPresen);

                            //Actualizar tabla 
                            dgGrupos.Items.Refresh();
                        }
                    }
                }
            }

            this.Close();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButt = sender as RadioButton;
            if (radioButt.IsChecked.Value)
                switch (radioButt.Content.ToString()) 
                {
                    case "Nuevo":
                        {
                            modalidad = "nuevo";
                            break;
                        }

                    case "Existente":
                        {
                            modalidad = "exist";
                            break;
                        }

                    case "Impartido ant.":
                        {
                            modalidad = "ant";
                            break;
                        }

                    case "Paralelo 1":
                        {
                            modalidad = "paral1";
                            break;
                        }

                    case "Paralelo 2":
                        {
                            modalidad = "paral2";
                            break;
                        }
                }
        }
    }
}
