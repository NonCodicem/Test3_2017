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
using System.IO;
using Microsoft.Win32;


namespace Test3_2017
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string initialDir = @"C:\Users\sekke\source\repos\Test3_2017\Test3_2017\bin";
        public MainWindow()
        {
            InitializeComponent();

            Bus bus1 = new Bus("Bus1");
            Bus bus2 = new Bus("Bus2");
            Bus bus3 = new Bus("Bus3");

            lstBussen.Items.Add(bus1);
            lstBussen.Items.Add(bus2);
            lstBussen.Items.Add(bus3);

            lstC.Items.Add("test");
        }

        private void lstBussen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bus selectedBus = (Bus)lstBussen.SelectedItem;
            string sourcePath = @"C:\Users\sekke\source\repos\Test3_2017\Test3_2017\bin";
            string fileName = lstBussen.SelectedItem.ToString() + ".txt";
            string filePath = System.IO.Path.Combine(sourcePath, fileName);

            //string[] words = new string[4];

            using (StreamReader reader = File.OpenText(filePath))
            {
                string line;
                string[] words = new string[4];
                while ((line = reader.ReadLine()) != null)
                {
                    words = line.Split(';');

                    switch (words[0])
                    {
                        case "C":
                            selectedBus.lstChauffeurs.Add(new Chauffeur(words[1], words[2]));
                            
                            lstC.Items.Clear();
                            foreach (var item in selectedBus.lstChauffeurs)
                            {
                                lstC.Items.Add(item);
                            }
                            break;
                        case "G":
                            selectedBus.lstGids.Add(new Gids(words[1], words[2], words[3]));
                            
                            lstG.Items.Clear();
                            foreach (var item in selectedBus.lstGids)
                            {
                                lstG.Items.Add(item);
                            }
                            break;
                        case "R":
                            selectedBus.lstReiziger.Add(new Reiziger(words[1], words[2], words[3]));
                          
                            lstR.Items.Clear();
                            foreach (var item in selectedBus.lstReiziger)
                            {
                                lstR.Items.Add(item);
                            }
                            break;
                        case "M":
                            Reiziger laatsteReiziger = selectedBus.lstReiziger.Last();
                            laatsteReiziger.lstMedereiziger.Add(new Medereiziger(words[1], words[2]));
                                                        
                            break;
                        
                    }

                }
            }
            

        }

        private void lstR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reiziger rzg = (Reiziger)lstR.SelectedItem;
            lstM.Items.Clear();
            foreach (var item in rzg.lstMedereiziger)
            {
                lstM.Items.Add(item);
            }
        }

        private void btnChauffeurs_Click(object sender, RoutedEventArgs e)
        {
            string naam = txtNaam.Text;
            string taal = txtTaal.Text;
            Bus bus = (Bus)lstBussen.SelectedItem;

            bus.lstChauffeurs.Add(new Chauffeur(naam, taal));

            lstC.Items.Clear();
            foreach (var item in bus.lstChauffeurs)
            {
                lstC.Items.Add(item);
            }

            txtNaam.Clear();
            txtTaal.Clear();
        }

        private void btnMedereizigers_Click(object sender, RoutedEventArgs e)
        {
            string nm = txtNaam.Text;
            string gsl = txtGeslacht.Text;
            Reiziger rzg = (Reiziger)lstR.SelectedItem;

            rzg.lstMedereiziger.Add(new Medereiziger(nm, gsl));
            lstM.Items.Clear();
            foreach (var item in rzg.lstMedereiziger)
            {
                lstM.Items.Add(item);
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            
            if (MessageBox.Show("Do you want to clear all the entries?", "Clear all fields", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                lstC.Items.Clear();
                lstG.Items.Clear();
                lstR.Items.Clear();
                lstM.Items.Clear();            }
        }

        public void SaveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = initialDir;
            string fileName = lstBussen.SelectedItem.ToString() + ".txt";
            string filePath = System.IO.Path.Combine(folderPath, fileName);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDir;
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {

                using (StreamWriter writer = File.CreateText(filePath))
                {
                    Bus bs = (Bus)lstBussen.SelectedItem;
                    foreach (var item in bs.lstChauffeurs)
                    {
                        writer.WriteLine(item.ToStringForFile());
                    }
                    foreach (var item in bs.lstGids)
                    {
                        writer.WriteLine(item.ToStringForFile());
                    }
                    foreach (var item in bs.lstReiziger)
                    {
                        Reiziger currentRzg = item;
                        writer.WriteLine(item.ToStringForFile());

                        foreach (var MDReiziger in currentRzg.lstMedereiziger)
                        {
                            writer.WriteLine(MDReiziger.ToStringForFile());
                        }
                    }

                }

            }

           

        }
    }
}
