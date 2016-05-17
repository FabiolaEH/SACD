using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para EliminarActividades.xaml
    /// </summary>
    public partial class EliminarActividades : Page
    {
        List<Curso> cursosList = new List<Curso>();
        List<Curso_GUI> cursosListGUI = new List<Curso_GUI>();

        List<Investigacion> investList = new List<Investigacion>();
        List<Investigs_GUI> investListGUI = new List<Investigs_GUI>();

        List<ActvAdmin> adminList = new List<ActvAdmin>();
        List<ActvsAdmin_GUI> adminListGUI = new List<ActvsAdmin_GUI>();
        List<int> idAsignaciones = new List<int>();

        public EliminarActividades()
        {
            InitializeComponent();
            ocultarElementos(3);
            actualizarTablaCursos();
            actualizarTablaInvest();
            actualizarTablaAdmin();
            cargarIdAsignaciones();
        }

        private void cargarIdAsignaciones()
        {
            List<int> listaAsignaciones = ActividadesManager.listarIdAsignaciones();

            foreach (int id in listaAsignaciones)
            {
                idAsignaciones.Add(id);
            }
        }

        private void actualizarTablaCursos()
        {
            cursosList = new List<Curso>();
            cursosListGUI = new List<Curso_GUI>();

            cursosList = ActividadesManager.listarCursos();

            foreach (Curso curso in cursosList)
            {
                cursosListGUI.Add(new Curso_GUI() { codigo = curso.getCodigo(), nombre = curso.getNombre() });
            }

            dgCursos.ItemsSource = cursosListGUI;
        }

        private void actualizarTablaAdmin()
        {
            adminList = new List<ActvAdmin>();
            adminListGUI = new List<ActvsAdmin_GUI>();

            adminList = ActividadesManager.listarAdministvs();
            foreach (ActvAdmin admin in adminList)
            {
                adminListGUI.Add(new ActvsAdmin_GUI() { id = admin.getId(), nombre = admin.getNombre() });
            }

            dgAdmin.ItemsSource = adminListGUI;
        }

        private void actualizarTablaInvest()
        {
            investList = new List<Investigacion>();
            investListGUI = new List<Investigs_GUI>();

            investList = ActividadesManager.listarInvestigs();
            foreach (Investigacion invest in investList)
            {
                investListGUI.Add(new Investigs_GUI() { id = invest.getId(), nombre = invest.getNombre(), inicio = invest.getInicio().Date, fin = invest.getFin().Date });
            }

            dgInvest.ItemsSource = investListGUI;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            int valor = cmb_Actividad.SelectedIndex;
            bool flag = false;
            if (valor == 0)
            {
                foreach (Curso_GUI cursoInfo in cursosListGUI)
                {
                    if (cursoInfo.isSelected)
                    {
                        for(int i = 0; i < idAsignaciones.Count; i++)
                        {
                            try
                            {
                                Grupo actividad = (Grupo)ActividadesManager.buscar(idAsignaciones[i]);
                                if (actividad != null)
                                {
                                    if (actividad.getCurso().getCodigo().Equals(cursoInfo.codigo))
                                    {
                                        flag = true;
                                        MessageBoxResult dialogResult = MessageBox.Show("El curso " + cursoInfo.nombre + " ya posee asignaciones. ¿Desea continuar?", "Atención", MessageBoxButton.YesNo);
                                        if (dialogResult == MessageBoxResult.Yes)
                                        {
                                            Boolean isValido = ActividadesManager.eliminarCursoAsig(cursoInfo.codigo, idAsignaciones[i]);
                                            if (!isValido)
                                                MessageBox.Show("Error al eliminar el curso.");
                                            else
                                                actualizarTablaCursos();
                                        }
                                    }
                                }
                            }catch(Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        if(flag == false)
                        {
                            Boolean isValido = ActividadesManager.eliminarCurso(cursoInfo.codigo);
                            if (!isValido)
                                MessageBox.Show("Error al eliminar el curso.");
                            else
                                actualizarTablaCursos();
                        }
                    }
                }
            }
            else if (valor == 1)
            {
                foreach (Investigs_GUI investInfo in investListGUI)
                {
                    if (investInfo.isSelected)
                    {
                        for (int i = 0; i < idAsignaciones.Count; i++)
                        {
                            try
                            {
                                Investigacion actividad = (Investigacion)ActividadesManager.buscar(idAsignaciones[i]);
                                if (actividad != null)
                                {
                                    if (actividad.getId().Equals(investInfo.id))
                                    {
                                        flag = true;
                                        MessageBoxResult dialogResult = MessageBox.Show("La investigación " + investInfo.nombre + " ya posee asignaciones. ¿Desea continuar?", "Atención", MessageBoxButton.YesNo);
                                        if (dialogResult == MessageBoxResult.Yes)
                                        {
                                            Boolean isValido = ActividadesManager.eliminarInvest(investInfo.id);
                                            if (!isValido)
                                                MessageBox.Show("Error al eliminar la investigación.");
                                            else
                                                actualizarTablaInvest();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        if(flag == false)
                        {
                            Boolean isValido = ActividadesManager.eliminarInvest(investInfo.id);
                            if (!isValido)
                                MessageBox.Show("Error al eliminar la investigación.");
                            else
                                actualizarTablaInvest();
                        }                        
                    }
                }
            }
            else if (valor == 2)
            {
                foreach (ActvsAdmin_GUI adminInfo in adminListGUI)
                {
                    if (adminInfo.isSelected)
                    {
                        for (int i = 0; i < idAsignaciones.Count; i++)
                        {
                            try
                            {
                                ActvAdmin actividad = (ActvAdmin)ActividadesManager.buscar(idAsignaciones[i]);
                                if (actividad != null)
                                {
                                    if (actividad.getId().Equals(adminInfo.id))
                                    {
                                        flag = true;
                                        MessageBoxResult dialogResult = MessageBox.Show("La actividad administrativa " + adminInfo.nombre + " ya posee asignaciones. ¿Desea continuar?", "Atención", MessageBoxButton.YesNo);
                                        if (dialogResult == MessageBoxResult.Yes)
                                        {
                                            Boolean isValido = ActividadesManager.eliminarAdmin(adminInfo.id);
                                            if (!isValido)
                                                MessageBox.Show("Error al eliminar la actividad administrativa.");
                                            else
                                                actualizarTablaAdmin();
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        if (flag == false)
                        {
                            Boolean isValido = ActividadesManager.eliminarAdmin(adminInfo.id);
                            if (!isValido)
                                MessageBox.Show("Error al eliminar la actividad administrativa.");
                            else
                                actualizarTablaAdmin();
                        }
                    }
                }
            }
        }


        private void ocultarElementos(int pActividad)
        {
            if (pActividad == 0)
            {
                dgCursos.Visibility = Visibility.Visible;
                dgInvest.Visibility = Visibility.Hidden;
                dgAdmin.Visibility = Visibility.Hidden;
            }
            else if (pActividad == 1)
            {
                dgCursos.Visibility = Visibility.Hidden;
                dgInvest.Visibility = Visibility.Visible;
                dgAdmin.Visibility = Visibility.Hidden;
            }
            else if (pActividad == 2)
            {
                dgCursos.Visibility = Visibility.Hidden;
                dgInvest.Visibility = Visibility.Hidden;
                dgAdmin.Visibility = Visibility.Visible;
            }
            else
            {
                dgCursos.Visibility = Visibility.Hidden;
                dgInvest.Visibility = Visibility.Hidden;
                dgAdmin.Visibility = Visibility.Hidden;
            }
        }

        private void ocultarCambios(object sender, SelectionChangedEventArgs e)
        {
            int valor = (sender as ComboBox).SelectedIndex;
            ocultarElementos(valor);
        }
    }
}
