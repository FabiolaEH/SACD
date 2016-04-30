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
    public partial class EliminarProfes : Page
    {
        List<Profesor> profesList = new List<Profesor>();
        List<Profesor_GUI> profesListGUI = new List<Profesor_GUI>();

        public EliminarProfes()
        {
            InitializeComponent();
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            profesList = new List<Profesor>();
            profesListGUI = new List<Profesor_GUI>();

            profesList = ProfesManager.listar();

            foreach (Profesor profe in profesList)
            {
                profesListGUI.Add(new Profesor_GUI() { id = profe.getId(), nombre = profe.getNombre()});
            }

            dgProfes.ItemsSource = profesListGUI;
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Profesor_GUI profeInfo in profesListGUI)
            {
                if (profeInfo.isSelected)
                {
                    Boolean isValido = ProfesManager.eliminar(profeInfo.id);
                    if (!isValido)
                        MessageBox.Show("Error al eliminar el profesor");
                    else
                        actualizarTabla();
                }
            }
        }
    }
}
