using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para EditarActividades.xaml
    /// </summary>
    public partial class EditarActividades : Page
    {
        List<Grupo> grupos = new List<Grupo>();
        List<Investigacion> invest_global = new List<Investigacion>();
        List<ActvAdmin> admin_global = new List<ActvAdmin>();
        List<Grupo> gruposNuevos = new List<Grupo>();
        List<string> idCursos = new List<string>();
        List<int> idInvestigaciones = new List<int>();
        List<int> idAdministrativas = new List<int>();
        string codigo;
        int idInvest, idAdmin;

        public EditarActividades()
        {
            InitializeComponent();
            ocultarElementos(3);
        }

        private void cargarComboboxCursos()
        {
            List<Curso> cursos = ActividadesManager.listarCursos();

            foreach (Curso curso in cursos)
            {
                cmb_cursos.Items.Add(curso.getNombre());
                idCursos.Add(curso.getCodigo());
            }
        }

        private void cargarComboboxInvestig()
        {
            List<Investigacion> investigaciones = ActividadesManager.listarInvestigs();
            invest_global = investigaciones;
            foreach (Investigacion inv in investigaciones)
            {
                cmb_invest.Items.Add(inv.getNombre());
                idInvestigaciones.Add(inv.getId());
            }
        }

        private void cargarComboboxAdmin()
        {
            List<ActvAdmin> administrativas = ActividadesManager.listarAdministvs();
            admin_global = administrativas;
            foreach (ActvAdmin adm in administrativas)
            {
                cmb_admin.Items.Add(adm.getNombre());
                idAdministrativas.Add(adm.getId());
            }
        }

        private void ocultarElementos(int pActividad)
        {
            tbxNombre.Text = "";
            tbxHoras.Text = "";
            listBox.Items.Clear();
            if (pActividad == 0)
            {
                cargarComboboxCursos();
                tbxHoras.Visibility = Visibility.Hidden;
                lblHoras.Visibility = Visibility.Hidden;

                tbxNombre.Visibility = Visibility.Visible;
                lblNombre.Visibility = Visibility.Visible;
                
                dtFechaFinal.Visibility = Visibility.Hidden;
                lblFechaFin.Visibility = Visibility.Hidden;

                dtFechaInicio.Visibility = Visibility.Hidden;
                lblFechaInicio.Visibility = Visibility.Hidden;

                lblCursos.Visibility = Visibility.Visible;
                lblInvestigaciones.Visibility = Visibility.Hidden;
                lblAdmin.Visibility = Visibility.Hidden;

                lblCantEst.Visibility = Visibility.Visible;
                lblNumGrupo.Visibility = Visibility.Visible;
                tbxCantEst.Visibility = Visibility.Visible;
                tbxNumGrupo.Visibility = Visibility.Visible;
                groupBox.Visibility = Visibility.Visible;
                btnAgregar.Visibility = Visibility.Visible;
                btnQuitar.Visibility = Visibility.Visible;
                listBox.Visibility = Visibility.Visible;

                cmb_cursos.Visibility = Visibility.Visible;
                cmb_admin.Visibility = Visibility.Hidden;
                cmb_invest.Visibility = Visibility.Hidden;
            }
            else if (pActividad == 1)
            {
                cargarComboboxInvestig();
                tbxHoras.Visibility = Visibility.Visible;
                lblHoras.Visibility = Visibility.Visible;

                tbxNombre.Visibility = Visibility.Visible;
                lblNombre.Visibility = Visibility.Visible;

                dtFechaFinal.Visibility = Visibility.Visible;
                lblFechaFin.Visibility = Visibility.Visible;

                dtFechaInicio.Visibility = Visibility.Visible;
                lblFechaInicio.Visibility = Visibility.Visible;
                
                lblCursos.Visibility = Visibility.Hidden;
                lblInvestigaciones.Visibility = Visibility.Visible;
                lblAdmin.Visibility = Visibility.Hidden;

                lblCantEst.Visibility = Visibility.Hidden;
                lblNumGrupo.Visibility = Visibility.Hidden;
                tbxCantEst.Visibility = Visibility.Hidden;
                tbxNumGrupo.Visibility = Visibility.Hidden;
                groupBox.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
                btnQuitar.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;

                cmb_cursos.Visibility = Visibility.Hidden;
                cmb_admin.Visibility = Visibility.Hidden;
                cmb_invest.Visibility = Visibility.Visible;
                
            }
            else if (pActividad == 2)
            {
                cargarComboboxAdmin();
                tbxHoras.Visibility = Visibility.Visible;
                lblHoras.Visibility = Visibility.Visible;

                tbxNombre.Visibility = Visibility.Visible;
                lblNombre.Visibility = Visibility.Visible;

                dtFechaFinal.Visibility = Visibility.Hidden;
                lblFechaFin.Visibility = Visibility.Hidden;

                dtFechaInicio.Visibility = Visibility.Hidden;
                lblFechaInicio.Visibility = Visibility.Hidden;

                lblCursos.Visibility = Visibility.Hidden;
                lblInvestigaciones.Visibility = Visibility.Hidden;
                lblAdmin.Visibility = Visibility.Visible;

                lblCantEst.Visibility = Visibility.Hidden;
                lblNumGrupo.Visibility = Visibility.Hidden;
                tbxCantEst.Visibility = Visibility.Hidden;
                tbxNumGrupo.Visibility = Visibility.Hidden;
                groupBox.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
                btnQuitar.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;

                cmb_cursos.Visibility = Visibility.Hidden;
                cmb_admin.Visibility = Visibility.Visible;
                cmb_invest.Visibility = Visibility.Hidden;
                
            }
            else
            {
                tbxNombre.Visibility = Visibility.Hidden;
                lblNombre.Visibility = Visibility.Hidden;

                tbxHoras.Visibility = Visibility.Hidden;
                lblHoras.Visibility = Visibility.Hidden;

                dtFechaFinal.Visibility = Visibility.Hidden;
                lblFechaFin.Visibility = Visibility.Hidden;

                dtFechaInicio.Visibility = Visibility.Hidden;
                lblFechaInicio.Visibility = Visibility.Hidden;
                    
                lblCursos.Visibility = Visibility.Hidden;
                lblInvestigaciones.Visibility = Visibility.Hidden;
                lblAdmin.Visibility = Visibility.Hidden;

                lblCantEst.Visibility = Visibility.Hidden;
                lblNumGrupo.Visibility = Visibility.Hidden;
                tbxCantEst.Visibility = Visibility.Hidden;
                tbxNumGrupo.Visibility = Visibility.Hidden;
                groupBox.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
                btnQuitar.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;
                
                cmb_cursos.Visibility = Visibility.Hidden;
                cmb_admin.Visibility = Visibility.Hidden;
                cmb_invest.Visibility = Visibility.Hidden;
            }

            tbxNombre.IsEnabled = false;
            tbxCantEst.IsEnabled = false;
            tbxNumGrupo.IsEnabled = false;
            btnAgregar.IsEnabled = false;
            btnQuitar.IsEnabled = false;
            listBox.IsEnabled = false;
            tbxHoras.IsEnabled = false;
            dtFechaFinal.IsEnabled = false;
            dtFechaInicio.IsEnabled = false;
            btn_Aceptar.IsEnabled = false;
        }

        private void ocultarCambios(object sender, SelectionChangedEventArgs e)
        {
            int valor = (sender as ComboBox).SelectedIndex;
            ocultarElementos(valor);
        }

        private void rellenarInfoAdmin(object sender, SelectionChangedEventArgs e)
        {
            int valor = (sender as ComboBox).SelectedIndex;
            if (valor >= 0)
            {
                idAdmin = idAdministrativas[valor];
                tbxNombre.Text = admin_global[valor].getNombre();
                tbxHoras.Text = admin_global[valor].getHoras().ToString();
            }

            tbxNombre.IsEnabled = true;
            tbxHoras.IsEnabled = true;
            btn_Aceptar.IsEnabled = true;
        }

        private void rellenarInfoInvest(object sender, SelectionChangedEventArgs e)
        {
            int valor = (sender as ComboBox).SelectedIndex;
            if (valor >= 0)
            {
                idInvest = idInvestigaciones[valor];
                tbxNombre.Text = invest_global[valor].getNombre();
                tbxHoras.Text = invest_global[valor].getHoras().ToString();
                dtFechaInicio.Text = invest_global[valor].getInicio().ToString();
                dtFechaFinal.Text = invest_global[valor].getFin().ToString();
            }
            tbxNombre.IsEnabled = true;
            tbxHoras.IsEnabled = true;
            dtFechaFinal.IsEnabled = true;
            dtFechaInicio.IsEnabled = true;
            btn_Aceptar.IsEnabled = true;
        }

        private void rellenarInfoCursos(object sender, SelectionChangedEventArgs e)
        {
            int valor = (sender as ComboBox).SelectedIndex;
            if(valor >= 0)
            {
                List<Curso> cursos_info = ActividadesManager.listarCursos();
                listBox.Items.Clear();

                foreach (Curso cur in cursos_info)
                {
                    if (cur.getCodigo().Equals(idCursos[valor]))
                    {
                        tbxNombre.Text = cur.getNombre();
                        codigo = idCursos[valor];
                        List<Grupo> grupos_info = ActividadesManager.getGrupoInfoCodigo(idCursos[valor]);
                        grupos = grupos_info;

                        foreach (Grupo gr in grupos_info)
                        {
                            listBox.Items.Add("Grupo: " + gr.getNumero().ToString() + " - Estud: " + gr.getCantEstudiantes().ToString());
                        }
                    }
                }
            }

            tbxNombre.IsEnabled = true;
            tbxCantEst.IsEnabled = true;
            tbxNumGrupo.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            btnQuitar.IsEnabled = true;
            listBox.IsEnabled = true;
            btn_Aceptar.IsEnabled = true;
        }
        
        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            int valor = -1;
            valor = cmb_Actividad.SelectedIndex;

            if (valor == 0)
            {
                if (tbxNombre.Text.Trim().Equals("")  || grupos.Count <= 0)
                {
                    MessageBox.Show("Favor no deja espacios en blanco.");
                }
                else
                {
                    String atributo = "NUM_GRUPO != ";
                    String consulta = "";

                    int cont = 0;
                    foreach(Grupo g in grupos)
                    {
                        cont++;
                        if(cont == grupos.Count())
                            consulta += atributo + g.getNumero();
                        else
                            consulta += atributo + g.getNumero() + " AND ";
                    }

                    Boolean isExitoso = ActividadesManager.eliminarGrupos(codigo, consulta);
                    
                    if (isExitoso)
                    {
                        try
                        {
                            if(gruposNuevos.Count > 0)
                                ActividadesManager.crearActGrupos(gruposNuevos);
                            isExitoso = ActividadesManager.editarCurso(codigo, tbxNombre.Text);
                            if (isExitoso)
                            {
                                MessageBox.Show("Grupos actualizados correctamente.");
                                int index = cmb_cursos.SelectedIndex;
                                cmb_cursos.Items.Insert(index, tbxNombre.Text);
                                cmb_cursos.Items.RemoveAt(index + 1);
                                cmb_cursos.SelectedIndex = index;

                                tbxNombre.Text = "";
                                tbxCantEst.Text = "";
                                tbxNumGrupo.Text = "";
                                listBox.Items.Clear();
                                gruposNuevos.Clear();
                                
                            }
                        } catch (Exception ex)
                        {
                            Console.WriteLine("Ha ocurrido un problema al insertar un grupo " + ex.ToString());   
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un problema al actualizar los grupos.");
                    }
                }
            }
            else if (valor == 1)
            {
                if (tbxNombre.Text.Trim().Equals("") || tbxHoras.Text.Trim().Equals("") ||
                    dtFechaInicio.Text.Trim().Equals("") || dtFechaFinal.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Favor no deja espacios en blanco.");
                }
                else
                {
                    Regex pattern = new Regex("\\b[0-9]{1,2}\\b(\\,[0-9][0-9]?)?");
                    if (pattern.IsMatch(tbxHoras.Text))
                    {
                        DateTime fechaInicio = Convert.ToDateTime(dtFechaInicio.Text);

                        DateTime fechaFin = Convert.ToDateTime(dtFechaFinal.Text);

                        Boolean isExitoso = ActividadesManager.editarInvestigacion(idInvest, tbxNombre.Text, Decimal.Parse(tbxHoras.Text), fechaInicio, fechaFin);
                        if (isExitoso)
                        {
                            MessageBox.Show("Investigación actualizada correctamente.");

                            int index = cmb_invest.SelectedIndex;
                            cmb_invest.Items.Insert(index, tbxNombre.Text);
                            cmb_invest.Items.RemoveAt(index + 1);

                            tbxHoras.Text = "";
                            tbxNombre.Text = "";
                            dtFechaInicio.Text = "";
                            dtFechaFinal.Text = "";

                            invest_global = ActividadesManager.listarInvestigs();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al actualizar la investigación.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Recuerde que la cantidad de horas debe estar compuesta por máximo 2 números enteros y opcionalmente 2 decimales.");
                    }
                }
            }
            else if (valor == 2)
            {
                if (tbxNombre.Text.Trim().Equals("") || tbxHoras.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Favor no deja espacios en blanco.");
                }
                else
                {
                    Regex pattern = new Regex("\\b[0-9]{1,2}\\b(\\,[0-9][0-9]?)?");
                    if (pattern.IsMatch(tbxHoras.Text))
                    {
                        Boolean isExitoso = ActividadesManager.editarAdmin(idAdmin, tbxNombre.Text.ToString(), Decimal.Parse(tbxHoras.Text));
                        if (isExitoso)
                        {
                            MessageBox.Show("Actividad administrativa actualizada correctamente.");

                            int index = cmb_admin.SelectedIndex;
                            cmb_admin.Items.Insert(index, tbxNombre.Text);
                            cmb_admin.Items.RemoveAt(index + 1);
                            
                            tbxHoras.Text = "";
                            tbxNombre.Text = "";

                            admin_global = ActividadesManager.listarAdministvs();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al actualizar la actividad administrativa.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Recuerde que la cantidad de horas debe estar compuesta por máximo 2 números enteros y opcionalmente 2 decimales.");
                    }
                }
            }
        }

        private void tbxHoras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Equals("D0") || e.Key.ToString().Equals("D1") || e.Key.ToString().Equals("D2") ||
               e.Key.ToString().Equals("D3") || e.Key.ToString().Equals("D4") || e.Key.ToString().Equals("D5") ||
               e.Key.ToString().Equals("D6") || e.Key.ToString().Equals("D7") || e.Key.ToString().Equals("D8") ||
               e.Key.ToString().Equals("D9") || e.Key.ToString().Equals("OemComma"))
            {

            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void tbxHoras_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbxOnlyNumbers(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Equals("D0") || e.Key.ToString().Equals("D1") || e.Key.ToString().Equals("D2") ||
               e.Key.ToString().Equals("D3") || e.Key.ToString().Equals("D4") || e.Key.ToString().Equals("D5") ||
               e.Key.ToString().Equals("D6") || e.Key.ToString().Equals("D7") || e.Key.ToString().Equals("D8") ||
               e.Key.ToString().Equals("D9"))
            {

            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void btn_Agregar(object sender, RoutedEventArgs e)
        {
            if (tbxNumGrupo.Text.Trim().Equals("") || tbxCantEst.Text.Trim().Equals("") ||
                tbxNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Favor completar todos los campos.");
            }
            else
            {
                Boolean isExitoso = true;
                for (int i = 0; i < grupos.Count; i++)
                {
                    if (grupos[i].getNumero() == Int32.Parse(tbxNumGrupo.Text.Trim()))
                    {
                        isExitoso = false;
                        MessageBox.Show("No se puede agregar un grupo con el mismo número.");
                    }
                }

                if (isExitoso)
                {
                    gruposNuevos.Add(new Grupo(0, "grup", 0, Int32.Parse(tbxNumGrupo.Text.Trim()), Int32.Parse(tbxCantEst.Text.Trim()), new Curso(codigo, tbxNombre.Text.Trim(), 0)));
                    listBox.Items.Add("Grupo: " + tbxNumGrupo.Text.Trim() + " - Estud: " + tbxCantEst.Text.Trim());
                }
            }
        }

        private void btn_Quitar(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                grupos.RemoveAt(listBox.SelectedIndex);
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún grupo.");
            }
        }
    }
}