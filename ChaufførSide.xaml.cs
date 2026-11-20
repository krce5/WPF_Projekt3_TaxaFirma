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
        private Taxafirma taxafirma = new Taxafirma();
        private string brugerNavn = "";

        public ChaufførSide()
        {
            InitializeComponent();
        }

        public ChaufførSide(Taxafirma taxafirma, string brugerNavn)
        {
            InitializeComponent();
            this.taxafirma = taxafirma;
            this.brugerNavn = brugerNavn;
        }

        private void KnapStartVagt_Click(object sender, RoutedEventArgs e)
        {
            bool ændreStatus = taxafirma.ÆndreStatusStartVagt(brugerNavn);
            TxtBoxStatus.Text = "Du har startet din vagt: " + ændreStatus;
        }
    }
}
