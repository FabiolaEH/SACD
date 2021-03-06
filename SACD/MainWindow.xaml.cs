﻿using System;
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

using SACD_Modelo;
using SACD.Páginas;
using SACD_Controlador;

namespace SACD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int anio_global { get; set; }
        public int periodo_global { get; set; }
        public int semestre_global { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            List<int> datos_Globales = SemestresManager.getSemestreGlobal();
            if(datos_Globales.Count != 0)
            {
                semestre_global = datos_Globales[0];
                anio_global = datos_Globales[1];
                periodo_global = datos_Globales[2];
            }
            else
            {

            }
            Application.Current.MainWindow = this;
        }


        private void GoToPageExecuteHandler(object sender, ExecutedRoutedEventArgs e)
        {
            
            frmContenido.NavigationService.Navigate(new Uri((string)e.Parameter, UriKind.Relative));
        }

        private void GoToPageCanExecuteHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void cerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void frmContenido_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void cli_Click(object sender, RoutedEventArgs e)
        {
            this.frmContenido.Navigate(new Asignaciones(this.frmContenido));
        }
    }  
}
