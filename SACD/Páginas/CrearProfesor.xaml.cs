﻿using SACD.Clases;
using SACD_Controlador;
using SACD_Modelo;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SACD.Páginas
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class CrearProfesor : Page
    {
        List<Plaza> plazasList = new List<Plaza>();
        List<Plazas_GUI> plazasListGUI = new List<Plazas_GUI>();

        public CrearProfesor()
        {
            InitializeComponent();
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            plazasList = new List<Plaza>();
            plazasListGUI = new List<Plazas_GUI>();

            plazasList = PlazasManager.listarPlazas();

            foreach (Plaza plaza in plazasList)
            {
                plazasListGUI.Add(new Plazas_GUI() { numero = plaza.getId(), porcentaje = plaza.getPorcentaje() });
            }

            dgPlazas.ItemsSource = plazasListGUI;
        }


        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Boolean exito = true;
            if(tbxNombre.Text != "")
            {
                //Primero insertar el profesor
                Boolean isValido = ProfesManager.crear(tbxNombre.Text);
                if (!isValido)
                {
                    MessageBox.Show("Error al insertar el profesor");
                    exito = false;
                }
                else
                {
                    //Obtener ID del profe insertado
                    int idProfe = ProfesManager.getUltimoProfesor();

                    //Crear relación Plaza_Profesor
                    foreach (Plazas_GUI plazaInfo in plazasListGUI)
                    {
                        if (plazaInfo.horAsignado != null)
                        {
                            if (verificarHoras(plazaInfo.porcentaje, plazaInfo.horAsignado)) {
                                isValido = ProfesManager.insertPlazaProfe(idProfe.ToString(), plazaInfo.numero.ToString(),
                                    plazaInfo.horAsignado, plazaInfo.isPropiedad);
                                if (!isValido)
                                {
                                    MessageBox.Show("Error al ligar la plaza");
                                    exito = false;
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Las horas asignadas a un profesor no puede exceder el porcentaje de la plaza");
                                ProfesManager.eliminar(idProfe);
                                exito = false;
                                break;
                            }
                        }
                    }
                }
                if (exito)
                    MessageBox.Show("Profesor creado correctamente");
            }
            else
            {
                MessageBox.Show("No puede dejar ningún espacio en blanco.");
            }
        }

        private Boolean verificarHoras (decimal pPorcentaje, String pHoras)
        {
            Boolean isValido = true;
            decimal horas = Decimal.Parse(pHoras.Replace(".", ","));

            decimal limiteHoras = 40 * pPorcentaje / 100;

            Console.WriteLine("Horas: " + horas);
            Console.WriteLine("Limite: " + limiteHoras);

            if (limiteHoras < horas)
                isValido = false;

            return isValido;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.OemPeriod))
                e.Handled = true;
        }
    }
}
