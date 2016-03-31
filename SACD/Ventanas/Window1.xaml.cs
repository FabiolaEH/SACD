using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace SACD.Ventanas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ObservableCollection<EmployeeDetail> mEmployees = new ObservableCollection<EmployeeDetail>();
        public Window1()
        {
            InitializeComponent();

            mEmployees.Add(new EmployeeDetail() { ID = 1, EmployeeName = "John", Month = 5, Year = 2012 });
            mEmployees.Add(new EmployeeDetail() { ID = 2, EmployeeName = "James", Month = 4, Year = 2013 });
            mEmployees.Add(new EmployeeDetail() { ID = 3, EmployeeName = "Ricky", Month = 1, Year = 2011 });

            dgPaySlip.ItemsSource = mEmployees;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*foreach (var item in mEmployees)
            {
                item.IsSelected = true;
            }*/

            foreach (var item in mEmployees)
            {
                if (item.IsSelected)
                    MessageBox.Show("CHEQUEADO");
            }
          
        }

        /// <summary>
        /// ////////////////////////////////////////////////
        /// </summary>

        public class EmployeeDetail : INotifyPropertyChanged
        {
            private int mID;
            private string mEmployeeName;
            private bool mIsSelected;
            private int mMonth, mYear;

            public int ID
            {
                get { return mID; }
                set
                {
                    mID = value;
                    OnPropertyChanged("ID");
                }
            }

            public int Month
            {
                get { return mMonth; }
                set
                {
                    mMonth = value;
                    OnPropertyChanged("Month");
                }
            }

            public int Year
            {
                get { return mYear; }
                set
                {
                    mYear = value;
                    OnPropertyChanged("Year");
                }
            }


            public string EmployeeName
            {
                get { return mEmployeeName; }
                set
                {
                    mEmployeeName = value;
                    OnPropertyChanged("EmployeeName");
                }
            }

            public bool IsSelected
            {
                get { return mIsSelected; }
                set
                {
                    mIsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

    }
}
