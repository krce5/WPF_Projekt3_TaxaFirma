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
    /// Interaction logic for ChaufførSide.xaml
    /// </summary>
    public partial class ChaufførSide : Window
    {
        Taxafirma taxafirma = new Taxafirma();
        public ChaufførSide()
        {
            InitializeComponent();
     
          
        }

        private void KnapStartVagt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Chauffør chauffør = new Chauffør();
            bool ændreStatus = taxafirma.ÆndreStatusStartVagt(mw.TxtBoxBrugernavn.Text);
            TxtBoxStatus.Text = "Du har startet din vagt: " + ændreStatus;

            Console.WriteLine();

        }
    }
}
