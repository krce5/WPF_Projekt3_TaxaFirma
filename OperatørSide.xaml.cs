using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Projekt3_TaxaFirma
{
    /// <summary>
    /// Interaction logic for OperatørSide.xaml
    /// </summary>
    public partial class OperatørSide : Window
    {
        private Taxafirma taxafirma;
        private string brugerNavnOperatør = "";

        public OperatørSide(Taxafirma taxafirma, string brugerNavnOperatør)
        {
            InitializeComponent();
            this.taxafirma = taxafirma;
            this.brugerNavnOperatør = brugerNavnOperatør;
        }

        private void LoggeUd_Knap_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void KnapSkiftTaxa_Click(object sender, RoutedEventArgs e)
        {
            OperatørSkiftTaxaSide operatørSide2 = new OperatørSkiftTaxaSide(taxafirma, brugerNavnOperatør);
            operatørSide2.Show();
            this.Close();

            OperatørSide operatørSide = new OperatørSide(taxafirma, brugerNavnOperatør);
            operatørSide.LblVelkommen.Content = "Velkommen " + operatørSide.brugerNavnOperatør;

            operatørSide.ListBoxChauffører.ItemsSource = taxafirma.listChauffører;
            operatørSide.ListBoxTaxaer.ItemsSource = taxafirma.listTaxaer;
            operatørSide.ListBoxBestillinger.ItemsSource = taxafirma.listBestillinger;

            string[] læsBestilling = System.IO.File.ReadAllLines(@"gemteBestillinger.txt");
            operatørSide.ListBoxBestillinger.ItemsSource = læsBestilling;

        }
    }
}
