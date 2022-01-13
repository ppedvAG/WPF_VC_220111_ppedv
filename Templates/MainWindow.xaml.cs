using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Anna", Name="Nass", Alter=23},
                new Person(){Vorname="Rainer", Name="Zufall", Alter=65},
                new Person(){Vorname="Maria", Name="Müller", Alter=78},
            };

            this.DataContext = this;
        }

        public ObservableCollection<Person> Personenliste { get; set; }

        private void Btn_ControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button funktioniert");
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Sarah", Name = "Schmidt", Alter = 45 });
        }

        private void Btn_Loeschen_01_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der in dem ListView angewählten Person
            if (Lbx_Personen.SelectedItem is Person)
                Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }

        private void Btn_Loeschen_02_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der Person, welche in dem Button-Tag liegt
            if ((sender as Button).Tag is Person)
                Personenliste.Remove((sender as Button).Tag as Person);
        }
    }
}
