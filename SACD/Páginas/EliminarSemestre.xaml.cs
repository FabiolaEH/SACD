using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class EliminarSemestre : Page
    {
        List<Semestre> semestresList = new List<Semestre>();
        List<Semestre_GUI> semestresListGUI = new List<Semestre_GUI>();

        public EliminarSemestre()
        {
            InitializeComponent();
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            semestresList = new List<Semestre>();
            semestresListGUI = new List<Semestre_GUI>();

            semestresList = SemestresManager.listar();

            foreach (Semestre semestre in semestresList)
                semestresListGUI.Add(new Semestre_GUI() { id = semestre.getId(), anio = semestre.getAnio(), periodo = semestre.getPeriodo()});

            dgSemestres.ItemsSource = semestresListGUI;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Semestre_GUI semestreInfo in semestresListGUI)
            {
                if (semestreInfo.isSelected)
                {
                    Boolean isValido = SemestresManager.eliminar(semestreInfo.id);
                    if (!isValido)
                        MessageBox.Show("Error al eliminar el semestre");
                    else
                        actualizarTabla();
                }
            }
        }
    }
}
