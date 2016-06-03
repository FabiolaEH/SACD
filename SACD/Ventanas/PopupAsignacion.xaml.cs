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
        Profesor profeInfo = null;
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
        string modalidad; //simp - amp - dbamp
        int idSemestre;
        int periodo;
        int anio;
        List<int> desmarcadosSim = new List<int>();
        List<int> desmarcadosAmp = new List<int>();

        public PopupAsignacion(int profeId)
        {
            InitializeComponent();

            //Obtener info semestre
            idSemestre = mainWindow.semestre_global;
            periodo = mainWindow.periodo_global;
            anio = mainWindow.anio_global;

            //Cargar actividades
            cargarGrupos();
            cargarActvsAdmin();
            cargarInvestig();

            //Obtener info profesor
            profeInfo = new Profesor(profeId, "");
            List<PlazaAsignada> plazasProfe = ProfesManager.getPlazasDeProfesor(profeId);
            List<Asignacion> asignacionesProf = AsignacsManager.getAsignaciones(profeInfo.getId(), idSemestre, periodo, anio, false);
            List<Ampliacion> ampliacionesProf = AsignacsManager.getAmpliaciones(profeInfo.getId(), idSemestre, periodo, anio);
            profeInfo.setPlazas(plazasProfe);
            profeInfo.setAsignaciones(asignacionesProf);
            profeInfo.setAmpliaciones(ampliacionesProf);

            cargarAsigProf();
            label_HorasAsig.Content = ProfesManager.calcHorasAsig(profeInfo);
            label_HorasMin.Content = ProfesManager.calcHorasMin(profeInfo);
        }


        //cargar lista de actividades académicas
        public void cargarGrupos()
        {
            List<Grupo> grupos = ActividadesManager.listarGrupos();
            List<Grupos_GUI> gruposListGUI = new List<Grupos_GUI>();

            foreach (Grupo grupo in grupos)
            {
                gruposListGUI.Add(new Grupos_GUI()
                {
                    nombre = grupo.getCurso().getNombre(),
                    numGrupo = grupo.getNumero(),
                    cantEstud = grupo.getCantEstudiantes(),
                    valHoras = grupo.getHoras(),
                    horasPresen = grupo.getCurso().getHorasPresen(),
                    id = grupo.getId(),
                    codCurso = grupo.getCurso().getCodigo()
                });
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
                actvsAdminListGUI.Add(new ActvsAdmin_GUI()
                {
                    nombre = admin.getNombre(),
                    valHoras = admin.getHoras(),
                    id = admin.getId()
                });
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
                investigsListGUI.Add(new Investigs_GUI()
                {
                    id = invest.getId(),
                    nombre = invest.getNombre(),
                    valHoras = invest.getHoras(),
                    inicio = invest.getInicio(),
                    fin = invest.getFin()
                });
            }

            this.dgInvestig.ItemsSource = investigsListGUI;
        }


        //marcar asignaciones según modalidad
        public void cargarAsigProf()
        {           
            List<Asignacion> asignacionesProf = profeInfo.getAsignaciones();
            List<Ampliacion> ampliacionesProf = profeInfo.getAmpliaciones();

            //Desmarcar actvs previas
            unCheckActivs();

            if (modalidad.Equals("simp"))
            {
                foreach (Asignacion asig in asignacionesProf)
                {
                    Actividad actv = asig.getActividad();
                    checkActiv(actv, asig, null);
                }
            }

            else //Ampliaciones
            {
                foreach (Ampliacion ampl in ampliacionesProf)
                {
                    if(modalidad.Equals("amp") && ampl.getIsDouble() == false)
                    {
                        Actividad actv = ampl.getActividad();
                        checkActiv(actv, null, ampl);
                    }

                    else if(modalidad.Equals("dbamp") && ampl.getIsDouble() == true)
                    {
                        Actividad actv = ampl.getActividad();
                        checkActiv(actv, null, ampl);
                    }   
                }
            }

            //Actualizar tablas 
            dgGrupos.Items.Refresh();
            dgAdmin.Items.Refresh();
            dgInvestig.Items.Refresh();
        }


        //Marca la actividad y le modifica las horas si es un curso
        private void checkActiv(Actividad pActv, Asignacion pAsig, Ampliacion pAmp)
        {
            //Marcar actividades
            if (pActv.getTipo().Equals("GRUP"))
            {
                foreach (Grupos_GUI grupoInfo in dgGrupos.ItemsSource)
                {
                    if (grupoInfo.id == pActv.getId())
                    {
                        grupoInfo.isSelected = true;
                        //actualizar horas
                        if (modalidad.Equals("simp"))
                            grupoInfo.valHoras = pAsig.getValorHoras();
                        else
                            grupoInfo.valHoras = pAmp.getValorHoras(); 
                    }
                }
            }

            else if (pActv.getTipo().Equals("ADMI"))
            {
                foreach (ActvsAdmin_GUI admiInfo in dgAdmin.ItemsSource)
                {
                    if (admiInfo.id == pActv.getId())
                    {
                        admiInfo.isSelected = true;
                        //actualizar horas
                        if (modalidad.Equals("simp"))
                            admiInfo.valHoras = pAsig.getValorHoras();
                        else
                            admiInfo.valHoras = pAmp.getValorHoras();
                    }
                }
            }

            else //Investigaciones
            {
                foreach (Investigs_GUI investInfo in dgInvestig.ItemsSource)
                {
                    if (investInfo.id == pActv.getId())
                    {
                        investInfo.isSelected = true;
                        //actualizar horas
                        if (modalidad.Equals("simp"))
                            investInfo.valHoras = pAsig.getValorHoras();
                        else
                            investInfo.valHoras = pAmp.getValorHoras();
                    }
                }
            }
        }


        private void unCheckActivs()
        {  
            foreach (Grupos_GUI grupoInfo in dgGrupos.ItemsSource)
            {
                grupoInfo.isSelected = false;
            }

            foreach (ActvsAdmin_GUI admiInfo in dgAdmin.ItemsSource)
            {
                admiInfo.isSelected = false;
            }

            foreach (Investigs_GUI investInfo in dgInvestig.ItemsSource)
            {
                investInfo.isSelected = false;
            }   
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

            else //calcular valor en ampliación
            { }
        }

        //Guardar cambios realizados en las asignaciones del profesor
        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            //eliminar deseleccionadas
            eliminarAsigs();

            //Guardar nuevas asignaciones seleccionadas
            string msj = guardarAsigs();

            

            MessageBox.Show(msj);    
        }
   

        //Elimina las asignaciones del profesor que fueron deseleccionadas
        private void eliminarAsigs()
        {
            if (modalidad.Equals("simp"))
            {
                foreach (int idActiv in desmarcadosSim)
                {
                    AsignacsManager.borrarAsignacion(idActiv, profeInfo.getId(), idSemestre);
                    profeInfo.borrarAsignacion(idActiv);
                }
            }

            else //ampliaciones
            {
                foreach (int idGrupo in desmarcadosAmp)
                {
                    AsignacsManager.borrarAmpliacion(idGrupo, profeInfo.getId(), idSemestre);
                    profeInfo.borrarAmpliacion(idGrupo);
                }
            }
        }


        //Guarda las asignaciones que fueron seleccionadas
        private string guardarAsigs()
        {
            string msj = "";

            //Recorrer tabla de cursos
            int estado = 0;
            bool tipoAmpl = false;
            bool tiempoValido = false; //indica si la ampliación es válida

            foreach (Grupos_GUI grupoInfo in dgGrupos.ItemsSource)
            {
                bool isChecked = grupoInfo.isSelected;
                if (isChecked)
                {
                    if (modalidad.Equals("simp"))
                    {
                        estado = AsignacsManager.asignarActiv(grupoInfo.id, profeInfo.getId(), idSemestre, grupoInfo.valHoras);
                        if (estado == 1)//la asig es nueva o hay que modificar una existente
                        {
                            Asignacion asigBuscada = profeInfo.buscarAsig(grupoInfo.id);

                            if (asigBuscada != null) //ya existe
                                asigBuscada.setValorHoras(grupoInfo.valHoras); //aplicar actualización
                            else
                                profeInfo.addAsignacion(new Asignacion(grupoInfo.valHoras, new Grupo(grupoInfo.id, "GRUP",
                                                        grupoInfo.horasPresen, grupoInfo.numGrupo, grupoInfo.cantEstud,
                                                        null), new Semestre(idSemestre, anio, periodo)));
                        }
                    }

                    else //Ampliacion
                    {
                        tiempoValido = false; //indica si la ampliación es válida

                        if (modalidad.Equals("amp"))
                        {
                            tipoAmpl = false;

                            if (profeInfo.getHorasAmplSimp() + grupoInfo.valHoras <= 4)
                            {
                                tiempoValido = true;
                                estado = AsignacsManager.asignarAmpl(grupoInfo.id, profeInfo.getId(), idSemestre, grupoInfo.valHoras, 0);
                            }   
                        }

                        else //doble
                        {
                            tipoAmpl = true;

                            if (profeInfo.getHorasAmplDb() + grupoInfo.valHoras <= 4)
                            {
                                tiempoValido = true;
                                estado = AsignacsManager.asignarAmpl(grupoInfo.id, profeInfo.getId(), idSemestre, grupoInfo.valHoras, 1);
                            }                         
                        }

                        if (estado == 1 && tiempoValido == true)//solo se insertan ampliaciones nuevas (NO se modifican)
                        {
                           /* Ampliacion amplBuscada = profeInfo.buscarAmpl(grupoInfo.id);

                            if (amplBuscada != null)//ya existe
                                amplBuscada.setValorHoras(grupoInfo.valHoras); //aplicar actualización
                            else*/
                                
                            profeInfo.addAmpliacion(new Ampliacion(grupoInfo.valHoras, new Grupo(grupoInfo.id, "GRUP",
                                                    grupoInfo.horasPresen, grupoInfo.numGrupo, grupoInfo.cantEstud,
                                                    null), new Semestre(idSemestre, anio, periodo), tipoAmpl));
                        }
                    }   
                }
            }

            //Recorrer tabla de actividades adaministrativas
            int tipoAmp = 0;
            foreach (ActvsAdmin_GUI adminInfo in dgAdmin.ItemsSource)
            {
                bool isChecked = adminInfo.isSelected;
                if (isChecked)
                {
                    if (modalidad.Equals("simp"))
                    {
                        AsignacsManager.asignarActiv(adminInfo.id, profeInfo.getId(), idSemestre, adminInfo.valHoras);
                        profeInfo.addAsignacion(new Asignacion(adminInfo.valHoras, new ActvAdmin(adminInfo.id, "ADMI",
                                                adminInfo.valHoras, adminInfo.nombre), new Semestre(idSemestre, anio, periodo)));
                    }

                    else //Ampliacion
                    {
                        tiempoValido = false;

                        if (modalidad.Equals("amp"))
                        {
                            if (profeInfo.getHorasAmplSimp() + adminInfo.valHoras <= 4)
                                tiempoValido = true;
                        }

                        if (modalidad.Equals("dbamp"))
                        {
                            if (profeInfo.getHorasAmplDb() + adminInfo.valHoras <= 4)
                            {
                                tiempoValido = true;
                                tipoAmp = 1;
                            }
                        }

                        if (tiempoValido)
                        {
                            AsignacsManager.asignarAmpl(adminInfo.id, profeInfo.getId(), idSemestre, adminInfo.valHoras, tipoAmp);
                            profeInfo.addAmpliacion(new Ampliacion(adminInfo.valHoras, new ActvAdmin(adminInfo.id, "ADMI",
                                                            adminInfo.valHoras, adminInfo.nombre), new Semestre(idSemestre, anio, periodo), tipoAmpl));
                        }
                    }
                }
            }

            //Recorrer tabla de investigaciones
            tipoAmp = 0;
            foreach (Investigs_GUI investInfo in dgInvestig.ItemsSource)
            {
                bool isChecked = investInfo.isSelected;
                if (isChecked)
                {
                    if (modalidad.Equals("simp"))
                    {
                        AsignacsManager.asignarActiv(investInfo.id, profeInfo.getId(), idSemestre, investInfo.valHoras);
                        profeInfo.addAsignacion(new Asignacion(investInfo.valHoras, new Investigacion(investInfo.id, "INVE",
                                                investInfo.valHoras, investInfo.nombre, investInfo.inicio, investInfo.fin), 
                                                new Semestre(idSemestre, anio, periodo)));
                    }

                    else //Ampliacion
                    {
                        tiempoValido = false;

                        if (modalidad.Equals("amp"))
                        {
                            if (profeInfo.getHorasAmplSimp() + investInfo.valHoras <= 4)
                                tiempoValido = true;
                        }

                        if (modalidad.Equals("dbamp"))
                        {
                            if (profeInfo.getHorasAmplDb() + investInfo.valHoras <= 4)
                            {
                                tiempoValido = true;
                                tipoAmp = 1;
                            }
                        }

                        if (tiempoValido)
                        {
                            AsignacsManager.asignarAmpl(investInfo.id, profeInfo.getId(), idSemestre, investInfo.valHoras, tipoAmp);
                            profeInfo.addAmpliacion(new Ampliacion(investInfo.valHoras, new Investigacion(investInfo.id, "INVE",
                                                    investInfo.valHoras, investInfo.nombre, investInfo.inicio, investInfo.fin),
                                                    new Semestre(idSemestre, anio, periodo), tipoAmpl));
                        }
                    }
                }
            }

            return msj;
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

                if (profeInfo != null)
                {
                    cargarGrupos(); //para limpiar horas
                    cargarAsigProf();
                }
            }
        }


        private void addDesmarcados(int pIdGrupo)
        {
            if (modalidad.Equals("simp"))
            {
                if (!desmarcadosSim.Contains(pIdGrupo))
                    desmarcadosSim.Add(pIdGrupo);
            }

            else //ampliaciones
            {
                if (!desmarcadosAmp.Contains(pIdGrupo))
                    desmarcadosAmp.Add(pIdGrupo);
            }
        }

        private void removDesmarcados(int pIdGrupo)
        {
            if (modalidad.Equals("simp"))
            {
                if (desmarcadosSim.Contains(pIdGrupo))
                    desmarcadosSim.Remove(pIdGrupo);
            }

            else //ampliaciones
            {
                if (desmarcadosAmp.Contains(pIdGrupo))
                    desmarcadosAmp.Remove(pIdGrupo);
            }
        }

        private void checkbx_SelectCu_Click(object sender, RoutedEventArgs e)
        {
            int idGrupo;
            idGrupo = Int32.Parse((sender as CheckBox).Uid);

            if ((sender as CheckBox).IsChecked == false) //deseleccionado
                addDesmarcados(idGrupo);

            else //seleccionado
                removDesmarcados(idGrupo);           
        }

        private void checkbx_SelectAc_Click(object sender, RoutedEventArgs e)
        {
            int idGrupo;
            idGrupo = Int32.Parse((sender as CheckBox).Uid);

            if ((sender as CheckBox).IsChecked == false) //deseleccionado
                addDesmarcados(idGrupo);

            else //seleccionado
                removDesmarcados(idGrupo);
        }

        private void checkbx_SelectIn_Click(object sender, RoutedEventArgs e)
        {
            int idGrupo;
            idGrupo = Int32.Parse((sender as CheckBox).Uid);

            if ((sender as CheckBox).IsChecked == false) //deseleccionado
                addDesmarcados(idGrupo);

            else //seleccionado
                removDesmarcados(idGrupo);
        }
    }
}
