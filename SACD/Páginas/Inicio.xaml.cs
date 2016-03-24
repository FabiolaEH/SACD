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
using System.Windows.Navigation;
using System.Windows.Shapes;

using SACD_AccesoDatos;


namespace SACD
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();

            DatosManager dm = new DatosManager();

            List<Object> profesList =  dm.getProfesoresList();

            foreach (Object[] obj in profesList)
            {
                labelBD.Content = obj[0];
            } 
        }
        
    }
}
