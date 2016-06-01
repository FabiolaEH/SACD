using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SACD_Controlador;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using SACD_Modelo;

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para CrearActividades.xaml
    /// </summary>
    public partial class CrearActividades : Page
    {
        List<Grupo> grupos = new List<Grupo>();
        public CrearActividades()
        {
            InitializeComponent();
            ocultarElementos(3);
        }

        private void ocultarElementos(int pActividad)
        {
            if (pActividad == 0)
            {
                tbxHoras.Visibility = Visibility.Hidden;
                lblHoras.Visibility = Visibility.Hidden;

                tbxCodigo.Visibility = Visibility.Visible;
                lblCodigo.Visibility = Visibility.Visible;

                tbxNombre.Visibility = Visibility.Visible;
                lblNombre.Visibility = Visibility.Visible;
                lblNombre.Margin = new Thickness(93, 155, 0, 0);
                tbxNombre.Margin = new Thickness(163, 155, 0, 0);

                dtFechaFinal.Visibility = Visibility.Hidden;
                lblFechaFin.Visibility = Visibility.Hidden;

                dtFechaInicio.Visibility = Visibility.Hidden;
                lblFechaInicio.Visibility = Visibility.Hidden;

                lblCantEst.Visibility = Visibility.Visible;
                lblNumGrupo.Visibility = Visibility.Visible;
                tbxCantEst.Visibility = Visibility.Visible;
                tbxNumGrupo.Visibility = Visibility.Visible;
                groupBox.Visibility = Visibility.Visible;
                btnAgregar.Visibility = Visibility.Visible;
                btnQuitar.Visibility = Visibility.Visible;
                listBox.Visibility = Visibility.Visible;
                lblHorasTeoricas.Visibility = Visibility.Visible;
                lblHorasPracticas.Visibility = Visibility.Visible;
                tbxTeoricas.Visibility = Visibility.Visible;
                tbxPracticas.Visibility = Visibility.Visible;
                tbxTeoricas.Text = "0";
                tbxPracticas.Text = "0";
            }
            else if (pActividad == 1)
            {
                lblNombre.Margin = new Thickness(143, 155, 0, 0);
                tbxNombre.Margin = new Thickness(238, 155, 0, 0);

                tbxCodigo.Visibility = Visibility.Hidden;
                lblCodigo.Visibility = Visibility.Hidden;

                tbxHoras.Visibility = Visibility.Visible;
                lblHoras.Visibility = Visibility.Visible;

                tbxNombre.Visibility = Visibility.Visible;
                lblNombre.Visibility = Visibility.Visible;

                dtFechaFinal.Visibility = Visibility.Visible;
                lblFechaFin.Visibility = Visibility.Visible;

                dtFechaInicio.Visibility = Visibility.Visible;
                lblFechaInicio.Visibility = Visibility.Visible;

                lblCantEst.Visibility = Visibility.Hidden;
                lblNumGrupo.Visibility = Visibility.Hidden;
                tbxCantEst.Visibility = Visibility.Hidden;
                tbxNumGrupo.Visibility = Visibility.Hidden;
                groupBox.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
                btnQuitar.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;
                lblHorasTeoricas.Visibility = Visibility.Hidden;
                lblHorasPracticas.Visibility = Visibility.Hidden;
                tbxTeoricas.Visibility = Visibility.Hidden;
                tbxPracticas.Visibility = Visibility.Hidden;
            }
            else if (pActividad == 2)
            {

                lblNombre.Margin = new Thickness(143, 155, 0, 0);
                tbxNombre.Margin = new Thickness(238, 155, 0, 0);

                tbxCodigo.Visibility = Visibility.Hidden;
                lblCodigo.Visibility = Visibility.Hidden;

                tbxHoras.Visibility = Visibility.Visible;
                lblHoras.Visibility = Visibility.Visible;

                tbxNombre.Visibility = Visibility.Visible;
                lblNombre.Visibility = Visibility.Visible;

                dtFechaFinal.Visibility = Visibility.Hidden;
                lblFechaFin.Visibility = Visibility.Hidden;

                dtFechaInicio.Visibility = Visibility.Hidden;
                lblFechaInicio.Visibility = Visibility.Hidden;

                lblCantEst.Visibility = Visibility.Hidden;
                lblNumGrupo.Visibility = Visibility.Hidden;
                tbxCantEst.Visibility = Visibility.Hidden;
                tbxNumGrupo.Visibility = Visibility.Hidden;
                groupBox.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
                btnQuitar.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;
                lblHorasTeoricas.Visibility = Visibility.Hidden;
                lblHorasPracticas.Visibility = Visibility.Hidden;
                tbxTeoricas.Visibility = Visibility.Hidden;
                tbxPracticas.Visibility = Visibility.Hidden;
            }
            else
            {
                tbxCodigo.Visibility = Visibility.Hidden;
                lblCodigo.Visibility = Visibility.Hidden;

                tbxNombre.Visibility = Visibility.Hidden;
                lblNombre.Visibility = Visibility.Hidden;

                tbxHoras.Visibility = Visibility.Hidden;
                lblHoras.Visibility = Visibility.Hidden;

                dtFechaFinal.Visibility = Visibility.Hidden;
                lblFechaFin.Visibility = Visibility.Hidden;

                dtFechaInicio.Visibility = Visibility.Hidden;
                lblFechaInicio.Visibility = Visibility.Hidden;

                lblCantEst.Visibility = Visibility.Hidden;
                lblNumGrupo.Visibility = Visibility.Hidden;
                tbxCantEst.Visibility = Visibility.Hidden;
                tbxNumGrupo.Visibility = Visibility.Hidden;
                groupBox.Visibility = Visibility.Hidden;
                btnAgregar.Visibility = Visibility.Hidden;
                btnQuitar.Visibility = Visibility.Hidden;
                listBox.Visibility = Visibility.Hidden;
                lblHorasTeoricas.Visibility = Visibility.Hidden;
                lblHorasPracticas.Visibility = Visibility.Hidden;
                tbxTeoricas.Visibility = Visibility.Hidden;
                tbxPracticas.Visibility = Visibility.Hidden;
            }
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            int valor = cmb_Actividad.SelectedIndex;
            if(valor == 0)
            {
                if (tbxNombre.Text.Trim().Equals("") || tbxCodigo.Text.Trim().Equals("") || grupos.Count <= 0 || tbxTeoricas.Text.Trim().Equals("") || tbxPracticas.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Favor no deja espacios en blanco.");
                }
                else
                {
                    decimal horasTeoricas = Decimal.Parse(tbxTeoricas.Text);
                    decimal horasPracticas = Decimal.Parse(tbxPracticas.Text);
                    if(horasTeoricas <= 0 && horasPracticas <= 0)
                    {
                        MessageBox.Show("Favor colocar alguno de los campos de horas con un valor positivo válido.");
                    }
                    else
                    {
                        Boolean isExitoso = ActividadesManager.crearActCurso(tbxNombre.Text.Trim(), tbxCodigo.Text.Trim());
                        if (isExitoso)
                        {

                            isExitoso = ActividadesManager.crearActGrupos(grupos);
                            if (isExitoso)
                            {
                                Boolean res = false;
                                if (!tbxTeoricas.Text.Trim().Equals("0"))
                                {
                                    isExitoso = ActividadesManager.crearTipoCursos(tbxCodigo.Text.Trim(), "TEOR", tbxTeoricas.Text);
                                    if (!isExitoso)
                                    {
                                        MessageBox.Show("Hubo un problema al insertar las horas teóricas del curso.");
                                    }
                                    else
                                        res = true;
                                }

                                if (!tbxPracticas.Text.Trim().Equals("0"))
                                {
                                    isExitoso = ActividadesManager.crearTipoCursos(tbxCodigo.Text.Trim(), "PRAC", tbxPracticas.Text);
                                    if (isExitoso)
                                    {
                                        res = true;
                                        tbxCodigo.Text = "";
                                        tbxNombre.Text = "";
                                        tbxCantEst.Text = "";
                                        tbxNumGrupo.Text = "";
                                        tbxTeoricas.Text = "0";
                                        tbxPracticas.Text = "0";
                                        listBox.Items.Clear();
                                        grupos.Clear();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hubo un problema al insertar las horas teóricas del curso.");
                                    }
                                }
                                if (res)
                                    MessageBox.Show("Actividad insertada correctamente.");
                                else
                                    MessageBox.Show("Hubo un problema al insertar la actividad.");
                            }
                            else
                            {
                                MessageBox.Show("Ha ocurrido un problema al insertar los grupos.");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al insertar el curso.");
                        }
                    }
                }
            }
            else if (valor == 1)
            {
                if (tbxNombre.Text.Trim().Equals("") || tbxHoras.Text.Trim().Equals("") ||
                    dtFechaInicio.Text.Trim().Equals("") || dtFechaFinal.Text.Trim().Equals("") )
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

                        Boolean isExitoso = ActividadesManager.crearActInvestigacion(tbxNombre.Text, Decimal.Parse(tbxHoras.Text), fechaInicio, fechaFin);
                        if (isExitoso)
                        {
                            MessageBox.Show("Actividad insertada correctamente.");
                            tbxHoras.Text = "";
                            tbxNombre.Text = "";
                            dtFechaInicio.Text = "";
                            dtFechaFinal.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al insertar la actividad.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Recuerde que la cantidad de horas debe estar compuesta por máximo 2 números enteros y opcionalmente 2 decimales.");
                    }
                }
            }
            else if(valor == 2)
            {
                if(tbxNombre.Text.Trim().Equals("") || tbxHoras.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Favor no deja espacios en blanco.");
                }
                else
                {
                    Regex pattern = new Regex("\\b[0-9]{1,2}\\b(\\,[0-9][0-9]?)?");
                    if (pattern.IsMatch(tbxHoras.Text))
                    {
                        Boolean isExitoso = ActividadesManager.crearActAdministrativa(tbxNombre.Text.ToString(), Decimal.Parse(tbxHoras.Text));
                        if (isExitoso)
                        {
                            MessageBox.Show("Actividad insertada correctamente.");
                            tbxHoras.Text = "";
                            tbxNombre.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema al insertar la actividad.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Recuerde que la cantidad de horas debe estar compuesta por máximo 2 números enteros y opcionalmente 2 decimales.");
                    }
                }
            }
        }

        private void ocultarCambios(object sender, SelectionChangedEventArgs e)
        {
            int valor = (sender as ComboBox).SelectedIndex;
            ocultarElementos(valor);
        }

        private void tbxHoras_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key.ToString().Equals("D0") || e.Key.ToString().Equals("D1") || e.Key.ToString().Equals("D2") ||
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
            if(tbxNumGrupo.Text.Trim().Equals("") || tbxCantEst.Text.Trim().Equals("") ||
               tbxCodigo.Text.Trim().Equals("") || tbxNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Favor completar todos los campos.");
            }
            else
            {
                Boolean isExitoso = true;
                for(int i = 0; i < grupos.Count; i++)
                {
                    if (grupos[i].getNumero() == Int32.Parse(tbxNumGrupo.Text.Trim())){
                        isExitoso = false;
                        MessageBox.Show("No se puede agregar un grupo con el mismo número.");
                    }
                }

                if (isExitoso)
                {
                    grupos.Add(new Grupo(0, "grup", 0, Int32.Parse(tbxNumGrupo.Text.Trim()), Int32.Parse(tbxCantEst.Text.Trim()), new Curso(tbxCodigo.Text.Trim(), tbxNombre.Text.Trim(), 0)));
                    listBox.Items.Add("Grupo: " + tbxNumGrupo.Text.Trim() + " - Estud: " + tbxCantEst.Text.Trim());
                }                
            }
        }

        private void btn_Quitar(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex != -1)
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
